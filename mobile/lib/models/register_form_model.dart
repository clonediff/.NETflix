class RegisterFormDto {
  final String userName;
  final String password;
  final String confirmPassword;
  final DateTime birthday;
  final String email;

  RegisterFormDto({
    required this.userName,
    required this.password,
    required this.confirmPassword,
    required this.birthday,
    required this.email
  });

  Map<String, dynamic> toJson() => {
    'userName': userName,
    'password': password,
    'confirmPassword': confirmPassword,
    'birthday': birthday.toString(),
    'email': email,
  };
}