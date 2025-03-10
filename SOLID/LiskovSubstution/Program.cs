// See https://aka.ms/new-console-template for more information
using LiskovSubstution;
using System.Security.Cryptography;

Console.WriteLine("Hello, World!");

//Liskov diyor ki: Bir sınıf başka sınıftan miras alıyorsa, ikisi de birbirinin yerine İSTİSNASIZ geçebilmelidir.
//Yani bir sınıfın alt sınıfı, üst sınıfın tüm özelliklerini ve davranışlarını aynen sergileyebilmelidir.


Kare kare = new Kare { KenarUzunlugu = 5 };
Dortgen dortgen = new Dortgen { Boy = 10, En = 5 };
//kare.En = 5;
//kare.Boy = 10;


//Console.WriteLine(kare.AlanHesapla());

Geometri geometri = new Geometri();
Console.WriteLine(geometri.Alan(kare));
Console.WriteLine(geometri.Alan(dortgen));

