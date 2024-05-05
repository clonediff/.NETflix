import 'package:flutter/material.dart';
import 'package:mobile/bloc/loading/states.dart';
import 'package:mobile/constants/colors.dart';
import 'package:mobile/constants/styles.dart';
import 'package:mobile/models/film_failure.dart';
import 'package:mobile/models/film_for_main_page.dart';
import 'package:mobile/models/film_info.dart';
import 'package:mobile/navigation/navigation_routes.dart';
import 'package:mobile/services/film_service.dart';

Widget parseState(BuildContext context, LoadingStateBase state) {
  return switch (state) {
    LoadingState() => const Center(
      child: CircularProgressIndicator(color: Colors.white),
    ),
    LoadedState<Map<String, List<FilmForMainPage>>>() => state.builder(state.data),
    LoadedState<List<FilmForMainPage>>() => state.builder(state.data),
    LoadedState<FilmInfo>() =>  state.builder(state.data),
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