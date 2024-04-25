class FilmForMainPage {
  final int id;
  final String name;
  final double rating;
  final String posterUrl;

  FilmForMainPage.fromDynamic(dynamic object)
    : id = object['id'],
      name = object['name'],
      rating = object['rating'].toDouble(),
      posterUrl = object['posterUrl'];
}

class Film {
  Film({
    required this.image,
    required this.name,
    required this.rating
  });

  final String image;
  final String name;
  final double rating;
}