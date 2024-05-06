import 'package:flutter/material.dart';
import 'package:flutter_secure_storage/flutter_secure_storage.dart';
import 'package:get_it/get_it.dart';
import 'package:graphql_flutter/graphql_flutter.dart';
import 'package:mobile/services/auth_service.dart';
import 'package:mobile/services/film_service.dart';
import 'package:mobile/navigation/navigation.dart';
import 'package:mobile/pages/authorization/authorization.dart';
import 'package:mobile/services/session_service.dart';

final getit = GetIt.instance;

void setup() {
  var sessionDataProvider = SessionDataProvider(const FlutterSecureStorage());
  getit.registerSingleton<GraphQLClient>(
    GraphQLClient(
      link: AuthLink(getToken: () async => 'Bearer ${await sessionDataProvider.getJwtToken()}')
          .concat(HttpLink('http://192.168.43.135:5130/graphql')),
      cache: GraphQLCache()
    )
  );
  getit.registerSingleton<SessionDataProvider>(SessionDataProvider(const FlutterSecureStorage()));
  getit.registerSingleton<FilmServiceBase>(FilmService());
  getit.registerSingleton<AuthServiceBase>(AuthService());
}

Future<void> main() async {
  setup();
  runApp(const MaterialApp(
    onGenerateRoute: buildRoutes,
    home: Authorization()
  ));
}