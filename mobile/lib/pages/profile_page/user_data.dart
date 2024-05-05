import 'package:flutter/material.dart';
import 'package:mobile/models/all_for_freezed.dart';

class UserData extends ChangeNotifier {
  UserDto? user;

  UserData({required this.user});

  void modifyUser(UserDto Function(UserDto) changeUser) {
    if (user == null) return;
    user = changeUser(user!);
    notifyListeners();
  }
}
