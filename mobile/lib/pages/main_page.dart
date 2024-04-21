import 'package:flutter/material.dart';
import 'package:mobile/constants/colors.dart';
import 'package:mobile/mocks/film.dart';
import 'package:mobile/widgets/bottom_navigation.dart';
import 'package:mobile/widgets/categorized_films.dart';
import 'package:mobile/widgets/header.dart';

class MainPage extends StatelessWidget {
  const MainPage({super.key});

  @override
  Widget build(BuildContext context) {
    final List<Film> films = List.filled(80, 0)
        .map((x) => Film(
            image: 'https://st.kp.yandex.net/images/film_big/404900.jpg',
            name: 'Во все тяжкие',
            rating: 9.5))
        .toList();

    return Scaffold(
      appBar: const Header(),
      body: Container(
        padding: const EdgeInsets.only(left: 12, right: 12),
        color: NetflixColors.mainBackgroundColor,
        child: ListView(
          children: List.generate(8, (index) => index * 10)
              .map((x) => CategorizedFilms(
                    films: films.getRange(x, x + 10).toList(),
                    category: 'Category ${x ~/ 10}',
                  ))
              .toList(),
        ),
      ),
      bottomNavigationBar: const BottomNavigation(),
    );
  }
}
