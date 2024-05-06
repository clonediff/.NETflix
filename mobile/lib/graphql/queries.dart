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

  static const filmByIdQueryName = 'filmById';
  static const filmByIdQuery = '''
  query $filmByIdQueryName(\$filmId: Int!, \$userId: String) {
    $filmByIdQueryName(filmId: \$filmId, userId: \$userId) {
      hasError
      error
      data {
        id
        name
        year
        description
        shortDescription
        slogan
        rating
        movieLength
        ageRating
        posterUrl
        type
        category
        budget
        fees {
            world
            russia
            usa
        }
        countries {
            name
            latitude
            longitude
        }
        genres
        seasonsInfo {
            number
            episodesCount
        }
        persons: professions {
            key
            value {
                name
                photo
                profession
            }
        }
        trailersMetaData {
          id
          name
          fileName
          date
          language
          resolution
        }
        postersMetaData {
          id
          name
          fileName
          resolution
        }
      }
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
