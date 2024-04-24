import 'package:flutter/material.dart';
import 'package:mobile/pages/profile_page/styles/settings_submit_button.dart';
import 'package:mobile/pages/profile_page/title_value/title_value.dart';
import 'package:mobile/pages/profile_page/user_data.dart';
import 'package:mobile/pages/profile_page/widgets/usettings_footer.dart';
import 'package:provider/provider.dart';

class Enable2FA extends StatefulWidget {
  final void Function(String routeName)
      navigatorPushNamed;

  const Enable2FA({
    super.key,
    required this.navigatorPushNamed,
  });

  @override
  State<Enable2FA> createState() => _Enable2FAState();
}

class _Enable2FAState extends State<Enable2FA> {
  final GlobalKey<FormState> _formKey = GlobalKey<FormState>();

  String formDataCode = '';
  bool codeSend = false;
  int remainedToResend = 0;

  Future<void> countdownRemainedToResend() async {
    while (remainedToResend > 0) {
      await Future.delayed(
        const Duration(seconds: 1),
        () => setState(() => remainedToResend--),
      );
    }
  }

  void sendCode() {
    // TODO: запросить код для 2FA
    setState(() {
      codeSend = true;
      remainedToResend = 120;
      countdownRemainedToResend();
    });
    print('Код запрошен');
  }

  void sendEnableRequest(BuildContext context, UserData userData) {
    if (_formKey.currentState?.validate() ?? false) {
      _formKey.currentState?.save();
      print('Хочу подключить 2FA, код: $formDataCode');

      // TODO: подтвердить 2FA на сервере
      userData.modifyUser((user) {
        user.enabled2FA = true;
      });

      ScaffoldMessenger.of(context).showSnackBar(
        const SnackBar(
          duration: Duration(seconds: 5),
          content: Text(
            'Двухфакторная аутентификация подключена',
            style: TextStyle(
              fontWeight: FontWeight.w600,
              fontSize: 16,
            ),
          ),
        ),
      );
      handleOk(context);
      // showDialog(
      //   context: context,
      //   builder: (context) {
      //     return AlertDialog(
      //       actions: [
      //         TextButton(
      //           onPressed: () => handleOk(context),
      //           child: const Text('Ok'),
      //         ),
      //       ],
      //       content: const Text('Двухфакторная аутентификация подключена'),
      //     );
      //   },
      // );
    }
  }

  void handleOk(BuildContext context) {
    Navigator.of(context).pop();
  }

  @override
  Widget build(BuildContext context) {
    return Consumer<UserData>(
      builder: (context, userData, child) => Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          TitleValue(
            title: 'Email',
            value: Text(userData.user?.email ?? ''),
          ),
          ElevatedButton(
            onPressed: remainedToResend == 0 ? sendCode : null,
            style: settingsSubmitButton(() => remainedToResend != 0),
            child: const Text('Отправить код'),
          ),
          if (codeSend)
            Form(
              key: _formKey,
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  TextFormField(
                    decoration: const InputDecoration(
                      labelText: 'Код',
                    ),
                    validator: (value) =>
                        value!.isEmpty ? 'Введите код из email' : null,
                    onSaved: (newValue) => formDataCode = newValue!,
                  ),
                  const SizedBox(
                    height: 10,
                  ),
                  ElevatedButton(
                    onPressed: () {
                      sendEnableRequest(context, userData);
                    },
                    style: settingsSubmitButton(),
                    child: const Text('Подтвердить'),
                  ),
                  const SizedBox(
                    height: 10,
                  ),
                  if (remainedToResend != 0)
                    Text(
                        'Повторно запросить код через ${getTimeString(remainedToResend)}')
                  else
                    const Text('Можно запросить код повторно'),
                  const SizedBox(
                    height: 10,
                  ),
                ],
              ),
            ),
          USettingsFooter(
            linkText: 'Вернуться к информации о пользователе',
            navTo: () => Navigator.of(context).pop(),
          ),
        ],
      ),
    );
  }

  String getTimeString(seconds) {
    final String minutes = (seconds ~/ 60).toString().padLeft(2, '0');
    final String cseconds = (seconds % 60).toString().padLeft(2, '0');
    return '$minutes:$cseconds';
  }
}
