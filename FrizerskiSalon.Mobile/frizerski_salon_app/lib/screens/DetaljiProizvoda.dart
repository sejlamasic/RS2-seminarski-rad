import 'dart:convert';
import 'dart:typed_data';
import 'package:flutter/material.dart';
import 'package:image/image.dart' as img;
import '/model/Proizvodi.dart';

class DetaljiProizvoda extends StatelessWidget {
  final Proizvodi? proizvod;

  const DetaljiProizvoda({Key? key, this.proizvod}) : super(key: key);

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
      body: SingleChildScrollView(
        child: Column(
          children: [
            Center(
              key: UniqueKey(),
              child: _buildImageFromBytes(proizvod!.slika!),
            ),
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
                  // Your existing logic for adding to cart
                },
                child: const Image(
                  width: 40,
                  height: 40,
                  image: AssetImage('assets/images/korpa.png'),
                ),
              ),
            ),
            const SizedBox(
              height: 20,
            ),
          ],
        ),
      ),
    );
  }

  Widget _buildImageFromBytes(List<int> bytes) {
    try {
      Uint8List uint8List = Uint8List.fromList(proizvod!.slika!);
      String base64Image = base64Encode(uint8List);

      // Decode the Base64-encoded string to bytes
      Uint8List decodedBytes = base64.decode(base64Image);

      // Decode the image using the decoded bytes
      final image = img.decodeImage(decodedBytes);

      return Image.memory(Uint8List.fromList(img.encodePng(image!)),
          height: 160, width: 160);
    } catch (e) {
      // ignore: avoid_print
      print('Error decoding image: $e');
      return Image.asset(
        'assets/images/imgplaceholder.jpg',
        height: 160,
        width: 160,
      );
    }
  }
}

