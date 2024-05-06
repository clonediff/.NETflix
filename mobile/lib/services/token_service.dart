import 'package:graphql_flutter/graphql_flutter.dart';
import 'package:mobile/graphql/mutations.dart';
import 'package:mobile/main.dart';
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
        query: Mutations.send2FATokenMutation,
        queryName: Mutations.send2FATokenMutationName,
      );

  @override
  Future<Result<String, String>> sendChangeMailToken(String newEmail) =>
      _sendToken(
        query: Mutations.sendChangeMailTokenMutation,
        queryName: Mutations.sendChangeMailTokenMutationName,
        variables: {Mutations.sendChangeMailTokenMutationDtoName: newEmail},
      );

  @override
  Future<Result<String, String>> sendChangePasswordToken() => _sendToken(
        query: Mutations.sendChangePasswordTokenMutation,
        queryName: Mutations.sendChangePasswordTokenMutationName,
      );

  Future<Result<String, String>> _sendToken({
    required String query,
    required String queryName,
    Map<String, dynamic> variables = const {},
  }) async {
    var response = await _client.query(
      QueryOptions(
        document: gql(query),
        fetchPolicy: FetchPolicy.networkOnly,
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
