import 'package:flutter/material.dart';

class HomePageScreen extends StatefulWidget {
  const HomePageScreen({Key? key}) : super(key: key);

  @override
  State createState() => _State();
}

class _State extends State<HomePageScreen> {
  @override
  Widget build(BuildContext context) {
    return Container(
      child: Scaffold(
        appBar: AppBar(
          title: const Text('Home Page'),
        ),
        drawer: Drawer(
          child: ListView(
            padding: EdgeInsets.zero,
            children: <Widget>[
              const DrawerHeader(
                decoration: BoxDecoration(
                  color: Colors.blue,
                ),
                child: Text(
                  'Menu',
                  style: TextStyle(
                    color: Colors.white,
                    fontSize: 24,
                  ),
                ),
              ),
              ListTile(
                title: const Text('Option 1'),
                onTap: () {
                  // Handle option 1
                },
              ),
              ListTile(
                title: const Text('Option 2'),
                onTap: () {
                  // Handle option 2
                },
              ),
              // Add more ListTile widgets for additional options
            ],
          ),
        ),
        body: const Column(
          children: [
            Text("Welcome to home page"),
            SizedBox(height: 8),
          ],
        ),
      ),
    );
  }
}
