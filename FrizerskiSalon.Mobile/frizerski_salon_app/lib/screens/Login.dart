//import 'dart:js_util';

import 'package:flutter/material.dart';
import '/providers/apiservice.dart';
import 'Pocetna.dart';

class Login extends StatefulWidget {
  const Login({Key? key}) : super(key: key);

  @override
  // ignore: library_private_types_in_public_api
  _LoginState createState() => _LoginState();
}

class _LoginState extends State<Login> {
  TextEditingController korisnickoImeController = TextEditingController();
  TextEditingController lozinkaController = TextEditingController();
  // ignore: prefer_typing_uninitialized_variables
  var result;
  bool _validateKorisnickoIme = false;
  bool _validateLozinka = false;
  // ignore: non_constant_identifier_names
  Future<void> GetData() async {
    result = await APIService.prijava(
        korisnickoImeController.text, lozinkaController.text);
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(
          leading: IconButton(
            icon: const Icon(Icons.arrow_back),
            onPressed: () {
              Navigator.of(context).pushReplacement(
                MaterialPageRoute(
                  builder: (context) => const Pocetna(),
                ),
              );
            },
          ),
        ),
        body: SingleChildScrollView(
          //Center(
          child: Padding(
            padding: const EdgeInsets.all(60),
            child:
                Column(mainAxisAlignment: MainAxisAlignment.center, children: [
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
                        : null),
              ),
              const SizedBox(
                height: 20,
              ),
              TextField(
                controller: lozinkaController,
                obscureText: true,
                autocorrect: false,
                decoration: InputDecoration(
                  border: OutlineInputBorder(
                      borderRadius: BorderRadius.circular(15)),
                  hintText: 'Lozinka',
                  errorText: _validateLozinka
                      ? 'Polje lozinka ne može biti prazno'
                      : null,
                ),
              ),
              const SizedBox(
                height: 20,
              ),
              Container(
                height: 60,
                width: 300,
                decoration: BoxDecoration(
                    color: Colors.blue[700],
                    borderRadius: BorderRadius.circular(15)),
                child: TextButton(
                    onPressed: () async {
                      setState(() {
                        korisnickoImeController.text.isEmpty
                            ? _validateKorisnickoIme = true
                            : _validateKorisnickoIme = false;
                        lozinkaController.text.isEmpty
                            ? _validateLozinka = true
                            : _validateLozinka = false;
                      });
                      APIService.korisnickoIme = korisnickoImeController.text;
                      APIService.lozinka = lozinkaController.text;
                      await GetData();
                      if (result != null) {
                        // ignore: use_build_context_synchronously
                        Navigator.of(context).pushReplacementNamed('/home');
                      } else {
                        if (_validateKorisnickoIme == false &&
                            _validateLozinka == false) {
                          // ignore: use_build_context_synchronously
                          showDialog(
                              context: context,
                              builder: (BuildContext context) {
                                return AlertDialog(
                                  title: const Text("Upozorenje"),
                                  content: const Text(
                                      "Pogrešno korisničko ime ili lozinka"),
                                  actions: [
                                    TextButton(
                                      child: const Text("OK"),
                                      onPressed: () {
                                        Navigator.of(context).pop();
                                      },
                                    ),
                                  ],
                                );
                              });
                        }
                      }
                    },
                    child: const Text('Prijava',
                        style: TextStyle(color: Colors.white, fontSize: 20))),
              ),
              const SizedBox(
                height: 20,
              ),
              Container(
                height: 60,
                width: 300,
                decoration: BoxDecoration(
                    color: Colors.white,
                    borderRadius: BorderRadius.circular(15)),
                child: TextButton(
                    onPressed: () async {
                      Navigator.of(context)
                          .pushReplacementNamed('/registracija');
                    },
                    child: Text('Registracija',
                        style:
                            TextStyle(color: Colors.blue[700], fontSize: 20))),
              ),
            ]),
          ),
        ));
  }
}
