import 'dart:core';
import 'package:flutter/material.dart';
import 'package:mobile/constants/styles.dart';
import 'package:mobile/widgets/date_form_field.dart';
import 'package:mobile/widgets/text_form_field.dart';

class RegistrationForm extends StatelessWidget{
  final GlobalKey<FormState> formKey;
  final Function(int pageNumber) onSelectedPage;
  final TextEditingController _emailController = TextEditingController();
  final TextEditingController _passwordController = TextEditingController();
  final TextEditingController _usernameController = TextEditingController();
  final TextEditingController _dateController = TextEditingController();

  RegistrationForm({super.key, required this.formKey, required this.onSelectedPage});

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
              controller: null,
              hideText: true,
            ),
            DotNetflixTextFormField(
              fieldName: 'Имя пользователь',
              icon: const Icon(Icons.person, color: Colors.red),
              validator: validateUserName,
              controller: _usernameController,
              hideText: false,
            ),
            DotNetflixDateFormField(
                fieldName: 'Дата рождения',
                icon: const Icon(Icons.date_range, color: Colors.red),
                controller: _dateController
            ),
            Center(
              child: Padding(
                padding: const EdgeInsets.symmetric(vertical: 16.0),
                child: ElevatedButton(
                  onPressed: () {
                    if (formKey.currentState!.validate()) {
                      //todo Process data and navigate.
                    }
                  },
                  style: DotNetflixButtonStyles.submitButtonStyle,
                  child: const Text('Submit', style: DotNetflixTextStyles.loginStyle,),
                ),
              ),
            ),
            InkWell(
              child: const Text('Есть аккаунт?', style: DotNetflixTextStyles.mainTextStyle),
              onTap: () => onSelectedPage(1),
            )
          ],
        ),
      ),
    );
  }
}
