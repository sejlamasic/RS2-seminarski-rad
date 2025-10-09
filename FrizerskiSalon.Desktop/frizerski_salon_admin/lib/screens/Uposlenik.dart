import 'dart:io';
import 'dart:typed_data';
import 'package:flutter/material.dart';
import 'package:frizerski_salon_admin/model/Zanimanja.dart';
import 'dart:convert';
import 'package:shared_preferences/shared_preferences.dart';
import '../model/Spolovi.dart';
import '../model/Uposlenik.dart';
import '../providers/APIService.dart';

class UposlenikScreen extends StatefulWidget {
  const UposlenikScreen({super.key});

  @override
  State<UposlenikScreen> createState() => _UposlenikScreenState();
}

class _UposlenikScreenState extends State<UposlenikScreen> {
  Uposlenici? uposlenik;
  bool isLoading = true;
  bool isSaving = false;

  final _formKey = GlobalKey<FormState>();

  // Kontroleri
  final imeController = TextEditingController();
  final prezimeController = TextEditingController();
  final korisnickoImeController = TextEditingController();
  final lozinkaController = TextEditingController();
  final potvrdiLozinkuController = TextEditingController();
  final emailController = TextEditingController();
  final telefonController = TextEditingController();

  // Dropdown vrijednosti
  List<Spolovi> sviSpolovi = [];
  List<Zanimanja> svaZanimanja = [];
  Spolovi? odabraniSpol;
  Zanimanja? odabranoZanimanje;

  @override
  void initState() {
    super.initState();
    fetchDropdownValues();
    fetchTrenutniUposlenik();
  }

  Future<void> fetchDropdownValues() async {
    try {
      var spolResponse = await APIService.Get('Spol', null);
      if (spolResponse != null) {
        sviSpolovi = spolResponse.map((e) => Spolovi.fromJson(e)).toList();
      }

      var zanimanjeResponse = await APIService.Get('Zanimanje', null);
      if (zanimanjeResponse != null) {
        // Ukloni duplikate po zanimanjeId
        svaZanimanja = zanimanjeResponse
            .map((e) => Zanimanja.fromJson(e))
            .fold<List<Zanimanja>>([], (acc, z) {
          if (!acc.any((x) => x.zanimanjeId == z.zanimanjeId)) acc.add(z);
          return acc;
        });
      }
      setState(() {});
    } catch (e) {
      print('❌ Greška pri dohvaćanju dropdown vrijednosti: $e');
    }
  }

  Future<void> fetchTrenutniUposlenik() async {
    setState(() => isLoading = true);

    final prefs = await SharedPreferences.getInstance();
    final savedKorisnickoIme = prefs.getString('korisnickoIme');
    final savedId = prefs.getInt('uposlenikId');

    if (savedKorisnickoIme == null || savedId == null) {
      setState(() => isLoading = false);
      return;
    }

    APIService.korisnickoIme = savedKorisnickoIme;
    APIService.uposlenikId = savedId;

    try {
      var response = await APIService.Get('Uposlenik', null);
      if (response != null) {
        final found = response.map((e) => Uposlenici.fromJson(e)).firstWhere(
              (u) =>
                  u.korisnickoIme?.toLowerCase() ==
                  APIService.korisnickoIme?.toLowerCase(),
              orElse: () => throw Exception('Trenutni uposlenik nije pronađen'),
            );

        setState(() {
          uposlenik = found;
          imeController.text = found.ime ?? '';
          prezimeController.text = found.prezime ?? '';
          korisnickoImeController.text = found.korisnickoIme ?? '';
          emailController.text = found.email ?? '';
          telefonController.text = found.telefon ?? '';

          // Spol
          if (sviSpolovi.isNotEmpty) {
            odabraniSpol = sviSpolovi.firstWhere(
              (s) => s.spolId == found.spolId,
              orElse: () => sviSpolovi.first,
            );
          }

          // Zanimanje
          if (found.zanimanjeId != null && svaZanimanja.isNotEmpty) {
            odabranoZanimanje = svaZanimanja.firstWhere(
              (z) => z.zanimanjeId == found.zanimanjeId,
              orElse: () => svaZanimanja.first,
            );
          }

          isLoading = false;
        });
      } else {
        setState(() => isLoading = false);
      }
    } catch (e) {
      setState(() => isLoading = false);
    }
  }

Future<void> spremiPromjene() async {
  if (!_formKey.currentState!.validate()) return;

  setState(() => isSaving = true);
  await APIService.loadToken();
  try {
    final updatedUposlenik = {
      "uposlenikId": uposlenik!.uposlenikId,
      "ime": imeController.text,
      "prezime": prezimeController.text,
      "korisnickoIme": korisnickoImeController.text,
      "email": emailController.text,
      "telefon": telefonController.text,
      "spolId": odabraniSpol?.spolId,
      "zanimanjeId": odabranoZanimanje?.zanimanjeId,
      "slika": uposlenik!.slika != null ? base64Encode(uposlenik!.slika!) : "",
    };

    if (lozinkaController.text.isNotEmpty) {
      updatedUposlenik["Lozinka"] = lozinkaController.text;
      updatedUposlenik["PotvrdiLozinku"] = potvrdiLozinkuController.text;
    }

    final body = jsonEncode(updatedUposlenik);

    bool success = await APIService.Put('Uposlenik', uposlenik!.uposlenikId!, body);

    if (success) {
      showDialog(
        context: context,
        builder: (context) => AlertDialog(
          content: const Text('Promjene su uspješno spremljene.'),
          actions: [
            TextButton(
              onPressed: () => Navigator.of(context).pop(),
              child: const Text('OK'),
            ),
          ],
        ),
      );

      await fetchTrenutniUposlenik();
    } else {
      ScaffoldMessenger.of(context).showSnackBar(
        const SnackBar(content: Text('⚠️ Greška pri spremanju.')),
      );
    }
  } catch (e) {
    ScaffoldMessenger.of(context).showSnackBar(
      const SnackBar(content: Text('Došlo je do greške.')),
    );
  } finally {
    setState(() => isSaving = false);
  }
}

  @override
  Widget build(BuildContext context) {
    if (isLoading)
      return const Scaffold(body: Center(child: CircularProgressIndicator()));
    if (uposlenik == null)
      return const Scaffold(
          body: Center(child: Text('Uposlenik nije pronađen.')));

    final formWidth = MediaQuery.of(context).size.width * 0.9;
    final fieldWidth = (formWidth - 24) / 2;

    return Scaffold(
      body: SingleChildScrollView(
        padding: const EdgeInsets.all(16.0),
        child: Center(
          child: Card(
            elevation: 4,
            shape:
                RoundedRectangleBorder(borderRadius: BorderRadius.circular(16)),
            child: Padding(
              padding: const EdgeInsets.all(24.0),
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.center,
                children: [
                  // Circle avatar na vrhu
                  CircleAvatar(
                    radius: 60,
                    backgroundImage:
                        const AssetImage('assets/images/userimage.png'),
                  ),
                  const SizedBox(height: 24),
                  Form(
                    key: _formKey,
                    child: Wrap(
                      spacing: 12,
                      runSpacing: 12,
                      children: [
                        _buildTextFieldWrap('Ime', imeController, fieldWidth),
                        _buildTextFieldWrap('Prezime', prezimeController, fieldWidth),
                        _buildTextFieldWrap('Korisničko ime', korisnickoImeController, fieldWidth),
                        _buildTextFieldWrap('Lozinka', lozinkaController, fieldWidth, obscureText: true),
                        _buildTextFieldWrap('Potvrdi lozinku', potvrdiLozinkuController, fieldWidth, obscureText: true),
                        _buildTextFieldWrap('Email', emailController, fieldWidth),
                        _buildTextFieldWrap('Telefon', telefonController, fieldWidth),
                        _buildDropdownWrap<Spolovi>('Spol', sviSpolovi, odabraniSpol, (v) => setState(() => odabraniSpol = v), fieldWidth),
                        _buildDropdownWrap<Zanimanja>('Zanimanje', svaZanimanja, odabranoZanimanje, (v) => setState(() => odabranoZanimanje = v), fieldWidth),
                      ],
                    ),
                  ),
                  const SizedBox(height: 32),
                  SizedBox(
                    width: 200,
                    child: ElevatedButton(
                      onPressed: isSaving ? null : spremiPromjene,
                      style: ElevatedButton.styleFrom(
                        backgroundColor: Colors.blueAccent,
                        padding: const EdgeInsets.symmetric(vertical: 16),
                        shape: RoundedRectangleBorder(
                            borderRadius: BorderRadius.circular(10)),
                      ),
                      child: isSaving
                          ? const CircularProgressIndicator(color: Colors.white)
                          : const Text('Spremi promjene', style: TextStyle(color: Colors.white, fontSize: 18)),
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

  Widget _buildTextFieldWrap(String label, TextEditingController controller, double width,
      {bool obscureText = false}) {
    return SizedBox(
      width: width,
      child: _buildTextField(label, controller, obscureText: obscureText),
    );
  }

  Widget _buildDropdownWrap<T>(String label, List<T> items, T? value,
      ValueChanged<T?> onChanged, double width) {
    return SizedBox(
      width: width,
      child: DropdownButtonFormField<T>(
        value: value,
        decoration: InputDecoration(
          labelText: label,
          border: OutlineInputBorder(borderRadius: BorderRadius.circular(10)),
        ),
        items: items.map((item) {
          return DropdownMenuItem(
            value: item,
            child: Text(item is Spolovi
                ? (item.naziv ?? '')
                : item is Zanimanja
                    ? item.naziv
                    : item.toString()),
          );
        }).toList(),
        onChanged: onChanged,
        validator: (v) => v == null ? 'Odaberite $label' : null,
      ),
    );
  }

  Widget _buildTextField(String label, TextEditingController controller,
      {bool obscureText = false}) {
    return TextFormField(
      controller: controller,
      obscureText: obscureText,
      decoration: InputDecoration(
        labelText: label,
        border: OutlineInputBorder(borderRadius: BorderRadius.circular(10)),
      ),
      validator: (value) {
        if ((value == null || value.isEmpty) &&
            label != 'Lozinka' &&
            label != 'Potvrdi lozinku') {
          return 'Unesite $label';
        }
        if (label == 'Potvrdi lozinku' &&
            lozinkaController.text.isNotEmpty &&
            value != lozinkaController.text) {
          return 'Lozinka i potvrda se ne poklapaju';
        }
        return null;
      },
    );
  }
}
