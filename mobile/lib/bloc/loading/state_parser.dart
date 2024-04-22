import 'package:flutter/material.dart';
import 'package:mobile/bloc/loading/states.dart';
import 'package:mobile/models/film.dart';
import 'package:mobile/widgets/categorized_films.dart';

Widget parseState(BuildContext context, LoadingStateBase state) {
  return switch (state) {
    LoadingState() => const Center(
      child: CircularProgressIndicator(color: Colors.white),
    ),
    LoadedState<Map<String, List<FilmForMainPage>>>() => ListView(
      children: state.data.entries
        .map((x) => CategorizedFilms(
          films: x.value, 
          category: x.key
        ))
        .toList()
    ),
    _ => Container()
  };
}