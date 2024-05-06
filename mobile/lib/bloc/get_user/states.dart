part of 'bloc.dart';

@freezed
class GetUserState with _$GetUserState {
  const factory GetUserState.loading() = _GetUserLoading;
  const factory GetUserState.loaded({required UserDto user}) = _GetUserLoaded;
  const factory GetUserState.error({required String errorMessage}) = _GetUserError;
}