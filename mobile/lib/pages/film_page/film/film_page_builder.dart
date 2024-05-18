import 'package:flutter/material.dart';
import 'package:dart_amqp/dart_amqp.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:mobile/bloc/loading/bloc.dart';
import 'package:mobile/bloc/loading/events.dart';
import 'package:mobile/bloc/loading/state_parser.dart';
import 'package:mobile/bloc/loading/states.dart';
import 'package:mobile/models/film_info.dart';
import 'package:mobile/pages/film_page/persons/persons_page.dart';
import 'film_page.dart';

class FilmPageBuilder extends StatelessWidget {
  const FilmPageBuilder({super.key});

  FilmPage filmPageBuilder(FilmInfo film) {
    return FilmPage(film: film);
  }

  @override
  Widget build(BuildContext context) {
    var filmId = ModalRoute.of(context)?.settings.arguments! as int;
    context.read<LoadingBloc>().add(LoadingFilmByIdEvent(builder: filmPageBuilder, filmId: filmId));
    return const BlocBuilder<LoadingBloc, LoadingStateBase>(builder: parseState);
  }
}

class FilmPage extends StatefulWidget{
  final FilmInfo film;
  final Client client = Client(
    settings: ConnectionSettings(
      host: '192.168.137.1',
      authProvider: const PlainAuthenticator('admin', 'admin')
    )
  );

  FilmPage({super.key, required this.film});

  @override
  State<StatefulWidget> createState() => _FilmPageState();
}

class _FilmPageState extends State<FilmPage>{
  int selectedPage = 0;
  bool firstLaunch = true;
  late List<Widget> pages = [
    MainFilmPage(film: widget.film, onSelectedPage: onSelectedPage, client: widget.client, isFirstLaunch: () => firstLaunch),
    PersonsPage(
        persons: Map.fromEntries(widget.film.persons.entries.where((element) => element.key == 'актеры' || element.key == 'актеры дубляжа')),
        title: 'Актёры',
        onSelectedPage: onSelectedPage),
    PersonsPage(
        persons: Map.fromEntries(widget.film.persons.entries.where((element) => element.key != 'актеры' && element.key != 'актеры дубляжа')),
        title: 'Съёмочная группа',
        onSelectedPage: onSelectedPage),
  ];

  onSelectedPage(int page) {
    setState(() {
      selectedPage = page;
      firstLaunch = false;
    });
  }

  @override
  Widget build(BuildContext context) {
    return pages[selectedPage];
  }
}