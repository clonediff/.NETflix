import 'dart:core';
import 'package:flutter/material.dart';
import 'package:mobile/constants/styles.dart';
import 'package:mobile/main.dart';
import 'package:mobile/models/register_form_model.dart';
import 'package:mobile/services/auth_service.dart';
import 'package:mobile/widgets/date_form_field.dart';
import 'package:mobile/widgets/text_form_field.dart';

class RegistrationForm extends StatefulWidget{
  final Function(int pageNumber) onSelectedPage;

  const RegistrationForm({super.key, required this.onSelectedPage});

  @override
  State<RegistrationForm> createState() => _RegistrationFormState();
}

class _RegistrationFormState extends State<RegistrationForm> {
  final GlobalKey<FormState> formKey = GlobalKey<FormState>(debugLabel: 'register');
  final TextEditingController _emailController = TextEditingController();
  final TextEditingController _passwordController = TextEditingController();
  final TextEditingController _confirmPasswordController = TextEditingController();
  final TextEditingController _userNameController = TextEditingController();
  final TextEditingController _dateController = TextEditingController();
  final AuthServiceBase _authService = getit<AuthServiceBase>();
  String registrationError = "";

  Future<void> onFormSubmit(BuildContext context) async {
    if (formKey.currentState == null || !formKey.currentState!.validate()) {
      return;
    }

    var email = _emailController.text;
    var userName = _userNameController.text;
    var password = _passwordController.text;
    var confirmPassword = _confirmPasswordController.text;
    var birthday =  DateTime.parse(_dateController.text);

    var registerFormDto = RegisterFormDto(userName: userName, password: password,
        confirmPassword: confirmPassword, birthday: birthday, email: email);

    var response = await _authService.register(registerFormDto);

    if(response.hasError) {
      setState(() {
        registrationError = response.error!;
      });
    }
    else {
      widget.onSelectedPage(0);
    }
  }

  String? validateEmail(String? email){
    if(email == null || email.isEmpty) {
      return 'Email-почта не должна быть пустой!';
    }
    if(!RegExp(r"^[a-zA-Z0-9.a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9]+\.[a-zA-Z]+")
        .hasMatch(email)){
      return 'Введённые данные не соответствуют электронной почте!';
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

  String? validatePasswords(String? secondPassword){
    if(_passwordController.text.isNotEmpty && _passwordController.text != secondPassword){
      return 'Пароли не совпадают!';
    }
    return null;
  }

  String? validateUserName(String? userName){
    if(userName == null || userName.isEmpty) {
      return 'Имя пользоателя не должно быть пустым!';
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
            const Text('Регистрация', style: DotNetflixTextStyles.loginStyle),
            DotNetflixTextFormField(
              fieldName: 'Email',
              icon: const Icon(Icons.email, color: Colors.red),
              validator: validateEmail,
              controller: _emailController,
              hideText: false,
            ),
            DotNetflixTextFormField(
              fieldName: 'Пароль',
              icon: const Icon(Icons.key, color: Colors.red),
              validator: validatePassword,
              controller: _passwordController,
              hideText: true,
            ),
            DotNetflixTextFormField(
              fieldName: 'Подтвердите пароль',
              icon: const Icon(Icons.key, color: Colors.red),
              validator: validatePasswords,
              controller: _confirmPasswordController,
              hideText: true,
            ),
            DotNetflixTextFormField(
              fieldName: 'Имя пользователь',
              icon: const Icon(Icons.person, color: Colors.red),
              validator: validateUserName,
              controller: _userNameController,
              hideText: false,
            ),
            DotNetflixDateFormField(
                fieldName: 'Дата рождения',
                icon: const Icon(Icons.date_range, color: Colors.red),
                controller: _dateController
            ),
            Text(registrationError, style: const TextStyle(fontSize: 18.0, color: Colors.red),),
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
              child: const Text('Есть аккаунт?', style: DotNetflixTextStyles.mainTextStyle),
              onTap: () => widget.onSelectedPage(0),
            )
          ],
        ),
      ),
    );
  }
}
