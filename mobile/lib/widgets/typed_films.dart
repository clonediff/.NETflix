import 'package:flutter/material.dart';
import 'package:mobile/models/film_for_main_page.dart';
import 'package:mobile/widgets/film_card.dart';

class TypedFilms extends StatelessWidget {

  final List<FilmForMainPage> films;

  const TypedFilms({ super.key, required this.films });

  @override
  Widget build(BuildContext context) {
    final mediaQuery = MediaQuery.of(context);
    return GridView.count(
      childAspectRatio: mediaQuery.size.width / (mediaQuery.size.height + 80),
      padding: const EdgeInsets.only(top: 12),
      crossAxisCount: 3,
      mainAxisSpacing: 10,
      crossAxisSpacing: 10,
      children: films
        .map((x) => FilmCard(film: x))
        .toList(),
    );
  }
}