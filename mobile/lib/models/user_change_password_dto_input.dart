part of 'all_for_freezed.dart';

@freezed
class UserChangePasswordDtoInput
    with _$UserChangePasswordDtoInput, ToJsonObject {
  const factory UserChangePasswordDtoInput({
    required String password,
    required String token,
  }) = _UserChangePasswordDtoInput;

  factory UserChangePasswordDtoInput.fromJson(Map<String, dynamic> json) =>
      _$UserChangePasswordDtoInputFromJson(json);
}
