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

  static const userQueryName = 'user';
  static const userQuery = '''
    query {
      $userQueryName {
        login
        email
        birthdate
        enabled2FA
      }
    }
  ''';

  static const allUserSubscriptionsQueryName = 'allUserSubscriptions';
  static const allUserSubscriptionsQuery = '''
    query{
      $allUserSubscriptionsQueryName {
        id
        subscriptionName
        cost
        expires
      }
    } 
  ''';

  static const changePasswordMutationName = 'setUserPassword';
  static const changePasswordMutationDtoName = 'chPass';
  static const changePasswordMutation = '''
    mutation $changePasswordMutationName(\$$changePasswordMutationDtoName: UserChangePasswordDtoInput!) {
        $changePasswordMutationName (chPass: \$$changePasswordMutationDtoName)
    }
  ''';

  static const changeEmailMutationName = 'setUserMail';
  static const changeEmailMutationDtoName = 'chMail';
  static const changeEmailMutation = '''
    mutation $changeEmailMutationName(\$$changeEmailMutationDtoName: UserChangeMailDtoInput!) {
        $changeEmailMutationName (chMail: \$$changeEmailMutationDtoName)
    }
  ''';

  static const changeUserDataMutationName = 'setUserData';
  static const changeUserDataMutationDtoName = 'chOrdinary';
  static const changeUserDataMutation = '''
    mutation $changeUserDataMutationName(\$$changeUserDataMutationDtoName: UserChangeOrdinaryDtoInput!) {
        $changeUserDataMutationName (chOrdinary: \$$changeUserDataMutationDtoName)
    }
  ''';

  static const enable2FAMutationName = 'enable2FA';
  static const enable2FAMutationDtoName = 'dto';
  static const enable2FAMutation = '''
    mutation $enable2FAMutationName(\$$enable2FAMutationDtoName: EnableTwoFactorAuthDtoInput!) {
        $enable2FAMutationName (dto: \$$enable2FAMutationDtoName)
    }
  ''';

  static const send2FATokenMutationName = 'send2FAToken';
  static const send2FATokenMutation = '''
    mutation {
        $send2FATokenMutationName
    }
  ''';

  static const sendChangePasswordTokenMutationName = 'sendChangePasswordToken';
  static const sendChangePasswordTokenMutation = '''
    mutation {
        $sendChangePasswordTokenMutationName
    }
  ''';

  static const sendChangeMailTokenMutationName = 'sendChangeMailToken';
  static const sendChangeMailTokenMutationDtoName = 'newEmail';
  static const sendChangeMailTokenMutation = '''
    mutation $sendChangeMailTokenMutationName(\$$sendChangeMailTokenMutationDtoName: String!){
        $sendChangeMailTokenMutationName (newEmail: \$$sendChangeMailTokenMutationDtoName)
    }
  ''';
}
