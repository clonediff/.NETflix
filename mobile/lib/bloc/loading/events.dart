import 'package:flutter/material.dart';
import 'package:mobile/models/film_for_main_page.dart';
import 'package:mobile/models/subscription.dart';

class LoadingEventBase { }

class GenericLoadingEventBase<TData> extends LoadingEventBase {
  final Widget Function(TData) builder;

  GenericLoadingEventBase({ required this.builder });
}

class LoadingAllFilmsEvent extends GenericLoadingEventBase<Map<String, List<FilmForMainPage>>> {
  LoadingAllFilmsEvent({ required super.builder });
}

class LoadingSearchedFilmsEvent extends GenericLoadingEventBase<List<FilmForMainPage>> { 
  final Map<String, dynamic> params;

  LoadingSearchedFilmsEvent({ required this.params, required super.builder });
}

class LoadingAllSubscriptionsEvent extends GenericLoadingEventBase<List<Subscription>> {
  LoadingAllSubscriptionsEvent({ required super.builder });
}