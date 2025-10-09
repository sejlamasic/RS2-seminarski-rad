// ignore: file_names
import '../model/Proizvodi.dart'; 

String? getSlikaZaProizvod(Proizvodi proizvod) {
  switch (proizvod.naziv) {
    case 'Šampon Kerastase':
      return 'assets/images/proizvodi/kerastase-sampon2.jpg';
    case 'Farba za kosu F12345':
      return 'assets/images/proizvodi/farba-za-kosu-F12345.png';
    case 'Macadamia četka za kosu':
      return 'assets/images/proizvodi/macadamia-četka.jpg';
    case 'Tangle teezer':
      return 'assets/images/proizvodi/tangle-teezer.jpg';
    case 'Regenerator Elseve':
      return 'assets/images/proizvodi/regenerator-elseve.jpg';
    case 'Regenerator za kosu syoss':
      return 'assets/images/proizvodi/regenerator-syoss.jpg';
    case 'Čistač četki':
      return 'assets/images/proizvodi/čistač-četki-za-kosu.jpg';
    case 'Sredstvo za uklanjanje farbe':
      return 'assets/images/proizvodi/sredstvo-za-uklanjanje-farbe.jpg';
    case 'Regenerator za kosu Kerastase':
      return 'assets/images/proizvodi/regenerator-kerastase.jpg';
    case 'Maska za kosu Kerastase':
      return 'assets/images/proizvodi/maska-za-kosu-kerastase.jpg';
    default:
      return null;
  }
}
