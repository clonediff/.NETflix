import 'package:flutter/material.dart';
import 'package:mobile/pages/profile_page/functions/helper.dart';
import 'package:mobile/pages/profile_page/styles/settings_submit_button.dart';
import 'package:mobile/pages/profile_page/user_data.dart';
import 'package:mobile/pages/profile_page/widgets/my_snack_bar.dart';
import 'package:mobile/pages/profile_page/widgets/usettings_footer.dart';
import 'package:mobile/pages/profile_page/profile_page_routes.dart';
import 'package:provider/provider.dart';

class ChangeUSettingsForm extends StatefulWidget {
  final void Function(String routeName) navigatorPushNamed;

  const ChangeUSettingsForm({
    super.key,
    required this.navigatorPushNamed,
  });

  @override
  State<ChangeUSettingsForm> createState() => _ChangeUSettingsFormState();
}

class _ChangeUSettingsFormState extends State<ChangeUSettingsForm> {
  final GlobalKey<FormState> _formKey = GlobalKey<FormState>();
  final Map<String, dynamic> _formData = {};
  final TextEditingController _birthdateController = TextEditingController();

  bool dateChange = false;

  void sendEnableRequest(BuildContext context, UserData userData) {
    if (_formKey.currentState?.validate() ?? false) {
      _formKey.currentState?.save();
      print(_formData);

      // TODO: запросить обновление на сервере
      userData.modifyUser((user) {
        user.birthdate = Helper.parseDate(_formData['birthday']);
        user.login = _formData['username'];
      });

      mySnackBar(
        context,
        'Базовые данные пользователя изменены',
      );

      Navigator.of(context).pop();
    }
  }

  @override
  Widget build(BuildContext context) {
    if (!dateChange) {
      final userData = Provider.of<UserData>(context, listen: false);
      _birthdateController.text = Helper.formatDate(userData.user?.birthdate);
    }
    return Column(
      children: [
        Consumer<UserData>(
          builder: (context, userData, child) => Form(
            key: _formKey,
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                TextFormField(
                  initialValue: userData.user?.login ?? '',
                  decoration: const InputDecoration(
                    labelText: 'Логин *',
                  ),
                  validator: (value) => (value?.isEmpty ?? true)
                      ? 'Пожалуйста, введите ваш логин!'
                      : null,
                  onSaved: (val) => _formData['username'] = val,
                ),
                TextFormField(
                  controller: _birthdateController,
                  decoration: const InputDecoration(
                    labelText: 'Дата рождения',
                  ),
                  onSaved: (val) => _formData['birthday'] = val,
                  onTap: () async {
                    FocusScope.of(context).requestFocus(FocusNode());
                    final DateTime? picked = await showDatePicker(
                      context: context,
                      initialDate: userData.user?.birthdate,
                      firstDate: DateTime(1970),
                      lastDate: DateTime(2101),
                    );
                    if (picked != null) {
                      dateChange = true;
                      _birthdateController.text = Helper.formatDate(picked);
                    }
                  },
                ),
                ElevatedButton(
                  onPressed: () {
                    sendEnableRequest(context, userData);
                  },
                  style: settingsSubmitButton(),
                  child: const Text('Применить изменения'),
                ),
                if (userData.user?.enabled2FA ?? false) ...[
                  InkWell(
                    onTap: () => widget.navigatorPushNamed(
                        ProfilePageNavigationRoutes.changeEmail),
                    child: const Text(
                      'Изменить почту',
                      style: TextStyle(color: Colors.white),
                    ),
                  ),
                  InkWell(
                    onTap: () => widget.navigatorPushNamed(
                        ProfilePageNavigationRoutes.changePass),
                    child: const Text(
                      'Изменить пароль',
                      style: TextStyle(color: Colors.white),
                    ),
                  ),
                ] else
                  const Text('Подключите двухфакторную аутентификацию'),
                USettingsFooter(
                  linkText: 'Вернуться к информации о пользователе',
                  navTo: () => Navigator.of(context).pop(),
                ),
              ],
            ),
          ),
        ),
      ],
    );
  }
}
