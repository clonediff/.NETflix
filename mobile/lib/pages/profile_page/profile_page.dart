import 'package:flutter/material.dart';
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
    return ChangeNotifierProvider<UserData>(
      create: (context) => UserData(
        user: User(
          login: 'Rail',
          email: 'railbariev1@gmail.com',
          birthdate: DateTime(2003, 10, 6),
          enabled2FA: false,
        ),
      ),
      child: Scaffold(
        appBar: const Header(),
        body: Container(
          decoration: const BoxDecoration(
            image: DecorationImage(
              image: AssetImage('assets/dotnetflix-bgi.jpg'),
              fit: BoxFit.cover,
            ),
            color: NetflixColors.mainBackgroundColor,
          ),
          child: Container(
            padding: const EdgeInsets.symmetric(horizontal: 15),
            margin: const EdgeInsets.symmetric(
              vertical: 20,
              horizontal: 5,
            ),
            child: Column(
              children: [
                Material(
                  shape: const RoundedRectangleBorder(
                    borderRadius: BorderRadius.vertical(
                      top: Radius.circular(30),
                    ),
                  ),
                  color: NetflixColors.headerBackgroundColor,
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

class User {
  String email;
  String login;
  DateTime birthdate;
  bool enabled2FA;

  User({
    required this.login,
    required this.email,
    required this.birthdate,
    required this.enabled2FA,
  });

  @override
  bool operator ==(Object other) {
    if (other is! User) return false;
    return (other.login == login);
  }

  @override
  int get hashCode => Object.hash(login, email);
}
