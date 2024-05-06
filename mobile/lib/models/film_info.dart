import 'package:flutter_guid/flutter_guid.dart';

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
  final List<TrailerMetaData> trailersMetaData;
  final List<PosterMetaData> postersMetaData;
  final Map<String, List<Person>> persons;

  FilmInfo.fromDynamic(dynamic object)
      : id = object['id'],
        name = object['name'],
        year = object['year'],
        description = object['description'],
        shortDescription = object['shortDescription'],
        slogan = object['slogan'],
        rating = (object['rating'] ?? 0).toDouble(),
        movieLength = object['movieLength'],
        ageRating = object['ageRating'] ?? 0,
        posterUrl = object['posterUrl'],
        type = object['type'],
        category = object['category'],
        budget = object['budget'],
        fees = Fees.fromDynamic(object['fees']),
        countries = (object['countries'] as List).map((x) => Country.fromDynamic(x)).toList(),
        genres = (object['genres'] as List).map((x) => x.toString()).toList(),
        seasonsInfo = (object['seasonsInfo'] as List).map((x) => Season.fromDynamic(x)).toList(),
        persons = { for (var v in object['persons'] as List) v['key'] : (v['value'] as List).map((x) => Person.fromDynamic(x)).toList() },
        trailersMetaData = (object['trailersMetaData'] as List).map((x) => TrailerMetaData.fromDynamic(x)).toList(),
        postersMetaData = (object['postersMetaData'] as List).map((x) => PosterMetaData.fromDynamic(x)).toList();
}

class Person {
  final String name;
  final String? photo;
  final String profession;

  Person.fromDynamic(dynamic object)
    : name = object['name'],
      photo = object['photo'],
      profession = object['profession'];
}

class Season {
  final int number;
  final int episodesCount;

  Season.fromDynamic(dynamic object)
      : number = object['number'],
        episodesCount = object['episodesCount'];
}

class Fees{
  final String world;
  final String russia;
  final String usa;

  Fees.fromDynamic(dynamic object)
      : world = object['world'],
        russia = object['russia'],
        usa = object['usa'];

}

class Country{
  final String name;
  final double latitude;
  final double longitude;

  Country.fromDynamic(dynamic object)
      : name = object['name'],
        latitude = object['latitude'].toDouble(),
        longitude = object['longitude'].toDouble();
}

class PosterMetaData {
  final Guid? id;
  final String name;
  final String fileName;
  final String resolution;

  PosterMetaData.fromDynamic(dynamic object)
      : id = Guid(object['id'].toString()),
        name = object['name'],
        fileName = object['fileName'],
        resolution = object['resolution'];
}

class TrailerMetaData {
  final Guid? id;
  final String name;
  final String fileName;
  final DateTime date;
  final String language;
  final String resolution;

  TrailerMetaData.fromDynamic(dynamic object)
      : id = Guid(object['id'].toString()),
        name = object['name'],
        fileName = object['fileName'],
        resolution = object['resolution'],
        language = object['language'],
        date = DateTime.parse(object['date']);
}