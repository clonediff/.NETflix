part of 'all_for_freezed.dart';

@freezed
class EnableTwoFactorAuthDtoInput with _$EnableTwoFactorAuthDtoInput, ToJsonObject {
  const factory EnableTwoFactorAuthDtoInput({
    required String token,
  }) = _EnableTwoFactorAuthDtoInput;

  factory EnableTwoFactorAuthDtoInput.fromJson(Map<String, dynamic> json) => _$EnableTwoFactorAuthDtoInputFromJson(json);
}
