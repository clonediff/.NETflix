import 'package:flutter/material.dart';

class USettingsFooter extends StatelessWidget {
  final String linkText;
  final void Function() navTo;

  const USettingsFooter({
    super.key,
    required this.linkText,
    required this.navTo,
  });

  @override
  Widget build(BuildContext context) {
    return Column(
      crossAxisAlignment: CrossAxisAlignment.start,
      children: [
        const Divider(
          color: Colors.black,
          height: 2,
        ),
        Container(
          margin: const EdgeInsets.only(bottom: 20),
          child: InkWell(
            onTap: navTo,
            child: Text(
              linkText,
              style: const TextStyle(
                color: Colors.white,
              ),
            ),
          ),
        ),
      ],
    );
  }
}
