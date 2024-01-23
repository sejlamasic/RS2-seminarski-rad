import 'package:flutter/material.dart';
import '/model/Proizvodi.dart';
import '/model/VrsteProizvoda.dart';
import '/providers/apiservice.dart';
import 'DetaljiProizvoda.dart';

class SviProizvodi extends StatefulWidget {
  const SviProizvodi({super.key});

  //const SviProizvodi({Key? key}) : super(key: key);
  @override
  // ignore: library_private_types_in_public_api
  _SviProizvodiState createState() => _SviProizvodiState();
}

class _SviProizvodiState extends State<SviProizvodi> {
  VrsteProizvoda? _selectedVrsteProizvoda;
  List<DropdownMenuItem> items = [];
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Proizvodi'),
      ),
      body: Column(
        children: [
          Center(child: dropDownWidget()),
          Expanded(child: bodyWidget())
        ],
      ),
    );
  }

  Widget dropDownWidget() {
    return FutureBuilder<List<VrsteProizvoda>>(
        future: GetVrsteProizvoda(_selectedVrsteProizvoda),
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
              return Padding(
                padding: const EdgeInsets.fromLTRB(30, 10, 30, 10),
                child: DropdownButton<dynamic>(
                  hint: const Text('Odaberite vrstu proizvoda'),
                  isExpanded: true,
                  items: items,
                  onChanged: (newVal) {
                    setState(() {
                      _selectedVrsteProizvoda = newVal; //as VrsteProizvoda;
                      GetProizvodi(_selectedVrsteProizvoda);
                    });
                  },
                  value: _selectedVrsteProizvoda,
                ),
              );
            }
          }
        });
  }

  // ignore: non_constant_identifier_names
  Future<List<VrsteProizvoda>> GetVrsteProizvoda(
      VrsteProizvoda? selectedItem) async {
    var vrsteProizvoda = await APIService.Get('TipProizvodum', null);
    var vrsteProizvodaList =
        vrsteProizvoda!.map((i) => VrsteProizvoda.fromJson(i)).toList();
    items = vrsteProizvodaList.map((item) {
      return DropdownMenuItem<VrsteProizvoda>(
        value: item,
        child: Text(item.naziv),
      );
    }).toList();
    if (selectedItem != null && selectedItem.vrstaId != 0) {
      _selectedVrsteProizvoda = vrsteProizvodaList
          .where((element) => element.vrstaId == selectedItem.vrstaId)
          .first;
    }
    return vrsteProizvodaList;
  }

  Widget bodyWidget() {
    return FutureBuilder<List<dynamic>>(
        future: GetProizvodi(_selectedVrsteProizvoda),
        builder: (BuildContext context, AsyncSnapshot<List<dynamic>> snapshot) {
          if (snapshot.connectionState == ConnectionState.waiting) {
            return const Center(
              child: Text('Loading...'),
            );
          } else {
            if (snapshot.hasError) {
              return Center(child: Text('${snapshot.error}'));
            } else {
              return ListView(
                children:
                    snapshot.data!.map((e) => ProizvodiWidget(e)).toList(),
              );
            }
          }
        });
  }

  // ignore: non_constant_identifier_names
  Future<List<dynamic>> GetProizvodi(VrsteProizvoda? selectedItem) async {
    Map<String, String>? queryParams;
    if (selectedItem != null && selectedItem.vrstaId != 0) {
      queryParams = {'tipProizvodaId': selectedItem.vrstaId.toString()};
    }
    var proizvodi = await APIService.Get('Proizvod', queryParams);
    return proizvodi!.map((i) => Proizvodi.fromJson(i)).toList();
  }

  // ignore: non_constant_identifier_names
  Widget ProizvodiWidget(proizvod) {
    return Card(
      child: TextButton(
        onPressed: () {
          Navigator.push(
              context,
              MaterialPageRoute(
                  builder: (context) => DetaljiProizvoda(proizvod: proizvod)));
        },
        child: Padding(
            padding: const EdgeInsets.all(15),
            child: Text(proizvod.naziv + ' (' + proizvod.cijena + ' KM)')),
      ),
    );
  }
}
