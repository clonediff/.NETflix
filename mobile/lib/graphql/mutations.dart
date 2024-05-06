class Mutations {

  static const subscriptionActionMutationName = 'subscriptionAction';
  static const subscriptionActionMutation = '''
    mutation $subscriptionActionMutationName(
      \$type: SubscriptionActionType!
      \$id: Int!
      \$card: CardDataDtoInput!
    ) {
      $subscriptionActionMutationName(
        type: \$type
        subscriptionId: \$id
        cardDataDto: \$card
      ) {
        hasError
        error
      }
    }
  ''';

  static const loginMutationName = 'login';
  static const loginMutation = '''mutation(\$form: LoginFormInput!){
    $loginMutationName(form: \$form){
      data,
      hasError,
      error
    }
  }''';

  static const registerMutationName = 'register';
  static const registerMutation = ''' mutation(\$form: RegisterFormInput!){
    $registerMutationName(form: \$form) {
      error,
      hasError
    }
  }''';

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