import 'dart:convert';
import 'package:flutter/material.dart';
import '/model/Klijenti.dart';
import '/providers/apiservice.dart';
import 'Home.dart';
import 'Pocetna.dart';


class DetaljiKlijenta extends StatefulWidget {
  const DetaljiKlijenta({Key? key}) : super(key: key);

  @override
  _DetaljiKlijentaState createState() => _DetaljiKlijentaState();
}

class _DetaljiKlijentaState extends State<DetaljiKlijenta> {

  Klijenti korisnik = Klijenti();
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: const Text("Moj profil")),
      body: body(),
    );
  }

    dynamic response;
    TextEditingController imeController = TextEditingController();
    TextEditingController prezimeController = TextEditingController();
    TextEditingController emailController = TextEditingController();
    TextEditingController dtpDatumRodjenjaController = TextEditingController();
    TextEditingController korisnickoImeController = TextEditingController();
    TextEditingController lozinkaController = TextEditingController();
    DateTime _odabraniDatumRodjenja = DateTime.now();

  Widget body() {
    const _obaveznoPolje = "Polje je obavezno";
    TextStyle style = const TextStyle(fontSize: 18.0);
    List<DropdownMenuItem> spolovi = [
      DropdownMenuItem(
          child: Text(
            "Muški",
            style: TextStyle(fontSize: 18.0, color: Colors.grey[600]),
          ),
          value: 1),
      DropdownMenuItem(
          child: Text(
            "Ženski",
            style: TextStyle(fontSize: 18.0, color: Colors.grey[600]),
          ),
          value: 2),
      DropdownMenuItem(
          child: Text(
            "Ostalo",
            style: TextStyle(fontSize: 18.0, color: Colors.grey[600]),
          ),
          value: 3),
    ];
    int? _odabraniSpol;

    final _formKey = GlobalKey<FormState>();

    Future<void> _selectDate(BuildContext context) async {
      final DateTime? picked = await showDatePicker(
          context: context,
          initialDate: _odabraniDatumRodjenja,
          firstDate: DateTime(1900, 1),
          lastDate: DateTime.now());

      if (picked != null && picked != _odabraniDatumRodjenja) {
        setState(() {
          _odabraniDatumRodjenja = picked;
          dtpDatumRodjenjaController.text =
              "${_odabraniDatumRodjenja.toLocal()}".split(' ')[0];
        });
      }
    }

    Future<void> sendRequest(Map<String, dynamic> request) async {
      response = await APIService.Put("Klijent", APIService.klijentId!,
          jsonEncode(request));
    }

    Future<void> _showDialog(String text, [dismissable = true]) async {
      return showDialog<void>(
        barrierDismissible: dismissable,
        context: context,
        builder: (BuildContext context) {
          return AlertDialog(
            content: Text(text),
            actions: <Widget>[
              TextButton(
                child: const Text('OK'),
                onPressed: () {
                  Navigator.of(context).pushAndRemoveUntil(
                    MaterialPageRoute(
                      builder: (BuildContext context) => const Home(),
                    ),
                    (route) => false,
                  );
                },
              ),
            ],
          );
        },
      );
    }

    final txtIme = TextFormField(
      validator: (value) {
        return value == null || value.isEmpty ? _obaveznoPolje : null;
      },
      controller: imeController,
      obscureText: false,
      style: style,
      decoration: InputDecoration(
          contentPadding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
          hintText: "Ime",
          border:
              OutlineInputBorder(borderRadius: BorderRadius.circular(32.0))),
    );
    final txtPrezime = TextFormField(
      validator: (value) {
        return value == null || value.isEmpty ? _obaveznoPolje : null;
      },
      controller: prezimeController,
      obscureText: false,
      style: style,
      decoration: InputDecoration(
          contentPadding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
          hintText: "Prezime",
          border:
              OutlineInputBorder(borderRadius: BorderRadius.circular(32.0))),
    );

    final txtMail = TextFormField(
      validator: (value) {
        if (value == null || value.isEmpty) {
          return _obaveznoPolje;
        } else {
          return null;
        }
      },
      controller: emailController,
      obscureText: false,
      style: style,
      decoration: InputDecoration(
          contentPadding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
          hintText: "Email",
          border:
              OutlineInputBorder(borderRadius: BorderRadius.circular(32.0))),
    );

    final dtpDatumRodjenja = InkWell(
      child: IgnorePointer(
        child: TextFormField(
          validator: (value) {
            return value == null || value.isEmpty ? _obaveznoPolje : null;
          },
          controller: dtpDatumRodjenjaController,
          obscureText: false,
          style: style,
          decoration: InputDecoration(
              contentPadding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
              hintText: "Datum rođenja",
              border: OutlineInputBorder(
                  borderRadius: BorderRadius.circular(32.0))),
        ),
      ),
      onTap: () {
        _selectDate(context);
      },
    );

    final txtKorisnickoIme = TextFormField(
      validator: (value) {
        return value == null || value.isEmpty ? _obaveznoPolje : null;
      },
      controller: korisnickoImeController,
      obscureText: false,
      style: style,
      decoration: InputDecoration(
          contentPadding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
          hintText: "Korisničko ime",
          border:
              OutlineInputBorder(borderRadius: BorderRadius.circular(32.0))),
    );
    final txtLozinka = TextFormField(
      validator: (value) {
        if (value==null || value.isEmpty)
          return "Obavezno polje!";
        else if (value != null && value.isNotEmpty) {
          if (value.length < 5) {
            return "Minimalna dužina 5!";
          } else if (!value.contains(RegExp(r'[0-9]')) ||
              !value.contains(RegExp(r'[a-zA-Z]'))) {
            return "Obavezno jedno slovo i broj!";
          } else {
            return null;
          }
        }
      },
      controller: lozinkaController,
      obscureText: true,
      style: style,
      decoration: InputDecoration(
          contentPadding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
          hintText: "Lozinka",
          border:
              OutlineInputBorder(borderRadius: BorderRadius.circular(32.0))),
    );

    final btnOdjava = Material(
      elevation: 5.0,
      borderRadius: BorderRadius.circular(30.0),
      color: Colors.white,
      child: MaterialButton(
        padding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
        onPressed: () async {
          Navigator.of(context).pushAndRemoveUntil(
            MaterialPageRoute(
              builder: (BuildContext context) => const Pocetna(),
            ),
            (route) => false,
          );
        },
        child: Text("Odjavi se",
            textAlign: TextAlign.center,
            style: style.copyWith(
                color: const Color(0xff01A0C7), fontWeight: FontWeight.bold)),
      ),
    );
    final btnSpremiIzmjene = Material(
      elevation: 5.0,
      borderRadius: BorderRadius.circular(30.0),
      color: const Color(0xff01A0C7),
      child: MaterialButton(
        padding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
        onPressed: () async {
          if (_formKey.currentState!.validate()) {
            response = null;
            Map<String, dynamic> request = {
            'ime': imeController.text,
            'prezime': prezimeController.text,
            'datumRodjenja': _odabraniDatumRodjenja.toIso8601String(),
            'email': emailController.text,
            'telefon': korisnik.telefon,
            'korisnickoIme': korisnickoImeController.text,
            'spolId': _odabraniSpol,
            'lozinka': lozinkaController.text,
            'potvrdiLozinku': lozinkaController.text,
            };

            if (lozinkaController.text == null || lozinkaController.text.isEmpty) {
              print("nedostaje lozinka ok");
            }

            await sendRequest(request);
            if (response == null) {
              _showDialog('Došlo je do greške, pokušajte opet! ');
            } else {
              _showDialog('Uspješno ste uredili Vaše podatke');
            }
          }
        },
        child: Text("Spremi izmjene",
            textAlign: TextAlign.center,
            style: style.copyWith(
                color: Colors.white, fontWeight: FontWeight.bold)),
      ),
    );

    Widget ddSpol() {
      return DropdownButtonFormField<dynamic>(
        validator: (value) {
          return value == null /*|| value.isEmpty*/ ? _obaveznoPolje : null;
        },
        hint: Text(
          'Spol',
          style: TextStyle(fontSize: 18.0, color: Colors.grey[600]),
        ),
        isExpanded: true,
        items: spolovi,
        onChanged: (newVal) {
          _odabraniSpol = newVal;
        },
        value: _odabraniSpol,
        decoration: InputDecoration(
            contentPadding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
            border:
                OutlineInputBorder(borderRadius: BorderRadius.circular(32.0))),
      );
    }

    return FutureBuilder(
      future: getKorisnik(APIService.klijentId),
      builder: (BuildContext context, AsyncSnapshot snapshot) {
        if (snapshot.connectionState == ConnectionState.waiting) {
          return const Center(child: Text("Loading..."));
        } else if (snapshot.hasError) {
          return const Center(child: Text("Greška pri učitavanju."));
        } else {
          imeController.text = korisnik.ime!;
          prezimeController.text = korisnik.prezime!;
          emailController.text = korisnik.email!;
          if(_odabraniDatumRodjenja.difference(DateTime.now()).inDays==0)
            _odabraniDatumRodjenja=korisnik.datumRodjenja!;
          dtpDatumRodjenjaController.text =
              "${_odabraniDatumRodjenja.toLocal()}".split(' ')[0];
          _odabraniSpol = korisnik.spolId!;
          korisnickoImeController.text = korisnik.korisnickoIme!;
          //lozinkaController.text = korisnik.lozinka!;
          imeController.text = korisnik.ime!;

          return SingleChildScrollView(
            child: Container(
              color: Colors.white,
              child: Padding(
                padding: const EdgeInsets.all(36.0),
                child: Column(
                    crossAxisAlignment: CrossAxisAlignment.center,
                    mainAxisAlignment: MainAxisAlignment.center,
                    children: [
                      Form(
                        key: _formKey,
                        autovalidateMode: AutovalidateMode.onUserInteraction,
                        child: Column(
                            crossAxisAlignment: CrossAxisAlignment.center,
                            mainAxisAlignment: MainAxisAlignment.center,
                            children: [
                              //Ime i prezime
                              Row(
                                children: [
                                  Flexible(child: txtIme),
                                  const SizedBox(
                                    width: 5.0,
                                  ),
                                  Flexible(child: txtPrezime)
                                ],
                              ),
                              const SizedBox(height: 5.0),
                              txtMail,
                              const SizedBox(height: 5.0),
                              //Datum rodjenja i spol
                              Row(
                                children: [
                                  Flexible(child: dtpDatumRodjenja),
                                  const SizedBox(
                                    width: 5.0,
                                  ),
                                  Flexible(child: ddSpol())
                                ],
                              ),
                              const SizedBox(height: 5.0),
                              //Korisnicko ime i lozinka
                              Row(
                                children: [
                                  Flexible(child: txtKorisnickoIme),
                                  const SizedBox(
                                    width: 5.0,
                                  ),
                                  Flexible(child: txtLozinka)
                                ],
                              ),
                              const SizedBox(height: 15.0),
                              //Buttoni
                              Row(
                                  crossAxisAlignment: CrossAxisAlignment.center,
                                  mainAxisAlignment: MainAxisAlignment.center,
                                  children: [
                                    btnOdjava,
                                    const SizedBox(width: 15.0),
                                    Expanded(child: btnSpremiIzmjene)
                                  ]),
                            ]),
                      ),
                    ]),
              ),
            ),
          );
        }
        // else {
        //   return const Center(
        //     child: Text("Došlo je do greške!"),
        //   );
        // }
      },
    );
  }

  Future<dynamic> getKorisnik(int? korisnikId) async {
    var response = await APIService.GetById("Klijent", korisnikId!, null);
    korisnik = Klijenti.fromJson(response);
    return response;
  }
}