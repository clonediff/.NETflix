import 'package:flutter/material.dart';
import 'package:mobile/dotnetflix_app.dart';
import 'package:mobile/navigation.dart';
import 'package:mobile/pages/authorization/authorization.dart';

void main() {
  runApp(const MaterialApp(
    onGenerateRoute: buildRoutes,
    home: Authorization()
  ));
}
