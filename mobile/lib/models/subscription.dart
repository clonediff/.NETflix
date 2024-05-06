class Subscription {
  final int id;
  final String name;
  final int cost;
  final int? periodInDays;
  final List<String> filmNames;
  bool belongsToUser;

  Subscription.fromDynamic(dynamic object)
    : id = object['id'],
      name = object['name'],
      cost = object['cost'],
      periodInDays = object['periodInDays'],
      filmNames = (object['filmNames'] as List).map((x) => x.toString()).toList(),
      belongsToUser = object['belongsToUser'];
}
