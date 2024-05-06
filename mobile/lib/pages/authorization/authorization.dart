import 'package:flutter/material.dart';
import 'package:mobile/constants/colors.dart';
import 'package:mobile/pages/authorization/login/login_form.dart';
import 'registration/registration_form.dart';

class Authorization extends StatefulWidget{
  const Authorization({super.key});

  @override
  State<StatefulWidget> createState() => _AuthorizationState();
}

class _AuthorizationState extends State<Authorization>{
  late int selectedPage = 0;
  final GlobalKey<FormState> _formKey = GlobalKey<FormState>();

  late var forms = [
    LoginForm(formKey: _formKey, onSelectedPage: onSelectedPage),
    RegistrationForm(formKey: _formKey, onSelectedPage: onSelectedPage),
  ];

  onSelectedPage(int page) {
    setState(() {
      selectedPage = page;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: DotNetflixColors.mainBackgroundColor,
      appBar: AppBar(
        centerTitle: true,
        title: const Text('.Netflix',
          style: TextStyle(
              color: Colors.red,
              fontWeight: FontWeight.w700,
              fontSize: 26
          ),
        ),
        backgroundColor: DotNetflixColors.headerBackgroundColor,
      ),
      body: SingleChildScrollView(
          child: forms[selectedPage]
      ),
    );
  }
}
