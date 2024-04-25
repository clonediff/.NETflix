import 'package:flutter/material.dart';
import 'package:mobile/bloc/loading/states.dart';
import 'package:mobile/models/film_for_main_page.dart';
import 'package:mobile/widgets/categorized_films.dart';
import 'package:mobile/widgets/film_card.dart';

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
    LoadedState<List<FilmForMainPage>>() => GridView.count(
      childAspectRatio: MediaQuery.of(context).size.width / (MediaQuery.of(context).size.height + 80),
      padding: const EdgeInsets.only(top: 12),
      crossAxisCount: 3,
      mainAxisSpacing: 10,
      crossAxisSpacing: 10,
      children: state.data
        .map((x) => FilmCard(film: x))
        .toList(),
    ),
    _ => Container()
  };
}