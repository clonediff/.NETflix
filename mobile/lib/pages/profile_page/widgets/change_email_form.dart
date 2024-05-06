import 'package:flutter/material.dart';
import 'package:mobile/main.dart';
import 'package:mobile/models/all_for_freezed.dart';
import 'package:mobile/pages/profile_page/functions/gen_2fa_code_send_field.dart';
import 'package:mobile/pages/profile_page/styles/settings_submit_button.dart';
import 'package:mobile/pages/profile_page/user_data.dart';
import 'package:mobile/pages/profile_page/widgets/my_snack_bar.dart';
import 'package:mobile/pages/profile_page/widgets/usettings_footer.dart';
import 'package:mobile/services/token_service.dart';
import 'package:mobile/services/user_service.dart';
import 'package:provider/provider.dart';

class ChangeEmailForm extends StatefulWidget {
  const ChangeEmailForm({super.key});

  @override
  State<ChangeEmailForm> createState() => _ChangeEmailFormState();
}

class _ChangeEmailFormState extends State<ChangeEmailForm> {
  final Map<String, dynamic> _formData = {};
  final GlobalKey<FormState> _formKey = GlobalKey<FormState>();
  final TextEditingController _emailController = TextEditingController();
  final TextEditingController _codeController = TextEditingController();

  void sendEnableRequest(BuildContext context, UserData userData) {
    if (_formKey.currentState?.validate() ?? false) {
      _formKey.currentState?.save();

      getit<UserServiceBase>()
          .changeEmail(UserChangeMailDtoInput.fromJson(_formData))
          .then((value) => value.match((s) {
                userData.modifyUser(
                  (user) => user.copyWith(email: _formData['email']),
                );

                mySnackBar(context, s);

                Navigator.of(context).pop();
                Navigator.of(context).pop();
              }, (f) => mySnackBar(context, f)));
    }
  }

  @override
  Widget build(BuildContext context) {
    if (_emailController.text.isEmpty) {
      _emailController.text = Provider.of<UserData>(context).user?.email ?? '';
    }
    return Consumer<UserData>(
      builder: (context, userData, child) => Form(
        child: Form(
          key: _formKey,
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              TextFormField(
                decoration: const InputDecoration(
                  labelText: 'Электронная почта',
                ),
                validator: (value) {
                  if (value?.isEmpty ?? true) {
                    return 'Пожалуйста, введите электронную почту!';
                  }
                  if (!RegExp(r'^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$')
                      .hasMatch(value!)) {
                    return 'Введённые данные не соответствуют электронной почте!';
                  }
                  if (_formData['token'] == null &&
                      _codeController.text.isEmpty) {
                    return 'Сначала надо ввести код';
                  }

                  return null;
                },
                onSaved: (val) => _formData['email'] = val,
                controller: _emailController,
              ),
              Gen2FACodeSendFields(
                set2FACode: (code) => _formData['token'] = code,
                sendCodeFunc: () => getit<TokenServiceBase>().sendChangeMailToken(_emailController.text),
                controller: _codeController,
              ),
              ElevatedButton(
                onPressed: () {
                  sendEnableRequest(context, userData);
                },
                style: settingsSubmitButton(),
                child: const Text('Применить изменения'),
              ),
              USettingsFooter(
                  linkText: 'Вернуться к основным настройкам',
                  navTo: () => Navigator.of(context).pop())
            ],
          ),
        ),
      ),
    );
  }
}
