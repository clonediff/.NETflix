// coverage:ignore-file
// GENERATED CODE - DO NOT MODIFY BY HAND
// ignore_for_file: type=lint
// ignore_for_file: unused_element, deprecated_member_use, deprecated_member_use_from_same_package, use_function_type_syntax_for_parameters, unnecessary_const, avoid_init_to_null, invalid_override_different_default_values_named, prefer_expression_function_bodies, annotate_overrides, invalid_annotation_target, unnecessary_question_mark

part of 'all_for_freezed.dart';

// **************************************************************************
// FreezedGenerator
// **************************************************************************

T _$identity<T>(T value) => value;

final _privateConstructorUsedError = UnsupportedError(
    'It seems like you constructed your class using `MyClass._()`. This constructor is only meant to be used by freezed and you are not supposed to need it nor use it.\nPlease check the documentation here for more information: https://github.com/rrousselGit/freezed#adding-getters-and-methods-to-our-models');

UserDto _$UserDtoFromJson(Map<String, dynamic> json) {
  return _UserDto.fromJson(json);
}

/// @nodoc
mixin _$UserDto {
  String get login => throw _privateConstructorUsedError;
  String get email => throw _privateConstructorUsedError;
  DateTime get birthdate => throw _privateConstructorUsedError;
  bool get enabled2FA => throw _privateConstructorUsedError;

  Map<String, dynamic> toJson() => throw _privateConstructorUsedError;
  @JsonKey(ignore: true)
  $UserDtoCopyWith<UserDto> get copyWith => throw _privateConstructorUsedError;
}

/// @nodoc
abstract class $UserDtoCopyWith<$Res> {
  factory $UserDtoCopyWith(UserDto value, $Res Function(UserDto) then) =
      _$UserDtoCopyWithImpl<$Res, UserDto>;
  @useResult
  $Res call({String login, String email, DateTime birthdate, bool enabled2FA});
}

/// @nodoc
class _$UserDtoCopyWithImpl<$Res, $Val extends UserDto>
    implements $UserDtoCopyWith<$Res> {
  _$UserDtoCopyWithImpl(this._value, this._then);

  // ignore: unused_field
  final $Val _value;
  // ignore: unused_field
  final $Res Function($Val) _then;

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? login = null,
    Object? email = null,
    Object? birthdate = null,
    Object? enabled2FA = null,
  }) {
    return _then(_value.copyWith(
      login: null == login
          ? _value.login
          : login // ignore: cast_nullable_to_non_nullable
              as String,
      email: null == email
          ? _value.email
          : email // ignore: cast_nullable_to_non_nullable
              as String,
      birthdate: null == birthdate
          ? _value.birthdate
          : birthdate // ignore: cast_nullable_to_non_nullable
              as DateTime,
      enabled2FA: null == enabled2FA
          ? _value.enabled2FA
          : enabled2FA // ignore: cast_nullable_to_non_nullable
              as bool,
    ) as $Val);
  }
}

/// @nodoc
abstract class _$$UserDtoImplCopyWith<$Res> implements $UserDtoCopyWith<$Res> {
  factory _$$UserDtoImplCopyWith(
          _$UserDtoImpl value, $Res Function(_$UserDtoImpl) then) =
      __$$UserDtoImplCopyWithImpl<$Res>;
  @override
  @useResult
  $Res call({String login, String email, DateTime birthdate, bool enabled2FA});
}

/// @nodoc
class __$$UserDtoImplCopyWithImpl<$Res>
    extends _$UserDtoCopyWithImpl<$Res, _$UserDtoImpl>
    implements _$$UserDtoImplCopyWith<$Res> {
  __$$UserDtoImplCopyWithImpl(
      _$UserDtoImpl _value, $Res Function(_$UserDtoImpl) _then)
      : super(_value, _then);

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? login = null,
    Object? email = null,
    Object? birthdate = null,
    Object? enabled2FA = null,
  }) {
    return _then(_$UserDtoImpl(
      login: null == login
          ? _value.login
          : login // ignore: cast_nullable_to_non_nullable
              as String,
      email: null == email
          ? _value.email
          : email // ignore: cast_nullable_to_non_nullable
              as String,
      birthdate: null == birthdate
          ? _value.birthdate
          : birthdate // ignore: cast_nullable_to_non_nullable
              as DateTime,
      enabled2FA: null == enabled2FA
          ? _value.enabled2FA
          : enabled2FA // ignore: cast_nullable_to_non_nullable
              as bool,
    ));
  }
}

/// @nodoc
@JsonSerializable()
class _$UserDtoImpl implements _UserDto {
  const _$UserDtoImpl(
      {required this.login,
      required this.email,
      required this.birthdate,
      required this.enabled2FA});

  factory _$UserDtoImpl.fromJson(Map<String, dynamic> json) =>
      _$$UserDtoImplFromJson(json);

  @override
  final String login;
  @override
  final String email;
  @override
  final DateTime birthdate;
  @override
  final bool enabled2FA;

  @override
  String toString() {
    return 'UserDto(login: $login, email: $email, birthdate: $birthdate, enabled2FA: $enabled2FA)';
  }

  @override
  bool operator ==(Object other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is _$UserDtoImpl &&
            (identical(other.login, login) || other.login == login) &&
            (identical(other.email, email) || other.email == email) &&
            (identical(other.birthdate, birthdate) ||
                other.birthdate == birthdate) &&
            (identical(other.enabled2FA, enabled2FA) ||
                other.enabled2FA == enabled2FA));
  }

  @JsonKey(ignore: true)
  @override
  int get hashCode =>
      Object.hash(runtimeType, login, email, birthdate, enabled2FA);

  @JsonKey(ignore: true)
  @override
  @pragma('vm:prefer-inline')
  _$$UserDtoImplCopyWith<_$UserDtoImpl> get copyWith =>
      __$$UserDtoImplCopyWithImpl<_$UserDtoImpl>(this, _$identity);

  @override
  Map<String, dynamic> toJson() {
    return _$$UserDtoImplToJson(
      this,
    );
  }
}

abstract class _UserDto implements UserDto {
  const factory _UserDto(
      {required final String login,
      required final String email,
      required final DateTime birthdate,
      required final bool enabled2FA}) = _$UserDtoImpl;

  factory _UserDto.fromJson(Map<String, dynamic> json) = _$UserDtoImpl.fromJson;

  @override
  String get login;
  @override
  String get email;
  @override
  DateTime get birthdate;
  @override
  bool get enabled2FA;
  @override
  @JsonKey(ignore: true)
  _$$UserDtoImplCopyWith<_$UserDtoImpl> get copyWith =>
      throw _privateConstructorUsedError;
}

UserSubscriptionDto _$UserSubscriptionDtoFromJson(Map<String, dynamic> json) {
  return _UserSubscriptionDto.fromJson(json);
}

/// @nodoc
mixin _$UserSubscriptionDto {
  int get id => throw _privateConstructorUsedError;
  String get subscriptionName => throw _privateConstructorUsedError;
  int get cost => throw _privateConstructorUsedError;
  DateTime? get expires => throw _privateConstructorUsedError;

  Map<String, dynamic> toJson() => throw _privateConstructorUsedError;
  @JsonKey(ignore: true)
  $UserSubscriptionDtoCopyWith<UserSubscriptionDto> get copyWith =>
      throw _privateConstructorUsedError;
}

/// @nodoc
abstract class $UserSubscriptionDtoCopyWith<$Res> {
  factory $UserSubscriptionDtoCopyWith(
          UserSubscriptionDto value, $Res Function(UserSubscriptionDto) then) =
      _$UserSubscriptionDtoCopyWithImpl<$Res, UserSubscriptionDto>;
  @useResult
  $Res call({int id, String subscriptionName, int cost, DateTime? expires});
}

/// @nodoc
class _$UserSubscriptionDtoCopyWithImpl<$Res, $Val extends UserSubscriptionDto>
    implements $UserSubscriptionDtoCopyWith<$Res> {
  _$UserSubscriptionDtoCopyWithImpl(this._value, this._then);

  // ignore: unused_field
  final $Val _value;
  // ignore: unused_field
  final $Res Function($Val) _then;

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? id = null,
    Object? subscriptionName = null,
    Object? cost = null,
    Object? expires = freezed,
  }) {
    return _then(_value.copyWith(
      id: null == id
          ? _value.id
          : id // ignore: cast_nullable_to_non_nullable
              as int,
      subscriptionName: null == subscriptionName
          ? _value.subscriptionName
          : subscriptionName // ignore: cast_nullable_to_non_nullable
              as String,
      cost: null == cost
          ? _value.cost
          : cost // ignore: cast_nullable_to_non_nullable
              as int,
      expires: freezed == expires
          ? _value.expires
          : expires // ignore: cast_nullable_to_non_nullable
              as DateTime?,
    ) as $Val);
  }
}

/// @nodoc
abstract class _$$UserSubscriptionDtoImplCopyWith<$Res>
    implements $UserSubscriptionDtoCopyWith<$Res> {
  factory _$$UserSubscriptionDtoImplCopyWith(_$UserSubscriptionDtoImpl value,
          $Res Function(_$UserSubscriptionDtoImpl) then) =
      __$$UserSubscriptionDtoImplCopyWithImpl<$Res>;
  @override
  @useResult
  $Res call({int id, String subscriptionName, int cost, DateTime? expires});
}

/// @nodoc
class __$$UserSubscriptionDtoImplCopyWithImpl<$Res>
    extends _$UserSubscriptionDtoCopyWithImpl<$Res, _$UserSubscriptionDtoImpl>
    implements _$$UserSubscriptionDtoImplCopyWith<$Res> {
  __$$UserSubscriptionDtoImplCopyWithImpl(_$UserSubscriptionDtoImpl _value,
      $Res Function(_$UserSubscriptionDtoImpl) _then)
      : super(_value, _then);

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? id = null,
    Object? subscriptionName = null,
    Object? cost = null,
    Object? expires = freezed,
  }) {
    return _then(_$UserSubscriptionDtoImpl(
      id: null == id
          ? _value.id
          : id // ignore: cast_nullable_to_non_nullable
              as int,
      subscriptionName: null == subscriptionName
          ? _value.subscriptionName
          : subscriptionName // ignore: cast_nullable_to_non_nullable
              as String,
      cost: null == cost
          ? _value.cost
          : cost // ignore: cast_nullable_to_non_nullable
              as int,
      expires: freezed == expires
          ? _value.expires
          : expires // ignore: cast_nullable_to_non_nullable
              as DateTime?,
    ));
  }
}

/// @nodoc
@JsonSerializable()
class _$UserSubscriptionDtoImpl implements _UserSubscriptionDto {
  const _$UserSubscriptionDtoImpl(
      {required this.id,
      required this.subscriptionName,
      required this.cost,
      required this.expires});

  factory _$UserSubscriptionDtoImpl.fromJson(Map<String, dynamic> json) =>
      _$$UserSubscriptionDtoImplFromJson(json);

  @override
  final int id;
  @override
  final String subscriptionName;
  @override
  final int cost;
  @override
  final DateTime? expires;

  @override
  String toString() {
    return 'UserSubscriptionDto(id: $id, subscriptionName: $subscriptionName, cost: $cost, expires: $expires)';
  }

  @override
  bool operator ==(Object other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is _$UserSubscriptionDtoImpl &&
            (identical(other.id, id) || other.id == id) &&
            (identical(other.subscriptionName, subscriptionName) ||
                other.subscriptionName == subscriptionName) &&
            (identical(other.cost, cost) || other.cost == cost) &&
            (identical(other.expires, expires) || other.expires == expires));
  }

  @JsonKey(ignore: true)
  @override
  int get hashCode =>
      Object.hash(runtimeType, id, subscriptionName, cost, expires);

  @JsonKey(ignore: true)
  @override
  @pragma('vm:prefer-inline')
  _$$UserSubscriptionDtoImplCopyWith<_$UserSubscriptionDtoImpl> get copyWith =>
      __$$UserSubscriptionDtoImplCopyWithImpl<_$UserSubscriptionDtoImpl>(
          this, _$identity);

  @override
  Map<String, dynamic> toJson() {
    return _$$UserSubscriptionDtoImplToJson(
      this,
    );
  }
}

abstract class _UserSubscriptionDto implements UserSubscriptionDto {
  const factory _UserSubscriptionDto(
      {required final int id,
      required final String subscriptionName,
      required final int cost,
      required final DateTime? expires}) = _$UserSubscriptionDtoImpl;

  factory _UserSubscriptionDto.fromJson(Map<String, dynamic> json) =
      _$UserSubscriptionDtoImpl.fromJson;

  @override
  int get id;
  @override
  String get subscriptionName;
  @override
  int get cost;
  @override
  DateTime? get expires;
  @override
  @JsonKey(ignore: true)
  _$$UserSubscriptionDtoImplCopyWith<_$UserSubscriptionDtoImpl> get copyWith =>
      throw _privateConstructorUsedError;
}

EnableTwoFactorAuthDtoInput _$EnableTwoFactorAuthDtoInputFromJson(
    Map<String, dynamic> json) {
  return _EnableTwoFactorAuthDtoInput.fromJson(json);
}

/// @nodoc
mixin _$EnableTwoFactorAuthDtoInput {
  String get token => throw _privateConstructorUsedError;

  Map<String, dynamic> toJson() => throw _privateConstructorUsedError;
  @JsonKey(ignore: true)
  $EnableTwoFactorAuthDtoInputCopyWith<EnableTwoFactorAuthDtoInput>
      get copyWith => throw _privateConstructorUsedError;
}

/// @nodoc
abstract class $EnableTwoFactorAuthDtoInputCopyWith<$Res> {
  factory $EnableTwoFactorAuthDtoInputCopyWith(
          EnableTwoFactorAuthDtoInput value,
          $Res Function(EnableTwoFactorAuthDtoInput) then) =
      _$EnableTwoFactorAuthDtoInputCopyWithImpl<$Res,
          EnableTwoFactorAuthDtoInput>;
  @useResult
  $Res call({String token});
}

/// @nodoc
class _$EnableTwoFactorAuthDtoInputCopyWithImpl<$Res,
        $Val extends EnableTwoFactorAuthDtoInput>
    implements $EnableTwoFactorAuthDtoInputCopyWith<$Res> {
  _$EnableTwoFactorAuthDtoInputCopyWithImpl(this._value, this._then);

  // ignore: unused_field
  final $Val _value;
  // ignore: unused_field
  final $Res Function($Val) _then;

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? token = null,
  }) {
    return _then(_value.copyWith(
      token: null == token
          ? _value.token
          : token // ignore: cast_nullable_to_non_nullable
              as String,
    ) as $Val);
  }
}

/// @nodoc
abstract class _$$EnableTwoFactorAuthDtoInputImplCopyWith<$Res>
    implements $EnableTwoFactorAuthDtoInputCopyWith<$Res> {
  factory _$$EnableTwoFactorAuthDtoInputImplCopyWith(
          _$EnableTwoFactorAuthDtoInputImpl value,
          $Res Function(_$EnableTwoFactorAuthDtoInputImpl) then) =
      __$$EnableTwoFactorAuthDtoInputImplCopyWithImpl<$Res>;
  @override
  @useResult
  $Res call({String token});
}

/// @nodoc
class __$$EnableTwoFactorAuthDtoInputImplCopyWithImpl<$Res>
    extends _$EnableTwoFactorAuthDtoInputCopyWithImpl<$Res,
        _$EnableTwoFactorAuthDtoInputImpl>
    implements _$$EnableTwoFactorAuthDtoInputImplCopyWith<$Res> {
  __$$EnableTwoFactorAuthDtoInputImplCopyWithImpl(
      _$EnableTwoFactorAuthDtoInputImpl _value,
      $Res Function(_$EnableTwoFactorAuthDtoInputImpl) _then)
      : super(_value, _then);

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? token = null,
  }) {
    return _then(_$EnableTwoFactorAuthDtoInputImpl(
      token: null == token
          ? _value.token
          : token // ignore: cast_nullable_to_non_nullable
              as String,
    ));
  }
}

/// @nodoc
@JsonSerializable()
class _$EnableTwoFactorAuthDtoInputImpl
    implements _EnableTwoFactorAuthDtoInput {
  const _$EnableTwoFactorAuthDtoInputImpl({required this.token});

  factory _$EnableTwoFactorAuthDtoInputImpl.fromJson(
          Map<String, dynamic> json) =>
      _$$EnableTwoFactorAuthDtoInputImplFromJson(json);

  @override
  final String token;

  @override
  String toString() {
    return 'EnableTwoFactorAuthDtoInput(token: $token)';
  }

  @override
  bool operator ==(Object other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is _$EnableTwoFactorAuthDtoInputImpl &&
            (identical(other.token, token) || other.token == token));
  }

  @JsonKey(ignore: true)
  @override
  int get hashCode => Object.hash(runtimeType, token);

  @JsonKey(ignore: true)
  @override
  @pragma('vm:prefer-inline')
  _$$EnableTwoFactorAuthDtoInputImplCopyWith<_$EnableTwoFactorAuthDtoInputImpl>
      get copyWith => __$$EnableTwoFactorAuthDtoInputImplCopyWithImpl<
          _$EnableTwoFactorAuthDtoInputImpl>(this, _$identity);

  @override
  Map<String, dynamic> toJson() {
    return _$$EnableTwoFactorAuthDtoInputImplToJson(
      this,
    );
  }
}

abstract class _EnableTwoFactorAuthDtoInput
    implements EnableTwoFactorAuthDtoInput {
  const factory _EnableTwoFactorAuthDtoInput({required final String token}) =
      _$EnableTwoFactorAuthDtoInputImpl;

  factory _EnableTwoFactorAuthDtoInput.fromJson(Map<String, dynamic> json) =
      _$EnableTwoFactorAuthDtoInputImpl.fromJson;

  @override
  String get token;
  @override
  @JsonKey(ignore: true)
  _$$EnableTwoFactorAuthDtoInputImplCopyWith<_$EnableTwoFactorAuthDtoInputImpl>
      get copyWith => throw _privateConstructorUsedError;
}

UserChangeMailDtoInput _$UserChangeMailDtoInputFromJson(
    Map<String, dynamic> json) {
  return _UserChangeMailDtoInput.fromJson(json);
}

/// @nodoc
mixin _$UserChangeMailDtoInput {
  String get email => throw _privateConstructorUsedError;
  String get token => throw _privateConstructorUsedError;

  Map<String, dynamic> toJson() => throw _privateConstructorUsedError;
  @JsonKey(ignore: true)
  $UserChangeMailDtoInputCopyWith<UserChangeMailDtoInput> get copyWith =>
      throw _privateConstructorUsedError;
}

/// @nodoc
abstract class $UserChangeMailDtoInputCopyWith<$Res> {
  factory $UserChangeMailDtoInputCopyWith(UserChangeMailDtoInput value,
          $Res Function(UserChangeMailDtoInput) then) =
      _$UserChangeMailDtoInputCopyWithImpl<$Res, UserChangeMailDtoInput>;
  @useResult
  $Res call({String email, String token});
}

/// @nodoc
class _$UserChangeMailDtoInputCopyWithImpl<$Res,
        $Val extends UserChangeMailDtoInput>
    implements $UserChangeMailDtoInputCopyWith<$Res> {
  _$UserChangeMailDtoInputCopyWithImpl(this._value, this._then);

  // ignore: unused_field
  final $Val _value;
  // ignore: unused_field
  final $Res Function($Val) _then;

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? email = null,
    Object? token = null,
  }) {
    return _then(_value.copyWith(
      email: null == email
          ? _value.email
          : email // ignore: cast_nullable_to_non_nullable
              as String,
      token: null == token
          ? _value.token
          : token // ignore: cast_nullable_to_non_nullable
              as String,
    ) as $Val);
  }
}

/// @nodoc
abstract class _$$UserChangeMailDtoInputImplCopyWith<$Res>
    implements $UserChangeMailDtoInputCopyWith<$Res> {
  factory _$$UserChangeMailDtoInputImplCopyWith(
          _$UserChangeMailDtoInputImpl value,
          $Res Function(_$UserChangeMailDtoInputImpl) then) =
      __$$UserChangeMailDtoInputImplCopyWithImpl<$Res>;
  @override
  @useResult
  $Res call({String email, String token});
}

/// @nodoc
class __$$UserChangeMailDtoInputImplCopyWithImpl<$Res>
    extends _$UserChangeMailDtoInputCopyWithImpl<$Res,
        _$UserChangeMailDtoInputImpl>
    implements _$$UserChangeMailDtoInputImplCopyWith<$Res> {
  __$$UserChangeMailDtoInputImplCopyWithImpl(
      _$UserChangeMailDtoInputImpl _value,
      $Res Function(_$UserChangeMailDtoInputImpl) _then)
      : super(_value, _then);

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? email = null,
    Object? token = null,
  }) {
    return _then(_$UserChangeMailDtoInputImpl(
      email: null == email
          ? _value.email
          : email // ignore: cast_nullable_to_non_nullable
              as String,
      token: null == token
          ? _value.token
          : token // ignore: cast_nullable_to_non_nullable
              as String,
    ));
  }
}

/// @nodoc
@JsonSerializable()
class _$UserChangeMailDtoInputImpl implements _UserChangeMailDtoInput {
  const _$UserChangeMailDtoInputImpl(
      {required this.email, required this.token});

  factory _$UserChangeMailDtoInputImpl.fromJson(Map<String, dynamic> json) =>
      _$$UserChangeMailDtoInputImplFromJson(json);

  @override
  final String email;
  @override
  final String token;

  @override
  String toString() {
    return 'UserChangeMailDtoInput(email: $email, token: $token)';
  }

  @override
  bool operator ==(Object other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is _$UserChangeMailDtoInputImpl &&
            (identical(other.email, email) || other.email == email) &&
            (identical(other.token, token) || other.token == token));
  }

  @JsonKey(ignore: true)
  @override
  int get hashCode => Object.hash(runtimeType, email, token);

  @JsonKey(ignore: true)
  @override
  @pragma('vm:prefer-inline')
  _$$UserChangeMailDtoInputImplCopyWith<_$UserChangeMailDtoInputImpl>
      get copyWith => __$$UserChangeMailDtoInputImplCopyWithImpl<
          _$UserChangeMailDtoInputImpl>(this, _$identity);

  @override
  Map<String, dynamic> toJson() {
    return _$$UserChangeMailDtoInputImplToJson(
      this,
    );
  }
}

abstract class _UserChangeMailDtoInput implements UserChangeMailDtoInput {
  const factory _UserChangeMailDtoInput(
      {required final String email,
      required final String token}) = _$UserChangeMailDtoInputImpl;

  factory _UserChangeMailDtoInput.fromJson(Map<String, dynamic> json) =
      _$UserChangeMailDtoInputImpl.fromJson;

  @override
  String get email;
  @override
  String get token;
  @override
  @JsonKey(ignore: true)
  _$$UserChangeMailDtoInputImplCopyWith<_$UserChangeMailDtoInputImpl>
      get copyWith => throw _privateConstructorUsedError;
}

UserChangeOrdinaryDtoInput _$UserChangeOrdinaryDtoInputFromJson(
    Map<String, dynamic> json) {
  return _UserChangeOrdinaryDtoInput.fromJson(json);
}

/// @nodoc
mixin _$UserChangeOrdinaryDtoInput {
  DateTime get birthdate => throw _privateConstructorUsedError;
  String get userName => throw _privateConstructorUsedError;

  Map<String, dynamic> toJson() => throw _privateConstructorUsedError;
  @JsonKey(ignore: true)
  $UserChangeOrdinaryDtoInputCopyWith<UserChangeOrdinaryDtoInput>
      get copyWith => throw _privateConstructorUsedError;
}

/// @nodoc
abstract class $UserChangeOrdinaryDtoInputCopyWith<$Res> {
  factory $UserChangeOrdinaryDtoInputCopyWith(UserChangeOrdinaryDtoInput value,
          $Res Function(UserChangeOrdinaryDtoInput) then) =
      _$UserChangeOrdinaryDtoInputCopyWithImpl<$Res,
          UserChangeOrdinaryDtoInput>;
  @useResult
  $Res call({DateTime birthdate, String userName});
}

/// @nodoc
class _$UserChangeOrdinaryDtoInputCopyWithImpl<$Res,
        $Val extends UserChangeOrdinaryDtoInput>
    implements $UserChangeOrdinaryDtoInputCopyWith<$Res> {
  _$UserChangeOrdinaryDtoInputCopyWithImpl(this._value, this._then);

  // ignore: unused_field
  final $Val _value;
  // ignore: unused_field
  final $Res Function($Val) _then;

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? birthdate = null,
    Object? userName = null,
  }) {
    return _then(_value.copyWith(
      birthdate: null == birthdate
          ? _value.birthdate
          : birthdate // ignore: cast_nullable_to_non_nullable
              as DateTime,
      userName: null == userName
          ? _value.userName
          : userName // ignore: cast_nullable_to_non_nullable
              as String,
    ) as $Val);
  }
}

/// @nodoc
abstract class _$$UserChangeOrdinaryDtoInputImplCopyWith<$Res>
    implements $UserChangeOrdinaryDtoInputCopyWith<$Res> {
  factory _$$UserChangeOrdinaryDtoInputImplCopyWith(
          _$UserChangeOrdinaryDtoInputImpl value,
          $Res Function(_$UserChangeOrdinaryDtoInputImpl) then) =
      __$$UserChangeOrdinaryDtoInputImplCopyWithImpl<$Res>;
  @override
  @useResult
  $Res call({DateTime birthdate, String userName});
}

/// @nodoc
class __$$UserChangeOrdinaryDtoInputImplCopyWithImpl<$Res>
    extends _$UserChangeOrdinaryDtoInputCopyWithImpl<$Res,
        _$UserChangeOrdinaryDtoInputImpl>
    implements _$$UserChangeOrdinaryDtoInputImplCopyWith<$Res> {
  __$$UserChangeOrdinaryDtoInputImplCopyWithImpl(
      _$UserChangeOrdinaryDtoInputImpl _value,
      $Res Function(_$UserChangeOrdinaryDtoInputImpl) _then)
      : super(_value, _then);

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? birthdate = null,
    Object? userName = null,
  }) {
    return _then(_$UserChangeOrdinaryDtoInputImpl(
      birthdate: null == birthdate
          ? _value.birthdate
          : birthdate // ignore: cast_nullable_to_non_nullable
              as DateTime,
      userName: null == userName
          ? _value.userName
          : userName // ignore: cast_nullable_to_non_nullable
              as String,
    ));
  }
}

/// @nodoc
@JsonSerializable()
class _$UserChangeOrdinaryDtoInputImpl implements _UserChangeOrdinaryDtoInput {
  const _$UserChangeOrdinaryDtoInputImpl(
      {required this.birthdate, required this.userName});

  factory _$UserChangeOrdinaryDtoInputImpl.fromJson(
          Map<String, dynamic> json) =>
      _$$UserChangeOrdinaryDtoInputImplFromJson(json);

  @override
  final DateTime birthdate;
  @override
  final String userName;

  @override
  String toString() {
    return 'UserChangeOrdinaryDtoInput(birthdate: $birthdate, userName: $userName)';
  }

  @override
  bool operator ==(Object other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is _$UserChangeOrdinaryDtoInputImpl &&
            (identical(other.birthdate, birthdate) ||
                other.birthdate == birthdate) &&
            (identical(other.userName, userName) ||
                other.userName == userName));
  }

  @JsonKey(ignore: true)
  @override
  int get hashCode => Object.hash(runtimeType, birthdate, userName);

  @JsonKey(ignore: true)
  @override
  @pragma('vm:prefer-inline')
  _$$UserChangeOrdinaryDtoInputImplCopyWith<_$UserChangeOrdinaryDtoInputImpl>
      get copyWith => __$$UserChangeOrdinaryDtoInputImplCopyWithImpl<
          _$UserChangeOrdinaryDtoInputImpl>(this, _$identity);

  @override
  Map<String, dynamic> toJson() {
    return _$$UserChangeOrdinaryDtoInputImplToJson(
      this,
    );
  }
}

abstract class _UserChangeOrdinaryDtoInput
    implements UserChangeOrdinaryDtoInput {
  const factory _UserChangeOrdinaryDtoInput(
      {required final DateTime birthdate,
      required final String userName}) = _$UserChangeOrdinaryDtoInputImpl;

  factory _UserChangeOrdinaryDtoInput.fromJson(Map<String, dynamic> json) =
      _$UserChangeOrdinaryDtoInputImpl.fromJson;

  @override
  DateTime get birthdate;
  @override
  String get userName;
  @override
  @JsonKey(ignore: true)
  _$$UserChangeOrdinaryDtoInputImplCopyWith<_$UserChangeOrdinaryDtoInputImpl>
      get copyWith => throw _privateConstructorUsedError;
}

UserChangePasswordDtoInput _$UserChangePasswordDtoInputFromJson(
    Map<String, dynamic> json) {
  return _UserChangePasswordDtoInput.fromJson(json);
}

/// @nodoc
mixin _$UserChangePasswordDtoInput {
  String get password => throw _privateConstructorUsedError;
  String get token => throw _privateConstructorUsedError;

  Map<String, dynamic> toJson() => throw _privateConstructorUsedError;
  @JsonKey(ignore: true)
  $UserChangePasswordDtoInputCopyWith<UserChangePasswordDtoInput>
      get copyWith => throw _privateConstructorUsedError;
}

/// @nodoc
abstract class $UserChangePasswordDtoInputCopyWith<$Res> {
  factory $UserChangePasswordDtoInputCopyWith(UserChangePasswordDtoInput value,
          $Res Function(UserChangePasswordDtoInput) then) =
      _$UserChangePasswordDtoInputCopyWithImpl<$Res,
          UserChangePasswordDtoInput>;
  @useResult
  $Res call({String password, String token});
}

/// @nodoc
class _$UserChangePasswordDtoInputCopyWithImpl<$Res,
        $Val extends UserChangePasswordDtoInput>
    implements $UserChangePasswordDtoInputCopyWith<$Res> {
  _$UserChangePasswordDtoInputCopyWithImpl(this._value, this._then);

  // ignore: unused_field
  final $Val _value;
  // ignore: unused_field
  final $Res Function($Val) _then;

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? password = null,
    Object? token = null,
  }) {
    return _then(_value.copyWith(
      password: null == password
          ? _value.password
          : password // ignore: cast_nullable_to_non_nullable
              as String,
      token: null == token
          ? _value.token
          : token // ignore: cast_nullable_to_non_nullable
              as String,
    ) as $Val);
  }
}

/// @nodoc
abstract class _$$UserChangePasswordDtoInputImplCopyWith<$Res>
    implements $UserChangePasswordDtoInputCopyWith<$Res> {
  factory _$$UserChangePasswordDtoInputImplCopyWith(
          _$UserChangePasswordDtoInputImpl value,
          $Res Function(_$UserChangePasswordDtoInputImpl) then) =
      __$$UserChangePasswordDtoInputImplCopyWithImpl<$Res>;
  @override
  @useResult
  $Res call({String password, String token});
}

/// @nodoc
class __$$UserChangePasswordDtoInputImplCopyWithImpl<$Res>
    extends _$UserChangePasswordDtoInputCopyWithImpl<$Res,
        _$UserChangePasswordDtoInputImpl>
    implements _$$UserChangePasswordDtoInputImplCopyWith<$Res> {
  __$$UserChangePasswordDtoInputImplCopyWithImpl(
      _$UserChangePasswordDtoInputImpl _value,
      $Res Function(_$UserChangePasswordDtoInputImpl) _then)
      : super(_value, _then);

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? password = null,
    Object? token = null,
  }) {
    return _then(_$UserChangePasswordDtoInputImpl(
      password: null == password
          ? _value.password
          : password // ignore: cast_nullable_to_non_nullable
              as String,
      token: null == token
          ? _value.token
          : token // ignore: cast_nullable_to_non_nullable
              as String,
    ));
  }
}

/// @nodoc
@JsonSerializable()
class _$UserChangePasswordDtoInputImpl implements _UserChangePasswordDtoInput {
  const _$UserChangePasswordDtoInputImpl(
      {required this.password, required this.token});

  factory _$UserChangePasswordDtoInputImpl.fromJson(
          Map<String, dynamic> json) =>
      _$$UserChangePasswordDtoInputImplFromJson(json);

  @override
  final String password;
  @override
  final String token;

  @override
  String toString() {
    return 'UserChangePasswordDtoInput(password: $password, token: $token)';
  }

  @override
  bool operator ==(Object other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is _$UserChangePasswordDtoInputImpl &&
            (identical(other.password, password) ||
                other.password == password) &&
            (identical(other.token, token) || other.token == token));
  }

  @JsonKey(ignore: true)
  @override
  int get hashCode => Object.hash(runtimeType, password, token);

  @JsonKey(ignore: true)
  @override
  @pragma('vm:prefer-inline')
  _$$UserChangePasswordDtoInputImplCopyWith<_$UserChangePasswordDtoInputImpl>
      get copyWith => __$$UserChangePasswordDtoInputImplCopyWithImpl<
          _$UserChangePasswordDtoInputImpl>(this, _$identity);

  @override
  Map<String, dynamic> toJson() {
    return _$$UserChangePasswordDtoInputImplToJson(
      this,
    );
  }
}

abstract class _UserChangePasswordDtoInput
    implements UserChangePasswordDtoInput {
  const factory _UserChangePasswordDtoInput(
      {required final String password,
      required final String token}) = _$UserChangePasswordDtoInputImpl;

  factory _UserChangePasswordDtoInput.fromJson(Map<String, dynamic> json) =
      _$UserChangePasswordDtoInputImpl.fromJson;

  @override
  String get password;
  @override
  String get token;
  @override
  @JsonKey(ignore: true)
  _$$UserChangePasswordDtoInputImplCopyWith<_$UserChangePasswordDtoInputImpl>
      get copyWith => throw _privateConstructorUsedError;
}
