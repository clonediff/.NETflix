import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:mobile/bloc/loading/bloc.dart';
import 'package:mobile/navigation/navigation_routes.dart';
import 'package:mobile/pages/film_page/film/film_page_builder.dart';
import 'package:mobile/pages/main_page.dart';
import 'package:mobile/pages/profile_page/profile_page.dart';
import 'package:mobile/pages/subscriptions_page/subscriptions_page.dart';

MaterialPageRoute? buildRoutes(RouteSettings settings) {
  return MaterialPageRoute(builder: (context) {
    return switch (settings.name) {
      NavigationRoutes.main => BlocProvider(
        create: (_) => LoadingBloc(),
        child: const MainPage()
      ),
      NavigationRoutes.profile => const ProfilePage(),
      NavigationRoutes.movie => BlocProvider(
          create: (_) => LoadingBloc(),
          child: const FilmPageBuilder(),
      ),
      NavigationRoutes.subscriptions => BlocProvider(
        create: (_) => LoadingBloc(),
        child: const SubscriptionsPage()
      ),
      _ => throw Error()
    };
  }, settings: settings);
}
