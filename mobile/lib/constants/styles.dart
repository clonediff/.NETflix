import 'package:flutter/material.dart';
import 'colors.dart';

class DotNetflixTextStyles {
  static const mainTextStyle = TextStyle(fontSize: 16, fontWeight: FontWeight.w400, color: Colors.white);
  static const subtitleStyle = TextStyle(fontSize: 12, fontWeight: FontWeight.w400, color: Colors.grey);
  static const titleStyle = TextStyle(fontSize: 14, fontWeight: FontWeight.w400, color: Colors.white);
  static const personsTitleStyle = TextStyle(fontSize: 16, fontWeight: FontWeight.w400, color: Colors.white);
  static const filmNameStyle = TextStyle(fontSize: 20, fontWeight: FontWeight.w500, color: Colors.white,);
  static const filmAgeRatingStyle = TextStyle(fontSize: 16, fontWeight: FontWeight.w500,
      color: DotNetflixColors.mainBackgroundColor, backgroundColor: Colors.white, height: 1.2
  );
  static const loginStyle = TextStyle(fontSize: 24, fontWeight: FontWeight.w600, color: Colors.white);
}

class DotNetflixButtonStyles {
  static final ButtonStyle submitButtonStyle =
  ElevatedButton.styleFrom(
      backgroundColor: DotNetflixColors.submitButtonColor
  );
}