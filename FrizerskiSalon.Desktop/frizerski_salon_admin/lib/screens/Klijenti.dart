import 'dart:convert';
import 'package:flutter/material.dart';
import '../model/Klijenti.dart';
import '../providers/apiservice.dart';

class KlijentiScreen extends StatefulWidget {
  const KlijentiScreen({Key? key}) : super(key: key);

  @override
  State<KlijentiScreen> createState() => _KlijentiScreenState();
}

class _KlijentiScreenState extends State<KlijentiScreen> {
  List<Klijenti> klijenti = [];
  List<Klijenti> filteredKlijenti = [];
  bool isLoading = true;
  TextEditingController searchController = TextEditingController();

  @override
  void initState() {
    super.initState();
    fetchKlijenti();
    searchController.addListener(_searchKlijenti);
  }

  @override
  void dispose() {
    searchController.dispose();
    super.dispose();
  }

  Future<void> fetchKlijenti() async {
    var result = await APIService.Get('Klijent', null);
    if (result != null) {
      setState(() {
        klijenti =
            result.map<Klijenti>((json) => Klijenti.fromJson(json)).toList();
        filteredKlijenti = klijenti;
        isLoading = false;
      });
    } else {
      setState(() {
        isLoading = false;
      });
    }
  }

  void _searchKlijenti() {
    String query = searchController.text.toLowerCase();
    setState(() {
      filteredKlijenti = klijenti.where((k) {
        return (k.ime?.toLowerCase().contains(query) ?? false) ||
            (k.prezime?.toLowerCase().contains(query) ?? false) ||
            (k.email?.toLowerCase().contains(query) ?? false) ||
            (k.telefon?.toLowerCase().contains(query) ?? false);
      }).toList();
    });
  }

  void _addKlijent() {
    showDialog(
      context: context,
      builder: (context) {
        TextEditingController imeController = TextEditingController();
        TextEditingController prezimeController = TextEditingController();
        TextEditingController emailController = TextEditingController();
        TextEditingController telefonController = TextEditingController();
        TextEditingController korisnickoImeController = TextEditingController();
        TextEditingController lozinkaController = TextEditingController();
        TextEditingController potvrdiLozinkuController =
            TextEditingController();
        TextEditingController datumRodjenjaController = TextEditingController();

        int? selectedSpolId;

        return AlertDialog(
          shape:
              RoundedRectangleBorder(borderRadius: BorderRadius.circular(15)),
          title: const Text('Dodaj klijenta'),
          content: SingleChildScrollView(
            child: Padding(
              padding: const EdgeInsets.only(top: 8.0, bottom: 8),
              child: Column(
                children: [
                  TextField(
                    controller: imeController,
                    decoration: const InputDecoration(
                        labelText: 'Ime', border: OutlineInputBorder()),
                  ),
                  const SizedBox(height: 10),
                  TextField(
                    controller: prezimeController,
                    decoration: const InputDecoration(
                        labelText: 'Prezime', border: OutlineInputBorder()),
                  ),
                  const SizedBox(height: 10),
                  TextField(
                    controller: emailController,
                    decoration: const InputDecoration(
                        labelText: 'Email', border: OutlineInputBorder()),
                  ),
                  const SizedBox(height: 10),
                  TextField(
                    controller: telefonController,
                    decoration: const InputDecoration(
                        labelText: 'Telefon', border: OutlineInputBorder()),
                  ),
                  const SizedBox(height: 10),
                  TextField(
                    controller: korisnickoImeController,
                    decoration: const InputDecoration(
                        labelText: 'Korisničko ime',
                        border: OutlineInputBorder()),
                  ),
                  const SizedBox(height: 10),
                  TextField(
                    controller: lozinkaController,
                    obscureText: true,
                    decoration: const InputDecoration(
                        labelText: 'Lozinka', border: OutlineInputBorder()),
                  ),
                  const SizedBox(height: 10),
                  TextField(
                    controller: potvrdiLozinkuController,
                    obscureText: true,
                    decoration: const InputDecoration(
                        labelText: 'Potvrdi lozinku',
                        border: OutlineInputBorder()),
                  ),
                  const SizedBox(height: 10),
                  TextField(
                    controller: datumRodjenjaController,
                    readOnly: true,
                    decoration: const InputDecoration(
                        labelText: 'Datum rođenja',
                        border: OutlineInputBorder()),
                    onTap: () async {
                      DateTime? pickedDate = await showDatePicker(
                        context: context,
                        initialDate: DateTime(2000),
                        firstDate: DateTime(1900),
                        lastDate: DateTime.now(),
                      );
                      if (pickedDate != null) {
                        datumRodjenjaController.text =
                            pickedDate.toIso8601String();
                      }
                    },
                  ),
                  const SizedBox(height: 10),
                  DropdownButtonFormField<int>(
                    value: selectedSpolId,
                    decoration: const InputDecoration(
                      labelText: 'Spol',
                      border: OutlineInputBorder(),
                    ),
                    items: const [
                      DropdownMenuItem(value: 1, child: Text('Muško')),
                      DropdownMenuItem(value: 2, child: Text('Žensko')),
                    ],
                    onChanged: (value) {
                      selectedSpolId = value;
                    },
                  ),
                ],
              ),
            ),
          ),
          actions: [
            TextButton(
              onPressed: () => Navigator.pop(context),
              child: const Text('Odustani'),
            ),
            ElevatedButton(
              onPressed: () async {
                if (imeController.text.isEmpty ||
                    prezimeController.text.isEmpty ||
                    emailController.text.isEmpty ||
                    telefonController.text.isEmpty ||
                    korisnickoImeController.text.isEmpty ||
                    lozinkaController.text.isEmpty ||
                    potvrdiLozinkuController.text.isEmpty ||
                    datumRodjenjaController.text.isEmpty ||
                    selectedSpolId == null) {
                  ScaffoldMessenger.of(context).showSnackBar(
                    const SnackBar(content: Text('Sva polja su obavezna')),
                  );
                  return;
                }

                if (lozinkaController.text != potvrdiLozinkuController.text) {
                  ScaffoldMessenger.of(context).showSnackBar(
                    const SnackBar(content: Text('Lozinke se ne podudaraju')),
                  );
                  return;
                }

                Map<String, dynamic> newKlijent = {
                  "ime": imeController.text,
                  "prezime": prezimeController.text,
                  "datumRodjenja": datumRodjenjaController.text,
                  "email": emailController.text,
                  "telefon": telefonController.text,
                  "korisnickoIme": korisnickoImeController.text,
                  "lozinka": lozinkaController.text,
                  "potvrdiLozinku": potvrdiLozinkuController.text,
                  "spolId": selectedSpolId,
                };

                var result =
                    await APIService.Post('Klijent', jsonEncode(newKlijent));

                if (result != null) {
                  Navigator.pop(context);
                  fetchKlijenti();
                  ScaffoldMessenger.of(context).showSnackBar(
                    const SnackBar(content: Text('Klijent uspješno dodan')),
                  );
                } else {
                  ScaffoldMessenger.of(context).showSnackBar(
                    const SnackBar(
                        content: Text('Greška pri dodavanju klijenta')),
                  );
                }
              },
              child: const Text('Dodaj'),
            ),
          ],
        );
      },
    );
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SafeArea(
        child: isLoading
            ? const Center(child: CircularProgressIndicator())
            : SingleChildScrollView(
                padding: const EdgeInsets.all(16.0),
                child: Column(
                  children: [
                    Row(
                      children: [
                        Expanded(
                          child: TextField(
                            controller: searchController,
                            decoration: InputDecoration(
                              labelText: 'Pretraži klijente',
                              prefixIcon: const Icon(Icons.search),
                              border: OutlineInputBorder(
                                borderRadius: BorderRadius.circular(10),
                              ),
                            ),
                          ),
                        ),
                        const SizedBox(width: 10),
                        ElevatedButton(
                          onPressed: _addKlijent,
                          child: const Text('Dodaj klijenta'),
                        ),
                      ],
                    ),
                    const SizedBox(height: 20),
                    SingleChildScrollView(
                      scrollDirection: Axis.horizontal,
                      child: DataTable(
                        headingRowColor: MaterialStateProperty.resolveWith(
                            (states) => Colors.blueGrey.shade100),
                        columnSpacing: 20,
                        columns: const [
                          DataColumn(
                              label: Text('Ime',
                                  style:
                                      TextStyle(fontWeight: FontWeight.bold))),
                          DataColumn(
                              label: Text('Prezime',
                                  style:
                                      TextStyle(fontWeight: FontWeight.bold))),
                          DataColumn(
                              label: Text('Datum rođenja',
                                  style:
                                      TextStyle(fontWeight: FontWeight.bold))),
                          DataColumn(
                              label: Text('Email',
                                  style:
                                      TextStyle(fontWeight: FontWeight.bold))),
                          DataColumn(
                              label: Text('Telefon',
                                  style:
                                      TextStyle(fontWeight: FontWeight.bold))),
                        ],
                        rows: filteredKlijenti
                            .map(
                              (k) => DataRow(
                                cells: [
                                  DataCell(Text(k.ime ?? '')),
                                  DataCell(Text(k.prezime ?? '')),
                                  DataCell(Text(k.datumRodjenja != null
                                      ? "${k.datumRodjenja!.day}/${k.datumRodjenja!.month}/${k.datumRodjenja!.year}"
                                      : '')),
                                  DataCell(Text(k.email ?? '')),
                                  DataCell(Text(k.telefon ?? '')),
                                ],
                              ),
                            )
                            .toList(),
                      ),
                    ),
                  ],
                ),
              ),
      ),
    );
  }
}
