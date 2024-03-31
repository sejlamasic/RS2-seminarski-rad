import 'package:flutter/material.dart';
import 'package:frizerski_salon_admin/screens/Login.dart';
import 'package:frizerski_salon_admin/screens/Registracija.dart';

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
              TextButton(
                onPressed: () async {
                  Navigator.of(context).push(
                    MaterialPageRoute(
                      builder: (context) => const Login(),
                    ),
                  );
                },
                style: ButtonStyle(
                  padding: MaterialStateProperty.all<EdgeInsets>(
                    const EdgeInsets.symmetric(vertical: 16, horizontal: 40),
                  ),
                  backgroundColor:
                      MaterialStateProperty.all<Color>(Colors.blue[700]!),
                  shape: MaterialStateProperty.all<RoundedRectangleBorder>(
                    RoundedRectangleBorder(
                      borderRadius: BorderRadius.circular(15),
                    ),
                  ),
                ),
                child: const Text(
                  'Prijava',
                  style: TextStyle(color: Colors.white, fontSize: 20),
                ),
              ),
              const SizedBox(height: 20),
              Align(
                alignment: Alignment.center,
                child: Container(
                  width: 200, // Adjust the width as needed
                  decoration: BoxDecoration(
                    color: Colors.blue[700],
                    borderRadius: BorderRadius.circular(15),
                  ),
                  child: TextButton(
                    onPressed: () async {
                      Navigator.of(context).push(
                        MaterialPageRoute(
                          builder: (context) =>  const Registracija(),
                        ),
                      );
                    },
                    style: ButtonStyle(
                      padding: MaterialStateProperty.all<EdgeInsets>(
                        const EdgeInsets.symmetric(
                            vertical: 16, horizontal: 40),
                      ),
                    ),
                    child: const Text(
                      'Registracija',
                      style: TextStyle(color: Colors.white, fontSize: 20),
                    ),
                  ),
                ),
              ),
              const SizedBox(height: 10),
              const Text(
                'Niste registrovani? Registrirajte se ovdje',
                style: TextStyle(fontSize: 16),
              ),
            ],
          ),
        ),
      ),
    );
  }
}
