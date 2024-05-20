import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:mobile/bloc/loading/bloc.dart';
import 'package:mobile/constants/colors.dart';
import 'package:mobile/navigation/navigation_routes.dart';
import 'package:mobile/widgets/search.dart';

class Header extends StatelessWidget implements PreferredSizeWidget {
  const Header({super.key});

  @override
  Widget build(BuildContext context) {
    return AppBar(
      title: const Text(
        '.Netflix',
        style: TextStyle(
            color: Colors.red, fontWeight: FontWeight.w700, fontSize: 26),
      ),
      actions: [
        IconButton(
          icon: const Icon(Icons.question_answer, size: 26),
          color: Colors.white,
          onPressed: () {
            Navigator.of(context).pushNamed(NavigationRoutes.supportChat, arguments: "RoomId");
          },
        ),
        IconButton(
          icon: const Icon(Icons.person, size: 26),
          color: Colors.white,
          onPressed: () {
            Navigator.of(context).pushNamed(NavigationRoutes.profile);
          },
        ),
        IconButton(
          icon: const Icon(Icons.search, size: 26),
          color: Colors.white,
          onPressed: () {
            showDialog(
              context: context, 
              builder: (context) => BlocProvider(
                create: (_) => LoadingBloc(),
                child: const SearchDialog()
              )
            );
          },
        ),
      ],
      backgroundColor: DotNetflixColors.headerBackgroundColor,
      iconTheme: const IconThemeData(
        color: Colors.white,
      )
    );
  }

  @override
  Size get preferredSize => const Size.fromHeight(48);
}
