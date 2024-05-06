class LoginFormDto {
  final String userName;
  final String password;
  final bool remember;

  LoginFormDto({required this.userName, required this.password, required this.remember});

  Map<String, dynamic> toJson() => {
    'userName': userName,
    'password': password,
    'remember': remember
  };
}