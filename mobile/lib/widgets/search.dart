import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:mobile/bloc/loading/bloc.dart';
import 'package:mobile/bloc/loading/events.dart';
import 'package:mobile/bloc/loading/state_parser.dart';
import 'package:mobile/bloc/loading/states.dart';
import 'package:mobile/constants/colors.dart';
import 'package:mobile/models/film_for_main_page.dart';
import 'package:mobile/navigation/navigation_routes.dart';

class SearchDialog extends StatefulWidget {
  const SearchDialog({ super.key });
  
  @override
  State<StatefulWidget> createState() => _SearchDialogState();
}

class _SearchDialogState extends State<SearchDialog> {

  final Map<String, dynamic> formData = {};
  int selectedPage = 0;

  void updatePage(int pageNumber) {
    setState(() => selectedPage = pageNumber);
  }

  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      scrollable: true,
      title: const Text(
        'Поиск',
        style: TextStyle(
          color: Colors.red,
          fontWeight: FontWeight.w600
        )
      ),
      content: selectedPage == 0 
        ? SearchForm(callback: (x) {
            if (x != 0) {
              context.read<LoadingBloc>().add(LoadingSearchedFilmsEvent(
                params: formData,
                builder: (films) => SearchResults(films: films)
              ));
            }
            updatePage(x);
          }) 
        : const BlocBuilder<LoadingBloc, LoadingStateBase>(builder: parseState),
      backgroundColor: DotNetflixColors.headerBackgroundColor,
      shape: const RoundedRectangleBorder(borderRadius: BorderRadius.all(Radius.circular(10)))
    );
  }
}

class SearchForm extends StatefulWidget {
  const SearchForm({ super.key, required this.callback });

  final void Function(int) callback;

  @override
  State<StatefulWidget> createState() => _SearchFormState();
}

class _SearchFormState extends State<SearchForm> {

  final _formKey = GlobalKey<FormState>();

  @override
  Widget build(BuildContext context) {
    final ancestor = context.findAncestorStateOfType<_SearchDialogState>()!;
    return Form(
      onChanged: () => _formKey.currentState!.save(),
      key: _formKey,
      child: Column(
        children: [
          SearchFormField(
            label: 'Название',
            onSaved: (value) => ancestor.formData['name'] = value!,
            validator: (value) {
              return ancestor.formData.entries.every((x) => x.value.toString().isEmpty)
                ? 'Введите название фильма'
                : null;
            }
          ),
          ExpansionTile(
            title: const Text(
              'Дополнительные параметры',
              style: TextStyle(color: Colors.white)
            ),
            iconColor: Colors.red,
            collapsedIconColor: Colors.red,
            children: [
              SearchFormField(
                label: 'Год выхода',
                onSaved: (value) => ancestor.formData['year'] = int.tryParse(value!),
                keyboardType: TextInputType.number,
                validator: (value) {
                  final parsed = int.tryParse(value!);
                  return value.isNotEmpty && (parsed == null || 1900 > parsed || parsed > 2100)
                    ? 'Введите значение между 1900 и 2100'
                    : null;
                },
              ),
              SearchFormField(label: 'Страна производства', onSaved: (value) => ancestor.formData['country'] = value!),
              SearchFormField(label: 'Жанры', onSaved: (value) => ancestor.formData['genres'] = value!),
              SearchFormField(label: 'Актёры', onSaved: (value) => ancestor.formData['actors'] = value!),
              SearchFormField(label: 'Режиссёр', onSaved: (value) => ancestor.formData['director'] = value!)
            ]
          ),
          TextButton(
            onPressed: () {
              if (_formKey.currentState!.validate()) {
                widget.callback(1);
              }
            },
            child: const Text(
              'Найти',
              style: TextStyle(
                color: Colors.red,
                fontWeight: FontWeight.w600
              )
            )
          )
        ]
      )
    );
  }
}

class SearchFormField extends StatelessWidget {
  const SearchFormField({
    super.key,
    required this.label,
    required this.onSaved,
    this.keyboardType,
    this.validator
  });

  final void Function(String?)? onSaved;
  final String label;
  final TextInputType? keyboardType;
  final String? Function(String?)? validator;

  @override
  Widget build(BuildContext context) {
    return TextFormField(
      validator: validator,
      onSaved: onSaved,
      style: const TextStyle(color: Colors.white),
      cursorColor: Colors.white,
      cursorErrorColor: Colors.red,
      decoration: InputDecoration(
        labelText: label,
        labelStyle: const TextStyle(color: Colors.white),
        errorStyle: const TextStyle(color: Colors.red)
      ),
      keyboardType: keyboardType,
    );
  }
}

class SearchResults extends StatelessWidget {
  
  final List<FilmForMainPage> films;

  const SearchResults({ super.key, required this.films });

  @override
  Widget build(BuildContext context) {
    return SizedBox(
      height: 450,
      child: ListView.builder(
        itemCount: films.length,
        itemBuilder: (context, index) => SearchResultsEntry(film: films[index]),
      )
    );
  }
}

class SearchResultsEntry extends StatelessWidget {
  const SearchResultsEntry({ super.key, required this.film });
  
  final FilmForMainPage film;

  @override
  Widget build(BuildContext context) {
    return Row(
      children: [
        Container(
          margin: const EdgeInsets.only(right: 8, bottom: 4),
          child: InkWell(
            onTap: () => Navigator.of(context).pushNamed(NavigationRoutes.movie, arguments: film.id),
            child: Column(
              children: [
                Image.network(
                  loadingBuilder: (context, child, loadingProgress) {
                    if (loadingProgress == null) return child;
                    return SizedBox(
                      width: 48,
                      height: 60,
                      child: Center(
                        child: CircularProgressIndicator(
                          color: Colors.white,
                          value: loadingProgress.cumulativeBytesLoaded / loadingProgress.expectedTotalBytes!,
                        ),
                      )
                    );
                  },
                  film.posterUrl,
                  width: 48,
                ),
                Row(
                  children: [
                    Text(
                      film.rating.toString(), 
                      overflow: TextOverflow.ellipsis, 
                      style: const TextStyle(color: Colors.white, fontSize: 12)
                    ),
                    const Icon(Icons.star, color: Colors.amber, size: 12)
                  ]
                )
              ]
            ),
          )
        ),
        SizedBox(
          width: 176,
          child: Text(
            film.name, 
            overflow: TextOverflow.ellipsis,
            style: const TextStyle(color: Colors.white)
          ),
        )
      ],
    );
  }
}