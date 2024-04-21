import 'package:flutter/material.dart';
import 'package:mobile/navigation.dart';
import 'package:mobile/navigationRoutes.dart';

void main() {
  runApp(const App());
}

class App extends StatelessWidget {
  const App({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      initialRoute: NavigationRoutes.main,
      onGenerateRoute: (settings) => buildRoutes(settings),
    );
  }
}
