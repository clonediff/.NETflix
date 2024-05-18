
import 'package:grpc/grpc.dart';
import 'package:mobile/generated/support-chat.pbgrpc.dart';

class ChatDto {
  final ResponseStream<MessageResponse> history;
  final ResponseStream<MessageResponse> receive;

  ChatDto({required this.history, required this.receive});
}