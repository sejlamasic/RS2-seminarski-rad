import 'package:flutter/material.dart';

class Pocetna extends StatefulWidget {
  const Pocetna({Key? key}) : super(key: key);

  @override
  // ignore: library_private_types_in_public_api
  _PocetnaState createState() => _PocetnaState();
}

class _PocetnaState extends State<Pocetna> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Center(
        child: Padding(
          padding: const EdgeInsets.all(16),
          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              const SizedBox(
                width: 150,
                height: 150,
                child: Image(image: AssetImage('assets/images/logo.jpg')),
              ),
              const SizedBox(height: 20),
              Container(
                width: double.infinity,
                decoration: BoxDecoration(
                  color: Colors.blue[700],
                  borderRadius: BorderRadius.circular(15),
                ),
                child: TextButton(
                  onPressed: () async {
                    Navigator.of(context).pushReplacementNamed('/registracija');
                  },
                  child: const Text(
                    'Registrujte se',
                    style: TextStyle(color: Colors.white, fontSize: 20),
                  ),
                ),
              ),
              const SizedBox(height: 10),
              Container(
                width: double.infinity,
                decoration: BoxDecoration(
                  color: Colors.blue[700],
                  borderRadius: BorderRadius.circular(15),
                ),
                child: TextButton(
                  onPressed: () async {
                    Navigator.of(context).pushReplacementNamed('/login');
                  },
                  child: const Text(
                    'Prijavite se',
                    style: TextStyle(color: Colors.white, fontSize: 20),
                  ),
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }
}
