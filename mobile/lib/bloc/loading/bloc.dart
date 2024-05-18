import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:mobile/bloc/loading/events.dart';
import 'package:mobile/bloc/loading/states.dart';
import 'package:mobile/dto/chat_dto.dart';
import 'package:mobile/generated/support-chat.pbgrpc.dart';
import 'package:mobile/main.dart';
import 'package:mobile/services/film_service.dart';
import 'package:mobile/services/session_service.dart';
import 'package:mobile/services/subscription_service.dart';
import 'package:grpc/grpc.dart' as $grpc;
import 'package:mobile/generated/support-chat.pb.dart' as grpc_models;

class LoadingBloc extends Bloc<LoadingEventBase, LoadingStateBase> {

  final _filmService = getit<FilmServiceBase>();
  final _subscriptionService = getit<SubscriptionServiceBase>();
  final _grpcSupportChatClient = SupportChatServiceClient(getit<$grpc.ClientChannel>());
  final _sessionDataProvider = getit<SessionDataProvider>();

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
    on<LoadingChatPageEvent>((event, emit) async {
      emit(LoadingState());

      var token = 'Bearer ${await _sessionDataProvider.getJwtToken()}';
      final history = _grpcSupportChatClient.history(grpc_models.HistoryRequest(roomId: ""), options: $grpc.CallOptions(metadata: {"Authorization": token}));

      final receive = _grpcSupportChatClient.receiveMessage(ReceiveRequest(roomId: ""), options: $grpc.CallOptions(metadata: {"Authorization": token}));

      emit(LoadedState(data: ChatDto(history: history, receive:receive), builder: event.builder));
    });
  }
}