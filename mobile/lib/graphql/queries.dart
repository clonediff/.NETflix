class Queries {

  static const allFilmsQueryName = 'allFilms';
  static const allFilmsQuery = '''
    query {
      $allFilmsQueryName {
        key
        value {
          id
          name
          rating
          posterUrl
        }
      }
    }
  ''';

  static const filmsBySearchQueryName = 'filmsBySearch';
  static const filmsBySearchQuery = '''
    query $filmsBySearchQueryName(\$dto: MovieSearchDtoInput!) {
      $filmsBySearchQueryName(dto: \$dto) {
        id
        name
        rating
        posterUrl
      }
    }
  ''';

  static const allSubscriptionsQueryName = 'allSubscriptions';
  static const allSubscriptionsQuery = '''
    query {
      $allSubscriptionsQueryName {
        id
        name
        cost
        periodInDays
        belongsToUser
        filmNames
      }
    }
  ''';
}
