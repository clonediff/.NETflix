import 'package:flutter/material.dart';
import 'package:mobile/constants/styles.dart';

class DotNetflixDateFormField extends StatelessWidget{
  final String fieldName;
  final Icon icon;
  final TextEditingController controller;

  const DotNetflixDateFormField({
    super.key,
    required this.fieldName,
    required this.icon,
    required this.controller
  });

  @override
  Widget build(BuildContext context) {
    return Padding(
        padding: const EdgeInsets.all(12.0),
        child: TextFormField(
          controller: controller,
          style: DotNetflixTextStyles.mainTextStyle,
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
          ),
          onTap: () async {
            FocusScope.of(context).requestFocus(FocusNode());
            final DateTime? picked = await showDatePicker(
              context: context,
              firstDate: DateTime(1970),
              lastDate: DateTime(2101),
            );
            if (picked != null) {
              var date = picked.toString();
              controller.text = date;
            }
          },
        )
    );
  }
}