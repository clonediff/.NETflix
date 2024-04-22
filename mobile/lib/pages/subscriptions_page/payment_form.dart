import 'package:flutter/material.dart';
import 'package:mobile/constants/colors.dart';
import 'package:mobile/pages/profile_page/functions/helper.dart';
import 'package:mobile/pages/profile_page/title_value/title_value.dart';
import 'package:mobile/pages/profile_page/widgets/my_snack_bar.dart';
import 'package:mobile/pages/subscriptions_page/subscriptions_page.dart';

class PaymentForm extends StatefulWidget {
  final Subscription subscription;

  const PaymentForm({super.key, required this.subscription});

  @override
  State<PaymentForm> createState() => _PaymentFormState();
}

class _PaymentFormState extends State<PaymentForm> {
  final Map<String, dynamic> _formData = {};
  final TextEditingController _expirationDateController =
      TextEditingController();
  final GlobalKey<FormState> _formKey = GlobalKey();

  void onFormSubmit(BuildContext context) {
    if (_formKey.currentState?.validate() ?? false) {
      _formKey.currentState!.save();

      // TODO: Отправка запроса на покупку
      print(_formData);
      print('Кто-то купил ${widget.subscription.name}');

      Navigator.of(context).pop();

      mySnackBar(context, 'Подписка успешно оформлена');
    }
  }

  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      backgroundColor: DotNetflixColors.headerBackgroundColor,
      content: Form(
        key: _formKey,
        child: Column(
          mainAxisSize: MainAxisSize.min,
          children: [
            TextFormField(
              decoration: const InputDecoration(
                labelText: 'Номер карты *',
                labelStyle: TextStyle(color: Colors.white),
              ),
              style: const TextStyle(color: Colors.white),
              validator: (value) => (value?.isEmpty ?? true)
                  ? 'Пожалуйста, введите номер вашей карты!'
                  : null,
              onSaved: (val) => _formData['cardnumber'] = val,
              keyboardType: TextInputType.number,
            ),
            TextFormField(
              decoration: const InputDecoration(
                labelText: 'Владелец карты *',
                labelStyle: TextStyle(color: Colors.white),
              ),
              style: const TextStyle(color: Colors.white),
              validator: (value) => (value?.isEmpty ?? true)
                  ? 'Пожалуйста, введите имя и фамилию владельца карты!'
                  : null,
              onSaved: (val) => _formData['cardholder'] = val,
            ),
            TextFormField(
              controller: _expirationDateController,
              decoration: const InputDecoration(
                labelText: 'Срок действия *',
                labelStyle: TextStyle(color: Colors.white),
              ),
              style: const TextStyle(color: Colors.white),
              onSaved: (val) => _formData['expirationDate'] = val,
              onTap: () async {
                FocusScope.of(context).requestFocus(FocusNode());
                final DateTime? picked = await showDatePicker(
                  context: context,
                  firstDate: DateTime(1970),
                  lastDate: DateTime(2101),
                );
                if (picked != null) {
                  _expirationDateController.text =
                      Helper.formatDate(picked, 'MM-yyyy');
                }
              },
              validator: (value) => (value?.isEmpty ?? true)
                  ? 'Пожалуйста, введите срок действия карты!'
                  : null,
            ),
            TextFormField(
              decoration: const InputDecoration(
                labelText: 'CVV/CVC *',
                labelStyle: TextStyle(color: Colors.white),
              ),
              style: const TextStyle(color: Colors.white),
              maxLength: 3,
              validator: (value) {
                if (value?.isEmpty ?? true) {
                  return 'Пожалуйста, введите трехзначный код на обратной стороне карты!';
                }
                if (value!.length != 3) {
                  return 'Введите 3 цифры';
                }
                return null;
              },
              onSaved: (val) => _formData['CVV_CVC'] = val,
              keyboardType: TextInputType.number,
            ),
            TitleValue(
                title: 'Товар',
                titleStyle: const TextStyle(color: Colors.white),
                value: Text(
                  widget.subscription.name,
                  style: const TextStyle(color: Colors.white),
                )),
            TitleValue(
                title: 'Цена',
                titleStyle: const TextStyle(color: Colors.white),
                value: Text(
                  widget.subscription.cost.toString(),
                  style: const TextStyle(color: Colors.white),
                )),
            ElevatedButton(
              onPressed: () => onFormSubmit(context),
              child: const Text('Подтвердить'),
            ),
          ],
        ),
      ),
    );
  }
}
