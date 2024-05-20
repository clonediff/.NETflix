import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:mobile/bloc/loading/events.dart';
import 'package:mobile/bloc/loading/states.dart';
import 'package:mobile/main.dart';
import 'package:mobile/services/film_service.dart';
import 'package:mobile/services/subscription_service.dart';


class LoadingBloc extends Bloc<LoadingEventBase, LoadingStateBase> {

  final _filmService = getit<FilmServiceBase>();
  final _subscriptionService = getit<SubscriptionServiceBase>();

  LoadingBloc() : super(LoadingState()) {
    on<LoadingAllFilmsEvent>((event, emit) async {
      emit(LoadingState());
      final result = await _filmService.getAllFilmsAsync();
      result.match(
        (s) => emit(LoadedState(data: s, builder: event.builder)),
        (f) => emit(ErrorState(error: f))
      );
    });
    on<LoadingSearchedFilmsEvent>((event, emit) async {
      emit(LoadingState());
      final result = await _filmService.getFilmsBySearchAsync(event.params);
      result.match(
        (s) => emit(LoadedState(data: s, builder: event.builder)),
        (f) => emit(ErrorState(error: f))
      );
    });
    on<LoadingAllSubscriptionsEvent>((event, emit) async {
      emit(LoadingState());
      final result = await _subscriptionService.getAllSubscriptionsAsync();
      result.match(
        (s) => emit(LoadedState(data: s, builder: event.builder)),
        (f) => emit(ErrorState(error: f))
      );
    });
    on<LoadingFilmByIdEvent>((event, emit) async {
      emit(LoadingState());
      final result = await _filmService.getFilmById(event.filmId, event.userId);
      result.match(
        (s) => emit(LoadedState(data: s, builder: event.builder)),
        (f) => emit(ErrorState(error: f))
      );
    });
  }
}