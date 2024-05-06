import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:mobile/bloc/loading/bloc.dart';
import 'package:mobile/bloc/loading/events.dart';
import 'package:mobile/bloc/loading/state_parser.dart';
import 'package:mobile/bloc/loading/states.dart';
import 'package:mobile/constants/colors.dart';
import 'package:mobile/widgets/bottom_navigation.dart';
import 'package:mobile/widgets/categorized_films.dart';
import 'package:mobile/widgets/header.dart';
import 'package:mobile/widgets/typed_films.dart';

class MainPage extends StatefulWidget {
  const MainPage({ super.key });
  
  @override
  State<StatefulWidget> createState() => _MainPageState();
}

class _MainPageState extends State<MainPage> {

  String _type = '';
  int _selectedPage = 0;

  void updatePage(int pageNumber, String type) {
    if (pageNumber == _selectedPage) return;
    setState(() {
      _type = type;
      _selectedPage = pageNumber;
    });
  }

  @override
  Widget build(BuildContext context) {
    context.read<LoadingBloc>().add(_selectedPage == 0
      ? LoadingAllFilmsEvent(builder: buildAllCategorizedFilms)
      : LoadingSearchedFilmsEvent(
          params: { 'type': _type }, 
          builder: (data) => TypedFilms(films: data)
        )
    );
    return Scaffold(
      appBar: const Header(),
      body: Container(
        padding: const EdgeInsets.only(left: 12, right: 12),
        color: DotNetflixColors.mainBackgroundColor,
        child: const BlocBuilder<LoadingBloc, LoadingStateBase>(builder: parseState)
      ),
      bottomNavigationBar: BottomNavigation(callback: updatePage)
    );
  }
}