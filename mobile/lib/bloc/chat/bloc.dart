import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:freezed_annotation/freezed_annotation.dart';
import 'package:grpc/grpc.dart' as $grpc;
import 'package:mobile/dto/chat_dto.dart';
import 'package:mobile/generated/support-chat.pbgrpc.dart';
import 'package:mobile/main.dart';
import 'package:mobile/services/session_service.dart';
import 'package:mobile/generated/support-chat.pb.dart' as grpc_models;

part 'bloc.freezed.dart';

part 'events.dart';

part 'states.dart';

class GetSupportChatBloc extends Bloc<GetSupportChatEvent, GetSupportChatState> {
  GetSupportChatBloc() : super(GetSupportChatState.loading()) {
    final grpcSupportChatClient = SupportChatServiceClient(getit<$grpc.ClientChannel>());
    final sessionDataProvider = getit<SessionDataProvider>();

    on<_GetSupportChatInfo>((event, emit) async {
        var roomId = event.roomId;
        emit(GetSupportChatState.loading());

        var token = 'Bearer ${await sessionDataProvider.getJwtToken()}';
        final history = await grpcSupportChatClient.history(
            grpc_models.HistoryRequest(roomId: ""),
            options: $grpc.CallOptions(metadata: {"Authorization": token}));

        final receive = grpcSupportChatClient.receiveMessage(
            ReceiveRequest(roomId: roomId),
            options: $grpc.CallOptions(metadata: {"Authorization": token})
        );

        emit(GetSupportChatState.loaded(chat: ChatDto(history: history, receive:receive)));
      },
    );
  }
}