import 'package:flutter/material.dart';
import 'package:mobile/pages/profile_page/styles/settings_submit_button.dart';

class Gen2FACodeSendFields extends StatefulWidget {
  final void Function(String code) set2FACode;
  final String codeType;
  final String? newEmail;
  final TextEditingController? controller;

  const Gen2FACodeSendFields({
    super.key,
    required this.set2FACode,
    required this.codeType,
    this.newEmail,
    this.controller,
  });

  @override
  State<Gen2FACodeSendFields> createState() => _Gen2FACodeSendFieldsState();
}

class _Gen2FACodeSendFieldsState extends State<Gen2FACodeSendFields> {
  int remainedToResend = 0;
  bool codeSend = false;

  void sendCode() {
    // TODO: запросить код для 2FA
    setState(() {
      codeSend = true;
      remainedToResend = 120;
      countdownRemainedToResend();
    });
    print(
        'Код с типом ${widget.codeType} ${widget.newEmail != null ? 'для ${widget.newEmail}' : ''} запрошен ');
  }

  Future<void> countdownRemainedToResend() async {
    while (remainedToResend > 0) {
      await Future.delayed(
        const Duration(seconds: 1),
        () => setState(() => remainedToResend--),
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
