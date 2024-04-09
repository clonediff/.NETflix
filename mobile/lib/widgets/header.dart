import 'package:flutter/material.dart';
import 'package:mobile/constants/colors.dart';

class Header extends StatelessWidget implements PreferredSizeWidget {
  const Header({ super.key });

  @override
  Widget build(BuildContext context) {
    return AppBar(
      title: const Text(
        '.Netflix',
        style: TextStyle(
          color: Colors.red,
          fontWeight: FontWeight.w700,
          fontSize: 26
        ),
      ),
      actions: [
        IconButton(
          icon: const Icon(Icons.person, size: 26),
          color: Colors.white,
          onPressed: () { },
        ),
        IconButton(
          icon: const Icon(Icons.search, size: 26),
          color: Colors.white,
          onPressed: () { },
        ),
      ],
      backgroundColor: DotNetflixColors.headerBackgroundColor,
    );
  }

  @override
  Size get preferredSize => const Size.fromHeight(48);
}