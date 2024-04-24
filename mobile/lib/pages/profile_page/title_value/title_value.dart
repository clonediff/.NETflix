import 'package:flutter/material.dart';

class TitleValue extends StatelessWidget {
  final String title;
  final TextStyle? titleStyle;
  final Widget value;
  final IconData? icon;

  const TitleValue({
    super.key,
    required this.title,
    required this.value,
    this.icon,
    this.titleStyle,
  });

  @override
  Widget build(BuildContext context) {
    return ListTile(
      leading: icon == null ? null : Icon(icon),
      title: Text(
        title,
        style: titleStyle,
      ),
      subtitle: value,
    );
  }
}
