part of 'bloc.dart';

@freezed
class GetAllUserSubscriptionsState with _$GetAllUserSubscriptionsState {
  const factory GetAllUserSubscriptionsState.loading() = _GetUserSubscriptionsLoading;
  const factory GetAllUserSubscriptionsState.loaded({required List<UserSubscriptionDto> subscriptions}) = _GetUserSubscriptionsLoaded;
  const factory GetAllUserSubscriptionsState.error({required String errorMessage}) = _GetUserSubscriptionsError;
}