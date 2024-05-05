import 'package:flutter/material.dart';
import 'package:mobile/main.dart';
import 'package:mobile/pages/profile_page/styles/settings_submit_button.dart';
import 'package:mobile/pages/profile_page/widgets/my_snack_bar.dart';
import 'package:mobile/services/user_service.dart';
import 'package:mobile/utils/result.dart';

class Gen2FACodeSendFields extends StatefulWidget {
  final void Function(String code) set2FACode;
  final Future<Result<String, String>> Function() sendCodeFunc;
  final TextEditingController? controller;

  const Gen2FACodeSendFields({
    super.key,
    required this.set2FACode,
    required this.sendCodeFunc,
    this.controller,
  });

  @override
  State<Gen2FACodeSendFields> createState() => _Gen2FACodeSendFieldsState();
}

class _Gen2FACodeSendFieldsState extends State<Gen2FACodeSendFields> {
  int remainedToResend = 0;
  bool codeSend = false;

  void sendCode() {
    setState(() {
      codeSend = true;
      remainedToResend = 120;
      countdownRemainedToResend();
    });
    widget.sendCodeFunc().then(
          (value) => value.match(
            (s) => mySnackBar(context, s),
            (f) {
              setState(() {
                codeSend = false;
                remainedToResend = 0;
              });

              mySnackBar(context, f);
            },
          ),
        );
  }

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

  @override
  Widget build(BuildContext context) {
    return Column(
      crossAxisAlignment: CrossAxisAlignment.start,
      children: [
        ElevatedButton(
          onPressed: remainedToResend == 0 ? sendCode : null,
          style: settingsSubmitButton(() => remainedToResend != 0),
          child: const Text('Отправить код'),
        ),
        if (codeSend) ...[
          TextFormField(
            decoration: const InputDecoration(
              labelText: 'Код',
            ),
            validator: (value) =>
                value!.isEmpty ? 'Введите код из email' : null,
            onSaved: (newValue) => widget.set2FACode(newValue!),
            controller: widget.controller,
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
      ],
    );
  }

  String getTimeString(seconds) {
    final String minutes = (seconds ~/ 60).toString().padLeft(2, '0');
    final String cseconds = (seconds % 60).toString().padLeft(2, '0');
    return '$minutes:$cseconds';
  }
}
