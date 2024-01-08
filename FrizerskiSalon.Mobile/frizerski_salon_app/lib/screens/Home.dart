import 'package:carousel_slider/carousel_slider.dart';
import 'package:flutter/material.dart';

class Home extends StatefulWidget {
  const Home({Key? key}) : super(key: key);

  @override
  // ignore: library_private_types_in_public_api
  _HomeState createState() => _HomeState();
}

class _HomeState extends State<Home> {
  List<String> images = [
    'assets/images/changestudio1.jpg',
    'assets/images/changestudio2.jpg',
    'assets/images/changestudio3.jpg',
  ];
  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(
          title: const Text('FrizerskiSalon'),
        ),
        drawer: Drawer(
          child: ListView(
            children: [
              const DrawerHeader(
                decoration: BoxDecoration(color: Colors.blue),
                child: Text('FrizerskiSalon'),
              ),
              ListTile(
                title: const Text('Nadolazeći termin'),
                onTap: () {
                  Navigator.of(context).pushNamed('/detaljiTermina');
                },
              ),
              ListTile(
                title: const Text('Korpa'),
                onTap: () {
                  Navigator.of(context).pushNamed('/narudzbe');
                },
              ),
              ListTile(
                title: const Text('Obavijesti'),
                onTap: () {
                  Navigator.of(context).pushNamed('/sveObavijesti');
                },
              ),
              ListTile(
                title: const Text('Proizvodi'),
                onTap: () {
                  Navigator.of(context).pushNamed('/sviProizvodi');
                },
              ),
              ListTile(
                title: const Text('Frizeri'),
                onTap: () {
                  Navigator.of(context).pushNamed('/sviUposlenici');
                },
              ),
              ListTile(
                title: const Text('Zakažite termin'),
                onTap: () {
                  Navigator.of(context).pushNamed('/zakazivanjeTermina');
                },
              ),
              ListTile(
                title: const Text('Profil'),
                onTap: () {
                  Navigator.of(context).pushNamed('/detaljiKlijenta');
                },
              ),
            ],
          ),
        ),
        body: SingleChildScrollView(
          child: Padding(
            padding: const EdgeInsets.all(16.0),
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                CarouselSlider(
                  options: CarouselOptions(
                    height: 200.0,
                    enlargeCenterPage: true,
                    autoPlay: true,
                    aspectRatio: 16 / 9,
                    autoPlayCurve: Curves.fastOutSlowIn,
                    enableInfiniteScroll: true,
                    autoPlayAnimationDuration:
                        const Duration(milliseconds: 800),
                    viewportFraction: 0.8,
                  ),
                  items: images.map((imagePath) {
                    return Builder(
                      builder: (BuildContext context) {
                        return Container(
                          width: MediaQuery.of(context).size.width,
                          margin: const EdgeInsets.symmetric(horizontal: 5.0),
                          child: Image.asset(
                            imagePath,
                            fit: BoxFit.cover,
                          ),
                        );
                      },
                    );
                  }).toList(),
                ),
                const SizedBox(height: 20),
                     const Padding(
                  padding: EdgeInsets.only(left: 120.0),
                 child: Text(
                  'Dobrodošli',
                  style: TextStyle(fontSize: 24, fontWeight: FontWeight.bold),
                ),
                ),
                const SizedBox(height: 10),
                const Padding(
                  padding: EdgeInsets.only(top: 10.0),
                  child: Text(
                    '"Change Studio" nudi vam najsavremenije tehnike šišanja, farbanja i barberinga kao i raznih drugih usluga za žene i muškarce u svijetu frizera. Posjetite nas na novoj lokaciji Bingo City Centar i uvjerite se u naš kvalitet.',
                    style: TextStyle(fontSize: 16, fontStyle: FontStyle.italic),
                  ),
                ),
                const SizedBox(height: 20),
                Padding(
                  padding: const EdgeInsets.only(top: 10.0, left: 120.0),
                  child: ElevatedButton(
                    onPressed: () {
                      Navigator.of(context).pushNamed('/zakazivanjeTermina');
                    },
                    child: const Text('Rezerviši termin'),
                  ),
                ),
                const SizedBox(height: 20),
                const Padding(
                  padding: EdgeInsets.only(top: 30, left: 70.0),
                  child: Column(
                    children: [
                      // Location
                      Row(
                        children: [
                          Icon(Icons.location_on, size: 30),
                          SizedBox(width: 10),
                          Text('Džemala Bijedića 160',
                              style: TextStyle(fontSize: 16)),
                        ],
                      ),
                      Padding(
                        padding: EdgeInsets.symmetric(vertical: 30),
                        child: Row(
                          children: [
                            Icon(Icons.access_time, size: 30),
                            SizedBox(width: 10),
                            Text('Radno vrijeme',
                                style: TextStyle(fontSize: 16)),
                            SizedBox(width: 10),
                            Text('Pon-Sub 9:00 - 21:00',
                                style: TextStyle(fontSize: 14)),
                          ],
                        ),
                      ),
                      Row(
                        children: [
                          Icon(Icons.contact_mail, size: 30),
                          SizedBox(width: 10),
                          Text('Kontaktirajte nas',
                              style: TextStyle(fontSize: 16)),
                        ],
                      ),
                      Row(
                        children: [
                          SizedBox(width: 40),
                          Text('contact@frizerskisalon.com',
                              style: TextStyle(fontSize: 14))
                        ],
                      ),
                    ],
                  ),
                ),
              ],
            ),
          ),
        ));
  }
}
