class Mutations {

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
}