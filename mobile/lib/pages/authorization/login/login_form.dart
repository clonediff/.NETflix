import 'package:flutter/material.dart';
import 'package:mobile/constants/styles.dart';
import 'package:mobile/main.dart';
import 'package:mobile/models/login_form_model.dart';
import 'package:mobile/navigation/navigation_routes.dart';
import 'package:mobile/services/auth_service.dart';
import 'package:mobile/services/session_service.dart';
import 'package:mobile/widgets/text_form_field.dart';

class LoginForm extends StatefulWidget{

  final Function(int pageNumber) onSelectedPage;

  const LoginForm({super.key, required this.onSelectedPage});

  @override
  State<LoginForm> createState() => _LoginFormState();
}

class _LoginFormState extends State<LoginForm> {
  final GlobalKey<FormState> formKey = GlobalKey<FormState>(debugLabel: "login");
  final TextEditingController _userNameController = TextEditingController();
  final TextEditingController _passwordController = TextEditingController();
  final AuthServiceBase _authService = getit<AuthServiceBase>();
  final SessionDataProvider _sessionDataProvider = getit<SessionDataProvider>();
  String loginError = "";

  Future<void> onFormSubmit(BuildContext context) async {
    if (formKey.currentState == null || !formKey.currentState!.validate()) {
      return;
    }

    var userName = _userNameController.text;
    var password = _passwordController.text;

    var loginFormDto = LoginFormDto(userName: userName, password: password, remember: true);

    var response = await _authService.login(loginFormDto);

    response.match(
            (token) => onSuccess(token),
            (error) => onFailure(error)
    );
  }

  onSuccess(String token){
      _sessionDataProvider.setJwtToken(token);
      Navigator.of(context)
        ..pop()
        ..pushNamed(NavigationRoutes.main);
  }

  onFailure(String error){
    setState(() {
      loginError = error;
    });
  }

  String? validateUserName(String? userName){
    if(userName == null || userName.isEmpty) {
      return 'Имя пользователя не должно быть пустым';
    }
    return null;
  }

  String? validatePassword(String? password){
    if(password == null || password.isEmpty) {
      return 'Пароль не должен быть пустой!';
    }
    if(password.length < 8){
      return 'Длина пароля не должна быть меньше 8 символов!';
    }
    return null;
  }

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.all(8.0),
      child: Form(
        key: formKey,
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            const Text('Вход', style: DotNetflixTextStyles.loginStyle),
            DotNetflixTextFormField(
              fieldName: 'Имя пользователя',
              icon: const Icon(Icons.email, color: Colors.red),
              validator: validateUserName,
              controller: _userNameController,
              hideText: false,
            ),
            DotNetflixTextFormField(
              fieldName: 'Пароль',
              icon: const Icon(Icons.key, color: Colors.red),
              validator: validatePassword,
              controller: _passwordController,
              hideText: true,
            ),
            Text(loginError, style: const TextStyle(fontSize: 18.0, color: Colors.red),),
            Center(
              child: Padding(
                padding: const EdgeInsets.symmetric(vertical: 16.0),
                child: ElevatedButton(
                  onPressed: () => onFormSubmit(context),
                  style: DotNetflixButtonStyles.submitButtonStyle,
                  child: const Text('Submit', style: DotNetflixTextStyles.loginStyle,),
                ),
              ),
            ),
            InkWell(
              child: const Text('Нет аккаунта?', style: DotNetflixTextStyles.mainTextStyle),
              onTap: () => widget.onSelectedPage(1),
            )
          ],
        ),
      ),
    );
  }
}