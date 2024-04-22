class FilmInfo{
  final int id;
  final String name;
  final int year;
  final String? description;
  final String? shortDescription;
  final String? slogan;
  final double? rating;
  final int movieLength;
  final int? ageRating;
  final String? posterUrl;
  final String type;
  final String? category;
  final String? budget;
  final Fees? fees;
  final List<Country> countries;
  final List<String> genres;
  final List<Season> seasonsInfo;
  final List<Trailer> trailersMetaData;
  final List<Poster> postersMetaData;
  final Map<String, List<Person>> professions;

  FilmInfo({required this.id,
    required this.name,
    required this.year,
    required this.description,
    required this.shortDescription,
    required this.slogan,
    required this.rating,
    required this.movieLength,
    required this.ageRating,
    required this.posterUrl,
    required this.type,
    required this.category,
    required this.budget,
    required this.fees,
    required this.countries,
    required this.genres,
    required this.seasonsInfo,
    required this.trailersMetaData,
    required this.postersMetaData,
    required this.professions});
}

class Person {
  final String name;
  final String? photo;
  final String profession;

  Person({required this.name,
    required this.photo,
    required this.profession});
}

class Trailer{
  final String trailerUrl;

  Trailer({required this.trailerUrl});
}

class Poster{
  final String posterUrl;

  Poster({required this.posterUrl});
}

class Season {
  final int number;
  final int episodesCount;

  Season({required this.number, required this.episodesCount});
}

class Fees{
  final String world;
  final String russia;
  final String usa;

  Fees({
    required this.world,
    required this.russia,
    required this.usa
  });
}

class Country{
  final String name;
  final double latitude;
  final double longitude;

  Country({
    required this.name,
    required this.latitude,
    required this.longitude});
}

/*class PosterMetaData {
  final Guid? id;
  final String name;
  final String fileName;
  final String resolution;

  PosterMetaData({
    this.id,
    required this.name,
    required this.fileName,
    required this.resolution
  });
}*/

/*class TrailerMetaData {
  final Guid? id;
  final String name;
  final String fileName;
  final DateTime date;
  final String language;
  final String resolution;

  TrailerMetaData({
    this.id,
    required this.name,
    required this.fileName,
    required this.date,
    required this.language,
    required this.resolution});
}*/