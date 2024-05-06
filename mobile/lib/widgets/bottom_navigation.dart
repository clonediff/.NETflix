import 'package:flutter/material.dart';
import 'package:mobile/constants/colors.dart';

class BottomNavigation extends StatefulWidget {
  const BottomNavigation({ super.key, required this.callback });

  final void Function(int, String) callback;

  @override
  State<StatefulWidget> createState() => _BottomNavigationState();
}

class _BottomNavigationState extends State<BottomNavigation> {

  int _selectedIndex = 0;
  final _types = ['movie', 'tv-series', 'cartoon', 'anime'];

  void updateSelectedIndex(int index) {
    setState(() {
      _selectedIndex = index;
    });
    widget.callback(index, index != 0 ? _types[index - 1] : '');
  }

  @override
  Widget build(BuildContext context) {
    return BottomNavigationBar(
      items: const [
        BottomNavigationBarItem(
          icon: Icon(Icons.home),
          label: 'Главная'
        ),
        BottomNavigationBarItem(
          icon: Icon(Icons.movie_rounded),
          label: 'Фильмы',
        ),
        BottomNavigationBarItem(
          icon: Icon(Icons.tv_rounded),
          label: 'Сериалы',
        ),
        BottomNavigationBarItem(
          icon: Icon(Icons.local_movies),
          label: 'Мульты',
        ),
        BottomNavigationBarItem(
          icon: Icon(Icons.animation),
          label: 'Аниме',
        )
      ],
      type: BottomNavigationBarType.fixed,
      currentIndex: _selectedIndex,
      backgroundColor: DotNetflixColors.headerBackgroundColor,
      selectedFontSize: 12,
      unselectedFontSize: 10,
      selectedItemColor: Colors.red,
      unselectedItemColor: Colors.white,
      onTap: updateSelectedIndex,
    );
  }
}