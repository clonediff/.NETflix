import 'package:graphql_flutter/graphql_flutter.dart';
import 'package:mobile/graphql/queries.dart';
import 'package:mobile/main.dart';

abstract class AnalyticsServiceBase {
  Future<int> getFilmVisitsAsync(int filmId);
  Future<String> connectAsync(int filmId);
}

class AnalyticsService implements AnalyticsServiceBase {

  final _analyticsClient = getit<GraphQLClient>(instanceName: 'analytics');

  @override
  Future<int> getFilmVisitsAsync(int filmId) async {
    
    final result = await _analyticsClient.query(
      QueryOptions(
        document: gql(Queries.filmVisitsQuery),
        variables: { 'filmId': filmId },
        fetchPolicy: FetchPolicy.noCache,
        cacheRereadPolicy: CacheRereadPolicy.ignoreAll
      )
    );

    return result.hasException ? 0 : result.data![Queries.filmVisitsQueryName];
  }
  
  @override
  Future<String> connectAsync(int filmId) async {
    
    final result = await _analyticsClient.query(
      QueryOptions(
        document: gql(Queries.connectQuery),
        variables: { 'filmId': filmId },
        fetchPolicy: FetchPolicy.noCache,
        cacheRereadPolicy: CacheRereadPolicy.ignoreAll
      )
    );

    return result.hasException ? '' : result.data![Queries.connectQueryName];
  }
}