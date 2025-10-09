// login.dart
import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:shared_preferences/shared_preferences.dart';
import '/providers/apiservice.dart';
import 'HomePage.dart';
import 'Pocetna.dart';
import 'Registracija.dart';

class Login extends StatefulWidget {
  const Login({Key? key}) : super(key: key);

  @override
  _LoginState createState() => _LoginState();
}

class _LoginState extends State<Login> {
  final TextEditingController korisnickoImeController = TextEditingController();
  final TextEditingController lozinkaController = TextEditingController();
  bool _validateKorisnickoIme = false;
  bool _validateLozinka = false;

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        leading: IconButton(
          icon: const Icon(Icons.arrow_back),
          onPressed: () {
            Navigator.of(context).pushReplacement(
              MaterialPageRoute(builder: (context) => const Pocetna()),
            );
          },
        ),
      ),
      body: SingleChildScrollView(
        child: Center(
          child: Padding(
            padding: const EdgeInsets.all(20.0),
            child: SizedBox(
              width: 300,
              child: Column(
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  const Image(image: AssetImage('assets/images/logo.jpg')),
                  const SizedBox(height: 10),
                  TextField(
                    controller: korisnickoImeController,
                    decoration: InputDecoration(
                      border: OutlineInputBorder(
                        borderRadius: BorderRadius.circular(15),
                      ),
                      hintText: 'Korisničko ime',
                      errorText: _validateKorisnickoIme
                          ? 'Polje korisničko ime ne može biti prazno'
                          : null,
                    ),
                  ),
                  const SizedBox(height: 20),
                  TextField(
                    controller: lozinkaController,
                    obscureText: true,
                    autocorrect: false,
                    decoration: InputDecoration(
                      border: OutlineInputBorder(
                        borderRadius: BorderRadius.circular(15),
                      ),
                      hintText: 'Lozinka',
                      errorText: _validateLozinka
                          ? 'Polje lozinka ne može biti prazno'
                          : null,
                    ),
                  ),
                  const SizedBox(height: 20),
                  Container(
                    height: 60,
                    width: 300,
                    decoration: BoxDecoration(
                      color: Colors.blue[700],
                      borderRadius: BorderRadius.circular(15),
                    ),
                    child: TextButton(
                      onPressed: () async {
                        setState(() {
                          _validateKorisnickoIme =
                              korisnickoImeController.text.isEmpty;
                          _validateLozinka = lozinkaController.text.isEmpty;
                        });
                        if (!_validateKorisnickoIme && !_validateLozinka) {
                          await prijava(context);
                        }
                      },
                      child: const Text(
                        'Prijava',
                        style: TextStyle(color: Colors.white, fontSize: 20),
                      ),
                    ),
                  ),
                  const SizedBox(height: 20),
                  Container(
                    height: 60,
                    width: 300,
                    decoration: BoxDecoration(
                      color: Colors.white,
                      borderRadius: BorderRadius.circular(15),
                    ),
                    child: TextButton(
                      onPressed: () {
                        Navigator.of(context).push(
                          MaterialPageRoute(
                            builder: (context) => const Registracija(),
                          ),
                        );
                      },
                      child: Text(
                        'Registracija',
                        style: TextStyle(color: Colors.blue[700], fontSize: 20),
                      ),
                    ),
                  ),
                ],
              ),
            ),
          ),
        ),
      ),
    );
  }

  Future<void> prijava(BuildContext context) async {
    final result = await APIService.prijava(
        korisnickoImeController.text, lozinkaController.text);

    if (result != null) {
      // ignore: unnecessary_type_check
      final map = result is String ? jsonDecode(result) : result;
      APIService.uposlenikId = map['id'];
      APIService.token = map['token'];
      APIService.korisnickoIme = korisnickoImeController.text;

      // Spremi podatke trajno
      final prefs = await SharedPreferences.getInstance();
      await prefs.setString('korisnickoIme', APIService.korisnickoIme!);
      await prefs.setString('token', APIService.token!);
      await prefs.setInt('uposlenikId', APIService.uposlenikId!);

      Navigator.of(context).pushReplacement(
        MaterialPageRoute(builder: (context) => const HomePageScreen()),
      );
    } else {
      showDialog(
        context: context,
        builder: (BuildContext context) {
          return AlertDialog(
            title: const Text("Upozorenje"),
            content: const Text("Pogrešno korisničko ime ili lozinka"),
            actions: [
              TextButton(
                child: const Text("OK"),
                onPressed: () => Navigator.of(context).pop(),
              ),
            ],
          );
        },
      );
    }
  }
}
