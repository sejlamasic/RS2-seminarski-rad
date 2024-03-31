import 'package:flutter/material.dart';

// ignore: must_be_immutable
class MasterScreenWidget extends StatefulWidget {
  Widget ? child;
  String ? title;
  MasterScreenWidget({this.child, this.title, Key? key }) : super(key: key);

  @override
  // ignore: library_private_types_in_public_api
  _MasterScreenWidgetState createState() => _MasterScreenWidgetState();
}

class _MasterScreenWidgetState extends State<MasterScreenWidget> {
   @override
  Widget build(BuildContext context) {
    // ignore: avoid_unnecessary_containers
    return Scaffold(
      appBar: AppBar(
       title: Text(widget.title ?? ""),
      ),
      body: widget.child,
      );
    
  }
}
