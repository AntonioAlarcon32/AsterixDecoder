<h1 align="center">Asterix Decoder</h1>

<!-- TABLE OF CONTENTS -->
<details open="open">
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#usage">Usage</a></li>
    <li><a href="#roadmap">Roadmap</a></li>
    <li><a href="#contributing">Contributing</a></li>
    <li><a href="#license">License</a></li>
    <li><a href="#contact">Contact</a></li>
    <li><a href="#acknowledgements">Acknowledgements</a></li>
  </ol>
</details>

<!-- ABOUT THE PROJECT -->
# About The Project

Project built for Projects In Air Traffic Management Course of EETAC-UPC Aerospace Systems Engineering Degree. Capable of full decoding of EuroControl Asterix CAT10 and CAT21 messages.

## Functionalities 
* Full Decoding of CAT10 and CAT21 Asterix Packets.
* Packet View with basic info, capable of showing complete info of packet.
* Processing of Packets to obtain Vehicles using MLAT or ADS-B.
* Transformation of coordinates to obtain WGS-84 Coordinates of CAT10 packets.
* Map View of traffic in function of the time.
* Map View of track of CAT21 and CAT10-MLAT Vehicles.

## Built With

This project was completely built using C#, using Windows Forms, thanks to Visual Studio. Map View using GMAP. Net Library.
* [GMap](https://www.nuget.org/packages/GMap.NET.Windows/)
* [Visual Studio](https://visualstudio.microsoft.com/es/)

# Getting Started

[alt text](https://github.com/AntonioAlarcon32/AsterixDecoder/blob/master/Git_images/1.png?raw=true)

When opening, go to File --> Open to select the .ast file.

After Loading, the packet table will open.

[alt text](https://github.com/AntonioAlarcon32/AsterixDecoder/blob/master/Git_images/2.png?raw=true)

To see extra info about a packet, click on it on the table and then click the Extra Info Button to open the extra info dialog

[alt text](https://github.com/AntonioAlarcon32/AsterixDecoder/blob/master/Git_images/3.png?raw=true)


