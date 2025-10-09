import 'dart:convert';
import 'Spolovi.dart';
import 'Zanimanja.dart';

class Uposlenici {
  int? uposlenikId;
  String? ime;
  String? prezime;
  String? email;
  String? telefon;
  String? korisnickoIme;
  List<int>? slika;
  int? spolId;
  int? zanimanjeId;
  Spolovi? spol;
  Zanimanja? zanimanje;

  Uposlenici({
    this.uposlenikId,
    this.ime,
    this.prezime,
    this.email,
    this.telefon,
    this.korisnickoIme,
    this.slika,
    this.spolId,
    this.zanimanjeId,
    this.spol,
    this.zanimanje,
  });

  factory Uposlenici.fromJson(Map<String, dynamic> json) {
    String stringByte = json['slika'] as String;
    List<int> bytes = base64.decode(stringByte);

    return Uposlenici(
      uposlenikId: json['uposlenikId'] as int?,
      ime: json['ime'] as String?,
      prezime: json['prezime'] as String?,
      email: json['email'] as String?,
      telefon: json['telefon'] as String?,
      korisnickoIme: json['korisnickoIme'] as String?,
      slika: bytes,
      spolId: json['spolId'] as int?,
      zanimanjeId: json['zanimanjeId'] as int?,
      spol: json['spol'] != null ? Spolovi.fromJson(json['spol']) : null,
    zanimanje: json['zanimanje'] != null ? Zanimanja.fromJson(json['zanimanje']) : null,

    );
  }

  Map<String, dynamic> toJson() => {
        "uposlenikId": uposlenikId,
        "ime": ime,
        "prezime": prezime,
        "email": email,
        "telefon": telefon,
        "korisnickoIme": korisnickoIme,
        "slika": slika,
        "spolId": spolId,
        "zanimanjeId": zanimanjeId,
        "spol": spol?.toJson(),
        "zanimanje": zanimanje?.toJson(),
      };
}
