part of 'bloc.dart';

@freezed
class GetSupportChatState with _$GetSupportChatState {
  factory GetSupportChatState.loading() = _GetSupportChatLoading;
  const factory GetSupportChatState.loaded({required ChatDto chat}) = _GetSupportChatLoaded;
}