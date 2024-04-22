import 'package:flutter/material.dart';
import 'package:mobile/constants/colors.dart';
import 'package:mobile/pages/subscriptions_page/payment_form.dart';
import 'package:mobile/pages/subscriptions_page/subscriptions_page.dart';

class SubscriptionCard extends StatelessWidget {
  final Subscription subscription;

  const SubscriptionCard({super.key, required this.subscription});

  @override
  Widget build(BuildContext context) {
    return Container(
      margin: const EdgeInsets.all(10),
      decoration: BoxDecoration(
        borderRadius: BorderRadius.circular(15),
        color: DotNetflixColors.headerBackgroundColor,
        border: Border.all(
          color: DotNetflixColors.headerBackgroundColor,
          width: 2,
          style: BorderStyle.solid,
        ),
      ),
      padding: const EdgeInsets.symmetric(vertical: 10, horizontal: 15),
      child: Column(
        mainAxisAlignment: MainAxisAlignment.spaceBetween,
        children: [
          Column(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              Wrap(
                direction: Axis.horizontal,
                children: [
                  const Text('Подписка ',
                      style: TextStyle(fontSize: 20, color: Colors.white)),
                  Text(subscription.name,
                      style: const TextStyle(
                        fontSize: 20,
                        color: Colors.white,
                        fontWeight: FontWeight.bold,
                      )),
                ],
              ),
              Container(
                width: 138,
                decoration: BoxDecoration(
                  borderRadius: BorderRadius.circular(4),
                  boxShadow: const [
                    BoxShadow(
                      color: Color.fromRGBO(0, 0, 0, 0.14),
                      offset: Offset(0, 3),
                      blurRadius: 5,
                      spreadRadius: 0,
                    ),
                  ],
                  color: DotNetflixColors.searchBackgroundColor,
                ),
                padding:
                    const EdgeInsets.symmetric(vertical: 30, horizontal: 25),
                margin: const EdgeInsets.only(top: 22),
                child: Column(
                  children: [
                    Text('${subscription.cost} ₽',
                        style:
                            const TextStyle(color: Colors.white, fontSize: 24)),
                    Text(
                      subscription.periodInDays != null
                          ? 'на ${subscription.periodInDays} дней'
                          : 'навсегда',
                      style: const TextStyle(
                          color: Colors.white, fontWeight: FontWeight.bold),
                    ),
                  ],
                ),
              ),
              Container(
                margin: const EdgeInsets.only(top: 20),
                child: Column(
                  children: [
                    const Text('Подключаемые фильмы',
                        style: TextStyle(color: Colors.white, fontSize: 15)),
                    ...subscription.filmNames.indexed.take(3).expand(
                          (e) => [
                            SizedBox(
                              height: 50,
                              child: Container(
                                alignment: Alignment.centerLeft,
                                child: Text(e.$2,
                                    style:
                                        const TextStyle(color: Colors.white)),
                              ),
                            ),
                            if (e.$1 != subscription.filmNames.length - 1)
                              const Divider(
                                  height: 1, color: Color(0xff414146)),
                          ],
                        ),
                    const Divider(height: 1, color: Color(0xff414146)),
                    SizedBox(
                      height: 50,
                      child: Container(
                        alignment: Alignment.centerLeft,
                        child: const Text('и т.д.',
                            style: TextStyle(color: Colors.white)),
                      ),
                    ),
                  ],
                ),
              ),
            ],
          ),
          ElevatedButton(
            onPressed: !(subscription.periodInDays == null &&
                    subscription.belongsToUser)
                ? () {
                    print('Купить подписку');
                    showDialog(
                      context: context,
                      builder: (context) =>
                          PaymentForm(subscription: subscription),
                    );
                  }
                : null,
            style: ButtonStyle(
              foregroundColor: MaterialStateProperty.resolveWith(
                (states) => Colors.white,
              ),
              backgroundColor: MaterialStateProperty.resolveWith(
                (states) => !(subscription.periodInDays == null &&
                        subscription.belongsToUser)
                    ? const Color(0xff1677ff)
                    : const Color(0x04000000),
              ),
              padding: MaterialStateProperty.resolveWith(
                (states) =>
                    const EdgeInsets.symmetric(vertical: 4, horizontal: 15),
              ),
              shape: MaterialStateProperty.resolveWith(
                (states) => RoundedRectangleBorder(
                  borderRadius: BorderRadius.circular(6),
                  side: !(subscription.periodInDays == null &&
                          subscription.belongsToUser)
                      ? const BorderSide()
                      : const BorderSide(
                          color: Color(0xffd9d9d9),
                          width: 1,
                          style: BorderStyle.solid,
                        ),
                ),
              ),
            ),
            child: Text(
              subscription.belongsToUser ? 'Продлить' : 'Оформить',
            ),
          ),
        ],
      ),
    );
  }
}
