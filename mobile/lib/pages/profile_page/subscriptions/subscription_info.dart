import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:mobile/bloc/get_all_user_subscriptions/bloc.dart';
import 'package:mobile/navigation/navigation_routes.dart';
import 'package:mobile/pages/profile_page/functions/helper.dart';
import 'package:mobile/pages/profile_page/widgets/usettings_footer.dart';

class SubscriptionsInfo extends StatefulWidget {
  const SubscriptionsInfo({super.key});

  @override
  State<StatefulWidget> createState() => _SubscriptionsInfoState();
}

class _SubscriptionsInfoState extends State<SubscriptionsInfo> {
  bool loadingCalled = false;

  @override
  Widget build(BuildContext context) {
    if (!loadingCalled) {
      context.read<GetAllUserSubscriptionsBloc>().add(
          const GetAllUserSubscriptionsEvent.getAllUserSubscriptionsInfo());
      setState(() {
        loadingCalled = true;
      });
    }
    return Column(
      crossAxisAlignment: CrossAxisAlignment.start,
      children: [
        BlocBuilder<GetAllUserSubscriptionsBloc, GetAllUserSubscriptionsState>(
          builder: (context, state) => state.when(
            loading: () => const Flexible(
              child: Center(
                child: CircularProgressIndicator(),
              ),
            ),
            loaded: (subscriptions) {
              print(subscriptions);
              if (subscriptions.isNotEmpty) {
                return Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    Text(
                      'Активные подписки:',
                      style: Theme.of(context).textTheme.headlineSmall,
                    ),
                    SizedBox(
                      height: MediaQuery.of(context).size.height - 324,
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
                );
              }
              return const Flexible(child: Center());
            },
            error: (errorMessage) => Flexible(
              child: Center(
                child: Text(errorMessage),
              ),
            ),
          ),
        ),
        USettingsFooter(
          linkText: 'Информацию обо всех подписках можно посмотреть здесь',
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
