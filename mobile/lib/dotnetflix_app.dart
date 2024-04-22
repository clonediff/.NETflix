import 'package:flutter/material.dart';
import 'package:mobile/pages/main_page.dart';
import 'package:mobile/pages/search_page.dart';
import 'package:mobile/widgets/bottom_navigation.dart';
import 'package:mobile/widgets/header.dart';

class DotNetflixApp extends StatefulWidget {
  const DotNetflixApp({ super.key });
  
  @override
  State<StatefulWidget> createState() => _DotNetflixAppState();
}

class _DotNetflixAppState extends State<DotNetflixApp> {

  final List<Widget> _pages = [MainPage(), SearchPage()];
  int selectedPage = 0;

  void updatePage(int pageNumber) {
    if (pageNumber == selectedPage) return;
    setState(() => selectedPage = pageNumber);
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: const Header(),
      body: _pages[selectedPage],
      bottomNavigationBar: BottomNavigation(callback: updatePage)
    );
  }
}