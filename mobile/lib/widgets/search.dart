import 'package:flutter/material.dart';
import 'package:mobile/constants/colors.dart';
import 'package:mobile/models/film_for_main_page.dart';

class SearchDialog extends StatefulWidget {
  const SearchDialog({ super.key });
  
  @override
  State<StatefulWidget> createState() => _SearchDialogState();
}

class _SearchDialogState extends State<SearchDialog> {

  final Map<String, String> formData = {};
  int selectedPage = 0;

  void updatePage(int pageNumber) {
    setState(() => selectedPage = pageNumber);
  }

  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      scrollable: true,
      title: const Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Text(
            'Поиск',
            style: TextStyle(
              color: Colors.red,
              fontWeight: FontWeight.w600
            )
          ),
          Text(
            'Введите название фильма или один из дополнительных параметров',
            style: TextStyle(
              color: Colors.red,
              fontSize: 12
            ),
          )
        ],
      ),
      content: selectedPage == 0 ? SearchForm(callback: updatePage) : SearchResults(formData: formData),
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
            label: Names.name,
            onSaved: (value) => ancestor.formData[Names.name] = value!,
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
                label: Names.year,
                onSaved: (value) => ancestor.formData[Names.year] = value!,
                keyboardType: TextInputType.number,
                validator: (value) {
                  final parsed = int.tryParse(value!);
                  return value.isNotEmpty && (parsed == null || 1900 > parsed || parsed > 2100)
                    ? 'Введите значение между 1900 и 2100'
                    : null;
                },
              ),
              SearchFormField(label: Names.country, onSaved: (value) => ancestor.formData[Names.country] = value!),
              SearchFormField(label: Names.genre, onSaved: (value) => ancestor.formData[Names.genre] = value!),
              SearchFormField(label: Names.actor, onSaved: (value) => ancestor.formData[Names.actor] = value!),
              SearchFormField(label: Names.director, onSaved: (value) => ancestor.formData[Names.director] = value!)
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
  SearchResults({ super.key, required this.formData });
  
  final Map<String, String> formData;
  final film = Film(
    image: 'https://st.kp.yandex.net/images/film_big/404900.jpg', 
    name: 'Во все тяжкие', 
    rating: 9.5
  );

  @override
  Widget build(BuildContext context) {
    return SizedBox(
      height: 450,
      child: ListView.builder(
        itemCount: 10,
        itemBuilder: (context, index) => SearchResultsEntry(film: film),
      )
    );
  }
}

class SearchResultsEntry extends StatelessWidget {
  const SearchResultsEntry({ super.key, required this.film });
  
  final Film film;

  @override
  Widget build(BuildContext context) {
    return Row(
      children: [
        Container(
          margin: const EdgeInsets.only(right: 8, bottom: 4),
          child: Column(
            children: [
              Image.network(film.image, width: 48),
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

class Names {
  static const String name = 'Название'; 
  static const String year = 'Год выхода'; 
  static const String country = 'Страна производства'; 
  static const String genre = 'Жанр'; 
  static const String actor = 'Актёр'; 
  static const String director = 'Режиссёр'; 
}