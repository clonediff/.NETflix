import 'dart:developer';

import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:mobile/bloc/get_user/bloc.dart';
import 'package:mobile/constants/colors.dart';
import 'package:mobile/main.dart';
import 'package:mobile/navigation/navigation_routes.dart';
import 'package:mobile/pages/profile_page/functions/helper.dart';
import 'package:mobile/pages/profile_page/widgets/change_email_form.dart';
import 'package:mobile/pages/profile_page/widgets/change_pass_form.dart';
import 'package:mobile/pages/profile_page/profile_page_routes.dart';
import 'package:mobile/pages/profile_page/enable2fa/enable2fa.dart';
import 'package:mobile/pages/profile_page/title_value/title_value.dart';
import 'package:mobile/pages/profile_page/user_data.dart';
import 'package:mobile/pages/profile_page/widgets/change_usettings_form.dart';
import 'package:mobile/services/session_service.dart';
import 'package:provider/provider.dart';

class MainInfo extends StatefulWidget {
  const MainInfo({super.key});

  @override
  State<MainInfo> createState() => _MainInfoState();
}

class _MainInfoState extends State<MainInfo> {
  final GlobalKey<NavigatorState> _navigatorKey = GlobalKey<NavigatorState>();
  int pagesCount = 0;
  bool loadingCalled = false;

  void incrementPagesCount() => setState(() => pagesCount++);

  void decrementPagesCount() => setState(() => pagesCount--);

  @override
  Widget build(BuildContext context) {
    if (!loadingCalled) {
      context.read<GetUserBloc>().add(const GetUserEvent.getUserInfo());
      setState(() {
        loadingCalled = true;
      });
    }
    return BlocBuilder<GetUserBloc, GetUserState>(
      builder: (context, state) => state.when(
        loading: () => const Center(
          child: CircularProgressIndicator(),
        ),
        loaded: (user) {
          log(user.toString());
          return ChangeNotifierProvider<UserData>(
          create: (BuildContext context) => UserData(user: user),
          child: PopScope(
            canPop: pagesCount <= 0,
            onPopInvoked: (didPop) {
              decrementPagesCount();
              if (_navigatorKey.currentState?.canPop() ?? false) {
                _navigatorKey.currentState?.pop();
              }
            },
            child: Navigator(
              key: _navigatorKey,
              onGenerateRoute: (settings) {
                if (settings.name != ProfilePageNavigationRoutes.main) {
                  incrementPagesCount();
                }
                switch (settings.name) {
                  case ProfilePageNavigationRoutes.main:
                    return MaterialPageRoute(
                      builder: (context) {
                        return Consumer<UserData>(
                          builder: (context, userData, child) =>
                              SingleChildScrollView(
                            child: Column(
                              crossAxisAlignment: CrossAxisAlignment.start,
                              children: [
                                ElevatedButton.icon(
                                  onPressed: () {
                                    _navigatorKey.currentState!.pushNamed(
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
                                    backgroundColor:
                                        MaterialStateProperty.resolveWith(
                                      (states) => DotNetflixColors
                                          .headerBackgroundColor,
                                    ),
                                    foregroundColor:
                                        MaterialStateProperty.resolveWith(
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
                                    value: Text(Helper.formatDate(
                                        userData.user?.birthdate))),
                                TitleValue(
                                    icon: Icons.calendar_today,
                                    title: 'Age',
                                    value:
                                        Text(getAge(userData.user?.birthdate))),
                                // TitleValue(
                                //     title: "Выход",
                                //     value: InkWell(
                                //       onTap: () async {
                                //         var sessionStorage = getit<SessionDataProvider>();
                                //         await sessionStorage.deleteJwtToken();
                                //         //_navigatorKey.currentState!.popUntil((route) => !route.isFirst);
                                //         _navigatorKey.currentState!
                                //           ..popUntil((route) => !route.isFirst)
                                //           ..pushNamed(NavigationRoutes.login);
                                //
                                //       },
                                //     )
                                // ),
                                if (userData.user?.enabled2FA ?? false)
                                  const Text(
                                    'Двухфакторная аутентификация подключена',
                                    style: TextStyle(fontSize: 20),
                                  )
                                else
                                  TitleValue(
                                    title:
                                        'Подключить двухфакторную аутентификацию',
                                    value: InkWell(
                                      onTap: () {
                                        _navigatorKey.currentState!.pushNamed(
                                            ProfilePageNavigationRoutes
                                                .enable2FA);
                                      },
                                      child: const Text(
                                        'Подключить',
                                        style: TextStyle(color: Colors.white),
                                      ),
                                    ),
                                  ),
                              ],
                            ),
                          ),
                        );
                      },
                    );
                  case ProfilePageNavigationRoutes.enable2FA:
                    return MaterialPageRoute(
                      builder: (context) {
                        return const Enable2FA();
                      },
                    );
                  case ProfilePageNavigationRoutes.change:
                    return MaterialPageRoute(
                      builder: (context) {
                        return const ChangeUSettingsForm();
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
          ),
        );
        },
        error: (errorMessage) => Center(
          child: Text(errorMessage),
        ),
      ),
    );
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
