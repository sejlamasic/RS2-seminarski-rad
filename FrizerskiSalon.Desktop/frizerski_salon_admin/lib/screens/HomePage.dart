import 'package:flutter/material.dart';
import 'Proizvodi.dart';

class HomePageScreen extends StatefulWidget {
  const HomePageScreen({Key? key}) : super(key: key);

  @override
  State createState() => _State();
}

class _State extends State<HomePageScreen> {
  int _selectedIndex = 0;

  static final List<Widget> _widgetOptions = <Widget>[
    const HomePage(),
    const ProizvodiScreen(),
    const GalleryPage(),
    const ContactPage(),
  ];

  void _onItemTapped(int index) {
    setState(() {
      _selectedIndex = index;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Change Studio'),
        automaticallyImplyLeading: false,
        actions: [
          TextButton(
            onPressed: () {
              _onItemTapped(0); // Navigate to HomePage
            },
            child: const Text(
              'Početna',
              style: TextStyle(
                color: Colors.white,
                fontSize: 16,
              ),
            ),
          ),
          TextButton(
            onPressed: () {
              _onItemTapped(1); // Navigate to ProizvodiScreen
            },
            child: const Text(
              'Proizvodi',
              style: TextStyle(
                color: Colors.white,
                fontSize: 16,
              ),
            ),
          ),
          IconButton(
            icon: const Icon(Icons.photo),
            onPressed: () {
              _onItemTapped(2);
            },
          ),
          IconButton(
            icon: const Icon(Icons.contact_mail),
            onPressed: () {
              _onItemTapped(3);
            },
          ),
        ],
      ),
      body: _widgetOptions.elementAt(_selectedIndex),
    );
  }
}

class HomePage extends StatelessWidget {
  const HomePage({super.key});

  @override
  Widget build(BuildContext context) {
    return SingleChildScrollView(
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Image.asset(
            'assets/images/hairdressersalon.jpg',
            width: double.infinity,
            height: 400,
            fit: BoxFit.cover,
          ),
          const Padding(
            padding: EdgeInsets.all(16.0),
            child: Padding(
              padding: EdgeInsets.only(bottom: 100.0),
              child: Column(
                children: [
                  Text(
                    'Frizerski salon za žene i muškarce "Change Studio" nudi vam najsavremenije tehnike šišanja, farbanja i barberinga kao i raznih drugih usluga za žene i muškarce u svijetu frizera. Posjetite nas na novoj lokaciji Bingo City Centar i uvjerite se u naš kvalitet.',
                    style:
                        TextStyle(fontSize: 20.0, fontStyle: FontStyle.italic),
                    textAlign: TextAlign.center,
                  ),
                  SizedBox(height: 50.0),
                  Row(
                    mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                    children: [
                      Expanded(
                        child: Column(
                          children: [
                            Text(
                              'Posjetite nas:',
                              style: TextStyle(
                                  fontSize: 20.0, fontWeight: FontWeight.bold),
                              textAlign: TextAlign.center,
                            ),
                            Text('Džemala Bijedića 160'),
                            Text('71000 Sarajevo'),
                          ],
                        ),
                      ),
                      Expanded(
                        child: Column(
                          children: [
                            Text(
                              'Kontaktirajte nas:',
                              style: TextStyle(
                                  fontSize: 20.0, fontWeight: FontWeight.bold),
                              textAlign: TextAlign.center,
                            ),
                            Text('033 788 180'),
                            Text('infodeskbcc2@bingotuzla.ba'),
                          ],
                        ),
                      ),
                      Expanded(
                        child: Column(
                          children: [
                            Text(
                              'Radno vrijeme:',
                              style: TextStyle(
                                  fontSize: 20.0, fontWeight: FontWeight.bold),
                              textAlign: TextAlign.center,
                            ),
                            Text('Pon-Sub 9:00 - 21:00'),
                            Text('Ned 10:00 - 18:00'),
                          ],
                        ),
                      ),
                    ],
                  ),
                  SizedBox(height: 30.0),
                ],
              ),
            ),
          ),
        ],
      ),
    );
  }
}

class GalleryPage extends StatelessWidget {
  const GalleryPage({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return const Center(
      child: Text(
        'Gallery Page',
        style: TextStyle(fontSize: 24),
      ),
    );
  }
}

class ContactPage extends StatelessWidget {
  const ContactPage({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return const Center(
      child: Text(
        'Contact Page',
        style: TextStyle(fontSize: 24),
      ),
    );
  }
}
