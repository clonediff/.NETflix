import 'package:flutter/material.dart';
import 'package:mobile/main.dart';
import 'package:mobile/models/all_for_freezed.dart';
import 'package:mobile/pages/profile_page/functions/gen_2fa_code_send_field.dart';
import 'package:mobile/pages/profile_page/styles/settings_submit_button.dart';
import 'package:mobile/pages/profile_page/widgets/my_snack_bar.dart';
import 'package:mobile/pages/profile_page/widgets/usettings_footer.dart';
import 'package:mobile/services/token_service.dart';
import 'package:mobile/services/user_service.dart';

class ChangePassForm extends StatefulWidget {
  const ChangePassForm({super.key});

  @override
  State<ChangePassForm> createState() => _ChangePassFormState();
}

class _ChangePassFormState extends State<ChangePassForm> {
  final Map<String, dynamic> _formData = {};
  final GlobalKey<FormState> _formKey = GlobalKey<FormState>();
  final TextEditingController _passwordController = TextEditingController();
  final TextEditingController _codeController = TextEditingController();

  void sendEnableRequest(BuildContext context) {
    if (_formKey.currentState?.validate() ?? false) {
      _formKey.currentState?.save();
      getit<UserServiceBase>()
          .changePassword(UserChangePasswordDtoInput.fromJson(_formData))
          .then(
            (value) => value.match(
              (s) {
                mySnackBar(context, s);

                Navigator.of(context).pop();
                Navigator.of(context).pop();
              },
              (f) => mySnackBar(context, f),
            ),
          );
    }
  }

  @override
  Widget build(BuildContext context) {
    return Form(
      child: Form(
        key: _formKey,
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            TextFormField(
              decoration: const InputDecoration(
                labelText: 'Новый пароль',
              ),
              obscureText: true,
              validator: (value) {
                if (value?.isEmpty ?? true) {
                  return 'Пожалуйста, введите пароль!';
                }
                if (_formData['token'] == null &&
                    _codeController.text.isEmpty) {
                  return 'Сначала надо ввести код';
                }

                return null;
              },
              onSaved: (val) => _formData['password'] = val,
              controller: _passwordController,
            ),
            TextFormField(
              decoration: const InputDecoration(
                labelText: 'Подтвердите пароль',
              ),
              obscureText: true,
              validator: (value) {
                if (value?.isEmpty ?? true) {
                  return 'Пожалуйста, подтвердите пароль!';
                }
                if (_passwordController.text != value) {
                  return 'Пароли должны совпадать!';
                }

                return null;
              },
              onSaved: (val) => _formData['confirm'] = val,
            ),
            Gen2FACodeSendFields(
              set2FACode: (code) => _formData['token'] = code,
              sendCodeFunc: () =>
                  getit<TokenServiceBase>().sendChangePasswordToken(),
              controller: _codeController,
            ),
            ElevatedButton(
              onPressed: () {
                sendEnableRequest(context);
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
    );
  }
}
