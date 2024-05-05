import 'dart:developer';

import 'package:graphql_flutter/graphql_flutter.dart';
import 'package:mobile/graphql/queries.dart';
import 'package:mobile/main.dart';
import 'package:mobile/models/all_for_freezed.dart';
import 'package:mobile/utils/result.dart';
import 'package:http/http.dart' as http;


abstract class UserServiceBase {
  Future<Result<UserDto, String>> getUser();

  Future<Result<List<UserSubscriptionDto>, String>> getAllUserSubscriptions();

  Future<Result<String, String>> enable2FA(EnableTwoFactorAuthDtoInput dto);

  Future<Result<String, String>> changePassword(
      UserChangePasswordDtoInput chPass);

  Future<Result<String, String>> changeEmail(UserChangeMailDtoInput chMail);

  Future<Result<String, String>> changeUserData(
      UserChangeOrdinaryDtoInput chOrdinary);
}

class UserService implements UserServiceBase {
  final _client = getit<GraphQLClient>();

  @override
  Future<Result<UserDto, String>> getUser() async {
    // TODO: вытаскивать из Storage, когда авторизация будет готова
    var cookie = await authTestUser();
    log(cookie.toString());
    var response = await _client.query(
      QueryOptions(
        document: gql(Queries.userQuery),
        context: Context.fromList(
          [HttpLinkHeaders(headers: cookie)],
        ),
        fetchPolicy: FetchPolicy.networkOnly,
      ),
    );

    return response.hasException
        ? const Result.fromFailure("Не удалось найти пользователя")
        : Result.fromSuccess(
            UserDto.fromJson(response.data![Queries.userQueryName]));
  }

  @override
  Future<Result<List<UserSubscriptionDto>, String>>
      getAllUserSubscriptions() async {
    // TODO: вытаскивать из Storage, когда авторизация будет готова
    var cookie = await authTestUser();
    log(cookie.toString());
    var response = await _client.query(
      QueryOptions(
        document: gql(Queries.allUserSubscriptionsQuery),
        context: Context.fromList(
          [HttpLinkHeaders(headers: cookie)],
        ),
        fetchPolicy: FetchPolicy.networkOnly,
      ),
    );

    return response.hasException
        ? const Result.fromFailure("Не удалось получить подписки пользователя")
        : Result.fromSuccess((response
                .data![Queries.allUserSubscriptionsQueryName] as List<dynamic>)
            .map((s) => UserSubscriptionDto.fromJson(s))
            .toList());
  }

  @override
  Future<Result<String, String>> enable2FA(EnableTwoFactorAuthDtoInput dto) =>
      _changeUser(
        queryDto: dto,
        queryDtoName: Queries.enable2FAMutationDtoName,
        query: Queries.enable2FAMutation,
        queryName: Queries.enable2FAMutationName,
      );

  @override
  Future<Result<String, String>> changeEmail(UserChangeMailDtoInput chMail) =>
      _changeUser(
        queryDto: chMail,
        queryDtoName: Queries.changeEmailMutationDtoName,
        query: Queries.changeEmailMutation,
        queryName: Queries.changeEmailMutationName,
      );

  @override
  Future<Result<String, String>> changePassword(
          UserChangePasswordDtoInput chPass) =>
      _changeUser(
        queryDto: chPass,
        queryDtoName: Queries.changePasswordMutationDtoName,
        query: Queries.changePasswordMutation,
        queryName: Queries.changePasswordMutationName,
      );

  @override
  Future<Result<String, String>> changeUserData(
          UserChangeOrdinaryDtoInput chOrdinary) =>
      _changeUser(
        queryDto: chOrdinary,
        queryDtoName: Queries.changeUserDataMutationDtoName,
        query: Queries.changeUserDataMutation,
        queryName: Queries.changeUserDataMutationName,
      );

  Future<Result<String, String>> _changeUser({
    required ToJsonObject queryDto,
    required String queryDtoName,
    required String query,
    required String queryName,
  }) async {
    // TODO: вытаскивать из Storage, когда авторизация будет готова
    var cookie = await authTestUser();
    log(cookie.toString());
    log('dto: ${queryDto.toString()}');
    log('dtoName: ${queryDtoName.toString()}');
    log('query: ${query.toString()}');
    log('queryName: ${queryName.toString()}');
    var response = await _client.query(
      QueryOptions(
        document: gql(query),
        fetchPolicy: FetchPolicy.networkOnly,
        context: Context.fromList(
          [HttpLinkHeaders(headers: cookie)],
        ),
        variables: {queryDtoName: queryDto.toJson()},
      ),
    );

    return response.hasException
        ? Result.fromFailure(
            (response.exception!.linkException as ServerException)
                .parsedResponse!
                .errors![0]
                .message
                .toString())
        : Result.fromSuccess(response.data![queryName]);
  }

  // TODO: удалить, когда авторизация будет готова
  static Future<Map<String, String>> authTestUser() async {
    final response = await http.get(Uri.parse(
        '$apiBaseUrl/auth_test?username=someuser&password=somePassword&remember=true'));
    final authCookie = response.headers['set-cookie']!;
    return {'Cookie': authCookie};
  }
}
