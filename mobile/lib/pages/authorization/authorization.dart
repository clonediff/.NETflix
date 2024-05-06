import 'package:flutter/material.dart';
import 'package:mobile/constants/colors.dart';
import 'package:mobile/main.dart';
import 'package:mobile/navigation/navigation_routes.dart';
import 'package:mobile/pages/authorization/login/login_form.dart';
import 'package:mobile/services/session_service.dart';
import 'registration/registration_form.dart';

class Authorization extends StatefulWidget{
  const Authorization({super.key});

  @override
  State<StatefulWidget> createState() => _AuthorizationState();
}

class _AuthorizationState extends State<Authorization>{
  late int selectedPage = 0;

  late var forms = [
    LoginForm(onSelectedPage: onSelectedPage),
    RegistrationForm(onSelectedPage: onSelectedPage),
  ];

  onSelectedPage(int page) {
    setState(() {
      selectedPage = page;
    });
  }

  navigateIfTokenExists(BuildContext context, VoidCallback onSuccess) async {
    var sessionDataProvider = getit<SessionDataProvider>();
    var token = await sessionDataProvider.getJwtToken();
    if(token != null && token.isNotEmpty){
      onSuccess.call();
    }
  }
  
  @override
  Widget build(BuildContext context) {
    return FutureBuilder(
      future: navigateIfTokenExists(context, () {
        if(!mounted) {
          return;
        }
        Navigator.of(context)
          ..pop()
          ..pushNamed(NavigationRoutes.main);
      }),
      builder: (context, snapshot) {
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
      },
      
    );
  }
}
