import 'package:flutter/material.dart';

class LoadingStateBase { }

class WaitState extends LoadingStateBase { }

class LoadingState extends LoadingStateBase { }

class LoadedState<TData> extends LoadingStateBase {
  final TData data;
  final Widget Function(TData data) builder;

  LoadedState({ required this.data, required this.builder });
}

class ErrorState<TError> extends LoadingStateBase {
  final TError error;

  ErrorState({required this.error});
}