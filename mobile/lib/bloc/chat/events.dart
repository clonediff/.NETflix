part of 'bloc.dart';

@freezed
class GetSupportChatEvent with _$GetSupportChatEvent {
  const factory GetSupportChatEvent.getSupportChatInfo(String roomId) = _GetSupportChatInfo;
}