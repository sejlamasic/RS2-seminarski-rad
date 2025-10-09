import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:frizerski_salon_admin/helpers/ProizvodiHelpers.dart';
import '../providers/apiservice.dart';
import '../model/Proizvodi.dart';

class VrsteProizvoda {
  int vrstaId;
  String naziv;

  VrsteProizvoda({required this.vrstaId, required this.naziv});

  factory VrsteProizvoda.fromJson(Map<String, dynamic> json) {
    return VrsteProizvoda(
      vrstaId: int.parse(json["tipProizvodaId"].toString()),
      naziv: json["naziv"],
    );
  }

  Map<String, dynamic> toJson() => {
        "tipProizvodaId": vrstaId,
        "naziv": naziv,
      };
}

class ProizvodiScreen extends StatefulWidget {
  const ProizvodiScreen({Key? key}) : super(key: key);

  @override
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
    }
    return [];
  }

  Future<List<VrsteProizvoda>> fetchVrsteProizvoda() async {
    var response = await APIService.Get('TipProizvodum', null);
    if (response != null) {
      return response
          .map<VrsteProizvoda>((json) => VrsteProizvoda.fromJson(json))
          .toList();
    }
    return [];
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
  void _deleteProizvod(int proizvodId) async {
    bool? deleted = await APIService.Delete('Proizvod', proizvodId);
    if (deleted == true) {
      setState(() {
        _proizvodiList = fetchProizvodi();
      });
      ScaffoldMessenger.of(context).showSnackBar(
        const SnackBar(content: Text('Proizvod uspješno obrisan')),
      );
    } else {
      showDialog(
        context: context,
        builder: (BuildContext context) {
          return AlertDialog(
            title: const Text('Greška'),
            content: const Text('Greška pri brisanju proizvoda.'),
            actions: [
              TextButton(
                onPressed: () => Navigator.of(context).pop(),
                child: const Text('OK'),
              )
            ],
          );
        },
      );
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Padding(
        padding: const EdgeInsets.all(16.0),
        child: Column(
          children: [
            const Text('Naši Proizvodi',
                style: TextStyle(fontSize: 24, fontWeight: FontWeight.bold)),
            const SizedBox(height: 16),
            Row(
              children: [
                Expanded(
                  child: TextField(
                    controller: _searchController,
                    decoration: const InputDecoration(
                      hintText: 'Pretražite proizvode...',
                      prefixIcon: Icon(Icons.search),
                    ),
                    onChanged: (text) => setState(() {}),
                  ),
                ),
                const SizedBox(width: 12),
                ElevatedButton(
                  onPressed: () => _openAddProizvodDialog(),
                  child: const Text('Dodaj Proizvod'),
                ),
              ],
            ),
            const SizedBox(height: 16),
            Expanded(
              child: FutureBuilder<List<Proizvodi>>(
                future: _proizvodiList,
                builder: (context, snapshot) {
                  if (!snapshot.hasData)
                    return const Center(child: CircularProgressIndicator());
                  final proizvodi =
                      _filterProizvodi(snapshot.data!, _searchController.text);
                  if (proizvodi.isEmpty)
                    return const Center(
                        child: Text('Nema pronađenih proizvoda.'));
                  return ListView.builder(
                    itemCount: proizvodi.length,
                    itemBuilder: (context, index) {
                      final proizvod = proizvodi[index];
                      final slikaPath = getSlikaZaProizvod(proizvod);

                      return Card(
                        elevation: 3,
                        margin: const EdgeInsets.symmetric(vertical: 10),
                        child: Padding(
                          padding: const EdgeInsets.all(12.0),
                          child: Row(
                            crossAxisAlignment: CrossAxisAlignment.start,
                            children: [
                              if (slikaPath != null)
                                GestureDetector(
                                  onTap: () {
                                    showDialog(
                                      context: context,
                                      builder: (BuildContext dialogContext) {
                                        return Dialog(
                                          shape: RoundedRectangleBorder(
                                              borderRadius:
                                                  BorderRadius.circular(12)),
                                          child: Stack(
                                            children: [
                                              Padding(
                                                padding:
                                                    const EdgeInsets.all(16.0),
                                                child: Image.asset(
                                                  slikaPath,
                                                  width: 460,
                                                  height: 460,
                                                  fit: BoxFit.contain,
                                                  filterQuality:
                                                      FilterQuality.high,
                                                  errorBuilder: (context, error,
                                                          stackTrace) =>
                                                      const Text(
                                                          'Greška pri učitavanju slike'),
                                                ),
                                              ),
                                              Positioned(
                                                top: 0,
                                                right: 0,
                                                child: IconButton(
                                                  icon: const Icon(Icons.close),
                                                  onPressed: () {
                                                    Navigator.of(dialogContext)
                                                        .pop();
                                                  },
                                                ),
                                              ),
                                            ],
                                          ),
                                        );
                                      },
                                    );
                                  },
                                  child: ClipRRect(
                                    borderRadius: BorderRadius.circular(8),
                                    child: Image.asset(
                                      slikaPath,
                                      width: 120,
                                      height: 120,
                                      fit: BoxFit.cover,
                                      errorBuilder:
                                          (context, error, stackTrace) =>
                                              const SizedBox.shrink(),
                                    ),
                                  ),
                                ),
                              const SizedBox(width: 16),
                              Expanded(
                                child: Column(
                                  crossAxisAlignment: CrossAxisAlignment.start,
                                  children: [
                                    Text(proizvod.naziv!,
                                        style: const TextStyle(
                                            fontSize: 18,
                                            fontWeight: FontWeight.bold)),
                                    const SizedBox(height: 4),
                                    Text(proizvod.opis!),
                                    const SizedBox(height: 6),
                                    Row(
                                      mainAxisAlignment:
                                          MainAxisAlignment.spaceBetween,
                                      children: [
                                        Text('Cijena: ${proizvod.cijena!} KM',
                                            style: const TextStyle(
                                                fontWeight: FontWeight.w600)),
                                        IconButton(
                                          icon: const Icon(Icons.delete),
                                          onPressed: () => _deleteProizvod(
                                              proizvod.proizvodId!),
                                        ),
                                      ],
                                    )
                                  ],
                                ),
                              )
                            ],
                          ),
                        ),
                      );
                    },
                  );
                },
              ),
            )
          ],
        ),
      ),
    );
  }

  void _openAddProizvodDialog() {
    _nazivController.clear();
    _cijenaController.clear();
    _opisController.clear();
    _selectedVrstaProizvodaId = null;

    showDialog(
      context: context,
      builder: (BuildContext context) {
        return FutureBuilder<List<VrsteProizvoda>>(
          future: _vrsteProizvodaList,
          builder: (context, snapshot) {
            if (!snapshot.hasData)
              return const Center(child: CircularProgressIndicator());

            return AlertDialog(
              title: const Text('Dodaj proizvod'),
              content: SingleChildScrollView(
                child: Column(
                  children: [
                    TextField(
                        controller: _nazivController,
                        decoration: const InputDecoration(labelText: 'Naziv')),
                    TextField(
                        controller: _cijenaController,
                        decoration: const InputDecoration(labelText: 'Cijena')),
                    TextField(
                      controller: _opisController,
                      decoration: const InputDecoration(labelText: 'Opis'),
                      maxLines: 3,
                    ),
                    DropdownButtonFormField<int>(
                      value: _selectedVrstaProizvodaId,
                      decoration:
                          const InputDecoration(labelText: 'Tip Proizvoda'),
                      items: snapshot.data!.map((vrsta) {
                        return DropdownMenuItem<int>(
                          value: vrsta.vrstaId,
                          child: Text(vrsta.naziv),
                        );
                      }).toList(),
                      onChanged: (value) =>
                          setState(() => _selectedVrstaProizvodaId = value),
                    ),
                  ],
                ),
              ),
              actions: [
                TextButton(
                  onPressed: () => Navigator.pop(context),
                  child: const Text('Odustani'),
                ),
                ElevatedButton(
                  onPressed: _addProizvod,
                  child: const Text('Dodaj'),
                )
              ],
            );
          },
        );
      },
    );
  }

  void _addProizvod() async {
    final naziv = _nazivController.text.trim();
    final cijena = _cijenaController.text.trim();
    final opis = _opisController.text.trim();

    if (naziv.isEmpty ||
        cijena.isEmpty ||
        opis.isEmpty ||
        _selectedVrstaProizvodaId == null) {
      showDialog(
        context: context,
        builder: (_) => AlertDialog(
          title: const Text('Greška'),
          content: const Text('Sva polja su obavezna.'),
          actions: [
            TextButton(
                onPressed: () => Navigator.pop(context),
                child: const Text('OK'))
          ],
        ),
      );
      return;
    }

    final newProizvod = Proizvodi(
      naziv: naziv,
      cijena: cijena,
      opis: opis,
      tipProizvodaId: _selectedVrstaProizvodaId,
    );

    final response =
        await APIService.Post('Proizvod', jsonEncode(newProizvod.toJson()));

    if (response != null) {
      setState(() {
        _proizvodiList = fetchProizvodi();
      });
      Navigator.pop(context);
      ScaffoldMessenger.of(context).showSnackBar(
        const SnackBar(content: Text('Proizvod dodan')),
      );
    } else {
      showDialog(
        context: context,
        builder: (_) => AlertDialog(
          title: const Text('Greška'),
          content: const Text('Dodavanje nije uspjelo.'),
          actions: [
            TextButton(
                onPressed: () => Navigator.pop(context),
                child: const Text('OK'))
          ],
        ),
      );
    }
  }
}
