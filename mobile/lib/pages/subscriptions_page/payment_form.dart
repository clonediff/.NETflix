import 'package:flutter/material.dart';
import 'package:mobile/constants/colors.dart';
import 'package:mobile/main.dart';
import 'package:mobile/models/subscription.dart';
import 'package:mobile/pages/profile_page/functions/helper.dart';
import 'package:mobile/pages/profile_page/title_value/title_value.dart';
import 'package:mobile/pages/profile_page/widgets/my_snack_bar.dart';
import 'package:mobile/services/subscription_service.dart';

class PaymentForm extends StatefulWidget {
  final Subscription subscription;
  final void Function() onBuy;

  const PaymentForm({super.key, required this.subscription, required this.onBuy});

  @override
  State<PaymentForm> createState() => _PaymentFormState();
}

class _PaymentFormState extends State<PaymentForm> {
  final SubscriptionServiceBase _subscriptionService = getit<SubscriptionServiceBase>();
  final Map<String, dynamic> _formData = {};
  final TextEditingController _expirationDateController = TextEditingController();
  final GlobalKey<FormState> _formKey = GlobalKey();

  Future<void> onFormSubmit(BuildContext context) async {
    if (_formKey.currentState == null || !_formKey.currentState!.validate()) {
      return;
    }
    
    _formKey.currentState!.save();

    final response = await _subscriptionService.performSubscriptionActionAsync(
      widget.subscription.belongsToUser ? SubscriptionActionType.extend : SubscriptionActionType.purchase,
      widget.subscription.id,
      _formData
    );

    if (context.mounted) {
      Navigator.of(context).pop();
      mySnackBar(context, !response.hasError ? 'Операция прошла успешна' : response.error!);
    }

    if (!response.hasError && !widget.subscription.belongsToUser) {
      widget.onBuy();
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
              onSaved: (val) => _formData['cardNumber'] = val,
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
              onSaved: (val) => _formData['cvv_CVC'] = int.parse(val!),
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
