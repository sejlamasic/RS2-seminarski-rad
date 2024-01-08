import 'dart:convert';
import 'package:flutter/material.dart';
import '/model/Narudzbe.dart';
import '/model/Proizvodi.dart';
import '/providers/apiservice.dart';

// ignore: must_be_immutable
class DetaljiProizvoda extends StatelessWidget {
  final Proizvodi? proizvod;
  DetaljiProizvoda({Key? key, this.proizvod}) : super(key: key);

  List<dynamic>? _recommendedProizvodi = [];
  Future<List<dynamic>?> getRecommendedProizvodi() async {
    var recommended = await APIService.Get(
        "Proizvod/Recommend/${proizvod!.proizvodId}", null);
    if (recommended != null) {
      recommended.map((i) => Proizvodi.fromJson(i)).toList();
      _recommendedProizvodi = recommended;
    }
    return null;
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(
          title: const Text(
            'Detalji proizvoda',
            style: TextStyle(fontSize: 20),
          ),
          backgroundColor: Colors.blue,
        ),
        body: FutureBuilder<dynamic>(
            future: getRecommendedProizvodi(),
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
                      child: Column(children: [
                    const Center(
                        child: Image(
                            height: 160,
                            width: 160,
                            image: /*Image.memory(Uint8List.fromList(proizvod!.slika!)).image, 
                errorBuilder: (context, error, stackTrace) => Image.asset("assets/images/error.jpg"))*/
                                AssetImage(
                                    'assets/images/imgplaceholder.jpg'))),
                    Text(
                      proizvod!.naziv!,
                      style: const TextStyle(fontSize: 25),
                    ),
                    Text(
                      '${proizvod!.cijena!} KM',
                      style: const TextStyle(fontSize: 20),
                    ),
                    Text(
                      proizvod!.opis!,
                      style: const TextStyle(fontSize: 17),
                    ),
                    Padding(
                        padding: const EdgeInsets.all(30),
                        child: TextButton(
                          onPressed: () async {
                            var response = await APIService.GetById(
                                "Narudzba", APIService.aktivnaNarudzba, null);
                            Narudzbe narudzba = Narudzbe.fromJson(response);
                            if (narudzba.IsPlacena == false &&
                                narudzba.isIsporucena == false) {
                              Map<String, dynamic> insertRequest = {
                                'narudzbaId': APIService.aktivnaNarudzba,
                                'proizvodId': proizvod!.proizvodId,
                                'kolicina': 1
                              };
                              await APIService.Post(
                                  "StavkeNarudzbe", jsonEncode(insertRequest));
                            }
                          },
                          child: const Image(
                              width: 40,
                              height: 40,
                              image: AssetImage('assets/images/kosrpa.png')),
                        )),
                    const SizedBox(
                      height: 20,
                    ),
                    const Text("Broj prodanih proizvoda je"),
                    const SizedBox(
                      height: 20,
                    ),
                    const Text("Korisnicima se svidjelo još i...",
                        style: TextStyle(color: Colors.blueGrey, fontSize: 16)),
                    const SizedBox(
                      height: 20,
                    ),
                    // ignore: unrelated_type_equality_checks
                    if (_recommendedProizvodi != "[]")
                      ListView(
                          shrinkWrap: true,
                          children: _recommendedProizvodi!
                              .map((e) => Card(
                                  child: TextButton(
                                      onPressed: () {
                                        Navigator.push(
                                            context,
                                            MaterialPageRoute(
                                                builder: (context) =>
                                                    DetaljiProizvoda(
                                                        proizvod: new Proizvodi
                                                            .fromJson(e))));
                                      },
                                      child: Padding(
                                          padding: EdgeInsets.all(15),
                                          child: Text(
                                              "${e['proizvodId']} ${e['naziv']}")))))
                              .toList())
                  ]));
                }
              }
            }));
  }
}
