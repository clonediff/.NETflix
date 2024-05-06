class MaybeErrorResponse {
  final bool hasError;
  final String? error;

  MaybeErrorResponse({ required this.hasError, this.error });

  MaybeErrorResponse.fromJson(Map<String, dynamic> json)
      : hasError = json['hasError'],
        error = json['hasError'] ? json['error'] : null;
}