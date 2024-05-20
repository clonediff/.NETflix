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
mixin _$GetSupportChatEvent {
  String get roomId => throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult when<TResult extends Object?>({
    required TResult Function(String roomId) getSupportChatInfo,
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult? whenOrNull<TResult extends Object?>({
    TResult? Function(String roomId)? getSupportChatInfo,
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult maybeWhen<TResult extends Object?>({
    TResult Function(String roomId)? getSupportChatInfo,
    required TResult orElse(),
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult map<TResult extends Object?>({
    required TResult Function(_GetSupportChatInfo value) getSupportChatInfo,
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult? mapOrNull<TResult extends Object?>({
    TResult? Function(_GetSupportChatInfo value)? getSupportChatInfo,
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult maybeMap<TResult extends Object?>({
    TResult Function(_GetSupportChatInfo value)? getSupportChatInfo,
    required TResult orElse(),
  }) =>
      throw _privateConstructorUsedError;

  @JsonKey(ignore: true)
  $GetSupportChatEventCopyWith<GetSupportChatEvent> get copyWith =>
      throw _privateConstructorUsedError;
}

/// @nodoc
abstract class $GetSupportChatEventCopyWith<$Res> {
  factory $GetSupportChatEventCopyWith(
          GetSupportChatEvent value, $Res Function(GetSupportChatEvent) then) =
      _$GetSupportChatEventCopyWithImpl<$Res, GetSupportChatEvent>;
  @useResult
  $Res call({String roomId});
}

/// @nodoc
class _$GetSupportChatEventCopyWithImpl<$Res, $Val extends GetSupportChatEvent>
    implements $GetSupportChatEventCopyWith<$Res> {
  _$GetSupportChatEventCopyWithImpl(this._value, this._then);

  // ignore: unused_field
  final $Val _value;
  // ignore: unused_field
  final $Res Function($Val) _then;

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? roomId = null,
  }) {
    return _then(_value.copyWith(
      roomId: null == roomId
          ? _value.roomId
          : roomId // ignore: cast_nullable_to_non_nullable
              as String,
    ) as $Val);
  }
}

/// @nodoc
abstract class _$$GetSupportChatInfoImplCopyWith<$Res>
    implements $GetSupportChatEventCopyWith<$Res> {
  factory _$$GetSupportChatInfoImplCopyWith(_$GetSupportChatInfoImpl value,
          $Res Function(_$GetSupportChatInfoImpl) then) =
      __$$GetSupportChatInfoImplCopyWithImpl<$Res>;
  @override
  @useResult
  $Res call({String roomId});
}

/// @nodoc
class __$$GetSupportChatInfoImplCopyWithImpl<$Res>
    extends _$GetSupportChatEventCopyWithImpl<$Res, _$GetSupportChatInfoImpl>
    implements _$$GetSupportChatInfoImplCopyWith<$Res> {
  __$$GetSupportChatInfoImplCopyWithImpl(_$GetSupportChatInfoImpl _value,
      $Res Function(_$GetSupportChatInfoImpl) _then)
      : super(_value, _then);

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? roomId = null,
  }) {
    return _then(_$GetSupportChatInfoImpl(
      null == roomId
          ? _value.roomId
          : roomId // ignore: cast_nullable_to_non_nullable
              as String,
    ));
  }
}

/// @nodoc

class _$GetSupportChatInfoImpl implements _GetSupportChatInfo {
  const _$GetSupportChatInfoImpl(this.roomId);

  @override
  final String roomId;

  @override
  String toString() {
    return 'GetSupportChatEvent.getSupportChatInfo(roomId: $roomId)';
  }

  @override
  bool operator ==(Object other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is _$GetSupportChatInfoImpl &&
            (identical(other.roomId, roomId) || other.roomId == roomId));
  }

  @override
  int get hashCode => Object.hash(runtimeType, roomId);

  @JsonKey(ignore: true)
  @override
  @pragma('vm:prefer-inline')
  _$$GetSupportChatInfoImplCopyWith<_$GetSupportChatInfoImpl> get copyWith =>
      __$$GetSupportChatInfoImplCopyWithImpl<_$GetSupportChatInfoImpl>(
          this, _$identity);

  @override
  @optionalTypeArgs
  TResult when<TResult extends Object?>({
    required TResult Function(String roomId) getSupportChatInfo,
  }) {
    return getSupportChatInfo(roomId);
  }

  @override
  @optionalTypeArgs
  TResult? whenOrNull<TResult extends Object?>({
    TResult? Function(String roomId)? getSupportChatInfo,
  }) {
    return getSupportChatInfo?.call(roomId);
  }

  @override
  @optionalTypeArgs
  TResult maybeWhen<TResult extends Object?>({
    TResult Function(String roomId)? getSupportChatInfo,
    required TResult orElse(),
  }) {
    if (getSupportChatInfo != null) {
      return getSupportChatInfo(roomId);
    }
    return orElse();
  }

  @override
  @optionalTypeArgs
  TResult map<TResult extends Object?>({
    required TResult Function(_GetSupportChatInfo value) getSupportChatInfo,
  }) {
    return getSupportChatInfo(this);
  }

  @override
  @optionalTypeArgs
  TResult? mapOrNull<TResult extends Object?>({
    TResult? Function(_GetSupportChatInfo value)? getSupportChatInfo,
  }) {
    return getSupportChatInfo?.call(this);
  }

  @override
  @optionalTypeArgs
  TResult maybeMap<TResult extends Object?>({
    TResult Function(_GetSupportChatInfo value)? getSupportChatInfo,
    required TResult orElse(),
  }) {
    if (getSupportChatInfo != null) {
      return getSupportChatInfo(this);
    }
    return orElse();
  }
}

abstract class _GetSupportChatInfo implements GetSupportChatEvent {
  const factory _GetSupportChatInfo(final String roomId) =
      _$GetSupportChatInfoImpl;

  @override
  String get roomId;
  @override
  @JsonKey(ignore: true)
  _$$GetSupportChatInfoImplCopyWith<_$GetSupportChatInfoImpl> get copyWith =>
      throw _privateConstructorUsedError;
}

/// @nodoc
mixin _$GetSupportChatState {
  @optionalTypeArgs
  TResult when<TResult extends Object?>({
    required TResult Function() loading,
    required TResult Function(ChatDto chat) loaded,
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult? whenOrNull<TResult extends Object?>({
    TResult? Function()? loading,
    TResult? Function(ChatDto chat)? loaded,
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult maybeWhen<TResult extends Object?>({
    TResult Function()? loading,
    TResult Function(ChatDto chat)? loaded,
    required TResult orElse(),
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult map<TResult extends Object?>({
    required TResult Function(_GetSupportChatLoading value) loading,
    required TResult Function(_GetSupportChatLoaded value) loaded,
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult? mapOrNull<TResult extends Object?>({
    TResult? Function(_GetSupportChatLoading value)? loading,
    TResult? Function(_GetSupportChatLoaded value)? loaded,
  }) =>
      throw _privateConstructorUsedError;
  @optionalTypeArgs
  TResult maybeMap<TResult extends Object?>({
    TResult Function(_GetSupportChatLoading value)? loading,
    TResult Function(_GetSupportChatLoaded value)? loaded,
    required TResult orElse(),
  }) =>
      throw _privateConstructorUsedError;
}

/// @nodoc
abstract class $GetSupportChatStateCopyWith<$Res> {
  factory $GetSupportChatStateCopyWith(
          GetSupportChatState value, $Res Function(GetSupportChatState) then) =
      _$GetSupportChatStateCopyWithImpl<$Res, GetSupportChatState>;
}

/// @nodoc
class _$GetSupportChatStateCopyWithImpl<$Res, $Val extends GetSupportChatState>
    implements $GetSupportChatStateCopyWith<$Res> {
  _$GetSupportChatStateCopyWithImpl(this._value, this._then);

  // ignore: unused_field
  final $Val _value;
  // ignore: unused_field
  final $Res Function($Val) _then;
}

/// @nodoc
abstract class _$$GetSupportChatLoadingImplCopyWith<$Res> {
  factory _$$GetSupportChatLoadingImplCopyWith(
          _$GetSupportChatLoadingImpl value,
          $Res Function(_$GetSupportChatLoadingImpl) then) =
      __$$GetSupportChatLoadingImplCopyWithImpl<$Res>;
}

/// @nodoc
class __$$GetSupportChatLoadingImplCopyWithImpl<$Res>
    extends _$GetSupportChatStateCopyWithImpl<$Res, _$GetSupportChatLoadingImpl>
    implements _$$GetSupportChatLoadingImplCopyWith<$Res> {
  __$$GetSupportChatLoadingImplCopyWithImpl(_$GetSupportChatLoadingImpl _value,
      $Res Function(_$GetSupportChatLoadingImpl) _then)
      : super(_value, _then);
}

/// @nodoc

class _$GetSupportChatLoadingImpl implements _GetSupportChatLoading {
  _$GetSupportChatLoadingImpl();

  @override
  String toString() {
    return 'GetSupportChatState.loading()';
  }

  @override
  bool operator ==(Object other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is _$GetSupportChatLoadingImpl);
  }

  @override
  int get hashCode => runtimeType.hashCode;

  @override
  @optionalTypeArgs
  TResult when<TResult extends Object?>({
    required TResult Function() loading,
    required TResult Function(ChatDto chat) loaded,
  }) {
    return loading();
  }

  @override
  @optionalTypeArgs
  TResult? whenOrNull<TResult extends Object?>({
    TResult? Function()? loading,
    TResult? Function(ChatDto chat)? loaded,
  }) {
    return loading?.call();
  }

  @override
  @optionalTypeArgs
  TResult maybeWhen<TResult extends Object?>({
    TResult Function()? loading,
    TResult Function(ChatDto chat)? loaded,
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
    required TResult Function(_GetSupportChatLoading value) loading,
    required TResult Function(_GetSupportChatLoaded value) loaded,
  }) {
    return loading(this);
  }

  @override
  @optionalTypeArgs
  TResult? mapOrNull<TResult extends Object?>({
    TResult? Function(_GetSupportChatLoading value)? loading,
    TResult? Function(_GetSupportChatLoaded value)? loaded,
  }) {
    return loading?.call(this);
  }

  @override
  @optionalTypeArgs
  TResult maybeMap<TResult extends Object?>({
    TResult Function(_GetSupportChatLoading value)? loading,
    TResult Function(_GetSupportChatLoaded value)? loaded,
    required TResult orElse(),
  }) {
    if (loading != null) {
      return loading(this);
    }
    return orElse();
  }
}

abstract class _GetSupportChatLoading implements GetSupportChatState {
  factory _GetSupportChatLoading() = _$GetSupportChatLoadingImpl;
}

/// @nodoc
abstract class _$$GetSupportChatLoadedImplCopyWith<$Res> {
  factory _$$GetSupportChatLoadedImplCopyWith(_$GetSupportChatLoadedImpl value,
          $Res Function(_$GetSupportChatLoadedImpl) then) =
      __$$GetSupportChatLoadedImplCopyWithImpl<$Res>;
  @useResult
  $Res call({ChatDto chat});
}

/// @nodoc
class __$$GetSupportChatLoadedImplCopyWithImpl<$Res>
    extends _$GetSupportChatStateCopyWithImpl<$Res, _$GetSupportChatLoadedImpl>
    implements _$$GetSupportChatLoadedImplCopyWith<$Res> {
  __$$GetSupportChatLoadedImplCopyWithImpl(_$GetSupportChatLoadedImpl _value,
      $Res Function(_$GetSupportChatLoadedImpl) _then)
      : super(_value, _then);

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? chat = null,
  }) {
    return _then(_$GetSupportChatLoadedImpl(
      chat: null == chat
          ? _value.chat
          : chat // ignore: cast_nullable_to_non_nullable
              as ChatDto,
    ));
  }
}

/// @nodoc

class _$GetSupportChatLoadedImpl implements _GetSupportChatLoaded {
  const _$GetSupportChatLoadedImpl({required this.chat});

  @override
  final ChatDto chat;

  @override
  String toString() {
    return 'GetSupportChatState.loaded(chat: $chat)';
  }

  @override
  bool operator ==(Object other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is _$GetSupportChatLoadedImpl &&
            (identical(other.chat, chat) || other.chat == chat));
  }

  @override
  int get hashCode => Object.hash(runtimeType, chat);

  @JsonKey(ignore: true)
  @override
  @pragma('vm:prefer-inline')
  _$$GetSupportChatLoadedImplCopyWith<_$GetSupportChatLoadedImpl>
      get copyWith =>
          __$$GetSupportChatLoadedImplCopyWithImpl<_$GetSupportChatLoadedImpl>(
              this, _$identity);

  @override
  @optionalTypeArgs
  TResult when<TResult extends Object?>({
    required TResult Function() loading,
    required TResult Function(ChatDto chat) loaded,
  }) {
    return loaded(chat);
  }

  @override
  @optionalTypeArgs
  TResult? whenOrNull<TResult extends Object?>({
    TResult? Function()? loading,
    TResult? Function(ChatDto chat)? loaded,
  }) {
    return loaded?.call(chat);
  }

  @override
  @optionalTypeArgs
  TResult maybeWhen<TResult extends Object?>({
    TResult Function()? loading,
    TResult Function(ChatDto chat)? loaded,
    required TResult orElse(),
  }) {
    if (loaded != null) {
      return loaded(chat);
    }
    return orElse();
  }

  @override
  @optionalTypeArgs
  TResult map<TResult extends Object?>({
    required TResult Function(_GetSupportChatLoading value) loading,
    required TResult Function(_GetSupportChatLoaded value) loaded,
  }) {
    return loaded(this);
  }

  @override
  @optionalTypeArgs
  TResult? mapOrNull<TResult extends Object?>({
    TResult? Function(_GetSupportChatLoading value)? loading,
    TResult? Function(_GetSupportChatLoaded value)? loaded,
  }) {
    return loaded?.call(this);
  }

  @override
  @optionalTypeArgs
  TResult maybeMap<TResult extends Object?>({
    TResult Function(_GetSupportChatLoading value)? loading,
    TResult Function(_GetSupportChatLoaded value)? loaded,
    required TResult orElse(),
  }) {
    if (loaded != null) {
      return loaded(this);
    }
    return orElse();
  }
}

abstract class _GetSupportChatLoaded implements GetSupportChatState {
  const factory _GetSupportChatLoaded({required final ChatDto chat}) =
      _$GetSupportChatLoadedImpl;

  ChatDto get chat;
  @JsonKey(ignore: true)
  _$$GetSupportChatLoadedImplCopyWith<_$GetSupportChatLoadedImpl>
      get copyWith => throw _privateConstructorUsedError;
}
