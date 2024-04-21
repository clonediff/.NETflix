import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:mobile/constants/colors.dart';
import 'package:mobile/pages/profile_page/functions/helper.dart';
import 'package:mobile/pages/profile_page/widgets/change_email_form.dart';
import 'package:mobile/pages/profile_page/widgets/change_pass_form.dart';
import 'package:mobile/pages/profile_page_routes.dart';
import 'package:mobile/pages/profile_page/enable2fa/enable2fa.dart';
import 'package:mobile/pages/profile_page/title_value/title_value.dart';
import 'package:mobile/pages/profile_page/user_data.dart';
import 'package:mobile/pages/profile_page/widgets/change_usettings_form.dart';
import 'package:provider/provider.dart';

class MainInfo extends StatefulWidget {
  const MainInfo({super.key});

  @override
  State<MainInfo> createState() => _MainInfoState();
}

class _MainInfoState extends State<MainInfo> {
  final GlobalKey<NavigatorState> _navigatorKey = GlobalKey<NavigatorState>();
  int pagesCount = 0;

  void incrementPagesCount() => setState(() => pagesCount++);

  void decrementPagesCount() => setState(() => pagesCount--);

  @override
  Widget build(BuildContext context) {
    return PopScope(
      canPop: pagesCount <= 0,
      onPopInvoked: (didPop) {
        decrementPagesCount();
        print('pop called');
        if (_navigatorKey.currentState?.canPop() ?? false) {
          _navigatorKey.currentState?.pop();
        }
      },
      child: Navigator(
        key: _navigatorKey,
        onGenerateRoute: (settings) {
          switch (settings.name) {
            case ProfilePageNavigationRoutes.main:
              return MaterialPageRoute(
                builder: (context) {
                  return Consumer<UserData>(
                    builder: (context, userData, child) => SingleChildScrollView(
                      child: Column(
                        crossAxisAlignment: CrossAxisAlignment.start,
                        children: [
                          ElevatedButton.icon(
                            onPressed: () {
                              navigatorPushNamed(
                                  ProfilePageNavigationRoutes.change);
                            },
                            icon: const Icon(
                              Icons.edit,
                              color: Colors.white,
                            ),
                            label: const Text('Изменить'),
                            style: ButtonStyle(
                              padding: MaterialStateProperty.resolveWith(
                                (states) => const EdgeInsets.symmetric(
                                    vertical: 5, horizontal: 10),
                              ),
                              backgroundColor: MaterialStateProperty.resolveWith(
                                (states) => NetflixColors.headerBackgroundColor,
                              ),
                              foregroundColor: MaterialStateProperty.resolveWith(
                                (states) => Colors.white,
                              ),
                            ),
                          ),
                          TitleValue(
                              icon: Icons.person,
                              title: 'Login',
                              value: Text(userData.user?.login ?? '')),
                          TitleValue(
                              icon: Icons.email,
                              title: 'Email',
                              value: Text(userData.user?.email ?? '')),
                          TitleValue(
                              icon: Icons.calendar_month,
                              title: 'Birthdate',
                              value: Text(Helper.formatDate(userData.user?.birthdate))),
                          TitleValue(
                              icon: Icons.calendar_today,
                              title: 'Age',
                              value: Text(getAge(userData.user?.birthdate))),
                          if (userData.user?.enabled2FA ?? false)
                            const Text(
                              'Двухфакторная аутентификация подключена',
                              style: TextStyle(fontSize: 20),
                            )
                          else
                            TitleValue(
                              title: 'Подключить двухфакторную аутентификацию',
                              value: InkWell(
                                onTap: () {
                                  navigatorPushNamed(
                                      ProfilePageNavigationRoutes.enable2FA);
                                },
                                child: const Text(
                                  'Подключить',
                                  style: TextStyle(color: Colors.white),
                                ),
                              ),
                            )
                        ],
                      ),
                    ),
                  );
                },
              );
            case ProfilePageNavigationRoutes.enable2FA:
              return MaterialPageRoute(
                builder: (context) {
                  return Enable2FA(
                    navigatorPushNamed: navigatorPushNamed,
                  );
                },
              );
            case ProfilePageNavigationRoutes.change:
              return MaterialPageRoute(
                builder: (context) {
                  return ChangeUSettingsForm(
                    navigatorPushNamed: navigatorPushNamed,
                  );
                },
              );
            case ProfilePageNavigationRoutes.changeEmail:
              return MaterialPageRoute(
                builder: (context) => const ChangeEmailForm(),
              );
            case ProfilePageNavigationRoutes.changePass:
              return MaterialPageRoute(
                builder: (context) => const ChangePassForm(),
              );
            default:
              Navigator.of(context).pop();
              throw UnimplementedError('Can\'t pop');
          }
        },
      ),
    );
  }

  void navigatorPushNamed(String routeName) {
    incrementPagesCount();
    _navigatorKey.currentState?.pushNamed(routeName);
  }

  String getAge(DateTime? date) {
    if (date == null) return '';
    final today = DateTime.now();
    final year = today.year - date.year;
    final mth = today.month - date.month;
    final days = today.day - date.day;
    return ((mth < 0 || mth == 0 && days < 0) ? year - 1 : year).toString();
  }
}

class MyNavigator extends StatelessWidget {
  const MyNavigator({super.key});

  @override
  Widget build(BuildContext context) {
    return const Placeholder();
  }
}

