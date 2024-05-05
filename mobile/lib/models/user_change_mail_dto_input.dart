part of 'all_for_freezed.dart';

@freezed
class UserChangeMailDtoInput with _$UserChangeMailDtoInput, ToJsonObject{
  const factory UserChangeMailDtoInput({
    required String email,
    required String token,
  }) = _UserChangeMailDtoInput;

  factory UserChangeMailDtoInput.fromJson(Map<String, dynamic> json) => _$UserChangeMailDtoInputFromJson(json);
}
