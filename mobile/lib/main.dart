import 'package:flutter/material.dart';
import 'package:flutter_secure_storage/flutter_secure_storage.dart';
import 'package:get_it/get_it.dart';
import 'package:graphql_flutter/graphql_flutter.dart';
import 'package:mobile/services/auth_service.dart';
import 'package:mobile/services/film_service.dart';
import 'package:mobile/navigation/navigation.dart';
import 'package:mobile/pages/authorization/authorization.dart';
import 'package:mobile/services/token_service.dart';
import 'package:mobile/services/user_service.dart';
import 'package:mobile/services/subscription_service.dart';
import 'package:mobile/services/session_service.dart';
import 'package:grpc/grpc.dart' as $grpc;
import 'package:grpc/grpc.dart';

final getit = GetIt.instance;
const String apiBaseIp = '192.168.1.35';
const int apiBasePort = 5130;
const int apiBaseGrpcPort = 5131;
const String apiBaseUrl = 'http://$apiBaseIp:$apiBasePort';

void setup() {
  var sessionDataProvider = SessionDataProvider(const FlutterSecureStorage());
  getit.registerSingleton<GraphQLClient>(
    GraphQLClient(
      link: AuthLink(getToken: () async => 'Bearer ${await sessionDataProvider.getJwtToken()}')
          .concat(HttpLink('$apiBaseUrl/graphql')),
      cache: GraphQLCache()
    )
  );

  final channel = $grpc.ClientChannel(
      apiBaseIp,
      port: apiBaseGrpcPort,
      options: const ChannelOptions(
          credentials: $grpc.ChannelCredentials.insecure(),

      )
  );

  getit.registerSingleton<$grpc.ClientChannel>(channel);

  getit.registerSingleton<SessionDataProvider>(sessionDataProvider);
  getit.registerSingleton<FilmServiceBase>(FilmService());
  getit.registerSingleton<SubscriptionServiceBase>(SubscriptionService());
  getit.registerSingleton<UserServiceBase>(UserService());
  getit.registerSingleton<TokenServiceBase>(TokenService());
  getit.registerSingleton<AuthServiceBase>(AuthService());
}

Future<void> main() async {
  setup();
  runApp(const MaterialApp(
    onGenerateRoute: buildRoutes,
    home: Authorization()
  ));
}