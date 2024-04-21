import 'package:flutter/material.dart';
import 'package:mobile/constants/colors.dart';
import 'package:mobile/pages/subscriptions_page/subscription_card.dart';
import 'package:mobile/widgets/header.dart';

class SubscriptionsPage extends StatefulWidget {
  const SubscriptionsPage({super.key});

  @override
  State<SubscriptionsPage> createState() => _SubscriptionsPageState();
}

class _SubscriptionsPageState extends State<SubscriptionsPage> {
  late List<Subscription> subscriptions;

  @override
  void initState() {
    setState(() {
      subscriptions = [
        Subscription(
          id: 1,
          name: 'Полный доступ',
          cost: 1000,
          periodInDays: null,
          filmNames: List.generate(10, (index) => 'Фильм ${index + 1}'),
          belongsToUser: true,
        ),
        Subscription(
          id: 2,
          name: 'Киновселенная Marvel',
          cost: 500,
          periodInDays: 30,
          filmNames: List.generate(10, (index) => 'Фильм марвел ${index + 1}'),
          belongsToUser: false,
        ),
        Subscription(
          id: 3,
          name: 'Вселенная Гарри Поттера',
          cost: 500,
          periodInDays: 30,
          filmNames:
              List.generate(10, (index) => 'Фильм Гарри Поттера ${index + 1}'),
          belongsToUser: false,
        ),
      ];
    });
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: const Header(),
      body: Container(
        color: NetflixColors.mainBackgroundColor,
        alignment: Alignment.center,
        child: ListView.builder(
          itemBuilder: (context, index) =>
              SubscriptionCard(subscription: subscriptions[index]),
          itemCount: subscriptions.length,
        ),
      ),
    );
  }
}

class Subscription {
  final int id;
  final String name;
  final int cost;
  final int? periodInDays;
  final List<String> filmNames;
  final bool belongsToUser;

  Subscription(
      {required this.id,
      required this.name,
      required this.cost,
      required this.periodInDays,
      required this.filmNames,
      required this.belongsToUser});
}
