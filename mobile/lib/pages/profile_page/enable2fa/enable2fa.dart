import 'package:flutter/material.dart';
import 'package:mobile/main.dart';
import 'package:mobile/models/all_for_freezed.dart';
import 'package:mobile/pages/profile_page/styles/settings_submit_button.dart';
import 'package:mobile/pages/profile_page/title_value/title_value.dart';
import 'package:mobile/pages/profile_page/user_data.dart';
import 'package:mobile/pages/profile_page/widgets/my_snack_bar.dart';
import 'package:mobile/pages/profile_page/widgets/usettings_footer.dart';
import 'package:mobile/services/token_service.dart';
import 'package:mobile/services/user_service.dart';
import 'package:provider/provider.dart';

class Enable2FA extends StatefulWidget {
  const Enable2FA({super.key});

  @override
  State<Enable2FA> createState() => _Enable2FAState();
}

class _Enable2FAState extends State<Enable2FA> {
  final GlobalKey<FormState> _formKey = GlobalKey<FormState>();

  String formDataCode = '';
  bool codeSend = false;
  int remainedToResend = 0;

  Future<void> countdownRemainedToResend() async {
    while (remainedToResend > 0 && mounted) {
      await Future.delayed(
        const Duration(seconds: 1),
        () {
          if (mounted) {
            setState(() => remainedToResend--);
          }
        },
      );
    }
  }

  void sendCode() {
    setState(() {
      codeSend = true;
      remainedToResend = 120;
      countdownRemainedToResend();
    });
    getit<TokenServiceBase>().send2FAToken().then((value) {
      value.match((s) => mySnackBar(context, s), (f) {
        setState(() {
          codeSend = false;
          remainedToResend = 0;
        });
        mySnackBar(context, f);
      });
    });
  }

  void sendEnableRequest(BuildContext context, UserData userData) {
    if (_formKey.currentState?.validate() ?? false) {
      _formKey.currentState?.save();

      getit<UserServiceBase>().enable2FA(
        EnableTwoFactorAuthDtoInput(token: formDataCode),
      ).then((value) {
        value.match((s) {
          userData.modifyUser(
                (user) => user.copyWith(enabled2FA: true),
          );
          mySnackBar(context, s);

          handleOk(context);
        }, (f) =>
            mySnackBar(context, f));
      });

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
