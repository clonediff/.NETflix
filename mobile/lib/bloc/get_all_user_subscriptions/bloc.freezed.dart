// coverage:ignore-file
// GENERATED CODE - DO NOT MODIFY BY HAND
// ignore_for_file: type=lint
// ignore_for_file: unused_element, deprecated_member_use, deprecated_member_use_from_same_package, use_function_type_syntax_for_parameters, unnecessary_const, avoid_init_to_null, invalid_override_different_default_values_named, prefer_expression_function_bodies, annotate_overrides, invalid_annotation_target, unnecessary_question_mark

part of 'bloc.dart';

// **************************************************************************
// FreezedGenerator
// **************************************************************************

T _$identity<T>(T value) => value;

final _privateConstructorUsedError = UnsupportedError(
    'It seems like you constructed your class using `MyClass._()`. This constructor is only meant to be used by freezed and you are not supposed to need it nor use it.\nPlease check the documentation here for more information: https://github.com/rrousselGit/freezed#adding-getters-and-methods-to-our-models');

/// @nodoc
mixin _$GetAllUserSubscriptionsEvent {
  @optionalTypeArgs
  TResult when<TResult extends Object?>({
    required TResult Function() getAllUserSubscriptionsInfo,
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult? whenOrNull<TResult extends Object?>({
    TResult? Function()? getAllUserSubscriptionsInfo,
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult maybeWhen<TResult extends Object?>({
    TResult Function()? getAllUserSubscriptionsInfo,
    required TResult orElse(),
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult map<TResult extends Object?>({
    required TResult Function(_GetAllUserSubscriptionsEvent value)
        getAllUserSubscriptionsInfo,
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult? mapOrNull<TResult extends Object?>({
    TResult? Function(_GetAllUserSubscriptionsEvent value)?
        getAllUserSubscriptionsInfo,
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult maybeMap<TResult extends Object?>({
    TResult Function(_GetAllUserSubscriptionsEvent value)?
        getAllUserSubscriptionsInfo,
    required TResult orElse(),
  }) =>
      throw _privateConstructorUsedError;
}

/// @nodoc
abstract class $GetAllUserSubscriptionsEventCopyWith<$Res> {
  factory $GetAllUserSubscriptionsEventCopyWith(
          GetAllUserSubscriptionsEvent value,
          $Res Function(GetAllUserSubscriptionsEvent) then) =
      _$GetAllUserSubscriptionsEventCopyWithImpl<$Res,
          GetAllUserSubscriptionsEvent>;
}

/// @nodoc
class _$GetAllUserSubscriptionsEventCopyWithImpl<$Res,
        $Val extends GetAllUserSubscriptionsEvent>
    implements $GetAllUserSubscriptionsEventCopyWith<$Res> {
  _$GetAllUserSubscriptionsEventCopyWithImpl(this._value, this._then);

  // ignore: unused_field
  final $Val _value;
  // ignore: unused_field
  final $Res Function($Val) _then;
}

/// @nodoc
abstract class _$$GetAllUserSubscriptionsEventImplCopyWith<$Res> {
  factory _$$GetAllUserSubscriptionsEventImplCopyWith(
          _$GetAllUserSubscriptionsEventImpl value,
          $Res Function(_$GetAllUserSubscriptionsEventImpl) then) =
      __$$GetAllUserSubscriptionsEventImplCopyWithImpl<$Res>;
}

/// @nodoc
class __$$GetAllUserSubscriptionsEventImplCopyWithImpl<$Res>
    extends _$GetAllUserSubscriptionsEventCopyWithImpl<$Res,
        _$GetAllUserSubscriptionsEventImpl>
    implements _$$GetAllUserSubscriptionsEventImplCopyWith<$Res> {
  __$$GetAllUserSubscriptionsEventImplCopyWithImpl(
      _$GetAllUserSubscriptionsEventImpl _value,
      $Res Function(_$GetAllUserSubscriptionsEventImpl) _then)
      : super(_value, _then);
}

/// @nodoc

class _$GetAllUserSubscriptionsEventImpl
    implements _GetAllUserSubscriptionsEvent {
  const _$GetAllUserSubscriptionsEventImpl();

  @override
  String toString() {
    return 'GetAllUserSubscriptionsEvent.getAllUserSubscriptionsInfo()';
  }

  @override
  bool operator ==(Object other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is _$GetAllUserSubscriptionsEventImpl);
  }

  @override
  int get hashCode => runtimeType.hashCode;

  @override
  @optionalTypeArgs
  TResult when<TResult extends Object?>({
    required TResult Function() getAllUserSubscriptionsInfo,
  }) {
    return getAllUserSubscriptionsInfo();
  }

  @override
  @optionalTypeArgs
  TResult? whenOrNull<TResult extends Object?>({
    TResult? Function()? getAllUserSubscriptionsInfo,
  }) {
    return getAllUserSubscriptionsInfo?.call();
  }

  @override
  @optionalTypeArgs
  TResult maybeWhen<TResult extends Object?>({
    TResult Function()? getAllUserSubscriptionsInfo,
    required TResult orElse(),
  }) {
    if (getAllUserSubscriptionsInfo != null) {
      return getAllUserSubscriptionsInfo();
    }
    return orElse();
  }

  @override
  @optionalTypeArgs
  TResult map<TResult extends Object?>({
    required TResult Function(_GetAllUserSubscriptionsEvent value)
        getAllUserSubscriptionsInfo,
  }) {
    return getAllUserSubscriptionsInfo(this);
  }

  @override
  @optionalTypeArgs
  TResult? mapOrNull<TResult extends Object?>({
    TResult? Function(_GetAllUserSubscriptionsEvent value)?
        getAllUserSubscriptionsInfo,
  }) {
    return getAllUserSubscriptionsInfo?.call(this);
  }

  @override
  @optionalTypeArgs
  TResult maybeMap<TResult extends Object?>({
    TResult Function(_GetAllUserSubscriptionsEvent value)?
        getAllUserSubscriptionsInfo,
    required TResult orElse(),
  }) {
    if (getAllUserSubscriptionsInfo != null) {
      return getAllUserSubscriptionsInfo(this);
    }
    return orElse();
  }
}

abstract class _GetAllUserSubscriptionsEvent
    implements GetAllUserSubscriptionsEvent {
  const factory _GetAllUserSubscriptionsEvent() =
      _$GetAllUserSubscriptionsEventImpl;
}

/// @nodoc
mixin _$GetAllUserSubscriptionsState {
  @optionalTypeArgs
  TResult when<TResult extends Object?>({
    required TResult Function() loading,
    required TResult Function(List<UserSubscriptionDto> subscriptions) loaded,
    required TResult Function(String errorMessage) error,
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult? whenOrNull<TResult extends Object?>({
    TResult? Function()? loading,
    TResult? Function(List<UserSubscriptionDto> subscriptions)? loaded,
    TResult? Function(String errorMessage)? error,
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult maybeWhen<TResult extends Object?>({
    TResult Function()? loading,
    TResult Function(List<UserSubscriptionDto> subscriptions)? loaded,
    TResult Function(String errorMessage)? error,
    required TResult orElse(),
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult map<TResult extends Object?>({
    required TResult Function(_GetUserSubscriptionsLoading value) loading,
    required TResult Function(_GetUserSubscriptionsLoaded value) loaded,
    required TResult Function(_GetUserSubscriptionsError value) error,
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult? mapOrNull<TResult extends Object?>({
    TResult? Function(_GetUserSubscriptionsLoading value)? loading,
    TResult? Function(_GetUserSubscriptionsLoaded value)? loaded,
    TResult? Function(_GetUserSubscriptionsError value)? error,
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult maybeMap<TResult extends Object?>({
    TResult Function(_GetUserSubscriptionsLoading value)? loading,
    TResult Function(_GetUserSubscriptionsLoaded value)? loaded,
    TResult Function(_GetUserSubscriptionsError value)? error,
    required TResult orElse(),
  }) =>
      throw _privateConstructorUsedError;
}

/// @nodoc
abstract class $GetAllUserSubscriptionsStateCopyWith<$Res> {
  factory $GetAllUserSubscriptionsStateCopyWith(
          GetAllUserSubscriptionsState value,
          $Res Function(GetAllUserSubscriptionsState) then) =
      _$GetAllUserSubscriptionsStateCopyWithImpl<$Res,
          GetAllUserSubscriptionsState>;
}

/// @nodoc
class _$GetAllUserSubscriptionsStateCopyWithImpl<$Res,
        $Val extends GetAllUserSubscriptionsState>
    implements $GetAllUserSubscriptionsStateCopyWith<$Res> {
  _$GetAllUserSubscriptionsStateCopyWithImpl(this._value, this._then);

  // ignore: unused_field
  final $Val _value;
  // ignore: unused_field
  final $Res Function($Val) _then;
}

/// @nodoc
abstract class _$$GetUserSubscriptionsLoadingImplCopyWith<$Res> {
  factory _$$GetUserSubscriptionsLoadingImplCopyWith(
          _$GetUserSubscriptionsLoadingImpl value,
          $Res Function(_$GetUserSubscriptionsLoadingImpl) then) =
      __$$GetUserSubscriptionsLoadingImplCopyWithImpl<$Res>;
}

/// @nodoc
class __$$GetUserSubscriptionsLoadingImplCopyWithImpl<$Res>
    extends _$GetAllUserSubscriptionsStateCopyWithImpl<$Res,
        _$GetUserSubscriptionsLoadingImpl>
    implements _$$GetUserSubscriptionsLoadingImplCopyWith<$Res> {
  __$$GetUserSubscriptionsLoadingImplCopyWithImpl(
      _$GetUserSubscriptionsLoadingImpl _value,
      $Res Function(_$GetUserSubscriptionsLoadingImpl) _then)
      : super(_value, _then);
}

/// @nodoc

class _$GetUserSubscriptionsLoadingImpl
    implements _GetUserSubscriptionsLoading {
  const _$GetUserSubscriptionsLoadingImpl();

  @override
  String toString() {
    return 'GetAllUserSubscriptionsState.loading()';
  }

  @override
  bool operator ==(Object other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is _$GetUserSubscriptionsLoadingImpl);
  }

  @override
  int get hashCode => runtimeType.hashCode;

  @override
  @optionalTypeArgs
  TResult when<TResult extends Object?>({
    required TResult Function() loading,
    required TResult Function(List<UserSubscriptionDto> subscriptions) loaded,
    required TResult Function(String errorMessage) error,
  }) {
    return loading();
  }

  @override
  @optionalTypeArgs
  TResult? whenOrNull<TResult extends Object?>({
    TResult? Function()? loading,
    TResult? Function(List<UserSubscriptionDto> subscriptions)? loaded,
    TResult? Function(String errorMessage)? error,
  }) {
    return loading?.call();
  }

  @override
  @optionalTypeArgs
  TResult maybeWhen<TResult extends Object?>({
    TResult Function()? loading,
    TResult Function(List<UserSubscriptionDto> subscriptions)? loaded,
    TResult Function(String errorMessage)? error,
    required TResult orElse(),
  }) {
    if (loading != null) {
      return loading();
    }
    return orElse();
  }

  @override
  @optionalTypeArgs
  TResult map<TResult extends Object?>({
    required TResult Function(_GetUserSubscriptionsLoading value) loading,
    required TResult Function(_GetUserSubscriptionsLoaded value) loaded,
    required TResult Function(_GetUserSubscriptionsError value) error,
  }) {
    return loading(this);
  }

  @override
  @optionalTypeArgs
  TResult? mapOrNull<TResult extends Object?>({
    TResult? Function(_GetUserSubscriptionsLoading value)? loading,
    TResult? Function(_GetUserSubscriptionsLoaded value)? loaded,
    TResult? Function(_GetUserSubscriptionsError value)? error,
  }) {
    return loading?.call(this);
  }

  @override
  @optionalTypeArgs
  TResult maybeMap<TResult extends Object?>({
    TResult Function(_GetUserSubscriptionsLoading value)? loading,
    TResult Function(_GetUserSubscriptionsLoaded value)? loaded,
    TResult Function(_GetUserSubscriptionsError value)? error,
    required TResult orElse(),
  }) {
    if (loading != null) {
      return loading(this);
    }
    return orElse();
  }
}

abstract class _GetUserSubscriptionsLoading
    implements GetAllUserSubscriptionsState {
  const factory _GetUserSubscriptionsLoading() =
      _$GetUserSubscriptionsLoadingImpl;
}

/// @nodoc
abstract class _$$GetUserSubscriptionsLoadedImplCopyWith<$Res> {
  factory _$$GetUserSubscriptionsLoadedImplCopyWith(
          _$GetUserSubscriptionsLoadedImpl value,
          $Res Function(_$GetUserSubscriptionsLoadedImpl) then) =
      __$$GetUserSubscriptionsLoadedImplCopyWithImpl<$Res>;
  @useResult
  $Res call({List<UserSubscriptionDto> subscriptions});
}

/// @nodoc
class __$$GetUserSubscriptionsLoadedImplCopyWithImpl<$Res>
    extends _$GetAllUserSubscriptionsStateCopyWithImpl<$Res,
        _$GetUserSubscriptionsLoadedImpl>
    implements _$$GetUserSubscriptionsLoadedImplCopyWith<$Res> {
  __$$GetUserSubscriptionsLoadedImplCopyWithImpl(
      _$GetUserSubscriptionsLoadedImpl _value,
      $Res Function(_$GetUserSubscriptionsLoadedImpl) _then)
      : super(_value, _then);

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? subscriptions = null,
  }) {
    return _then(_$GetUserSubscriptionsLoadedImpl(
      subscriptions: null == subscriptions
          ? _value._subscriptions
          : subscriptions // ignore: cast_nullable_to_non_nullable
              as List<UserSubscriptionDto>,
    ));
  }
}

/// @nodoc

class _$GetUserSubscriptionsLoadedImpl implements _GetUserSubscriptionsLoaded {
  const _$GetUserSubscriptionsLoadedImpl(
      {required final List<UserSubscriptionDto> subscriptions})
      : _subscriptions = subscriptions;

  final List<UserSubscriptionDto> _subscriptions;
  @override
  List<UserSubscriptionDto> get subscriptions {
    if (_subscriptions is EqualUnmodifiableListView) return _subscriptions;
    // ignore: implicit_dynamic_type
    return EqualUnmodifiableListView(_subscriptions);
  }

  @override
  String toString() {
    return 'GetAllUserSubscriptionsState.loaded(subscriptions: $subscriptions)';
  }

  @override
  bool operator ==(Object other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is _$GetUserSubscriptionsLoadedImpl &&
            const DeepCollectionEquality()
                .equals(other._subscriptions, _subscriptions));
  }

  @override
  int get hashCode => Object.hash(
      runtimeType, const DeepCollectionEquality().hash(_subscriptions));

  @JsonKey(ignore: true)
  @override
  @pragma('vm:prefer-inline')
  _$$GetUserSubscriptionsLoadedImplCopyWith<_$GetUserSubscriptionsLoadedImpl>
      get copyWith => __$$GetUserSubscriptionsLoadedImplCopyWithImpl<
          _$GetUserSubscriptionsLoadedImpl>(this, _$identity);

  @override
  @optionalTypeArgs
  TResult when<TResult extends Object?>({
    required TResult Function() loading,
    required TResult Function(List<UserSubscriptionDto> subscriptions) loaded,
    required TResult Function(String errorMessage) error,
  }) {
    return loaded(subscriptions);
  }

  @override
  @optionalTypeArgs
  TResult? whenOrNull<TResult extends Object?>({
    TResult? Function()? loading,
    TResult? Function(List<UserSubscriptionDto> subscriptions)? loaded,
    TResult? Function(String errorMessage)? error,
  }) {
    return loaded?.call(subscriptions);
  }

  @override
  @optionalTypeArgs
  TResult maybeWhen<TResult extends Object?>({
    TResult Function()? loading,
    TResult Function(List<UserSubscriptionDto> subscriptions)? loaded,
    TResult Function(String errorMessage)? error,
    required TResult orElse(),
  }) {
    if (loaded != null) {
      return loaded(subscriptions);
    }
    return orElse();
  }

  @override
  @optionalTypeArgs
  TResult map<TResult extends Object?>({
    required TResult Function(_GetUserSubscriptionsLoading value) loading,
    required TResult Function(_GetUserSubscriptionsLoaded value) loaded,
    required TResult Function(_GetUserSubscriptionsError value) error,
  }) {
    return loaded(this);
  }

  @override
  @optionalTypeArgs
  TResult? mapOrNull<TResult extends Object?>({
    TResult? Function(_GetUserSubscriptionsLoading value)? loading,
    TResult? Function(_GetUserSubscriptionsLoaded value)? loaded,
    TResult? Function(_GetUserSubscriptionsError value)? error,
  }) {
    return loaded?.call(this);
  }

  @override
  @optionalTypeArgs
  TResult maybeMap<TResult extends Object?>({
    TResult Function(_GetUserSubscriptionsLoading value)? loading,
    TResult Function(_GetUserSubscriptionsLoaded value)? loaded,
    TResult Function(_GetUserSubscriptionsError value)? error,
    required TResult orElse(),
  }) {
    if (loaded != null) {
      return loaded(this);
    }
    return orElse();
  }
}

abstract class _GetUserSubscriptionsLoaded
    implements GetAllUserSubscriptionsState {
  const factory _GetUserSubscriptionsLoaded(
          {required final List<UserSubscriptionDto> subscriptions}) =
      _$GetUserSubscriptionsLoadedImpl;

  List<UserSubscriptionDto> get subscriptions;
  @JsonKey(ignore: true)
  _$$GetUserSubscriptionsLoadedImplCopyWith<_$GetUserSubscriptionsLoadedImpl>
      get copyWith => throw _privateConstructorUsedError;
}

/// @nodoc
abstract class _$$GetUserSubscriptionsErrorImplCopyWith<$Res> {
  factory _$$GetUserSubscriptionsErrorImplCopyWith(
          _$GetUserSubscriptionsErrorImpl value,
          $Res Function(_$GetUserSubscriptionsErrorImpl) then) =
      __$$GetUserSubscriptionsErrorImplCopyWithImpl<$Res>;
  @useResult
  $Res call({String errorMessage});
}

/// @nodoc
class __$$GetUserSubscriptionsErrorImplCopyWithImpl<$Res>
    extends _$GetAllUserSubscriptionsStateCopyWithImpl<$Res,
        _$GetUserSubscriptionsErrorImpl>
    implements _$$GetUserSubscriptionsErrorImplCopyWith<$Res> {
  __$$GetUserSubscriptionsErrorImplCopyWithImpl(
      _$GetUserSubscriptionsErrorImpl _value,
      $Res Function(_$GetUserSubscriptionsErrorImpl) _then)
      : super(_value, _then);

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? errorMessage = null,
  }) {
    return _then(_$GetUserSubscriptionsErrorImpl(
      errorMessage: null == errorMessage
          ? _value.errorMessage
          : errorMessage // ignore: cast_nullable_to_non_nullable
              as String,
    ));
  }
}

/// @nodoc

class _$GetUserSubscriptionsErrorImpl implements _GetUserSubscriptionsError {
  const _$GetUserSubscriptionsErrorImpl({required this.errorMessage});

  @override
  final String errorMessage;

  @override
  String toString() {
    return 'GetAllUserSubscriptionsState.error(errorMessage: $errorMessage)';
  }

  @override
  bool operator ==(Object other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is _$GetUserSubscriptionsErrorImpl &&
            (identical(other.errorMessage, errorMessage) ||
                other.errorMessage == errorMessage));
  }

  @override
  int get hashCode => Object.hash(runtimeType, errorMessage);

  @JsonKey(ignore: true)
  @override
  @pragma('vm:prefer-inline')
  _$$GetUserSubscriptionsErrorImplCopyWith<_$GetUserSubscriptionsErrorImpl>
      get copyWith => __$$GetUserSubscriptionsErrorImplCopyWithImpl<
          _$GetUserSubscriptionsErrorImpl>(this, _$identity);

  @override
  @optionalTypeArgs
  TResult when<TResult extends Object?>({
    required TResult Function() loading,
    required TResult Function(List<UserSubscriptionDto> subscriptions) loaded,
    required TResult Function(String errorMessage) error,
  }) {
    return error(errorMessage);
  }

  @override
  @optionalTypeArgs
  TResult? whenOrNull<TResult extends Object?>({
    TResult? Function()? loading,
    TResult? Function(List<UserSubscriptionDto> subscriptions)? loaded,
    TResult? Function(String errorMessage)? error,
  }) {
    return error?.call(errorMessage);
  }

  @override
  @optionalTypeArgs
  TResult maybeWhen<TResult extends Object?>({
    TResult Function()? loading,
    TResult Function(List<UserSubscriptionDto> subscriptions)? loaded,
    TResult Function(String errorMessage)? error,
    required TResult orElse(),
  }) {
    if (error != null) {
      return error(errorMessage);
    }
    return orElse();
  }

  @override
  @optionalTypeArgs
  TResult map<TResult extends Object?>({
    required TResult Function(_GetUserSubscriptionsLoading value) loading,
    required TResult Function(_GetUserSubscriptionsLoaded value) loaded,
    required TResult Function(_GetUserSubscriptionsError value) error,
  }) {
    return error(this);
  }

  @override
  @optionalTypeArgs
  TResult? mapOrNull<TResult extends Object?>({
    TResult? Function(_GetUserSubscriptionsLoading value)? loading,
    TResult? Function(_GetUserSubscriptionsLoaded value)? loaded,
    TResult? Function(_GetUserSubscriptionsError value)? error,
  }) {
    return error?.call(this);
  }

  @override
  @optionalTypeArgs
  TResult maybeMap<TResult extends Object?>({
    TResult Function(_GetUserSubscriptionsLoading value)? loading,
    TResult Function(_GetUserSubscriptionsLoaded value)? loaded,
    TResult Function(_GetUserSubscriptionsError value)? error,
    required TResult orElse(),
  }) {
    if (error != null) {
      return error(this);
    }
    return orElse();
  }
}

abstract class _GetUserSubscriptionsError
    implements GetAllUserSubscriptionsState {
  const factory _GetUserSubscriptionsError(
      {required final String errorMessage}) = _$GetUserSubscriptionsErrorImpl;

  String get errorMessage;
  @JsonKey(ignore: true)
  _$$GetUserSubscriptionsErrorImplCopyWith<_$GetUserSubscriptionsErrorImpl>
      get copyWith => throw _privateConstructorUsedError;
}
