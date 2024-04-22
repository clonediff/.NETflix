import 'package:flutter/material.dart';
import 'package:mobile/navigationRoutes.dart';
import 'package:mobile/pages/film_page/film/film_page.dart';
import 'package:mobile/pages/main_page.dart';
import 'package:mobile/pages/profile_page/profile_page.dart';
import 'package:mobile/pages/subscriptions_page/subscriptions_page.dart';

MaterialPageRoute? buildRoutes(RouteSettings settings) {
  switch (settings.name) {
    case NavigationRoutes.main:
      return MaterialPageRoute(builder: (context) {
        return MainPage();
      });
    case NavigationRoutes.profile:
      return MaterialPageRoute(builder: (context) {
        return const ProfilePage();
      });
    case NavigationRoutes.subscriptions:
      return MaterialPageRoute(builder: (context) {
        return const SubscriptionsPage();
      });
    case NavigationRoutes.movie:
      return MaterialPageRoute(builder: (context) {
        return const FilmPage();
      });
  }
  return null;
}
