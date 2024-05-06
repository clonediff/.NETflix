import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:mobile/bloc/loading/bloc.dart';
import 'package:mobile/bloc/loading/events.dart';
import 'package:mobile/bloc/loading/state_parser.dart';
import 'package:mobile/bloc/loading/states.dart';
import 'package:mobile/constants/colors.dart';
import 'package:mobile/pages/subscriptions_page/subscription_card.dart';
import 'package:mobile/widgets/header.dart';

class SubscriptionsPage extends StatelessWidget {
  const SubscriptionsPage({super.key});

  @override
  Widget build(BuildContext context) {
    context.read<LoadingBloc>().add(
      LoadingAllSubscriptionsEvent(builder: (data) =>
        ListView.builder(
          itemBuilder: (context, index) =>
              SubscriptionCard(subscription: data[index]),
          itemCount: data.length,
        )
      )
    );
    return Scaffold(
      appBar: const Header(),
      body: Container(
        color: DotNetflixColors.mainBackgroundColor,
        alignment: Alignment.center,
        child: const BlocBuilder<LoadingBloc, LoadingStateBase>(builder: parseState),
      ),
    );
  }
}