import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:freezed_annotation/freezed_annotation.dart';
import 'package:mobile/main.dart';
import 'package:mobile/models/all_for_freezed.dart';
import 'package:mobile/services/user_service.dart';

part 'bloc.freezed.dart';

part 'events.dart';

part 'states.dart';

class GetUserBloc extends Bloc<GetUserEvent, GetUserState> {
  GetUserBloc() : super(const GetUserState.loading()) {
    on<_GetUserInfo>(
      (event, emit) async {
        emit(const GetUserState.loading());
        var service = getit<UserServiceBase>();
        var user = await service.getUser();
        user.match(
          (s) => emit(GetUserState.loaded(user: s)),
          (f) => emit(GetUserState.error(errorMessage: f)),
        );
      },
    );
  }
}
