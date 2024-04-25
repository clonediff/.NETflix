import 'package:graphql_flutter/graphql_flutter.dart';
import 'package:mobile/graphql/queries.dart';
import 'package:mobile/main.dart';
import 'package:mobile/models/film_for_main_page.dart';

class FilmService {

  final _client = getit<GraphQLClient>();

  Future<Map<String, List<FilmForMainPage>>> getAllFilmsAsync() async {
    final result = await _client.query(
      QueryOptions(document: gql(Queries.allFilmsQuery))
    );

    // ignore: prefer_for_elements_to_map_fromiterable
    return Map.fromIterable(
      result.data![Queries.allFilmsQueryName],
      key: (x) => x['key'],
      value: (x) => (x['value'] as List).map((x) => FilmForMainPage.fromDynamic(x)).toList()
    );
  }

  Future<List<FilmForMainPage>> getFilmsBySearchAsync(Map<String, String> params) async {
    final result = await _client.query(
      QueryOptions(
        document: gql(Queries.filmsBySearchQuery),
        variables: { 'dto': params }
      )
    );

    print(result.exception.toString());

    return (result.data![Queries.filmsBySearchQueryName] as List)
      .map((x) => FilmForMainPage.fromDynamic(x))
      .toList();
  }
}