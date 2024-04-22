import 'package:flutter/material.dart';
import 'package:mobile/constants/styles.dart';

class DotNetflixTextFormField extends StatelessWidget{
  final String fieldName;
  final Icon icon;
  final Function(String? value) validator;
  final bool hideText;
  TextEditingController? controller;

  DotNetflixTextFormField({
    super.key,
    required this.fieldName,
    required this.icon,
    required this.validator,
    required this.hideText,
    this.controller
  });

  @override
  Widget build(BuildContext context) {
    return Padding(
        padding: const EdgeInsets.all(12.0),
        child: TextFormField(
          obscureText: hideText,
          controller: controller,
          style: DotNetflixTextStyles.mainTextStyle,
          validator: (value) => validator(value),
          decoration: InputDecoration(
              errorMaxLines: 3,
              hintText: fieldName,
              labelText: fieldName,
              prefixIcon: icon,
              errorStyle: const TextStyle(fontSize: 18.0, color: Colors.red),
              border: const OutlineInputBorder(
                  borderSide: BorderSide(color: Colors.red),
                  borderRadius: BorderRadius.all(Radius.circular(9.0)
                  )
              )
          )
        )
    );
  }
}