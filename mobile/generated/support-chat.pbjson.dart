//
//  Generated code. Do not modify.
//  source: support-chat.proto
//
// @dart = 2.12

// ignore_for_file: annotate_overrides, camel_case_types, comment_references
// ignore_for_file: constant_identifier_names, library_prefixes
// ignore_for_file: non_constant_identifier_names, prefer_final_fields
// ignore_for_file: unnecessary_import, unnecessary_this, unused_import

import 'dart:convert' as $convert;
import 'dart:core' as $core;
import 'dart:typed_data' as $typed_data;

import 'google/protobuf/any.pbjson.dart' as $0;
import 'google/protobuf/timestamp.pbjson.dart' as $1;

@$core.Deprecated('Use messageTypeDescriptor instead')
const MessageType$json = {
  '1': 'MessageType',
  '2': [
    {'1': 'text', '2': 0},
    {'1': 'file', '2': 1},
  ],
};

/// Descriptor for `MessageType`. Decode as a `google.protobuf.EnumDescriptorProto`.
final $typed_data.Uint8List messageTypeDescriptor = $convert.base64Decode(
    'CgtNZXNzYWdlVHlwZRIICgR0ZXh0EAASCAoEZmlsZRAB');

@$core.Deprecated('Use textMessageRequestDescriptor instead')
const TextMessageRequest$json = {
  '1': 'TextMessageRequest',
  '2': [
    {'1': 'content', '3': 1, '4': 1, '5': 9, '10': 'content'},
    {'1': 'roomId', '3': 2, '4': 1, '5': 9, '10': 'roomId'},
  ],
};

/// Descriptor for `TextMessageRequest`. Decode as a `google.protobuf.DescriptorProto`.
final $typed_data.Uint8List textMessageRequestDescriptor = $convert.base64Decode(
    'ChJUZXh0TWVzc2FnZVJlcXVlc3QSGAoHY29udGVudBgBIAEoCVIHY29udGVudBIWCgZyb29tSW'
    'QYAiABKAlSBnJvb21JZA==');

@$core.Deprecated('Use fileMessageRequestDescriptor instead')
const FileMessageRequest$json = {
  '1': 'FileMessageRequest',
  '2': [
    {'1': 'content', '3': 1, '4': 1, '5': 12, '10': 'content'},
    {'1': 'roomId', '3': 2, '4': 1, '5': 9, '10': 'roomId'},
    {'1': 'contentType', '3': 3, '4': 1, '5': 9, '10': 'contentType'},
  ],
};

/// Descriptor for `FileMessageRequest`. Decode as a `google.protobuf.DescriptorProto`.
final $typed_data.Uint8List fileMessageRequestDescriptor = $convert.base64Decode(
    'ChJGaWxlTWVzc2FnZVJlcXVlc3QSGAoHY29udGVudBgBIAEoDFIHY29udGVudBIWCgZyb29tSW'
    'QYAiABKAlSBnJvb21JZBIgCgtjb250ZW50VHlwZRgDIAEoCVILY29udGVudFR5cGU=');

@$core.Deprecated('Use receiveRequestDescriptor instead')
const ReceiveRequest$json = {
  '1': 'ReceiveRequest',
  '2': [
    {'1': 'roomId', '3': 1, '4': 1, '5': 9, '10': 'roomId'},
  ],
};

/// Descriptor for `ReceiveRequest`. Decode as a `google.protobuf.DescriptorProto`.
final $typed_data.Uint8List receiveRequestDescriptor = $convert.base64Decode(
    'Cg5SZWNlaXZlUmVxdWVzdBIWCgZyb29tSWQYASABKAlSBnJvb21JZA==');

@$core.Deprecated('Use messageResponseDescriptor instead')
const MessageResponse$json = {
  '1': 'MessageResponse',
  '2': [
    {'1': 'roomId', '3': 1, '4': 1, '5': 9, '10': 'roomId'},
    {'1': 'messageType', '3': 2, '4': 1, '5': 14, '6': '.MessageType', '10': 'messageType'},
    {'1': 'content', '3': 3, '4': 1, '5': 11, '6': '.google.protobuf.Any', '10': 'content'},
    {'1': 'senderName', '3': 4, '4': 1, '5': 9, '10': 'senderName'},
    {'1': 'sendingDate', '3': 5, '4': 1, '5': 11, '6': '.google.protobuf.Timestamp', '10': 'sendingDate'},
    {'1': 'belongsToSender', '3': 6, '4': 1, '5': 8, '10': 'belongsToSender'},
  ],
};

/// Descriptor for `MessageResponse`. Decode as a `google.protobuf.DescriptorProto`.
final $typed_data.Uint8List messageResponseDescriptor = $convert.base64Decode(
    'Cg9NZXNzYWdlUmVzcG9uc2USFgoGcm9vbUlkGAEgASgJUgZyb29tSWQSLgoLbWVzc2FnZVR5cG'
    'UYAiABKA4yDC5NZXNzYWdlVHlwZVILbWVzc2FnZVR5cGUSLgoHY29udGVudBgDIAEoCzIULmdv'
    'b2dsZS5wcm90b2J1Zi5BbnlSB2NvbnRlbnQSHgoKc2VuZGVyTmFtZRgEIAEoCVIKc2VuZGVyTm'
    'FtZRI8CgtzZW5kaW5nRGF0ZRgFIAEoCzIaLmdvb2dsZS5wcm90b2J1Zi5UaW1lc3RhbXBSC3Nl'
    'bmRpbmdEYXRlEigKD2JlbG9uZ3NUb1NlbmRlchgGIAEoCFIPYmVsb25nc1RvU2VuZGVy');

@$core.Deprecated('Use historyRequestDescriptor instead')
const HistoryRequest$json = {
  '1': 'HistoryRequest',
  '2': [
    {'1': 'roomId', '3': 1, '4': 1, '5': 9, '10': 'roomId'},
  ],
};

/// Descriptor for `HistoryRequest`. Decode as a `google.protobuf.DescriptorProto`.
final $typed_data.Uint8List historyRequestDescriptor = $convert.base64Decode(
    'Cg5IaXN0b3J5UmVxdWVzdBIWCgZyb29tSWQYASABKAlSBnJvb21JZA==');

@$core.Deprecated('Use emptyDescriptor instead')
const Empty$json = {
  '1': 'Empty',
};

/// Descriptor for `Empty`. Decode as a `google.protobuf.DescriptorProto`.
final $typed_data.Uint8List emptyDescriptor = $convert.base64Decode(
    'CgVFbXB0eQ==');

const $core.Map<$core.String, $core.dynamic> SupportChatServiceBase$json = {
  '1': 'SupportChatService',
  '2': [
    {'1': 'SendTextMessage', '2': '.TextMessageRequest', '3': '.Empty'},
    {'1': 'SendFileMessage', '2': '.FileMessageRequest', '3': '.Empty'},
    {'1': 'ReceiveMessage', '2': '.ReceiveRequest', '3': '.MessageResponse', '6': true},
    {'1': 'History', '2': '.HistoryRequest', '3': '.MessageResponse', '6': true},
  ],
};

@$core.Deprecated('Use supportChatServiceDescriptor instead')
const $core.Map<$core.String, $core.Map<$core.String, $core.dynamic>> SupportChatServiceBase$messageJson = {
  '.TextMessageRequest': TextMessageRequest$json,
  '.Empty': Empty$json,
  '.FileMessageRequest': FileMessageRequest$json,
  '.ReceiveRequest': ReceiveRequest$json,
  '.MessageResponse': MessageResponse$json,
  '.google.protobuf.Any': $0.Any$json,
  '.google.protobuf.Timestamp': $1.Timestamp$json,
  '.HistoryRequest': HistoryRequest$json,
};

/// Descriptor for `SupportChatService`. Decode as a `google.protobuf.ServiceDescriptorProto`.
final $typed_data.Uint8List supportChatServiceDescriptor = $convert.base64Decode(
    'ChJTdXBwb3J0Q2hhdFNlcnZpY2USLgoPU2VuZFRleHRNZXNzYWdlEhMuVGV4dE1lc3NhZ2VSZX'
    'F1ZXN0GgYuRW1wdHkSLgoPU2VuZEZpbGVNZXNzYWdlEhMuRmlsZU1lc3NhZ2VSZXF1ZXN0GgYu'
    'RW1wdHkSNQoOUmVjZWl2ZU1lc3NhZ2USDy5SZWNlaXZlUmVxdWVzdBoQLk1lc3NhZ2VSZXNwb2'
    '5zZTABEi4KB0hpc3RvcnkSDy5IaXN0b3J5UmVxdWVzdBoQLk1lc3NhZ2VSZXNwb25zZTAB');

