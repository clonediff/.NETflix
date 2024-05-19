//
//  Generated code. Do not modify.
//  source: support-chat.proto
//
// @dart = 2.12

// ignore_for_file: annotate_overrides, camel_case_types, comment_references
// ignore_for_file: constant_identifier_names, library_prefixes
// ignore_for_file: non_constant_identifier_names, prefer_final_fields
// ignore_for_file: unnecessary_import, unnecessary_this, unused_import

import 'dart:async' as $async;
import 'dart:core' as $core;

import 'package:grpc/service_api.dart' as $grpc;
import 'package:protobuf/protobuf.dart' as $pb;

import 'support-chat.pb.dart' as $0;

export 'support-chat.pb.dart';

@$pb.GrpcServiceName('SupportChatService')
class SupportChatServiceClient extends $grpc.Client {
  static final _$sendTextMessage = $grpc.ClientMethod<$0.TextMessageRequest, $0.Empty>(
      '/SupportChatService/SendTextMessage',
      ($0.TextMessageRequest value) => value.writeToBuffer(),
      ($core.List<$core.int> value) => $0.Empty.fromBuffer(value));
  static final _$sendFileMessage = $grpc.ClientMethod<$0.FileMessageRequest, $0.Empty>(
      '/SupportChatService/SendFileMessage',
      ($0.FileMessageRequest value) => value.writeToBuffer(),
      ($core.List<$core.int> value) => $0.Empty.fromBuffer(value));
  static final _$receiveMessage = $grpc.ClientMethod<$0.ReceiveRequest, $0.MessageResponse>(
      '/SupportChatService/ReceiveMessage',
      ($0.ReceiveRequest value) => value.writeToBuffer(),
      ($core.List<$core.int> value) => $0.MessageResponse.fromBuffer(value));
  static final _$history = $grpc.ClientMethod<$0.HistoryRequest, $0.HistoryResponse>(
      '/SupportChatService/History',
      ($0.HistoryRequest value) => value.writeToBuffer(),
      ($core.List<$core.int> value) => $0.HistoryResponse.fromBuffer(value));

  SupportChatServiceClient($grpc.ClientChannel channel,
      {$grpc.CallOptions? options,
      $core.Iterable<$grpc.ClientInterceptor>? interceptors})
      : super(channel, options: options,
        interceptors: interceptors);

  $grpc.ResponseFuture<$0.Empty> sendTextMessage($0.TextMessageRequest request, {$grpc.CallOptions? options}) {
    return $createUnaryCall(_$sendTextMessage, request, options: options);
  }

  $grpc.ResponseFuture<$0.Empty> sendFileMessage($0.FileMessageRequest request, {$grpc.CallOptions? options}) {
    return $createUnaryCall(_$sendFileMessage, request, options: options);
  }

  $grpc.ResponseStream<$0.MessageResponse> receiveMessage($0.ReceiveRequest request, {$grpc.CallOptions? options}) {
    return $createStreamingCall(_$receiveMessage, $async.Stream.fromIterable([request]), options: options);
  }

  $grpc.ResponseFuture<$0.HistoryResponse> history($0.HistoryRequest request, {$grpc.CallOptions? options}) {
    return $createUnaryCall(_$history, request, options: options);
  }
}

@$pb.GrpcServiceName('SupportChatService')
abstract class SupportChatServiceBase extends $grpc.Service {
  $core.String get $name => 'SupportChatService';

  SupportChatServiceBase() {
    $addMethod($grpc.ServiceMethod<$0.TextMessageRequest, $0.Empty>(
        'SendTextMessage',
        sendTextMessage_Pre,
        false,
        false,
        ($core.List<$core.int> value) => $0.TextMessageRequest.fromBuffer(value),
        ($0.Empty value) => value.writeToBuffer()));
    $addMethod($grpc.ServiceMethod<$0.FileMessageRequest, $0.Empty>(
        'SendFileMessage',
        sendFileMessage_Pre,
        false,
        false,
        ($core.List<$core.int> value) => $0.FileMessageRequest.fromBuffer(value),
        ($0.Empty value) => value.writeToBuffer()));
    $addMethod($grpc.ServiceMethod<$0.ReceiveRequest, $0.MessageResponse>(
        'ReceiveMessage',
        receiveMessage_Pre,
        false,
        true,
        ($core.List<$core.int> value) => $0.ReceiveRequest.fromBuffer(value),
        ($0.MessageResponse value) => value.writeToBuffer()));
    $addMethod($grpc.ServiceMethod<$0.HistoryRequest, $0.HistoryResponse>(
        'History',
        history_Pre,
        false,
        false,
        ($core.List<$core.int> value) => $0.HistoryRequest.fromBuffer(value),
        ($0.HistoryResponse value) => value.writeToBuffer()));
  }

  $async.Future<$0.Empty> sendTextMessage_Pre($grpc.ServiceCall call, $async.Future<$0.TextMessageRequest> request) async {
    return sendTextMessage(call, await request);
  }

  $async.Future<$0.Empty> sendFileMessage_Pre($grpc.ServiceCall call, $async.Future<$0.FileMessageRequest> request) async {
    return sendFileMessage(call, await request);
  }

  $async.Stream<$0.MessageResponse> receiveMessage_Pre($grpc.ServiceCall call, $async.Future<$0.ReceiveRequest> request) async* {
    yield* receiveMessage(call, await request);
  }

  $async.Future<$0.HistoryResponse> history_Pre($grpc.ServiceCall call, $async.Future<$0.HistoryRequest> request) async {
    return history(call, await request);
  }

  $async.Future<$0.Empty> sendTextMessage($grpc.ServiceCall call, $0.TextMessageRequest request);
  $async.Future<$0.Empty> sendFileMessage($grpc.ServiceCall call, $0.FileMessageRequest request);
  $async.Stream<$0.MessageResponse> receiveMessage($grpc.ServiceCall call, $0.ReceiveRequest request);
  $async.Future<$0.HistoryResponse> history($grpc.ServiceCall call, $0.HistoryRequest request);
}
