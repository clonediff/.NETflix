class LoadingEventBase { }

class LoadingAllFilmsEvent extends LoadingEventBase { }

class LoadingSearchedFilmsEvent extends LoadingEventBase { 
  final Map<String, String> params;

  LoadingSearchedFilmsEvent({ required this.params });
}