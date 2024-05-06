import 'package:flutter_secure_storage/flutter_secure_storage.dart';
class _Keys {
  static const token = "jwt_token";
}

class SessionDataProvider {
  final FlutterSecureStorage _secureStorage;

  SessionDataProvider(this._secureStorage);

  Future<String?> getJwtToken() async {
    return _secureStorage.read(key: _Keys.token);
  }

  Future<void> setJwtToken(String token) async {
    return _secureStorage.write(key: _Keys.token, value: token);
  }

  Future<void> deleteJwtToken() async {
    return _secureStorage.delete(key: _Keys.token);
  }
}