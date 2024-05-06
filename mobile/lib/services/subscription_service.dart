import 'package:graphql_flutter/graphql_flutter.dart';
import 'package:mobile/dto/maybe_error_response.dart';
import 'package:mobile/graphql/mutations.dart';
import 'package:mobile/graphql/queries.dart';
import 'package:mobile/main.dart';
import 'package:mobile/models/subscription.dart' as models;
import 'package:mobile/utils/result.dart';

abstract class SubscriptionServiceBase {
  Future<MaybeErrorResponse> performSubscriptionActionAsync(SubscriptionActionType type, int subscriptionId, Map<String, dynamic> cardData);
  Future<Result<List<models.Subscription>, String>> getAllSubscriptionsAsync();
}

class SubscriptionService implements SubscriptionServiceBase {

  final _client = getit<GraphQLClient>();

  @override
  Future<MaybeErrorResponse> performSubscriptionActionAsync(SubscriptionActionType type, int subscriptionId, Map<String, dynamic> cardData) async {
    final result = await _client.mutate(
      MutationOptions(
        document: gql(Mutations.subscriptionActionMutation),
        variables: {
          'type': type.name.toUpperCase(),
          'id': subscriptionId,
          'card': cardData
        }
      )
    );

    return result.hasException
      ? MaybeErrorResponse(hasError: true, error: "Не удалось провести операцию")
      : MaybeErrorResponse.fromJson(result.data![Mutations.subscriptionActionMutationName]);
  }
  
  @override
  Future<Result<List<models.Subscription>, String>> getAllSubscriptionsAsync() async {
    final result = await _client.query(
      QueryOptions(document: gql(Queries.allSubscriptionsQuery))
    );

    return result.hasException
      ? const Result.fromFailure("Не удалось загрузить контент")
      : Result.fromSuccess(
          (result.data![Queries.allSubscriptionsQueryName] as List)
            .map((x) => models.Subscription.fromDynamic(x))
            .toList()
        );
  }
}

enum SubscriptionActionType {
  purchase,
  extend
}