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

  final List<Widget> _pages = [const MainPage(), const SearchPage()];
  int selectedPage = 0;

  void updatePage(int pageNumber) {
    if (pageNumber == selectedPage) return;
    setState(() => selectedPage = pageNumber);
  }

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      home: BlocProvider(
        create: (_) => LoadingBloc(),
        child: Scaffold(
          appBar: const Header(),
          body: _pages[selectedPage],
          bottomNavigationBar: BottomNavigation(callback: updatePage)
        ),
      )
    );
  }
}