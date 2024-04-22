import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:mobile/bloc/loading/events.dart';
import 'package:mobile/bloc/loading/states.dart';
import 'package:mobile/main.dart';
import 'package:mobile/services/film_service.dart';

class LoadingBloc extends Bloc<LoadingEventBase, LoadingStateBase> {
  LoadingBloc() : super(LoadingState()) {
    on<LoadingEvent>((event, emit) async {
      emit(LoadingState());
      final service = getit<FilmService>();
      final films = await service.getAllFilmsAsync();
      emit(LoadedState(data: films));
    });
  }
}