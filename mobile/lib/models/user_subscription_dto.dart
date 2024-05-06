part of 'all_for_freezed.dart';

@freezed
class UserSubscriptionDto with _$UserSubscriptionDto {
  const factory UserSubscriptionDto({
    required int id,
    required String subscriptionName,
    required int cost,
    required DateTime? expires,
  }) = _UserSubscriptionDto;

  factory UserSubscriptionDto.fromJson(Map<String, dynamic> json) => _$UserSubscriptionDtoFromJson(json);
}