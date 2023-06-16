import 'dart:convert';
import 'dart:typed_data';
import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import '/model/StavkePortfolija.dart';
import 'SviProizvodi.dart';

class DetaljiStavkePortfolija extends StatelessWidget {
  final StavkePortfolija? stavka;
  DetaljiStavkePortfolija({Key? key, this.stavka}) : super(key: key);
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text(
          'Detalji stavke portfolija',
          style: TextStyle(fontSize: 20),
        ),
        backgroundColor: Colors.blue,
      ),
      body: Column(
        children: [
          Center(
            child: Image(
                height: 300,
                width: 300,
                image: /*Image.memory(Uint8List.fromList(stavka!.slika!)).image, 
                errorBuilder: (context, error, stackTrace) => Image.asset("assets/images/error.jpg"),*/
                AssetImage('assets/images/imgplaceholder.jpg')
                )),
          Text(
            "Datum objave: ${DateFormat('dd/MM/yyyy').format(stavka!.datum!)}",
            style: TextStyle(fontSize: 20),
          ),
          Text(
            stavka!.opis!,
            style: TextStyle(fontSize: 18, color: Colors.blueGrey),
          ),
          //TextButton(onPressed: () {print("${Uint8List.fromList(stavka!.slika!)}");}, child: Text('vidi list<int> sliku'))
        ],
      ),
    );
  }
}
