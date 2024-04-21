import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter/widgets.dart';
import 'package:mobile/navigationRoutes.dart';
import 'package:mobile/pages/profile_page/functions/helper.dart';
import 'package:mobile/pages/profile_page/user_data.dart';
import 'package:mobile/pages/profile_page/widgets/usettings_footer.dart';

class SubscriptionsInfo extends StatefulWidget {
  const SubscriptionsInfo({super.key});

  @override
  State<StatefulWidget> createState() => _SubscriptionsInfoState();
}

class _SubscriptionsInfoState extends State<SubscriptionsInfo> {
  late List<SubscriptionInfo> subscriptions;

  @override
  void initState() {
    setState(() {
      subscriptions = [
        SubscriptionInfo(subscriptionName: 'Полный доступ', expires: null),
        SubscriptionInfo(
            subscriptionName: 'Вселенная Гарри Поттера',
            expires: DateTime(2024, 5, 12)),
      ];
    });

    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return Column(
      crossAxisAlignment: CrossAxisAlignment.start,
      children: [
        if (subscriptions.isNotEmpty) ...[
          // TODO: открытие инфы о подписке
          Text(
            'Активные подписки:',
            style: Theme.of(context).textTheme.headlineSmall,
          ),
          Flexible(
            child: ListView.builder(
              itemCount: subscriptions.length,
              itemBuilder: (context, index) => Card(
                color: Colors.white,
                child: ListTile(
                  title: Text(
                    subscriptions[index].subscriptionName,
                  ),
                  subtitle: subscriptions[index].expires == null
                      ? const Text('Действует бессрочно')
                      : Text(
                          'Действует до ${Helper.formatDate(subscriptions[index].expires)}'),
                ),
              ),
            ),
          ),
        ],
        USettingsFooter(
          linkText:
              'Информацию о ${subscriptions.isNotEmpty ? 'других' : ''} подписках можно посмотреть здесь',
          navTo: () =>
              Navigator.of(context).pushNamed(NavigationRoutes.subscriptions),
        ),
      ],
    );
  }
}

class SubscriptionInfo {
  final String subscriptionName;
  final DateTime? expires;

  SubscriptionInfo({required this.subscriptionName, required this.expires});
}
