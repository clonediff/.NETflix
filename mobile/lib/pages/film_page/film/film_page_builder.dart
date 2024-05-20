import 'package:flutter/material.dart';
import 'package:dart_amqp/dart_amqp.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:mobile/bloc/loading/bloc.dart';
import 'package:mobile/bloc/loading/events.dart';
import 'package:mobile/bloc/loading/state_parser.dart';
import 'package:mobile/bloc/loading/states.dart';
import 'package:mobile/models/film_info.dart';
import 'package:mobile/navigation/navigation_routes.dart';
import 'package:mobile/main.dart';
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
      host: apiBaseIp,
      authProvider: const PlainAuthenticator('admin', 'admin')
    )
  );

  FilmPage({super.key, required this.film});

  @override
  State<StatefulWidget> createState() => _FilmPageState();
}

class _FilmPageState extends State<FilmPage>{
  bool firstLaunch = true;

  late List<Map<String, List<Person>>> personsPages = [
    Map.fromEntries(widget.film.persons.entries.where((element) => element.key == 'актеры' || element.key == 'актеры дубляжа')),
    Map.fromEntries(widget.film.persons.entries.where((element) => element.key != 'актеры' && element.key != 'актеры дубляжа')),
  ];

  onSelectedPage(int page, BuildContext context) {
    Navigator.of(context).pushNamed(NavigationRoutes.persons, arguments: personsPages[page]);
    setState(() => firstLaunch = false);
  }

  @override
  Widget build(BuildContext context) {
    return MainFilmPage(film: widget.film, onSelectedPage: onSelectedPage, client: widget.client, isFirstLaunch: () => firstLaunch);
  }
}