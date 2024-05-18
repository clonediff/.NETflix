import 'package:graphql_flutter/graphql_flutter.dart';
import 'package:mobile/graphql/mutations.dart';
import 'package:mobile/graphql/queries.dart';
import 'package:mobile/main.dart';
import 'package:mobile/models/all_for_freezed.dart';
import 'package:mobile/utils/result.dart';


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
  final _apiClient = getit<GraphQLClient>(instanceName: 'api');

  @override
  Future<Result<UserDto, String>> getUser() async {
    var response = await _apiClient.query(
      QueryOptions(
        document: gql(Queries.userQuery),
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
    var response = await _apiClient.query(
      QueryOptions(
        document: gql(Queries.allUserSubscriptionsQuery),
        fetchPolicy: FetchPolicy.networkOnly
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
        queryDtoName: Mutations.enable2FAMutationDtoName,
        query: Mutations.enable2FAMutation,
        queryName: Mutations.enable2FAMutationName,
      );

  @override
  Future<Result<String, String>> changeEmail(UserChangeMailDtoInput chMail) =>
      _changeUser(
        queryDto: chMail,
        queryDtoName: Mutations.changeEmailMutationDtoName,
        query: Mutations.changeEmailMutation,
        queryName: Mutations.changeEmailMutationName,
      );

  @override
  Future<Result<String, String>> changePassword(
          UserChangePasswordDtoInput chPass) =>
      _changeUser(
        queryDto: chPass,
        queryDtoName: Mutations.changePasswordMutationDtoName,
        query: Mutations.changePasswordMutation,
        queryName: Mutations.changePasswordMutationName,
      );

  @override
  Future<Result<String, String>> changeUserData(
          UserChangeOrdinaryDtoInput chOrdinary) =>
      _changeUser(
        queryDto: chOrdinary,
        queryDtoName: Mutations.changeUserDataMutationDtoName,
        query: Mutations.changeUserDataMutation,
        queryName: Mutations.changeUserDataMutationName,
      );

  Future<Result<String, String>> _changeUser({
    required ToJsonObject queryDto,
    required String queryDtoName,
    required String query,
    required String queryName,
  }) async {
    var response = await _apiClient.query(
      QueryOptions(
        document: gql(query),
        fetchPolicy: FetchPolicy.networkOnly,
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
}
