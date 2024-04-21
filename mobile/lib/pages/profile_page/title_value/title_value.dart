import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:mobile/pages/profile_page/user_data.dart';

class TitleValue extends StatelessWidget {
  final String title;
  final Widget value;
  final IconData? icon;

  const TitleValue({
    super.key,
    required this.title,
    required this.value,
    this.icon,
  });

  @override
  Widget build(BuildContext context) {
    return ListTile(
      leading: icon == null ? null : Icon(icon),
      title: Text(title),
      subtitle: value,
    );
  }
}
