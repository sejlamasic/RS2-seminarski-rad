import 'dart:convert';
import 'package:flutter/material.dart';
import '../providers/apiservice.dart';
import '../model/Proizvodi.dart';

class VrsteProizvoda {
  int vrstaId;
  String naziv;

  VrsteProizvoda({
    required this.vrstaId,
    required this.naziv,
  });

  factory VrsteProizvoda.fromJson(Map<String, dynamic> json) {
    return VrsteProizvoda(
      vrstaId: int.parse(json["tipProizvodaId"].toString()),
      naziv: json["naziv"],
    );
  }

  Map<String, dynamic> toJson() => {"tipProizvodaId": vrstaId, "naziv": naziv};
}

class ProizvodiScreen extends StatefulWidget {
  const ProizvodiScreen({Key? key}) : super(key: key);

  @override
  // ignore: library_private_types_in_public_api
  _ProizvodiScreenState createState() => _ProizvodiScreenState();
}

class _ProizvodiScreenState extends State<ProizvodiScreen> {
  late Future<List<Proizvodi>> _proizvodiList;
  late Future<List<VrsteProizvoda>> _vrsteProizvodaList;
  final TextEditingController _searchController = TextEditingController();
  final TextEditingController _nazivController = TextEditingController();
  final TextEditingController _cijenaController = TextEditingController();
  final TextEditingController _opisController = TextEditingController();
  int? _selectedVrstaProizvodaId;

  @override
  void initState() {
    super.initState();
    _proizvodiList = fetchProizvodi();
    _vrsteProizvodaList = fetchVrsteProizvoda();
  }

  Future<List<Proizvodi>> fetchProizvodi() async {
    var response = await APIService.Get('Proizvod', null);
    if (response != null) {
      return response
          .map<Proizvodi>((json) => Proizvodi.fromJson(json))
          .toList();
    } else {
      return [];
    }
  }

  Future<List<VrsteProizvoda>> fetchVrsteProizvoda() async {
    var response = await APIService.Get('TipProizvodum', null);
    if (response != null) {
      return response
          .map<VrsteProizvoda>((json) => VrsteProizvoda.fromJson(json))
          .toList();
    } else {
      return [];
    }
  }

  List<Proizvodi> _filterProizvodi(
      List<Proizvodi> proizvodiList, String searchText) {
    searchText = searchText.toLowerCase();
    return proizvodiList.where((proizvod) {
      return proizvod.naziv!.toLowerCase().contains(searchText) ||
          proizvod.cijena!.toLowerCase().contains(searchText) ||
          proizvod.opis!.toLowerCase().contains(searchText);
    }).toList();
  }

  void _openAddProizvodDialog() {
    _nazivController.clear();
    _cijenaController.clear();
    _opisController.clear();
    setState(() {
      _selectedVrstaProizvodaId = null;
    });

    showDialog(
      context: context,
      builder: (BuildContext context) {
        return FutureBuilder<List<VrsteProizvoda>>(
          future: _vrsteProizvodaList,
          builder: (context, snapshot) {
            if (!snapshot.hasData) {
              return const Center(child: CircularProgressIndicator());
            } else {
              return Dialog(
                shape: RoundedRectangleBorder(
                  borderRadius: BorderRadius.circular(8.0),
                ),
                elevation: 0.0,
                backgroundColor: Colors.transparent,
                child: SingleChildScrollView(
                  child: Padding(
                    padding: const EdgeInsets.all(16.0),
                    child: Container(
                      constraints: const BoxConstraints(
                          maxWidth: 400.0), 
                      padding: const EdgeInsets.all(16.0),
                      decoration: BoxDecoration(
                        color: Colors.white,
                        borderRadius: BorderRadius.circular(8.0),
                      ),
                      child: Column(
                        crossAxisAlignment: CrossAxisAlignment.start,
                        mainAxisSize: MainAxisSize.min,
                        children: [
                          const Text(
                            'Dodaj proizvod',
                            style: TextStyle(
                              fontSize: 20.0,
                              fontWeight: FontWeight.bold,
                            ),
                          ),
                          const SizedBox(height: 16.0),
                          TextField(
                            controller: _nazivController,
                            decoration: const InputDecoration(labelText: 'Naziv'),
                          ),
                          const SizedBox(height: 12.0),
                          TextField(
                            controller: _cijenaController,
                            decoration:
                                const InputDecoration(labelText: 'Cijena'),
                          ),
                          const SizedBox(height: 12.0),
                          TextField(
                            controller: _opisController,
                            decoration:
                                const InputDecoration(labelText: 'Opis'),
                            maxLines: 3,
                          ),
                          const SizedBox(height: 12.0),
                          DropdownButtonFormField<int>(
                            value: _selectedVrstaProizvodaId,
                            items: snapshot.data!.map((vrsta) {
                              return DropdownMenuItem<int>(
                                value: vrsta.vrstaId,
                                child: Text(vrsta.naziv),
                              );
                            }).toList(),
                            onChanged: (value) {
                              setState(() {
                                _selectedVrstaProizvodaId = value;
                              });
                            },
                            decoration: const InputDecoration(
                                labelText: 'Tip Proizvoda'),
                          ),
                          const SizedBox(height: 16.0),
                          Row(
                            mainAxisAlignment: MainAxisAlignment.end,
                            children: [
                              TextButton(
                                child: const Text('Cancel'),
                                onPressed: () {
                                  Navigator.of(context).pop();
                                },
                              ),
                              ElevatedButton(
                                child: const Text('Dodaj'),
                                onPressed: () {
                                  _addProizvod();
                                },
                              ),
                            ],
                          ),
                        ],
                      ),
                    ),
                  ),
                ),
              );
            }
          },
        );
      },
    );
  }

  void _addProizvod() async {
    String naziv = _nazivController.text.trim();
    String cijena = _cijenaController.text.trim();
    String opis = _opisController.text.trim();

    if (naziv.isEmpty ||
        cijena.isEmpty ||
        opis.isEmpty ||
        _selectedVrstaProizvodaId == null) {
      showDialog(
        context: context,
        builder: (BuildContext context) {
          return AlertDialog(
            title: const Text('Incomplete Information'),
            content: const Text('Please fill in all fields.'),
            actions: <Widget>[
              TextButton(
                child: const Text('OK'),
                onPressed: () {
                  Navigator.of(context).pop();
                },
              ),
            ],
          );
        },
      );
      return;
    }

    var newProizvod = Proizvodi(
      naziv: naziv,
      cijena: cijena,
      opis: opis,
      tipProizvodaId: _selectedVrstaProizvodaId,
    );

    var response =
        await APIService.Post('Proizvod', jsonEncode(newProizvod.toJson()));

    if (response != null) {
      setState(() {
        _proizvodiList = fetchProizvodi();
      });

      // ignore: use_build_context_synchronously
      Navigator.of(context, rootNavigator: true).pop();

      // Show SnackBar with success message
      // ignore: use_build_context_synchronously
      ScaffoldMessenger.of(context).showSnackBar(
        const SnackBar(
          content: Text('Proizvod uspješno dodan'),
          duration: Duration(seconds: 2),
          backgroundColor: Colors.blue,
        ),
      );

      // Clear text controllers after adding product
      _nazivController.clear();
      _cijenaController.clear();
      _opisController.clear();
    } else {
      // ignore: use_build_context_synchronously
      showDialog(
        context: context,
        builder: (BuildContext context) {
          return AlertDialog(
            title: const Text('Error'),
            content: const Text('Greška pri dodavanju proizvoda, molimo pokušajte kasnije...'),
            actions: <Widget>[
              TextButton(
                child: const Text('OK'),
                onPressed: () {
                  Navigator.of(context).pop();
                },
              ),
            ],
          );
        },
      );
    }
  }

  void _deleteProizvod(int proizvodId) async {
    try {
      bool? deleted = await APIService.Delete('Proizvod', proizvodId);
      if (deleted == true) {
        setState(() {
          _proizvodiList = fetchProizvodi();
        });

        // ignore: use_build_context_synchronously
        ScaffoldMessenger.of(context).showSnackBar(
          const SnackBar(
            content: Text('Proizvod uspješno obrisan'),
            duration: Duration(seconds: 2),
          ),
        );
      } else {
        // ignore: use_build_context_synchronously
        showDialog(
          context: context,
          builder: (BuildContext context) {
            return AlertDialog(
              title: const Text('Error'),
              content:
                  const Text('Greška pri brisanju proizvoda, molimo pokušajte kasnije...'),
              actions: <Widget>[
                TextButton(
                  child: const Text('OK'),
                  onPressed: () {
                    Navigator.of(context).pop();
                  },
                ),
              ],
            );
          },
        );
      }
    } catch (e) {
      // ignore: avoid_print
      print('Exception while deleting proizvod: $e');
      // ignore: use_build_context_synchronously
      showDialog(
        context: context,
        builder: (BuildContext context) {
          return AlertDialog(
            title: const Text('Error'),
            content: const Text('Failed to delete Proizvod. Please try again later.'),
            actions: <Widget>[
              TextButton(
                child: const Text('OK'),
                onPressed: () {
                  Navigator.of(context).pop();
                },
              ),
            ],
          );
        },
      );
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Proizvodi'),
        automaticallyImplyLeading: false,
      ),
      body: Padding(
        padding: const EdgeInsets.all(16.0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.stretch,
          children: [
            const Text(
              'Naši Proizvodi',
              style: TextStyle(fontSize: 24, fontWeight: FontWeight.bold),
            ),
            const SizedBox(height: 16),
            Row(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: [
                Expanded(
                  child: TextField(
                    controller: _searchController,
                    decoration: const InputDecoration(
                      hintText: 'Pretražite proizvode...',
                      prefixIcon: Icon(Icons.search),
                    ),
                    onChanged: (text) {
                      setState(() {});
                    },
                  ),
                ),
                ElevatedButton(
                  onPressed: _openAddProizvodDialog,
                  child: const Text('Dodaj Proizvod'),
                ),
              ],
            ),
            const SizedBox(height: 16),
            Expanded(
              child: FutureBuilder<List<Proizvodi>>(
                future: _proizvodiList,
                builder: (context, snapshot) {
                  if (!snapshot.hasData) {
                    return const Center(child: CircularProgressIndicator());
                  } else if (snapshot.data!.isEmpty) {
                    return const Center(child: Text('Nema proizvoda.'));
                  } else {
                    final filteredProizvodi = _filterProizvodi(
                        snapshot.data!, _searchController.text);
                    return ListView.builder(
                      itemCount: filteredProizvodi.length,
                      itemBuilder: (context, index) {
                        final proizvod = filteredProizvodi[index];
                        return ListTile(
                          title: Text(proizvod.naziv!),
                          subtitle: Column(
                            crossAxisAlignment: CrossAxisAlignment.start,
                            children: [
                              Text(proizvod.opis!),
                              const SizedBox(
                                  height:
                                      4), 
                              Row(
                                mainAxisAlignment:
                                    MainAxisAlignment.spaceBetween,
                                children: [
                                  Text('Cijena: ${proizvod.cijena!} KM',
                                      style: const TextStyle(
                                          fontWeight: FontWeight.bold)),
                                  IconButton(
                                    icon: const Icon(Icons.delete),
                                    onPressed: () =>
                                        _deleteProizvod(proizvod.proizvodId!),
                                  ),
                                ],
                              ),
                            ],
                          ),
                        );
                      },
                    );
                  }
                },
              ),
            ),
          ],
        ),
      ),
    );
  }
}
