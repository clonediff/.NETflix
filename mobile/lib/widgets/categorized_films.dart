import 'package:flutter/material.dart';
import 'package:mobile/mocks/film.dart';
import 'package:mobile/widgets/film_card.dart';

class CategorizedFilms extends StatelessWidget {
  const CategorizedFilms({ 
    super.key, 
    required this.films,
    required this.category
  });

  final List<Film> films;
  final String category;
  
  @override
  Widget build(BuildContext context) {
    return Container(
      margin: const EdgeInsets.only(top: 12),
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Container(
            margin: const EdgeInsets.only(bottom: 4),
            child: Text(
              category,
              style: const TextStyle(
                color: Colors.white,
                fontWeight: FontWeight.w600,
                fontSize: 16
              ),
            )
          ),
          SizedBox(
            height: 230,
            child: ListView.separated(
              scrollDirection: Axis.horizontal,
              itemBuilder: (context, index) => FilmCard(film: films[index]),
              separatorBuilder: (context, index) => const Divider(indent: 8),
              itemCount: films.length,
            )
          )
        ]
      )
    );
  }
}