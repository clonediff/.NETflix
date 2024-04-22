import 'package:intl/intl.dart';

class Helper {
  static String formatDate(DateTime? date, [String format = 'dd.MM.yyyy']) {
    if (date == null) return '';
    return DateFormat(format).format(date);
  }

  static DateTime parseDate(String str, [String format = 'dd.MM.yyyy']) {
    return DateFormat(format).parse(str);
  }
}
