import 'package:graphql_flutter/graphql_flutter.dart';
import 'package:mobile/dto/maybe_error_response.dart';
import 'package:mobile/graphql/mutations.dart';
import 'package:mobile/main.dart';
import 'package:mobile/models/login_form_model.dart';
import 'package:mobile/models/register_form_model.dart';
import 'package:mobile/utils/result.dart';

abstract class AuthServiceBase {
  Future<Result<String, String>> login(LoginFormDto dto);
  Future<MaybeErrorResponse> register(RegisterFormDto dto);
}

class AuthService implements AuthServiceBase{
  final _apiClient = getit<GraphQLClient>(instanceName: 'api');

  @override
  Future<Result<String, String>> login(LoginFormDto dto) async {
    var options = MutationOptions(
        document: gql(Mutations.loginMutation),
        variables: {'form': dto.toJson() }
    );
    final result = await _apiClient.mutate(options);

    return result.hasException
        ? const Result.fromFailure("Не удалось войти в аккаунт")
        : result.data![Mutations.loginMutationName]['hasError'] 
          ? Result.fromFailure(result.data![Mutations.loginMutationName]['error'])
          : Result.fromSuccess(result.data![Mutations.loginMutationName]['data'])
    ;
  }

  @override
  Future<MaybeErrorResponse> register(RegisterFormDto dto) async{
    final result = await _apiClient.mutate(
        MutationOptions(
            document: gql(Mutations.registerMutation),
            variables: {'form': dto.toJson() }
        ));

    return result.hasException
        ? MaybeErrorResponse(hasError: true, error: "Не удалось зарегистрироваться")
        : result.data![Mutations.registerMutationName]['hasError']
          ? MaybeErrorResponse(hasError: true, error: result.data![Mutations.registerMutationName]['error'])
          : MaybeErrorResponse.fromJson(result.data![Mutations.registerMutationName]);
  }
}