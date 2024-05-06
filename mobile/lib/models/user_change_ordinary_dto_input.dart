part of 'all_for_freezed.dart';

@freezed
class UserChangeOrdinaryDtoInput
    with _$UserChangeOrdinaryDtoInput, ToJsonObject {
  const factory UserChangeOrdinaryDtoInput({
    required DateTime birthdate,
    required String userName,
  }) = _UserChangeOrdinaryDtoInput;

  factory UserChangeOrdinaryDtoInput.fromJson(Map<String, dynamic> json) =>
      _$UserChangeOrdinaryDtoInputFromJson(json);
}
