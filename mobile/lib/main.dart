import 'package:flutter/material.dart';
import 'package:get_it/get_it.dart';
import 'package:graphql_flutter/graphql_flutter.dart';
import 'package:mobile/services/film_service.dart';
import 'package:mobile/navigation/navigation.dart';
import 'package:mobile/pages/authorization/authorization.dart';

final getit = GetIt.instance;

void setup() {
  getit.registerSingleton<GraphQLClient>(
    GraphQLClient(
      link: HttpLink('http://192.168.43.135:5088/graphql'), 
      cache: GraphQLCache()
    )
  );
  getit.registerSingleton<FilmService>(FilmService());
}

void main() {
  setup();
  runApp(const MaterialApp(
    onGenerateRoute: buildRoutes,
    home: Authorization()
  ));
}