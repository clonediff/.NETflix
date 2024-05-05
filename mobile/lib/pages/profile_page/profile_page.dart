import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:mobile/bloc/get_all_user_subscriptions/bloc.dart';
import 'package:mobile/bloc/get_user/bloc.dart';
import 'package:mobile/constants/colors.dart';
import 'package:mobile/pages/profile_page/main_info/main_info.dart';
import 'package:mobile/pages/profile_page/subscriptions/subscription_info.dart';
import 'package:mobile/pages/profile_page/user_data.dart';
import 'package:mobile/widgets/header.dart';
import 'package:provider/provider.dart';

class ProfilePage extends StatefulWidget {
  const ProfilePage({super.key});

  @override
  State<StatefulWidget> createState() => _ProfilePageState();
}

class _ProfilePageState extends State<ProfilePage>
    with SingleTickerProviderStateMixin {
  late List<({String title, Widget body})> _tabs;
  late TabController _tabController;

  @override
  void initState() {
    _tabs = [
      (title: 'Основная информация', body: const MainInfo()),
      (title: 'Управление подпиской', body: const SubscriptionsInfo())
    ];
    _tabController = TabController(length: _tabs.length, vsync: this);

    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: const Header(),
      body: Container(
        decoration: const BoxDecoration(
          image: DecorationImage(
            image: AssetImage('assets/dotnetflix-bgi.jpg'),
            fit: BoxFit.cover,
          ),
          color: DotNetflixColors.mainBackgroundColor,
        ),
        child: Container(
          padding: const EdgeInsets.symmetric(horizontal: 15),
          margin: const EdgeInsets.symmetric(
            vertical: 20,
            horizontal: 5,
          ),
          child: MultiBlocProvider(
            providers: [
              BlocProvider<GetUserBloc>(
                create: (context) => GetUserBloc(),
              ),
              BlocProvider<GetAllUserSubscriptionsBloc>(
                create: (context) => GetAllUserSubscriptionsBloc(),
              )
            ],
            child: Column(
              children: [
                Material(
                  shape: const RoundedRectangleBorder(
                    borderRadius: BorderRadius.vertical(
                      top: Radius.circular(30),
                    ),
                  ),
                  color: DotNetflixColors.headerBackgroundColor,
                  child: TabBar(
                    controller: _tabController,
                    labelColor: Colors.red,
                    unselectedLabelColor: Colors.white,
                    tabs: _tabs
                        .map(
                          (tab) => Tab(
                            child: Text(
                              tab.title,
                              textAlign: TextAlign.center,
                            ),
                          ),
                        )
                        .toList(),
                  ),
                ),
                Container(
                  height: MediaQuery.of(context).size.height - 200,
                  decoration: const BoxDecoration(
                    borderRadius: BorderRadius.vertical(
                      bottom: Radius.circular(30),
                    ),
                    color: Colors.grey,
                  ),
                  padding:
                      const EdgeInsets.only(right: 20, left: 20, bottom: 30),
                  child: TabBarView(
                    controller: _tabController,
                    children: _tabs
                        .map(
                          (tab) => tab.body,
                        )
                        .toList(),
                  ),
                ),
              ],
            ),
          ),
        ),
      ),
    );
  }
}
