//
//  Generated code. Do not modify.
//  source: support-chat.proto
//
// @dart = 2.12

// ignore_for_file: annotate_overrides, camel_case_types, comment_references
// ignore_for_file: constant_identifier_names
// ignore_for_file: deprecated_member_use_from_same_package, library_prefixes
// ignore_for_file: non_constant_identifier_names, prefer_final_fields
// ignore_for_file: unnecessary_import, unnecessary_this, unused_import

import 'dart:async' as $async;
import 'dart:core' as $core;

import 'package:protobuf/protobuf.dart' as $pb;

import 'support-chat.pb.dart' as $2;
import 'support-chat.pbjson.dart';

export 'support-chat.pb.dart';

abstract class SupportChatServiceBase extends $pb.GeneratedService {
  $async.Future<$2.Empty> sendTextMessage($pb.ServerContext ctx, $2.TextMessageRequest request);
  $async.Future<$2.Empty> sendFileMessage($pb.ServerContext ctx, $2.FileMessageRequest request);
  $async.Future<$2.MessageResponse> receiveMessage($pb.ServerContext ctx, $2.ReceiveRequest request);
  $async.Future<$2.MessageResponse> history($pb.ServerContext ctx, $2.HistoryRequest request);

  $pb.GeneratedMessage createRequest($core.String methodName) {
    switch (methodName) {
      case 'SendTextMessage': return $2.TextMessageRequest();
      case 'SendFileMessage': return $2.FileMessageRequest();
      case 'ReceiveMessage': return $2.ReceiveRequest();
      case 'History': return $2.HistoryRequest();
      default: throw $core.ArgumentError('Unknown method: $methodName');
    }
  }

  $async.Future<$pb.GeneratedMessage> handleCall($pb.ServerContext ctx, $core.String methodName, $pb.GeneratedMessage request) {
    switch (methodName) {
      case 'SendTextMessage': return this.sendTextMessage(ctx, request as $2.TextMessageRequest);
      case 'SendFileMessage': return this.sendFileMessage(ctx, request as $2.FileMessageRequest);
      case 'ReceiveMessage': return this.receiveMessage(ctx, request as $2.ReceiveRequest);
      case 'History': return this.history(ctx, request as $2.HistoryRequest);
      default: throw $core.ArgumentError('Unknown method: $methodName');
    }
  }

  $core.Map<$core.String, $core.dynamic> get $json => SupportChatServiceBase$json;
  $core.Map<$core.String, $core.Map<$core.String, $core.dynamic>> get $messageJson => SupportChatServiceBase$messageJson;
}

