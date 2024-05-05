part of 'all_for_freezed.dart';

@freezed
class UserDto with _$UserDto {
  const factory UserDto({
    required String login,
    required String email,
    required DateTime birthdate,
    required bool enabled2FA,
  }) = _UserDto;

  factory UserDto.fromJson(Map<String, dynamic> json) =>
      _$UserDtoFromJson(json);
}
