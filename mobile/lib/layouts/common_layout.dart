import 'package:flutter/material.dart';
import 'package:mobile/widgets/bottom_navigation.dart';
import 'package:mobile/widgets/header.dart';

class CommonLayout extends StatelessWidget {
  const CommonLayout({super.key, required this.body});

  final Widget body;

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: const Header(),
      body: body,
      bottomNavigationBar: const BottomNavigation(),
    );
  }
}
