import 'package:intl/intl.dart';

class CardData {
  final String cardNumber;
  final String cardholder;
  final DateTime expirationDate;
  final int cvvCVC;

  CardData.fromJson(Map<String, dynamic> json)
    : cardNumber = json['cardnumber'],
      cardholder = json['cardholder'],
      expirationDate = DateFormat('MM-yyyy').parse(json['expirationDate']),
      cvvCVC = int.parse(json['CVV_CVC']);
}