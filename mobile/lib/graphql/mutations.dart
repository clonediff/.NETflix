class Mutations {

  static const subscriptionActionMutationName = 'subscriptionAction';
  static const subscriptionActionMutation = '''
    mutation $subscriptionActionMutationName(
      \$type: SubscriptionActionType!
      \$id: Int!
      \$card: CardDataDtoInput!
    ) {
      $subscriptionActionMutationName(
        type: \$type
        subscriptionId: \$id
        cardDataDto: \$card
      ) {
        hasError
        error
      }
    }
  ''';
}