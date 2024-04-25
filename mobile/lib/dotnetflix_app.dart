import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:mobile/bloc/loading/bloc.dart';
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

  int _selectedPage = 0;
  List<Widget> _pages = [const MainPage(), const SearchPage(type: '')];

  void updatePage(int pageNumber, String type) {
    if (pageNumber == _selectedPage) return;
    if (type != '') {
      setState(() => _pages = [_pages[0], SearchPage(type: type)]);
    }
    setState(() => _selectedPage = pageNumber);
  }

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      home: BlocProvider(
        create: (_) => LoadingBloc(),
        child: Scaffold(
          appBar: const Header(),
          body: _pages[_selectedPage == 0 ? 0 : 1],
          bottomNavigationBar: BottomNavigation(callback: updatePage)
        ),
      )
    );
  }
}