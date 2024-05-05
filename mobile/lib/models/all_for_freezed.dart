import 'dart:convert';

import 'package:freezed_annotation/freezed_annotation.dart';

part 'all_for_freezed.freezed.dart';
part 'all_for_freezed.g.dart';

part 'user_dto.dart';
part 'user_subscription_dto.dart';
part 'enable_two_factor_auth_dto_input.dart';
part 'user_change_mail_dto_input.dart';
part 'user_change_ordinary_dto_input.dart';
part 'user_change_password_dto_input.dart';

mixin ToJsonObject {
  Map<String, dynamic> toJson();
}