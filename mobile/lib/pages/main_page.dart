import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:mobile/bloc/loading/bloc.dart';
import 'package:mobile/bloc/loading/events.dart';
import 'package:mobile/bloc/loading/state_parser.dart';
import 'package:mobile/bloc/loading/states.dart';
import 'package:mobile/constants/colors.dart';

class MainPage extends StatelessWidget {
  const MainPage({ super.key });

  @override
  Widget build(BuildContext context) {
    context.read<LoadingBloc>().add(LoadingEvent());
    return Container(
      padding: const EdgeInsets.only(left: 12, right: 12),
      color: DotNetflixColors.mainBackgroundColor,
      child: const BlocBuilder<LoadingBloc, LoadingStateBase>(builder: parseState)
    );
  }
}