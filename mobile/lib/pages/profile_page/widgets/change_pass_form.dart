import 'package:flutter/material.dart';
import 'package:mobile/pages/profile_page/functions/Gen2FACodeSendField.dart';
import 'package:mobile/pages/profile_page/styles/settings_submit_button.dart';
import 'package:mobile/pages/profile_page/user_data.dart';
import 'package:mobile/pages/profile_page/widgets/my_snack_bar.dart';
import 'package:mobile/pages/profile_page/widgets/usettings_footer.dart';
import 'package:provider/provider.dart';

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
      print(_formData);

      // TODO: запросить обновление на сервере
      mySnackBar(
        context,
        'Пароль изменён!',
      );

      Navigator.of(context).pop();
      Navigator.of(context).pop();
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
                if (_formData['code'] == null && _codeController.text.isEmpty) {
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
              set2FACode: (code) => _formData['code'] = code,
              codeType: 'SendChangePasswordToken',
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
