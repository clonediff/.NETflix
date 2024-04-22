import 'package:flutter/material.dart';
import 'package:mobile/mocks/film.dart';
import 'package:mobile/navigationRoutes.dart';

class FilmCard extends StatelessWidget {
  const FilmCard({ super.key, required this.film });

  final Film film;
  
  @override
  Widget build(BuildContext context) {
    return InkWell(
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          ClipRRect(
            borderRadius: BorderRadius.circular(6),
            child: Image.network(
              film.image,
              width: 120,
            )
          ),
          SizedBox(
            width: 120,
            child: Text(
              film.name,
              overflow: TextOverflow.ellipsis,
              style: const TextStyle(
                color: Colors.white,
                fontWeight: FontWeight.w600
              )
            )
          ),
          Row(
            children: [
              Text(
                film.rating.toString(),
                style: const TextStyle(
                  color: Colors.white,
                  fontSize: 12.0
                ),
              ),
              const Icon(
                Icons.star, 
                color: Colors.amber,
                size: 12.0,
              )
            ],
          )
        ],
      ),
      onTap: () => Navigator.of(context).pushNamed(NavigationRoutes.movie)
    );
  }
}