import 'package:flutter/material.dart';
import 'package:mobile/constants/colors.dart';
import 'package:mobile/mocks/film.dart';
import 'package:mobile/widgets/categorized_films.dart';

class MainPage extends StatelessWidget {
  MainPage({ super.key });

  final List<Film> films = List
    .filled(80, 0)
    .map((x) => Film(
      image: 'https://st.kp.yandex.net/images/film_big/404900.jpg', 
      name: 'Во все тяжкие', 
      rating: 9.5
    ))
    .toList();

  @override
  Widget build(BuildContext context) {
    return Container(
      padding: const EdgeInsets.only(left: 12, right: 12),
      color: DotNetflixColors.mainBackgroundColor,
      child: ListView(
        children: List
          .generate(8, (index) => index * 10)
          .map((x) => CategorizedFilms(
            films: films.getRange(x, x + 10).toList(),
            category: 'Category ${x ~/ 10}',
          ))
          .toList()
      )
    );
  }
}