import 'package:flutter/material.dart';
import 'package:mobile/constants/colors.dart';
import 'package:mobile/constants/styles.dart';
import 'package:mobile/models/film_info.dart';
import 'package:mobile/widgets/header.dart';

class PersonsPage extends StatelessWidget{

  const PersonsPage({super.key});

  Widget getPersonsWidgets(Map<String, List<Person>> persons)
  {
    var personsWidgets = persons
        .entries
        .map((element) => PersonsList(persons: element.value, title: element.key.toUpperCase()))
        .toList();
    return Column(
      crossAxisAlignment: CrossAxisAlignment.center,
      children:
        personsWidgets
    );
  }

  @override
  Widget build(BuildContext context) {
    var persons = ModalRoute.of(context)?.settings.arguments as Map<String, List<Person>>;
    return Scaffold(
      appBar: const Header(),
      body: Container(
          padding: const EdgeInsets.only(left: 12, right: 12, top: 5),
          color: DotNetflixColors.mainBackgroundColor,
          child: SingleChildScrollView(
            child: getPersonsWidgets(persons)
          ),
        ),
    );
  }
}

class PersonsList extends StatelessWidget{
  final List<Person> persons;
  final String title;

  const PersonsList({super.key, required this.persons, required this.title});
  
  @override
  Widget build(BuildContext context) {
    return Column(
      crossAxisAlignment: CrossAxisAlignment.center,
      children: [
        Text(title, style: DotNetflixTextStyles.personsTitleStyle),
        ListView.separated(
          physics: const NeverScrollableScrollPhysics(),
          shrinkWrap: true,
          itemBuilder: (BuildContext context, int index) {
            return Row(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Image.network(persons[index].photo!, height: 160, width: 120, fit: BoxFit.cover),
                Column(
                  mainAxisAlignment: MainAxisAlignment.spaceAround,
                  crossAxisAlignment: CrossAxisAlignment.end,
                  children: [
                    SizedBox(
                      width: 200,
                      child: Text(persons[index].name,
                        style: DotNetflixTextStyles.mainTextStyle,
                        textAlign: TextAlign.end,
                      ),
                    ),
                    Text('${persons[index].profession[0].toUpperCase()}${persons[index].profession.substring(1)}',
                      style: DotNetflixTextStyles.subtitleStyle,
                      textAlign: TextAlign.end,
                    )
                  ],
                ),
              ],
            );
          },
          separatorBuilder: (BuildContext context, int index) =>
              const Divider(height: 20,
                color: DotNetflixColors.buttonColor,
                thickness: 3,
              ),
          itemCount: persons.length
        ),
      ],
    );
  }
}