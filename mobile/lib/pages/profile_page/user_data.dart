import 'package:flutter/material.dart';
import 'package:mobile/pages/profile_page/profile_page.dart';

class UserData extends ChangeNotifier {
  final User? user;

  UserData({required this.user});

  void modifyUser(void Function(User) changeUser) {
    if (user == null) return;
    changeUser(user!);
    notifyListeners();
  }
}
