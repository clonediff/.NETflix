// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'all_for_freezed.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

_$UserDtoImpl _$$UserDtoImplFromJson(Map<String, dynamic> json) =>
    _$UserDtoImpl(
      login: json['login'] as String,
      email: json['email'] as String,
      birthdate: DateTime.parse(json['birthdate'] as String),
      enabled2FA: json['enabled2FA'] as bool,
    );

Map<String, dynamic> _$$UserDtoImplToJson(_$UserDtoImpl instance) =>
    <String, dynamic>{
      'login': instance.login,
      'email': instance.email,
      'birthdate': instance.birthdate.toIso8601String(),
      'enabled2FA': instance.enabled2FA,
    };

_$UserSubscriptionDtoImpl _$$UserSubscriptionDtoImplFromJson(
        Map<String, dynamic> json) =>
    _$UserSubscriptionDtoImpl(
      id: (json['id'] as num).toInt(),
      subscriptionName: json['subscriptionName'] as String,
      cost: (json['cost'] as num).toInt(),
      expires: json['expires'] == null
          ? null
          : DateTime.parse(json['expires'] as String),
    );

Map<String, dynamic> _$$UserSubscriptionDtoImplToJson(
        _$UserSubscriptionDtoImpl instance) =>
    <String, dynamic>{
      'id': instance.id,
      'subscriptionName': instance.subscriptionName,
      'cost': instance.cost,
      'expires': instance.expires?.toIso8601String(),
    };

_$EnableTwoFactorAuthDtoInputImpl _$$EnableTwoFactorAuthDtoInputImplFromJson(
        Map<String, dynamic> json) =>
    _$EnableTwoFactorAuthDtoInputImpl(
      token: json['token'] as String,
    );

Map<String, dynamic> _$$EnableTwoFactorAuthDtoInputImplToJson(
        _$EnableTwoFactorAuthDtoInputImpl instance) =>
    <String, dynamic>{
      'token': instance.token,
    };

_$UserChangeMailDtoInputImpl _$$UserChangeMailDtoInputImplFromJson(
        Map<String, dynamic> json) =>
    _$UserChangeMailDtoInputImpl(
      email: json['email'] as String,
      token: json['token'] as String,
    );

Map<String, dynamic> _$$UserChangeMailDtoInputImplToJson(
        _$UserChangeMailDtoInputImpl instance) =>
    <String, dynamic>{
      'email': instance.email,
      'token': instance.token,
    };

_$UserChangeOrdinaryDtoInputImpl _$$UserChangeOrdinaryDtoInputImplFromJson(
        Map<String, dynamic> json) =>
    _$UserChangeOrdinaryDtoInputImpl(
      birthdate: DateTime.parse(json['birthdate'] as String),
      userName: json['userName'] as String,
    );

Map<String, dynamic> _$$UserChangeOrdinaryDtoInputImplToJson(
        _$UserChangeOrdinaryDtoInputImpl instance) =>
    <String, dynamic>{
      'birthdate': instance.birthdate.toIso8601String(),
      'userName': instance.userName,
    };

_$UserChangePasswordDtoInputImpl _$$UserChangePasswordDtoInputImplFromJson(
        Map<String, dynamic> json) =>
    _$UserChangePasswordDtoInputImpl(
      password: json['password'] as String,
      token: json['token'] as String,
    );

Map<String, dynamic> _$$UserChangePasswordDtoInputImplToJson(
        _$UserChangePasswordDtoInputImpl instance) =>
    <String, dynamic>{
      'password': instance.password,
      'token': instance.token,
    };
