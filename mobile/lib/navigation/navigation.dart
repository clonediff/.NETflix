import 'package:flutter/material.dart';
import 'package:mobile/navigation/navigation_routes.dart';
import 'package:mobile/dotnetflix_app.dart';
import 'package:mobile/pages/film_page/film/film_page.dart';
import 'package:mobile/pages/profile_page/profile_page.dart';
import 'package:mobile/pages/subscriptions_page/subscriptions_page.dart';

MaterialPageRoute? buildRoutes(RouteSettings settings) {
  return MaterialPageRoute(builder: (context) {
    return switch (settings.name) {
      NavigationRoutes.main => const DotNetflixApp(),
      NavigationRoutes.profile => const ProfilePage(),
      NavigationRoutes.subscriptions => const SubscriptionsPage(),
      NavigationRoutes.movie => const FilmPage(),
      _ => throw Error()
    };
  });
}
