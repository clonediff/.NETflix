import 'package:flutter/material.dart';
import 'package:mobile/constants/styles.dart';
import 'package:mobile/widgets/text_form_field.dart';

class LoginForm extends StatelessWidget{
  final GlobalKey<FormState> formKey;
  final Function(int pageNumber) onSelectedPage;
  final TextEditingController _emailController = TextEditingController();
  final TextEditingController _passwordController = TextEditingController();

  LoginForm({super.key, required this.formKey, required this.onSelectedPage});

  String? validateEmail(String? email){
    if(email == null || email.isEmpty) {
      return 'Email-почта не должна быть пустой';
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
            Center(
              child: Padding(
                padding: const EdgeInsets.symmetric(vertical: 16.0),
                child: ElevatedButton(
                  onPressed: () {
                    if (formKey.currentState!.validate()) {
                      var email = _emailController.text;
                      var password = _passwordController.text;

                      //todo Process data and navigate
                    }
                  },
                  style: DotNetflixButtonStyles.submitButtonStyle,
                  child: const Text('Submit', style: DotNetflixTextStyles.loginStyle,),
                ),
              ),
            ),
            InkWell(
              child: const Text('Неn аккаунта?', style: DotNetflixTextStyles.mainTextStyle),
              onTap: () => onSelectedPage(1),
            )
          ],
        ),
      ),
    );
  }
}