import 'package:flutter/material.dart';
import 'package:mobile/mocks/film_info.dart';
import 'package:mobile/pages/film_page/persons/persons_page.dart';
import 'main_film_page.dart';

class FilmPage extends StatefulWidget{
  const FilmPage({super.key});

  @override
  State<StatefulWidget> createState() => _FilmPageState();
}

class _FilmPageState extends State<FilmPage>{
  late Person person1;
  late Person person2;
  late Person actor;
  late Map<String, List<Person>> persons;
  late FilmInfo film;
  late int selectedPage = 0;
  late List<Widget> pages;

  @override
  void initState() {
    super.initState();
    person1 = Person(name: 'Хаяо Миядзаки', photo: 'https://avatars.mds.yandex.net/get-kinopoisk-image/10812607/f0e85cab-513b-42e2-9862-4f441e044731/1920x', profession: 'Режиссёр');
    person2 = Person(name: 'Диана Уинн Джонс', photo: 'https://avatars.mds.yandex.net/get-kinopoisk-image/1600647/f1335ec8-7682-4d05-b0f0-7e043561e054/1920x', profession: 'Сценарист');
    actor = Person(name: 'Тиэко Байсё', photo: 'https://avatars.mds.yandex.net/get-kinopoisk-image/1773646/8a887dc0-db2a-4a6e-829e-d0c2fbe40dd3/1920x', profession: 'Актриса');
    persons = {
      'Режиссёр': [
        person1,
        person2,
      ],
      'Сценарий' : [
        person1,
        person2,
      ],
      'Продюсер': [
        person1
      ],
      'Оператор': [
        person1
      ],
      'Композитор': [
        person1
      ],
      'Художник': [
        person1
      ],
      'Монтаж': [
        person1,
        person2,
        person1,
        person2,
        person1
      ],
      'Актеры' : [
        actor,
        person1,
        actor,
        person2,
        person1
      ]
    };
    film = FilmInfo(id: 1,
        name: 'Ходячий замок',
        year: 2004,
        description: 'Злая ведьма заточила 18-летнюю Софи в тело старухи. Девушка-бабушка бежит из города куда глаза глядят и встречает удивительный дом на ножках, где знакомится с могущественным волшебником Хаулом и демоном Кальцифером. Кальцифер должен служить Хаулу по договору, условия которого он не может разглашать. Девушка и демон решают помочь друг другу избавиться от злых чар.',
        shortDescription: 'Короткое описание',
        slogan: '—',
        rating: 9.5,
        movieLength: 119,
        ageRating: 6,
        posterUrl: 'https://avatars.mds.yandex.net/get-kinopoisk-image/4303601/2db629ae-04c6-48ea-9738-0874cdf67546/1920x',
        type: 'Фильм',
        category: '',
        budget: '\$24 000 000',
        fees: Fees(world: '\$236 214 446', russia: '\$82 500', usa: '\$5 576 743'),
        countries: [ Country(name: 'Япония', latitude: 0, longitude: 0) ],
        genres: ['аниме', 'мультфильм', 'фэнтези', 'мелодрама', 'приключения'],
        seasonsInfo: [ Season(number: 1, episodesCount: 1)],
        trailersMetaData: [ Trailer(trailerUrl: '')],
        postersMetaData: [
          Poster(posterUrl: 'https://www.kinopoisk.ru/picture/1851817/'),
          Poster(posterUrl: 'https://www.kinopoisk.ru/picture/828194/'),
          Poster(posterUrl: 'https://avatars.mds.yandex.net/get-kinopoisk-image/4303601/2db629ae-04c6-48ea-9738-0874cdf67546/1920x')],
        professions: persons);

    pages = [
      MainFilmPage(film: film, onSelectedPage: onSelectedPage),
      PersonsPage(
          persons: Map.fromEntries(film.professions.entries.where((element) => element.key == 'Актеры')),
          title: 'Актёры',
          onSelectedPage: onSelectedPage),
      PersonsPage(
          persons: Map.fromEntries(film.professions.entries.where((element) => element.key != 'Актеры')),
          title: 'Съёмочная группа',
          onSelectedPage: onSelectedPage),
    ];
  }

  onSelectedPage(int page) {
    setState(() {
      selectedPage = page;
    });
  }

  @override
  Widget build(BuildContext context) {
    return pages[selectedPage];
  }
}