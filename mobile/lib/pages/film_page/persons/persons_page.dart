import 'package:flutter/material.dart';
import 'package:mobile/constants/colors.dart';
import 'package:mobile/constants/styles.dart';
import 'package:mobile/mocks/film_info.dart';
import 'package:mobile/widgets/header.dart';

class PersonsPage extends StatefulWidget{
  final Map<String, List<Person>> persons;
  final Function(int pageNumber) onSelectedPage;
  final String title;

  const PersonsPage({super.key, required this.persons, required this.title, required this.onSelectedPage});

  @override
  State<StatefulWidget> createState() => _PersonsPageState();
}

class _PersonsPageState extends State<PersonsPage>{

  void goToSelectedPage(BuildContext context, int page){
    widget.onSelectedPage(page);
  }

  Widget getPersonsWidgets(Map<String, List<Person>> persons)
  {
    var personsWidgets = persons
        .entries
        .map((element) => PersonsList(persons: element.value, title: element.key))
        .toList();
    return Column(
      crossAxisAlignment: CrossAxisAlignment.center,
      children:
        personsWidgets
    );
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: const Header(),
      floatingActionButtonLocation: FloatingActionButtonLocation.startTop,
      floatingActionButton: FloatingActionButton(
        backgroundColor: DotNetflixColors.floatingButtonColor,
        onPressed: () {
          goToSelectedPage(context, 0);
        },
        child: const Icon(Icons.arrow_back, color: Colors.white, size: 20),
      ),
      body: Container(
        padding: const EdgeInsets.only(left: 12, right: 12, top: 5),
        color: DotNetflixColors.mainBackgroundColor,
        child: SingleChildScrollView(
          child: getPersonsWidgets(widget.persons)
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
                    Text(persons[index].name, style: DotNetflixTextStyles.mainTextStyle),
                    Text(persons[index].profession, style: DotNetflixTextStyles.subtitleStyle)
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