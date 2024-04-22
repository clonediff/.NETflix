import 'package:flutter/material.dart';
import 'package:mobile/constants/colors.dart';

ButtonStyle settingsSubmitButton([bool Function()? isDisabled]) {
  return ButtonStyle(
    textStyle: MaterialStateProperty.resolveWith(
          (states) => const TextStyle(
        fontWeight: FontWeight.w500,
      ),
    ),
    padding: MaterialStateProperty.resolveWith(
          (states) => const EdgeInsets.symmetric(vertical: 5, horizontal: 10),
    ),
    backgroundColor: MaterialStateProperty.resolveWith(
          (states) => isDisabled == null || !isDisabled()
          ? DotNetflixColors.headerBackgroundColor
          : const Color.fromARGB(40, 0, 0, 0),
    ),
    foregroundColor: MaterialStateProperty.resolveWith(
          (states) => isDisabled == null || !isDisabled()
          ? Colors.white
          : const Color.fromARGB(25, 0, 0, 0),
    ),
  );
}
