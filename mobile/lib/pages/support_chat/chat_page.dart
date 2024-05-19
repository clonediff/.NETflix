
import 'dart:async';
import 'dart:convert';
import 'dart:io';

import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:grpc/grpc.dart' as $grpc;
import 'package:image_picker/image_picker.dart';
import 'package:intl/intl.dart';
import 'package:mime/mime.dart';
import 'package:mobile/bloc/loading/bloc.dart';
import 'package:mobile/bloc/loading/events.dart';
import 'package:mobile/bloc/loading/state_parser.dart';
import 'package:mobile/bloc/loading/states.dart';
import 'package:mobile/constants/colors.dart';
import 'package:mobile/constants/styles.dart';
import 'package:mobile/dto/chat_dto.dart';
import 'package:mobile/generated/support-chat.pbgrpc.dart';
import 'package:mobile/main.dart';
import 'package:mobile/services/session_service.dart';
import 'package:mobile/widgets/header.dart';

class ChatPageBuilder extends StatelessWidget {
  const ChatPageBuilder({super.key});

  ChatPage chatPageBuilderBuilder(ChatDto chat) {
    return ChatPage(chat: chat,);
  }

  @override
  Widget build(BuildContext context) {
    var roomId = ModalRoute.of(context)?.settings.arguments! as String;
    context.read<LoadingBloc>().add(LoadingChatPageEvent(builder: chatPageBuilderBuilder, roomId: roomId));
    return const BlocBuilder<LoadingBloc, LoadingStateBase>(builder: parseState);
  }
}

class ChatPage extends StatefulWidget {
  final ChatDto chat;

  const ChatPage({super.key, required this.chat});

  @override
  State<ChatPage> createState() => _ChatPageState();
}

class _ChatPageState extends State<ChatPage> {
  final _sessionDataProvider = getit<SessionDataProvider>();
  final _grpcSupportChatClient = SupportChatServiceClient(getit<$grpc.ClientChannel>());
  bool loadingCalled = false;
  List<MessageResponse> messages = [];

  @override
  void dispose() {
    widget.chat.receive.cancel();

    super.dispose();
  }

  Future<void> onTextSend(TextMessageRequest message) async {
    var token = 'Bearer ${await _sessionDataProvider.getJwtToken()}';
    await _grpcSupportChatClient.sendTextMessage(message,options: $grpc.CallOptions(metadata: {"Authorization": token}));
  }

  Future<void> onFileSend(FileMessageRequest file) async {
    var token = 'Bearer ${await _sessionDataProvider.getJwtToken()}';
    await _grpcSupportChatClient.sendFileMessage(file,options: $grpc.CallOptions(metadata: {"Authorization": token}));
  }

  @override
  Widget build(BuildContext context) {
    return StreamBuilder(
      stream: widget.chat.receive,
      builder: (context, receive) {
        messages.addAll(widget.chat.history.messages);
        List<Widget> children = [
          ChatMessagesList(messages: widget.chat.history.messages),
          ChatInput(onTextSend: onTextSend, onFileSend: onFileSend)
        ];
        if(receive.hasData) {
          messages.add(receive.data!);
        }
        return Scaffold(
          appBar: const Header(),
          backgroundColor: DotNetflixColors.mainBackgroundColor,
          body: Stack(
            children: children,
          ),
        );
      },
    );
  }
}

class ChatInput extends StatefulWidget {
  final Future<void> Function(TextMessageRequest message) onTextSend;
  final Future<void> Function(FileMessageRequest message) onFileSend;

  const ChatInput({super.key, required this.onTextSend, required this.onFileSend});

  @override
  State<ChatInput> createState() => _ChatInputState();
}

class _ChatInputState extends State<ChatInput> {

  final TextEditingController _textController = TextEditingController();
  Icon imagesCount = const Icon(Icons.filter, color: Colors.white);
  List<File> images = [];

  @override
  Widget build(BuildContext context) {
    var width = MediaQuery.of(context).size.width * 0.7;
    return Container(
      alignment: Alignment.bottomCenter,
      padding: const EdgeInsets.only(top: 10),
      child: Container(
        color: DotNetflixColors.searchBackgroundColor,
        child: Row(
          mainAxisAlignment: MainAxisAlignment.spaceBetween,
          children: [
            Container(
              padding: const EdgeInsets.only(left: 10),
              child: InkWell(
                onTap: () => _showPicker(context: context),
                child: _showImagesCount(),
              ),
            ),
            const SizedBox(width: 15),
            SizedBox(
              width: width,
              child: TextFormField(
                controller: _textController,
                style: DotNetflixTextStyles.mainTextStyle,
                maxLines: 1,
                textAlign: TextAlign.start,
              ),
            ),
            const SizedBox(width: 15),
            Container(
              padding: const EdgeInsets.only(right: 10),
              child: InkWell(
                child: const Icon(Icons.send, color: Colors.white),
                onTap: () => _sendMessage(),
              ),
            ),
          ],
        ),
      ),
    );
  }

  Icon _showImagesCount(){
    var icon = switch(images.length){
      1 => Icons.filter_1,
      2 => Icons.filter_2,
      3 => Icons.filter_3,
      4 => Icons.filter_4,
      5 => Icons.filter_5,
      _ => Icons.filter,
    };
    setState(() {
      imagesCount = Icon(icon, color: Colors.white);
    });
    return imagesCount;
  }

  void _sendMessage() async {
    var text = _textController.text;
    var imageList = [...images];

    setState(() {
      _textController.clear();
      images.clear();
    });

    if(text.isNotEmpty) {
      var chatMessage = TextMessageRequest(content: text, roomId: "");
      widget.onTextSend(chatMessage);
    }

    if(imageList.isNotEmpty) {
      var messages = imageList.map((file) {
        var bytes = file.readAsBytesSync();

        return FileMessageRequest(roomId: "", content: bytes, contentType: lookupMimeType(file.path));
      });

      for (var element in messages) {
        await widget.onFileSend(element);
      }
    }
  }

  Future _getImage() async {
    final picker = ImagePicker();
    final pickedFiles = await picker.pickMultiImage(limit: 5);
    final xFiles = pickedFiles;
    setState(() {
    if (xFiles.isNotEmpty) {
        images = xFiles.map((e) => File(e.path)).toList();
      _showImagesCount();
    }
    else {
      ScaffoldMessenger.of(context).showSnackBar(
          const SnackBar(
            content: Text('Nothing is selected',
                style: TextStyle(color: Colors.white)),
            backgroundColor: DotNetflixColors.searchBackgroundColor,
          )
      );
    }
    });
  }

  void _showPicker({required BuildContext context}) {
    showModalBottomSheet(
      isScrollControlled: true,
      useSafeArea: true,

      context: context,
      builder: (BuildContext context) {
        return SafeArea(
          child: ListTile(
            tileColor: DotNetflixColors.buttonColor,
            leading: const Icon(Icons.photo_library, color: Colors.white,),
            title: const Text('Photo Library', style: DotNetflixTextStyles.loginStyle,),
            onTap: () {
              _getImage();
              Navigator.of(context).pop();
            },
          ),
        );
      },
    );
  }

}

class ChatMessagesList extends StatelessWidget {
  final List<MessageResponse> messages;

  const ChatMessagesList({super.key, required this.messages});

  @override
  Widget build(BuildContext context) {
    return ListView.builder(
      scrollDirection: Axis.vertical,
      padding: const EdgeInsets.only(top: 10,bottom: 10),
      shrinkWrap: true,
      itemCount: messages.length,
      itemBuilder: (context, index) {

        var message = messages[index];
        var messageText = message.messageType == MessageType.text
            ? Text(utf8.decode(message.content.value), style: DotNetflixTextStyles.mainTextStyle,)
            : const Text("");

        var dateFormat = DateFormat('yyyy-MM-dd hh:mm')
            .format(DateTime.fromMillisecondsSinceEpoch((message.sendingDate.seconds * 1000).toInt()));

        Widget image = const Center(child: CircularProgressIndicator(color: Colors.white));
        if(message.messageType != MessageType.text) {
          var deserialized = json.decode(utf8.decode(message.content.value));
          image = Image.memory(base64.decode(deserialized['Bytes']), width: 120, height: 160, fit: BoxFit.cover,);
        }
        else {
          image = const Text('Не удалось загрузить данные', style: TextStyle(color: Colors.white));
        }


        var content = Column(
          children: [
            message.messageType == MessageType.text
                ? messageText
                : image,
            Text(
              dateFormat,
              style: const TextStyle(color: Colors.grey, fontSize: 10),
              textAlign: TextAlign.right,
            )
          ],
        );

        return Container(
          padding: const EdgeInsets.only(left: 14,right: 14,top: 10,bottom: 10),
          child: Align(
            alignment: (message.belongsToSender ? Alignment.topRight : Alignment.topLeft),
            child: Container(
              decoration: BoxDecoration(
                borderRadius: BorderRadius.circular(20),
                color: (message.belongsToSender ? DotNetflixColors.receiverMessageColor : DotNetflixColors.senderMessageColor),
                border: Border.all(color: Colors.black)
              ),
              padding: const EdgeInsets.all(16),
              child: content,
            ),
          ),
        );
      },
    );
  }
}