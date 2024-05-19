//
//  Generated code. Do not modify.
//  source: support-chat.proto
//
// @dart = 2.12

// ignore_for_file: annotate_overrides, camel_case_types, comment_references
// ignore_for_file: constant_identifier_names, library_prefixes
// ignore_for_file: non_constant_identifier_names, prefer_final_fields
// ignore_for_file: unnecessary_import, unnecessary_this, unused_import

import 'dart:core' as $core;

import 'package:protobuf/protobuf.dart' as $pb;

import 'google/protobuf/any.pb.dart' as $1;
import 'google/protobuf/timestamp.pb.dart' as $2;
import 'support-chat.pbenum.dart';

export 'support-chat.pbenum.dart';

class TextMessageRequest extends $pb.GeneratedMessage {
  factory TextMessageRequest({
    $core.String? content,
    $core.String? roomId,
  }) {
    final $result = create();
    if (content != null) {
      $result.content = content;
    }
    if (roomId != null) {
      $result.roomId = roomId;
    }
    return $result;
  }
  TextMessageRequest._() : super();
  factory TextMessageRequest.fromBuffer($core.List<$core.int> i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromBuffer(i, r);
  factory TextMessageRequest.fromJson($core.String i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromJson(i, r);

  static final $pb.BuilderInfo _i = $pb.BuilderInfo(_omitMessageNames ? '' : 'TextMessageRequest', createEmptyInstance: create)
    ..aOS(1, _omitFieldNames ? '' : 'content')
    ..aOS(2, _omitFieldNames ? '' : 'roomId', protoName: 'roomId')
    ..hasRequiredFields = false
  ;

  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.deepCopy] instead. '
  'Will be removed in next major version')
  TextMessageRequest clone() => TextMessageRequest()..mergeFromMessage(this);
  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.rebuild] instead. '
  'Will be removed in next major version')
  TextMessageRequest copyWith(void Function(TextMessageRequest) updates) => super.copyWith((message) => updates(message as TextMessageRequest)) as TextMessageRequest;

  $pb.BuilderInfo get info_ => _i;

  @$core.pragma('dart2js:noInline')
  static TextMessageRequest create() => TextMessageRequest._();
  TextMessageRequest createEmptyInstance() => create();
  static $pb.PbList<TextMessageRequest> createRepeated() => $pb.PbList<TextMessageRequest>();
  @$core.pragma('dart2js:noInline')
  static TextMessageRequest getDefault() => _defaultInstance ??= $pb.GeneratedMessage.$_defaultFor<TextMessageRequest>(create);
  static TextMessageRequest? _defaultInstance;

  @$pb.TagNumber(1)
  $core.String get content => $_getSZ(0);
  @$pb.TagNumber(1)
  set content($core.String v) { $_setString(0, v); }
  @$pb.TagNumber(1)
  $core.bool hasContent() => $_has(0);
  @$pb.TagNumber(1)
  void clearContent() => clearField(1);

  @$pb.TagNumber(2)
  $core.String get roomId => $_getSZ(1);
  @$pb.TagNumber(2)
  set roomId($core.String v) { $_setString(1, v); }
  @$pb.TagNumber(2)
  $core.bool hasRoomId() => $_has(1);
  @$pb.TagNumber(2)
  void clearRoomId() => clearField(2);
}

class FileMessageRequest extends $pb.GeneratedMessage {
  factory FileMessageRequest({
    $core.List<$core.int>? content,
    $core.String? roomId,
    $core.String? contentType,
  }) {
    final $result = create();
    if (content != null) {
      $result.content = content;
    }
    if (roomId != null) {
      $result.roomId = roomId;
    }
    if (contentType != null) {
      $result.contentType = contentType;
    }
    return $result;
  }
  FileMessageRequest._() : super();
  factory FileMessageRequest.fromBuffer($core.List<$core.int> i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromBuffer(i, r);
  factory FileMessageRequest.fromJson($core.String i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromJson(i, r);

  static final $pb.BuilderInfo _i = $pb.BuilderInfo(_omitMessageNames ? '' : 'FileMessageRequest', createEmptyInstance: create)
    ..a<$core.List<$core.int>>(1, _omitFieldNames ? '' : 'content', $pb.PbFieldType.OY)
    ..aOS(2, _omitFieldNames ? '' : 'roomId', protoName: 'roomId')
    ..aOS(3, _omitFieldNames ? '' : 'contentType', protoName: 'contentType')
    ..hasRequiredFields = false
  ;

  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.deepCopy] instead. '
  'Will be removed in next major version')
  FileMessageRequest clone() => FileMessageRequest()..mergeFromMessage(this);
  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.rebuild] instead. '
  'Will be removed in next major version')
  FileMessageRequest copyWith(void Function(FileMessageRequest) updates) => super.copyWith((message) => updates(message as FileMessageRequest)) as FileMessageRequest;

  $pb.BuilderInfo get info_ => _i;

  @$core.pragma('dart2js:noInline')
  static FileMessageRequest create() => FileMessageRequest._();
  FileMessageRequest createEmptyInstance() => create();
  static $pb.PbList<FileMessageRequest> createRepeated() => $pb.PbList<FileMessageRequest>();
  @$core.pragma('dart2js:noInline')
  static FileMessageRequest getDefault() => _defaultInstance ??= $pb.GeneratedMessage.$_defaultFor<FileMessageRequest>(create);
  static FileMessageRequest? _defaultInstance;

  @$pb.TagNumber(1)
  $core.List<$core.int> get content => $_getN(0);
  @$pb.TagNumber(1)
  set content($core.List<$core.int> v) { $_setBytes(0, v); }
  @$pb.TagNumber(1)
  $core.bool hasContent() => $_has(0);
  @$pb.TagNumber(1)
  void clearContent() => clearField(1);

  @$pb.TagNumber(2)
  $core.String get roomId => $_getSZ(1);
  @$pb.TagNumber(2)
  set roomId($core.String v) { $_setString(1, v); }
  @$pb.TagNumber(2)
  $core.bool hasRoomId() => $_has(1);
  @$pb.TagNumber(2)
  void clearRoomId() => clearField(2);

  @$pb.TagNumber(3)
  $core.String get contentType => $_getSZ(2);
  @$pb.TagNumber(3)
  set contentType($core.String v) { $_setString(2, v); }
  @$pb.TagNumber(3)
  $core.bool hasContentType() => $_has(2);
  @$pb.TagNumber(3)
  void clearContentType() => clearField(3);
}

class ReceiveRequest extends $pb.GeneratedMessage {
  factory ReceiveRequest({
    $core.String? roomId,
  }) {
    final $result = create();
    if (roomId != null) {
      $result.roomId = roomId;
    }
    return $result;
  }
  ReceiveRequest._() : super();
  factory ReceiveRequest.fromBuffer($core.List<$core.int> i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromBuffer(i, r);
  factory ReceiveRequest.fromJson($core.String i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromJson(i, r);

  static final $pb.BuilderInfo _i = $pb.BuilderInfo(_omitMessageNames ? '' : 'ReceiveRequest', createEmptyInstance: create)
    ..aOS(1, _omitFieldNames ? '' : 'roomId', protoName: 'roomId')
    ..hasRequiredFields = false
  ;

  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.deepCopy] instead. '
  'Will be removed in next major version')
  ReceiveRequest clone() => ReceiveRequest()..mergeFromMessage(this);
  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.rebuild] instead. '
  'Will be removed in next major version')
  ReceiveRequest copyWith(void Function(ReceiveRequest) updates) => super.copyWith((message) => updates(message as ReceiveRequest)) as ReceiveRequest;

  $pb.BuilderInfo get info_ => _i;

  @$core.pragma('dart2js:noInline')
  static ReceiveRequest create() => ReceiveRequest._();
  ReceiveRequest createEmptyInstance() => create();
  static $pb.PbList<ReceiveRequest> createRepeated() => $pb.PbList<ReceiveRequest>();
  @$core.pragma('dart2js:noInline')
  static ReceiveRequest getDefault() => _defaultInstance ??= $pb.GeneratedMessage.$_defaultFor<ReceiveRequest>(create);
  static ReceiveRequest? _defaultInstance;

  @$pb.TagNumber(1)
  $core.String get roomId => $_getSZ(0);
  @$pb.TagNumber(1)
  set roomId($core.String v) { $_setString(0, v); }
  @$pb.TagNumber(1)
  $core.bool hasRoomId() => $_has(0);
  @$pb.TagNumber(1)
  void clearRoomId() => clearField(1);
}

class MessageResponse extends $pb.GeneratedMessage {
  factory MessageResponse({
    $core.String? roomId,
    MessageType? messageType,
    $1.Any? content,
    $core.String? senderName,
    $2.Timestamp? sendingDate,
    $core.bool? belongsToSender,
  }) {
    final $result = create();
    if (roomId != null) {
      $result.roomId = roomId;
    }
    if (messageType != null) {
      $result.messageType = messageType;
    }
    if (content != null) {
      $result.content = content;
    }
    if (senderName != null) {
      $result.senderName = senderName;
    }
    if (sendingDate != null) {
      $result.sendingDate = sendingDate;
    }
    if (belongsToSender != null) {
      $result.belongsToSender = belongsToSender;
    }
    return $result;
  }
  MessageResponse._() : super();
  factory MessageResponse.fromBuffer($core.List<$core.int> i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromBuffer(i, r);
  factory MessageResponse.fromJson($core.String i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromJson(i, r);

  static final $pb.BuilderInfo _i = $pb.BuilderInfo(_omitMessageNames ? '' : 'MessageResponse', createEmptyInstance: create)
    ..aOS(1, _omitFieldNames ? '' : 'roomId', protoName: 'roomId')
    ..e<MessageType>(2, _omitFieldNames ? '' : 'messageType', $pb.PbFieldType.OE, protoName: 'messageType', defaultOrMaker: MessageType.text, valueOf: MessageType.valueOf, enumValues: MessageType.values)
    ..aOM<$1.Any>(3, _omitFieldNames ? '' : 'content', subBuilder: $1.Any.create)
    ..aOS(4, _omitFieldNames ? '' : 'senderName', protoName: 'senderName')
    ..aOM<$2.Timestamp>(5, _omitFieldNames ? '' : 'sendingDate', protoName: 'sendingDate', subBuilder: $2.Timestamp.create)
    ..aOB(6, _omitFieldNames ? '' : 'belongsToSender', protoName: 'belongsToSender')
    ..hasRequiredFields = false
  ;

  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.deepCopy] instead. '
  'Will be removed in next major version')
  MessageResponse clone() => MessageResponse()..mergeFromMessage(this);
  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.rebuild] instead. '
  'Will be removed in next major version')
  MessageResponse copyWith(void Function(MessageResponse) updates) => super.copyWith((message) => updates(message as MessageResponse)) as MessageResponse;

  $pb.BuilderInfo get info_ => _i;

  @$core.pragma('dart2js:noInline')
  static MessageResponse create() => MessageResponse._();
  MessageResponse createEmptyInstance() => create();
  static $pb.PbList<MessageResponse> createRepeated() => $pb.PbList<MessageResponse>();
  @$core.pragma('dart2js:noInline')
  static MessageResponse getDefault() => _defaultInstance ??= $pb.GeneratedMessage.$_defaultFor<MessageResponse>(create);
  static MessageResponse? _defaultInstance;

  @$pb.TagNumber(1)
  $core.String get roomId => $_getSZ(0);
  @$pb.TagNumber(1)
  set roomId($core.String v) { $_setString(0, v); }
  @$pb.TagNumber(1)
  $core.bool hasRoomId() => $_has(0);
  @$pb.TagNumber(1)
  void clearRoomId() => clearField(1);

  @$pb.TagNumber(2)
  MessageType get messageType => $_getN(1);
  @$pb.TagNumber(2)
  set messageType(MessageType v) { setField(2, v); }
  @$pb.TagNumber(2)
  $core.bool hasMessageType() => $_has(1);
  @$pb.TagNumber(2)
  void clearMessageType() => clearField(2);

  @$pb.TagNumber(3)
  $1.Any get content => $_getN(2);
  @$pb.TagNumber(3)
  set content($1.Any v) { setField(3, v); }
  @$pb.TagNumber(3)
  $core.bool hasContent() => $_has(2);
  @$pb.TagNumber(3)
  void clearContent() => clearField(3);
  @$pb.TagNumber(3)
  $1.Any ensureContent() => $_ensure(2);

  @$pb.TagNumber(4)
  $core.String get senderName => $_getSZ(3);
  @$pb.TagNumber(4)
  set senderName($core.String v) { $_setString(3, v); }
  @$pb.TagNumber(4)
  $core.bool hasSenderName() => $_has(3);
  @$pb.TagNumber(4)
  void clearSenderName() => clearField(4);

  @$pb.TagNumber(5)
  $2.Timestamp get sendingDate => $_getN(4);
  @$pb.TagNumber(5)
  set sendingDate($2.Timestamp v) { setField(5, v); }
  @$pb.TagNumber(5)
  $core.bool hasSendingDate() => $_has(4);
  @$pb.TagNumber(5)
  void clearSendingDate() => clearField(5);
  @$pb.TagNumber(5)
  $2.Timestamp ensureSendingDate() => $_ensure(4);

  @$pb.TagNumber(6)
  $core.bool get belongsToSender => $_getBF(5);
  @$pb.TagNumber(6)
  set belongsToSender($core.bool v) { $_setBool(5, v); }
  @$pb.TagNumber(6)
  $core.bool hasBelongsToSender() => $_has(5);
  @$pb.TagNumber(6)
  void clearBelongsToSender() => clearField(6);
}

class HistoryResponse extends $pb.GeneratedMessage {
  factory HistoryResponse({
    $core.Iterable<MessageResponse>? messages,
  }) {
    final $result = create();
    if (messages != null) {
      $result.messages.addAll(messages);
    }
    return $result;
  }
  HistoryResponse._() : super();
  factory HistoryResponse.fromBuffer($core.List<$core.int> i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromBuffer(i, r);
  factory HistoryResponse.fromJson($core.String i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromJson(i, r);

  static final $pb.BuilderInfo _i = $pb.BuilderInfo(_omitMessageNames ? '' : 'HistoryResponse', createEmptyInstance: create)
    ..pc<MessageResponse>(1, _omitFieldNames ? '' : 'messages', $pb.PbFieldType.PM, subBuilder: MessageResponse.create)
    ..hasRequiredFields = false
  ;

  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.deepCopy] instead. '
  'Will be removed in next major version')
  HistoryResponse clone() => HistoryResponse()..mergeFromMessage(this);
  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.rebuild] instead. '
  'Will be removed in next major version')
  HistoryResponse copyWith(void Function(HistoryResponse) updates) => super.copyWith((message) => updates(message as HistoryResponse)) as HistoryResponse;

  $pb.BuilderInfo get info_ => _i;

  @$core.pragma('dart2js:noInline')
  static HistoryResponse create() => HistoryResponse._();
  HistoryResponse createEmptyInstance() => create();
  static $pb.PbList<HistoryResponse> createRepeated() => $pb.PbList<HistoryResponse>();
  @$core.pragma('dart2js:noInline')
  static HistoryResponse getDefault() => _defaultInstance ??= $pb.GeneratedMessage.$_defaultFor<HistoryResponse>(create);
  static HistoryResponse? _defaultInstance;

  @$pb.TagNumber(1)
  $core.List<MessageResponse> get messages => $_getList(0);
}

class HistoryRequest extends $pb.GeneratedMessage {
  factory HistoryRequest({
    $core.String? roomId,
  }) {
    final $result = create();
    if (roomId != null) {
      $result.roomId = roomId;
    }
    return $result;
  }
  HistoryRequest._() : super();
  factory HistoryRequest.fromBuffer($core.List<$core.int> i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromBuffer(i, r);
  factory HistoryRequest.fromJson($core.String i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromJson(i, r);

  static final $pb.BuilderInfo _i = $pb.BuilderInfo(_omitMessageNames ? '' : 'HistoryRequest', createEmptyInstance: create)
    ..aOS(1, _omitFieldNames ? '' : 'roomId', protoName: 'roomId')
    ..hasRequiredFields = false
  ;

  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.deepCopy] instead. '
  'Will be removed in next major version')
  HistoryRequest clone() => HistoryRequest()..mergeFromMessage(this);
  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.rebuild] instead. '
  'Will be removed in next major version')
  HistoryRequest copyWith(void Function(HistoryRequest) updates) => super.copyWith((message) => updates(message as HistoryRequest)) as HistoryRequest;

  $pb.BuilderInfo get info_ => _i;

  @$core.pragma('dart2js:noInline')
  static HistoryRequest create() => HistoryRequest._();
  HistoryRequest createEmptyInstance() => create();
  static $pb.PbList<HistoryRequest> createRepeated() => $pb.PbList<HistoryRequest>();
  @$core.pragma('dart2js:noInline')
  static HistoryRequest getDefault() => _defaultInstance ??= $pb.GeneratedMessage.$_defaultFor<HistoryRequest>(create);
  static HistoryRequest? _defaultInstance;

  @$pb.TagNumber(1)
  $core.String get roomId => $_getSZ(0);
  @$pb.TagNumber(1)
  set roomId($core.String v) { $_setString(0, v); }
  @$pb.TagNumber(1)
  $core.bool hasRoomId() => $_has(0);
  @$pb.TagNumber(1)
  void clearRoomId() => clearField(1);
}

class Empty extends $pb.GeneratedMessage {
  factory Empty() => create();
  Empty._() : super();
  factory Empty.fromBuffer($core.List<$core.int> i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromBuffer(i, r);
  factory Empty.fromJson($core.String i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromJson(i, r);

  static final $pb.BuilderInfo _i = $pb.BuilderInfo(_omitMessageNames ? '' : 'Empty', createEmptyInstance: create)
    ..hasRequiredFields = false
  ;

  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.deepCopy] instead. '
  'Will be removed in next major version')
  Empty clone() => Empty()..mergeFromMessage(this);
  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.rebuild] instead. '
  'Will be removed in next major version')
  Empty copyWith(void Function(Empty) updates) => super.copyWith((message) => updates(message as Empty)) as Empty;

  $pb.BuilderInfo get info_ => _i;

  @$core.pragma('dart2js:noInline')
  static Empty create() => Empty._();
  Empty createEmptyInstance() => create();
  static $pb.PbList<Empty> createRepeated() => $pb.PbList<Empty>();
  @$core.pragma('dart2js:noInline')
  static Empty getDefault() => _defaultInstance ??= $pb.GeneratedMessage.$_defaultFor<Empty>(create);
  static Empty? _defaultInstance;
}


const _omitFieldNames = $core.bool.fromEnvironment('protobuf.omit_field_names');
const _omitMessageNames = $core.bool.fromEnvironment('protobuf.omit_message_names');
