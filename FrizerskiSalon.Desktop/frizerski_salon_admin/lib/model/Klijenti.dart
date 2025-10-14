import 'package:intl/intl.dart';

class Klijenti {
  int? klijentId;
  String? ime;
  String? prezime;
  DateTime? datumRodjenja;
  String? email;
  String? telefon;
  String? korisnickoIme;
  String? lozinka;
  int? spolId;

  Klijenti({
    this.klijentId,
    this.ime,
    this.prezime,
    this.datumRodjenja,
    this.email,
    this.telefon,
    this.korisnickoIme,
    this.lozinka,
    this.spolId,
  });

  factory Klijenti.fromJson(Map<String, dynamic> json) {
    return Klijenti(
      klijentId: json['KlijentId'] != null
        ? int.tryParse(json['KlijentId'].toString())
        : null,
      ime: json['ime'] as String?,
      prezime: json['prezime'] as String?,
      datumRodjenja: json['datumRodjenja'] != null
          ? DateTime.tryParse(json['datumRodjenja'].toString())
          : null,
      email: json['email'] as String?,
      telefon: json['telefon'] as String?,
      korisnickoIme: json['korisnickoIme'] as String?,
      lozinka: json['lozinka'] as String?,
      spolId: json['spolId'] != null ? json['spolId'] as int : null,
    );
  }

  Map<String, dynamic> toJson() => {
        "id": klijentId,
        "ime": ime,
        "prezime": prezime,
        "datumRodjenja": datumRodjenja?.toIso8601String(),
        "email": email,
        "telefon": telefon,
        "korisnickoIme": korisnickoIme,
        "lozinka": lozinka ?? "",
        "spolId": spolId,
      };
}
