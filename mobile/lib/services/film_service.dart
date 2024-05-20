// ignore_for_file: prefer_for_elements_to_map_fromiterable

import 'package:graphql_flutter/graphql_flutter.dart';
import 'package:mobile/graphql/queries.dart';
import 'package:mobile/main.dart';
import 'package:mobile/dto/film_failure.dart';
import 'package:mobile/models/film_for_main_page.dart';
import 'package:mobile/models/film_info.dart';
import 'package:mobile/utils/result.dart';

abstract class FilmServiceBase {
  Future<Result<Map<String, List<FilmForMainPage>>, String>> getAllFilmsAsync();
  Future<Result<List<FilmForMainPage>, String>> getFilmsBySearchAsync(Map<String, dynamic> params);
  Future<Result<FilmInfo, GetFilmFailure>> getFilmById(int filmId, String? userId);
}

class FilmService implements FilmServiceBase {

  final _apiClient = getit<GraphQLClient>(instanceName: 'api');

  @override
  Future<Result<Map<String, List<FilmForMainPage>>, String>> getAllFilmsAsync() async {

    final result = await _apiClient.query(
      QueryOptions(document: gql(Queries.allFilmsQuery))
    );

    return result.hasException
      ? const Result.fromFailure("Не удалось загрузить контент")
      : Result.fromSuccess(
          Map.fromIterable(
            result.data![Queries.allFilmsQueryName],
            key: (x) => x['key'],
            value: (x) => (x['value'] as List).map((x) => FilmForMainPage.fromDynamic(x)).toList()
          )
        );
  }

  @override
  Future<Result<List<FilmForMainPage>, String>> getFilmsBySearchAsync(Map<String, dynamic> params) async {
    params.removeWhere((key, value) => value == null || value == '');
    final searchDto = params
      .map((key, value) {
        if (key == 'actors' || key == 'genres') {
          return MapEntry(key, value.split(',').map((x) => x.trimLeft().trimRight()).toList());
        }
        if (key == 'year') {
          return MapEntry(key, value);
        }
        return MapEntry(key, value.trimLeft().trimRight());
      });

    final result = await _apiClient.query(
      QueryOptions(
        document: gql(Queries.filmsBySearchQuery),
        variables: { 'dto': searchDto }
      )
    );

    return result.hasException
      ? const Result.fromFailure("Не удалось загрузить контент")
      : Result.fromSuccess(
          (result.data![Queries.filmsBySearchQueryName] as List)
            .map((x) => FilmForMainPage.fromDynamic(x))
            .toList()
        );
  }

  @override
  Future<Result<FilmInfo, GetFilmFailure>> getFilmById(int filmId, String? userId) async {

    final result = await _apiClient.query(
        QueryOptions(
            document: gql(Queries.filmByIdQuery),
            variables: { 'filmId': filmId, 'userId': userId },
            fetchPolicy: FetchPolicy.noCache,
            cacheRereadPolicy: CacheRereadPolicy.ignoreAll
        )
    );

    return result.hasException
        ? Result.fromFailure(GetFilmFailure(failure: "Не удалось загрузить контент"))
        : result.data![Queries.filmByIdQueryName]['hasError']
          ? Result.fromFailure(GetFilmFailure(failure: result.data![Queries.filmByIdQueryName]['error']))
          : Result.fromSuccess(FilmInfo.fromDynamic(result.data![Queries.filmByIdQueryName]['data']));
  }
}