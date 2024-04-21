import 'package:intl/intl.dart';

class Helper {
  static String formatDate(DateTime? date) {
    if (date == null) return '';
    return DateFormat('dd.MM.yyyy').format(date);
  }

  static DateTime parseDate(String str) {
    return DateFormat('dd.MM.yyyy').parse(str);
  }
}
