import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:freezed_annotation/freezed_annotation.dart';
import 'package:mobile/main.dart';
import 'package:mobile/models/all_for_freezed.dart';
import 'package:mobile/services/user_service.dart';

part 'bloc.freezed.dart';

part 'events.dart';

part 'states.dart';

class GetAllUserSubscriptionsBloc
    extends Bloc<GetAllUserSubscriptionsEvent, GetAllUserSubscriptionsState> {
  GetAllUserSubscriptionsBloc()
      : super(const GetAllUserSubscriptionsState.loading()) {
    on<_GetAllUserSubscriptionsEvent>(
      (event, emit) async {
        emit(const GetAllUserSubscriptionsState.loading());
        var service = getit<UserServiceBase>();
        var subscriptions = await service.getAllUserSubscriptions();
        emit(
          subscriptions.match(
            (s) => GetAllUserSubscriptionsState.loaded(subscriptions: s),
            (f) => GetAllUserSubscriptionsState.error(errorMessage: f),
          ),
        );
      },
    );
  }
}
