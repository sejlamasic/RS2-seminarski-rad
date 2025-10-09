import 'dart:convert';

class Proizvodi {
  final int? proizvodId;
  final int? tipProizvodaId;
  final String? naziv;
  final String? cijena;
  final List<int>? slika;
  final String? opis;

  Proizvodi({
    this.proizvodId,
    this.tipProizvodaId,
    this.naziv,
    this.cijena,
    this.slika,
    this.opis,
  });
factory Proizvodi.fromJson(Map<String, dynamic> json) {
  String stringByte = json["slika"] as String;
  
  // Ensure there are no extra characters in the base64 string
  stringByte = stringByte.replaceAll(RegExp(r'\s+'), '');

  List<int> bytes = base64.decode(stringByte);
  
  // Log the byte data for debugging
  print("Decoded bytes length: ${bytes.length}");
  
  return Proizvodi(
    proizvodId: json["proizvodId"],
    tipProizvodaId: json["tipProizvodaId"],
    naziv: json["naziv"],
    cijena: json["cijena"].toString(),
    slika: bytes,
    opis: json["opis"],
  );
}

  Map<String, dynamic> toJson() {
    return {
      'proizvodId': proizvodId,
      'tipProizvodaId': tipProizvodaId,
      'naziv': naziv,
      'cijena': cijena,
      'slika': slika != null ? base64.encode(slika!).toString() : null,
      'opis': opis,
    };
  }
}
