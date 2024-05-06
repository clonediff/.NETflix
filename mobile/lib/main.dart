import 'package:flutter/material.dart';
import 'package:get_it/get_it.dart';
import 'package:graphql_flutter/graphql_flutter.dart';
import 'package:mobile/services/film_service.dart';
import 'package:mobile/navigation/navigation.dart';
import 'package:mobile/pages/authorization/authorization.dart';
import 'package:mobile/services/token_service.dart';
import 'package:mobile/services/user_service.dart';
import 'package:mobile/services/subscription_service.dart';

final getit = GetIt.instance;
const String apiBaseUrl = 'http://192.168.1.5:5130';

void setup() {
  getit.registerSingleton<GraphQLClient>(
    GraphQLClient(
      link: AuthLink(getToken: () => 'Bearer token').concat(HttpLink('$apiBaseUrl/graphql')), 
      cache: GraphQLCache()
    )
  );
  getit.registerSingleton<FilmServiceBase>(FilmService());
  getit.registerSingleton<SubscriptionServiceBase>(SubscriptionService());
  getit.registerSingleton<UserServiceBase>(UserService());
  getit.registerSingleton<TokenServiceBase>(TokenService());
}

void main() {
  setup();
  runApp(const MaterialApp(
    onGenerateRoute: buildRoutes,
    home: Authorization()
  ));
}