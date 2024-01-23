import 'dart:convert';

import 'package:flutter/material.dart';
import '/model/Narudzbe.dart';
import '/model/StavkeNarudzbe.dart';
import '/providers/apiservice.dart';
import '/providers/Payment.dart';

// ignore: must_be_immutable
class Narudzba extends StatefulWidget {
  Narudzbe? narudzba;
  Narudzba({Key? key, this.narudzba}) : super(key: key);

  @override
  State<Narudzba> createState() => _NarudzbaState();
}

class _NarudzbaState extends State<Narudzba> {
  List<dynamic>? _stavkeNarudzbe = [];
  Narudzbe? narudzba;
  Future<List<dynamic>?> getNarudzbaStavke() async {
    var response =
        await APIService.GetById("Narudzba", APIService.aktivnaNarudzba, null);
    narudzba = Narudzbe.fromJson(response); //
    Map<String, dynamic> queryParams = {
      'NarudzbaId': APIService.aktivnaNarudzba.toString()
    };
    var stavke = await APIService.Get("StavkeNarudzbe", queryParams);
    if (stavke != null) {
      stavke.map((i) => StavkeNarudzbe.fromJson(i)).toList();
      _stavkeNarudzbe = stavke;
    }
    return _stavkeNarudzbe;
  }

  // ignore: non_constant_identifier_names
  Future<void> UkloniStavku(int id) async {
    await APIService.Delete("StavkeNarudzbe", id);
  }

  void payWithCard({required int amount}) async {
    var response = await StripeService.payWithNewCard(
        amount: amount.toString(), currency: 'BAM');
    // ignore: avoid_print
    print(response.message);
    if (response.message == 'Transaction cancelled') {
    } else {
      // ignore: use_build_context_synchronously
      ScaffoldMessenger.of(context).showSnackBar(
        SnackBar(
          content: Row(
            children: [
              const CircularProgressIndicator(),
              Container(
                  margin: const EdgeInsets.only(left: 15),
                  child: const Text("Molimo pričekajte...")),
            ],
          ),
          duration: const Duration(seconds: 5),
        ),
      );
    }
  }

  @override
  void initState() {
    super.initState();
    StripeService.init();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(
          title: const Text('Vaša korpa'),
          backgroundColor: Colors.blue,
        ),
        body: FutureBuilder<dynamic>(
            future: getNarudzbaStavke(),
            builder: (BuildContext context, AsyncSnapshot<dynamic> snapshot) {
              if (snapshot.connectionState == ConnectionState.waiting) {
                return const Center(
                  child: Text('Loading...'),
                );
              } else {
                if (snapshot.hasError) {
                  return Center(
                    child: Text('${snapshot.error}'),
                  );
                } else {
                  return SingleChildScrollView(
                      child: Padding(
                          padding: const EdgeInsets.all(30),
                          child: Column(
                              crossAxisAlignment: CrossAxisAlignment.stretch,
                              children: [
                                const Text(
                                  'Vaša trenutna narudžba',
                                  style: TextStyle(
                                      fontSize: 18,
                                      fontWeight: FontWeight.w500,
                                      color: Colors.blue),
                                  textAlign: TextAlign.center,
                                ),
                                const SizedBox(
                                  height: 26,
                                ),
                                Text(
                                  'Ukupni iznos: ${narudzba!.ukupniIznos} KM\nPlaćeno: ${narudzba!.IsPlacena}\nIsporučeno: ${narudzba!.isIsporucena}',
                                  style: const TextStyle(
                                      fontSize: 16,
                                      fontWeight: FontWeight.w400,
                                      color: Colors.blue),
                                  textAlign: TextAlign.center,
                                ),
                                const SizedBox(
                                  height: 26,
                                ),
                                ListView(
                                    shrinkWrap: true,
                                    children: _stavkeNarudzbe!
                                        .map((e) => Card(
                                            child: TextButton(
                                                onPressed: () {
                                                  UkloniStavku(
                                                      e['stavkeNarudzbeId']);
                                                },
                                                child: Padding(
                                                    padding:
                                                        const EdgeInsets.all(
                                                            15),
                                                    child: Text(
                                                        "Stavka narudžbe ${e['proizvodId']}\nKoličina ${e['kolicina']}\n(klikni da ukloniš)")))))
                                        .toList()),
                                if (_stavkeNarudzbe!.isNotEmpty)
                                  TextButton(
                                      onPressed: () async {
                                        payWithCard(
                                            amount: narudzba!.ukupniIznos!);
                                        Map<String, dynamic> request = {
                                          'IsPlacena': true,
                                          'klijentId': APIService.klijentId,
                                          'datum': narudzba!.datum!
                                              .toIso8601String(),
                                          'ukupniIznos': narudzba!.ukupniIznos,
                                          'isIsporucena': narudzba!.isIsporucena
                                        };
                                        await APIService.Put(
                                            "Narudzba",
                                            APIService.aktivnaNarudzba!,
                                            jsonEncode(request));
                                      },
                                      child: const Text('Naruči/plati',
                                          style: TextStyle(
                                              color: Colors.blue,
                                              fontSize: 20)))
                              ])));
                }
              }
            }));
  }
}
