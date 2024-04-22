import 'package:flutter/material.dart';
import 'package:mobile/models/film.dart';

class FilmCard extends StatelessWidget {
  const FilmCard({ super.key, required this.film });

  final FilmForMainPage film;
  
  @override
  Widget build(BuildContext context) {
    return Column(
      crossAxisAlignment: CrossAxisAlignment.start,
      children: [
        ClipRRect(
          borderRadius: BorderRadius.circular(6),
          child: Image.network(
            loadingBuilder: (context, child, loadingProgress) {
              if (loadingProgress == null) return child;
              return SizedBox(
                width: 120,
                height: 180,
                child: Center(
                  child: CircularProgressIndicator(
                    color: Colors.white,
                    value: loadingProgress.cumulativeBytesLoaded / loadingProgress.expectedTotalBytes!,
                  ),
                )
              );
            },
            film.posterUrl,
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
    );
  }
}