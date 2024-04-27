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