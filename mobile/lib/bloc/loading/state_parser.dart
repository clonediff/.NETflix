import 'package:flutter/material.dart';
import 'package:grpc/grpc.dart';
import 'package:mobile/bloc/loading/states.dart';
import 'package:mobile/constants/colors.dart';
import 'package:mobile/constants/styles.dart';
import 'package:mobile/dto/chat_dto.dart';
import 'package:mobile/dto/film_failure.dart';
import 'package:mobile/generated/support-chat.pb.dart';
import 'package:mobile/models/chat_message.dart';
import 'package:mobile/models/film_for_main_page.dart';
import 'package:mobile/models/film_info.dart';
import 'package:mobile/models/subscription.dart';

Widget parseState(BuildContext context, LoadingStateBase state) {
  return switch (state) {
    LoadingState() => const Center(
      child: CircularProgressIndicator(color: Colors.white),
    ),
    LoadedState<Map<String, List<FilmForMainPage>>>() => state.builder(state.data),
    LoadedState<List<FilmForMainPage>>() => state.builder(state.data),
    LoadedState<FilmInfo>() => state.builder(state.data),
    LoadedState<List<Subscription>>() => state.builder(state.data),
    LoadedState<ChatDto>() => state.builder(state.data),
    ErrorState<String>() => Center(child: Text(state.error, style: const TextStyle(color: Colors.white))),
    ErrorState<GetFilmFailure>() => getFilmFailureAlertDialog(state),
    _ => Container()
  };
}

AlertDialog getFilmFailureAlertDialog(ErrorState<GetFilmFailure> state){
  return AlertDialog(
      scrollable: true,
      title: const Text(
          'Внимание',
          style: TextStyle(
              color: Colors.red,
              fontWeight: FontWeight.w600
          )
      ),
      content: Text(state.error.failure, style: DotNetflixTextStyles.filmNameStyle),
      backgroundColor: DotNetflixColors.headerBackgroundColor,
      shape: const RoundedRectangleBorder(borderRadius: BorderRadius.all(Radius.circular(10))),

  );
}