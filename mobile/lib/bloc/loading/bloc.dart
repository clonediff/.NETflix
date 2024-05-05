import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:mobile/bloc/loading/events.dart';
import 'package:mobile/bloc/loading/states.dart';
import 'package:mobile/main.dart';
import 'package:mobile/services/film_service.dart';

class LoadingBloc extends Bloc<LoadingEventBase, LoadingStateBase> {
  LoadingBloc() : super(LoadingState()) {
    on<LoadingAllFilmsEvent>((event, emit) async {
      emit(LoadingState());
      final service = getit<FilmServiceBase>();
      final result = await service.getAllFilmsAsync();
      result.match(
        (s) => emit(LoadedState(data: s, builder: event.builder)),
        (f) => emit(ErrorState(error: f))
      );
    });
    on<LoadingSearchedFilmsEvent>((event, emit) async {
      emit(LoadingState());
      final service = getit<FilmServiceBase>();
      final result = await service.getFilmsBySearchAsync(event.params);
      result.match(
        (s) => emit(LoadedState(data: s, builder: event.builder)),
        (f) => emit(ErrorState(error: f))
      );
    });
    on<LoadingFilmByIdEvent>((event, emit) async {
      emit(LoadingState());
      final result = await event.filmService.getFilmById(event.filmId, event.userId);
      result.match(
        (s) => emit(LoadedState(data: s, builder: event.builder)),
        (f) => emit(ErrorState(error: f))
      );
    });

  }
}