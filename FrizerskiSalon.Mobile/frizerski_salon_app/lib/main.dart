
import 'dart:io';

import 'package:flutter/material.dart';
import '/screens/DetaljiKlijenta.dart';
import '/screens/DetaljiObavijesti.dart';
import '/screens/DetaljiProizvoda.dart';
import '/screens/DetaljiTermina.dart';
import '/screens/Home.dart';
import '/screens/Loading.dart';
import '/screens/Login.dart';
import '/screens/Pocetna.dart';
import '/screens/PortfolioDetalji.dart';
import '/screens/Registracija.dart';
import '/screens/SveObavijesti.dart';
import '/screens/SviProizvodi.dart';
import '/screens/SviUposlenici.dart';
import '/screens/ZakazivanjeTermina.dart';
import '/screens/Narudzba.dart';

import 'model/Narudzbe.dart';

class IgnoreCertificateErrorOverrides extends HttpOverrides{
  @override
  HttpClient createHttpClient(SecurityContext? context){
    return super.createHttpClient(context)
      ..badCertificateCallback = ((X509Certificate cert, String host, int port) {
        return true;
      });
  }
}

void main() {
  HttpOverrides.global=new IgnoreCertificateErrorOverrides();
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({Key? key}) : super(key: key);

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      home:Pocetna(),
      routes: {
        '/detaljiKlijenta':(context)=>DetaljiKlijenta(),
        '/detaljiObavijesti':(context)=>DetaljiObavijesti(),
        'detaljiProizvoda':(context)=>DetaljiProizvoda(),
        '/detaljiTermina':(context)=>DetaljiTermina(),
        '/home':(context)=>Home(),
        '/loading':(context)=>Loading(),
        '/login':(context)=>Login(),
        '/narudzbe':(context)=>Narudzba(),
        '/portfolioDetalji':(context)=>PortfolioDetalji(),
        '/registracija':(context)=>Registracija(),
        '/sveObavijesti':(context)=>SveObavijesti(),
        '/sviProizvodi':(context)=>SviProizvodi(),
        '/sviUposlenici':(context)=>SviUposlenici(),
        '/zakazivanjeTermina':(context)=>ZakazivanjeTermina(),
      }
    );
  }
}