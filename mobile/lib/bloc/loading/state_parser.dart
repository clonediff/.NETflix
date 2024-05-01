import 'package:flutter/material.dart';
import 'package:mobile/bloc/loading/states.dart';
import 'package:mobile/models/film_for_main_page.dart';
import 'package:mobile/models/subscription.dart';

Widget parseState(BuildContext context, LoadingStateBase state) {
  return switch (state) {
    LoadingState() => const Center(
      child: CircularProgressIndicator(color: Colors.white),
    ),
    LoadedState<Map<String, List<FilmForMainPage>>>() => state.builder(state.data),
    LoadedState<List<FilmForMainPage>>() => state.builder(state.data),
    LoadedState<List<Subscription>>() => state.builder(state.data),
    ErrorState<String>() => Center(child: Text(state.error, style: const TextStyle(color: Colors.white))),
    _ => Container()
  };
}