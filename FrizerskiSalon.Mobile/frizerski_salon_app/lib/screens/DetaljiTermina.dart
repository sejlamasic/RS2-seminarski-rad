import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import '/model/Termini.dart';
import '/providers/Payment.dart';
import '/providers/apiservice.dart';

// ignore: must_be_immutable
class DetaljiTermina extends StatefulWidget {
  Termini? termin;
  DetaljiTermina({Key? key, this.termin}) : super(key: key);

  @override
  State<DetaljiTermina> createState() => _DetaljiTerminaState();
}

class _DetaljiTerminaState extends State<DetaljiTermina> {
  Termini? termin;

  Future<dynamic> getTermin(int? korisnikId) async {
    var response = await APIService.GetById("Termin", APIService.klijentId!,
        "KlijentId=${APIService.klijentId}&NadolazeciTermini=true");
    if (response.isNotEmpty) {
      termin = Termini.fromJson(response[0]);
    }
    return response;
  }

  int getDaniDoTermina(DateTime datumTermina) {
    var danasnjiDatum = DateTime.now();
    return datumTermina.difference(danasnjiDatum).inDays;
  }

  void payWithCard({required int amount}) async {
    var response = await StripeService.payWithNewCard(
        amount: amount.toString(), currency: 'BAM');
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
          title: const Text('Nadolazeći termin'),
          backgroundColor: Colors.blue,
        ),
        body: FutureBuilder<dynamic>(
            future: getTermin(APIService.klijentId),
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
                } else if (termin == null) {
                  return const Padding(
                      padding: EdgeInsets.all(25),
                      child: Text(
                        'Trenutno nemate zakazane nikakve nadolazeće termine',
                        style: TextStyle(
                            fontSize: 27, fontWeight: FontWeight.w400),
                        textAlign: TextAlign.center,
                      ));
                } else {
                  return SingleChildScrollView(
                      child: Padding(
                          padding: const EdgeInsets.all(30),
                          child: Column(
                              crossAxisAlignment: CrossAxisAlignment.stretch,
                              children: [
                                Text(
                                  'Imate termin za ${getDaniDoTermina(termin!.datum!).toString()} dana!',
                                  style: const TextStyle(
                                      fontSize: 25,
                                      fontWeight: FontWeight.w500),
                                  textAlign: TextAlign.center,
                                ),
                                const SizedBox(
                                  height: 20,
                                ),
                                Text(
                                  'Datum vašeg nadolazećeg termina u našem studiju je ${termin?.datum != null ? DateFormat('dd.MM.yyyy').format(termin!.datum!) : 'N/A'}',
                                  style: const TextStyle(
                                    fontSize: 20,
                                    fontWeight: FontWeight.w400,
                                  ),
                                  textAlign: TextAlign.center,
                                ),
                                const SizedBox(
                                  height: 20,
                                ),
                                Text(
                                  termin!.isPlacen == true
                                      ? 'Cijena iznosi ${termin?.cijena?.toString() ?? 'N/A'}. Ovaj termin je plaćen.'
                                      : 'Cijena iznosi ${termin?.cijena?.toString() ?? 'N/A'}. Ovaj termin nije plaćen.',
                                  style: const TextStyle(
                                      fontSize: 20,
                                      fontWeight: FontWeight.w300),
                                  textAlign: TextAlign.center,
                                ),
                                const SizedBox(height: 20),
                                Text(
                                  'Vaš zahtjev i opis termina: ${termin!.opis}',
                                  style: const TextStyle(
                                      fontSize: 20,
                                      fontWeight: FontWeight.w300),
                                  textAlign: TextAlign.center,
                                ),
                                const SizedBox(height: 20),
                                if (termin!.isOtkazan == false)
                                  Text(
                                    termin!.isOdobren == true
                                        ? 'Vaš termin je odobren'
                                        : 'Vaš termin još nije odobren.\nPlaćanje termina će biti moguće izvršiti nakon što uposlenik odobri termin.',
                                    style: const TextStyle(
                                        fontSize: 20,
                                        color: Colors.blueGrey,
                                        fontWeight: FontWeight.w400),
                                    textAlign: TextAlign.center,
                                  ),
                                const SizedBox(height: 20),
                                Text(
                                  termin!.isOtkazan == true
                                      ? 'Vaš termin je otkazan. Komentar uposlenog: ${termin!.komentar}'
                                      : '',
                                  style: const TextStyle(
                                      fontSize: 20,
                                      color: Colors.red,
                                      fontWeight: FontWeight.w500),
                                  textAlign: TextAlign.center,
                                ),
                                const SizedBox(height: 30),
                                if (termin!.isOdobren! &&
                                    !termin!.isPlacen! &&
                                    !termin!.isOtkazan!)
                                  ElevatedButton(
                                      onPressed: () async {
                                        payWithCard(
                                            amount: termin!.cijena!.toInt());
                                      },
                                      child: const Text(
                                        'Plati ovaj termin',
                                        style: TextStyle(
                                            color: Colors.white, fontSize: 16),
                                      ))
                              ])));
                }
              }
            }));
  }
}
