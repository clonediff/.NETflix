import 'package:flutter/material.dart';
import 'package:mobile/constants/colors.dart';
import 'package:mobile/mocks/film.dart';
import 'package:mobile/widgets/film_card.dart';

class SearchPage extends StatelessWidget {
  SearchPage({ super.key });
  
  final List<Film> films = List
    .filled(40, 0)
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
      color: DotNetflixColors.headerBackgroundColor,
      child: ListView(
        children: List
          .generate(10, (index) => index * 4)
          .map((x) => SizedBox(
            height: 230, 
            child: ListView.separated(
              scrollDirection: Axis.horizontal,
              itemBuilder: (context, index) => FilmCard(film: films[x + index]),
              itemCount: 4,
              separatorBuilder: (context, index) => const Divider(indent: 8)
            )
          ))
          .toList(),
      ),
    );
  }
}