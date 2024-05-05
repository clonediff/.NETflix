import 'dart:developer';

import 'package:graphql_flutter/graphql_flutter.dart';
import 'package:mobile/graphql/queries.dart';
import 'package:mobile/main.dart';
import 'package:mobile/services/user_service.dart';
import 'package:mobile/utils/result.dart';

abstract class TokenServiceBase {
  Future<Result<String, String>> send2FAToken();

  Future<Result<String, String>> sendChangePasswordToken();

  Future<Result<String, String>> sendChangeMailToken(String newEmail);
}

class TokenService implements TokenServiceBase {
  final _client = getit<GraphQLClient>();

  @override
  Future<Result<String, String>> send2FAToken() => _sendToken(
        query: Queries.send2FATokenMutation,
        queryName: Queries.send2FATokenMutationName,
      );

  @override
  Future<Result<String, String>> sendChangeMailToken(String newEmail) =>
      _sendToken(
        query: Queries.sendChangeMailTokenMutation,
        queryName: Queries.sendChangeMailTokenMutationName,
        variables: {Queries.sendChangeMailTokenMutationDtoName: newEmail},
      );

  @override
  Future<Result<String, String>> sendChangePasswordToken() => _sendToken(
        query: Queries.sendChangePasswordTokenMutation,
        queryName: Queries.sendChangePasswordTokenMutationName,
      );

  Future<Result<String, String>> _sendToken({
    required String query,
    required String queryName,
    Map<String, dynamic> variables = const {},
  }) async {
    // TODO: вытаскивать из Storage, когда авторизация будет готова
    var cookie = await UserService.authTestUser();
    log(cookie.toString());
    var response = await _client.query(
      QueryOptions(
        document: gql(query),
        fetchPolicy: FetchPolicy.networkOnly,
        context: Context.fromList(
          [HttpLinkHeaders(headers: cookie)],
        ),
        variables: variables,
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
