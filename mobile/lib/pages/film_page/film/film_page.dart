import 'dart:async';
import 'package:flag/flag.dart';
import 'package:flutter/material.dart';
import 'package:mobile/constants/colors.dart';
import 'package:mobile/constants/styles.dart';
import 'package:mobile/models/film_info.dart';
import 'package:mobile/widgets/header.dart';

class MainFilmPage extends StatelessWidget{
  final FilmInfo film;
  final Function(int pageNumber) onSelectedPage;

  const MainFilmPage({
    super.key,
    required this.film,
    required this.onSelectedPage
  });

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: const Header(),
      body: Container(
          padding: const EdgeInsets.only(left: 12, right: 12, top: 5),
          color: DotNetflixColors.mainBackgroundColor,
          child: SingleChildScrollView(
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.center,
              children: [
                PosterImage(film: film),
                Caption(film: film),
                MainInfo(film: film),
                MoreInfo(film: film),
                Persons(persons: film.persons.entries
                    .where((element) => element.key == 'актеры' || element.key == 'актеры дубляжа')
                    .map((e) => e.value)
                    .expand((element) => element)
                    .take(10)
                    .toList(),
                    title: 'Актёры',
                    onSelectedPage: onSelectedPage),
                const Padding(padding: EdgeInsets.only(top: 20)),
                Persons(persons: film.persons.entries
                    .where((element) => element.key != 'актеры' && element.key != 'актеры дубляжа')
                    .map((e) => e.value)
                    .expand((element) => element)
                    .take(10)
                    .toList(),
                    title: 'Съёмочная группа',
                    onSelectedPage: onSelectedPage),
              ],
            ),
          )
      ),
    );
  }
}

class PosterImage extends StatelessWidget{
  final FilmInfo film;

  const PosterImage({super.key, required this.film});

  @override
  Widget build(BuildContext context) {
    return Row(
      mainAxisAlignment: MainAxisAlignment.center,
      children: [
        ClipRRect(
          borderRadius: BorderRadius.circular(12.0),
          child: Image.network(
            film.posterUrl!,
            height: 300,
          ),
        )
      ],
    );
  }

}

class Caption extends StatelessWidget{
  final FilmInfo film;

  const Caption({super.key, required this.film});

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.only(left: 30, right: 30, top: 10),
      child: Row(
        mainAxisAlignment: MainAxisAlignment.spaceEvenly,
        children: [
          Flexible(
            child: Text(
              film.name,
              style: DotNetflixTextStyles.filmNameStyle,
            ),
          ),
          ClipRRect(
            borderRadius: BorderRadius.circular(2.0),
            child: Text(
              '${film.ageRating}+',
              style: DotNetflixTextStyles.filmAgeRatingStyle
            ),
          ),
        ],
      ),
    );
  }
}

class MainInfo extends StatelessWidget{
  final FilmInfo film;

  const MainInfo({super.key, required this.film});

  FlagsCode getFlagCodeFromCountry(Country country){
    return switch(country.name){
      'Япония' => FlagsCode.JP,
      'Россия' => FlagsCode.RU,
      'США' => FlagsCode.US,
      'Англия' => FlagsCode.GB,
      'Франция' => FlagsCode.FR,
      'СССР' => FlagsCode.RU,
      _ => FlagsCode.US
    };
  }

  Text getSeasonsInfo(List<Season> seasonsInfo)
    => Text('${seasonsInfo.isNotEmpty ? 'Cезонов: ${seasonsInfo.last.number} по' : ''} '
        '${seasonsInfo.isNotEmpty ? '${seasonsInfo.first.episodesCount} эп. по' : ''} '
        '~${film.movieLength} мин.',style: DotNetflixTextStyles.mainTextStyle);

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.only(left: 10, top: 10),
      child: Column(
        mainAxisAlignment: MainAxisAlignment.spaceEvenly,
        children: [
          Row(
            mainAxisAlignment: MainAxisAlignment.start,
            children: [
              Flag.fromCode(
                getFlagCodeFromCountry(film.countries.first),
                height: 12,
                width: 18,
                fit: BoxFit.fill,
              ),
              const Padding(padding: EdgeInsets.only(left: 10)),
              Expanded(
                child: SizedBox(
                    height: 25,
                    child: ListView.builder(
                        scrollDirection: Axis.horizontal,
                        itemCount: film.countries.length,
                        itemBuilder: (context, index) {
                          if(index < film.countries.length-1) {
                            return Text('${film.countries[index].name}, ', style: DotNetflixTextStyles.mainTextStyle);
                          } else {
                            return Text('${film.countries[index].name}, ${film.year} г.', style: DotNetflixTextStyles.mainTextStyle);
                          }
                        })
                ),
              ),
            ],
          ),
          Row(
            children: [
              const Icon(Icons.live_tv_outlined, color: Colors.white, size: 20),
              const Padding(padding: EdgeInsets.only(left: 5)),
              Flexible(
                child: getSeasonsInfo(film.seasonsInfo),
              )
            ],
          ),
          Row(
            children: [
              const Icon(Icons.movie_outlined, color: Colors.white, size: 20),
              const Padding(padding: EdgeInsets.only(left: 10)),
              Flexible(
                  child: Text(
                      '${film.type == 'movie' ? 'Фильм' : 'Сериал'}, ${film.year < DateTime.now().year ? 'вышел' : 'выходит'}.',
                      style: DotNetflixTextStyles.mainTextStyle
                  )
              )
            ],
          ),
          Row(
            children: [
              const Icon(Icons.book_outlined, color: Colors.white, size: 20),
              const Padding(padding: EdgeInsets.only(left: 10)),
              Expanded(
                child: SizedBox(
                    height: 25,
                    child: ListView.builder(
                        scrollDirection: Axis.horizontal,
                        itemCount: film.genres.length,
                        itemBuilder: (context, index) {
                          if(index < film.genres.length-1) {
                            return Text('${film.genres[index]}, ', style: DotNetflixTextStyles.mainTextStyle);
                          } else {
                            return Text('${film.genres[index]}.', style: DotNetflixTextStyles.mainTextStyle);
                          }
                        })
                ),
              )
            ],
          ),
          Row(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              const Icon(Icons.library_books, color: Colors.white, size: 20),
              const Padding(padding: EdgeInsets.only(left: 10)),
              Flexible(child: ShortDescription(film: film))
            ],
          )
        ],
      ),
    );
  }
}

class MoreInfo extends StatefulWidget{
  final FilmInfo film;

  const MoreInfo({super.key, required this.film});

  @override
  State<StatefulWidget> createState() => _MoreInfoState();
}

class _MoreInfoState extends State<MoreInfo> {
  bool _customIcon = false;

  final ratingStyle = const TextStyle(
      color: Colors.amberAccent,
      fontSize: 16,
      fontWeight: FontWeight.w400
  );

  @override
  Widget build(BuildContext context) {
    return SizedBox(
      child: ExpansionTile(
        title: const Text('Больше информации', style: DotNetflixTextStyles.mainTextStyle,),
        trailing: Icon(_customIcon ? Icons.arrow_drop_down_circle : Icons.arrow_drop_down),
        onExpansionChanged: (bool expanded){
          setState(() => _customIcon = expanded);
        },
        children: [
          Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              Description(film: widget.film),
              FeesInfo(title: 'Кассовые сборы в мире: ', fees: widget.film.fees?.world ?? ''),
              FeesInfo(title: 'Кассовые сборы в России: ', fees: widget.film.fees?.russia ?? ''),
              FeesInfo(title: 'Кассовые сборы в США: ', fees: widget.film.fees?.usa ?? ''),
              Row(
                children: [
                  const Text('Рейтинг: ', style: DotNetflixTextStyles.mainTextStyle),
                  Text('${widget.film.rating.toString()}/10', style: ratingStyle,)
                ],
              ),
            ],
          ),
        ],
      ),
    );
  }
}

class FeesInfo extends StatelessWidget{
  final String title;
  final String fees;
  final feesStyle = const TextStyle(
    color: Colors.green,
    fontSize: 16,
    fontWeight: FontWeight.w400,
  );

  const FeesInfo({super.key, required this.title, required this.fees});

  @override
  Widget build(BuildContext context) {
    return Row(
      children: [
        Text(title, style: DotNetflixTextStyles.mainTextStyle),
        Flexible(
            child: Text('$fees\$',
                style: feesStyle,
                overflow: TextOverflow.ellipsis
            )
        )
      ],
    );
  }
}

class Description extends StatelessWidget{
  final FilmInfo film;

  const Description({super.key, required this.film});
  @override
  Widget build(BuildContext context) {
    return Row(
      children: [
        Flexible(
            child: Text('Описание: ${film.description ?? ''}', style: DotNetflixTextStyles.mainTextStyle,)
        ),
      ],
    );
  }

}

class ShortDescription extends StatelessWidget{
  final FilmInfo film;

  const ShortDescription({super.key, required this.film});

  @override
  Widget build(BuildContext context) {
    return Text(
        film.shortDescription ?? '-',
        style: DotNetflixTextStyles.mainTextStyle
    );
  }
}

class Persons extends StatelessWidget{
  final List<Person> persons;
  final String title;
  final Function(int pageNumber) onSelectedPage;

  const Persons({
    super.key,
    required this.persons,
    required this.title,
    required this.onSelectedPage
  });

  void goToSelectedPage(BuildContext context, int page){
    onSelectedPage(page);
  }

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        Padding(
          padding: const EdgeInsets.only(bottom: 8),
          child: Row(
            mainAxisAlignment: MainAxisAlignment.spaceBetween,
            children: [
              Flexible(child: Text('$title: ', style: DotNetflixTextStyles.mainTextStyle)),
              Material(
                animationDuration: const Duration(seconds: 1),
                borderRadius: const BorderRadius.all(Radius.circular(5)),
                color: DotNetflixColors.buttonColor,
                child: InkWell(
                  child: const Text('Больше информации >', style: DotNetflixTextStyles.mainTextStyle),
                  onTap: () {
                    Timer(const Duration(seconds: 1),() => goToSelectedPage(context, title == 'Актёры' ? 1 : 2));
                  },
                ),
              )
            ],
          ),
        ),
        SizedBox(
          height: 210,
          child: ListView.builder(
            scrollDirection: Axis.horizontal,
            itemCount: persons.length,
            itemBuilder: (context, index) {
              var person = persons[index];
              var photo = (person.photo ?? '');
              var image = Image.network(photo, height: 160, width: 120, fit: BoxFit.cover);
              return PersonInfo(person: person, image: image) ;
            }
          ),
        ),
      ],
    );
  }
}

class PersonInfo extends StatelessWidget{
  final Image image;
  final Person person;

  const PersonInfo({super.key, required this.image, required this.person});

  @override
  Widget build(BuildContext context) {
    return Container(
      decoration: const BoxDecoration(
        borderRadius: BorderRadius.horizontal(
          left: Radius.circular(5),
          right: Radius.circular(5)
        ),
        border: Border(
          top: BorderSide(
              color: Colors.blueAccent
          ),
          bottom: BorderSide(
            color: Colors.blueAccent,
          ),
        ),
        color: DotNetflixColors.headerBackgroundColor,
      ),
      child: Padding(
        padding: const EdgeInsets.only(left: 4.0, right: 4.0, top: 4.0),
        child: Column(
          children: [
            image,
            SizedBox(
              width: 120,
              child: Text(
                person.name,
                style: DotNetflixTextStyles.titleStyle,
                textAlign: TextAlign.center,
                softWrap: true,
                overflow: TextOverflow.ellipsis,
              )
            ),
            SizedBox(
              width: 120,
              child: Text(
                person.profession,
                style: DotNetflixTextStyles.subtitleStyle,
                textAlign: TextAlign.center,
                softWrap: true,
                overflow: TextOverflow.ellipsis,
              ),
            )
          ],
        ),
      ),
    );
  }
}

class TrailersAndPosters extends StatelessWidget{
  final List<PosterMetaData> posters;
  final List<TrailerMetaData> trailers;

  const TrailersAndPosters({super.key, required this.posters, required this.trailers});

  @override
  Widget build(BuildContext context) {
    // TODO: implement build
    throw UnimplementedError();
  }
}