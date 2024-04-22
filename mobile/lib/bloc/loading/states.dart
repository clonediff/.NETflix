class LoadingStateBase { }

class WaitState extends LoadingStateBase { }

class LoadingState extends LoadingStateBase { }

class LoadedState<TData> extends LoadingStateBase {
  final TData data;

  LoadedState({ required this.data });
}