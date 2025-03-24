using System;
using System.Collections.Generic;

namespace ProjketAPBD1

{
    public class Kontenerchlodniczy:Kontener
    {
        public string rodzaj;
        public double temperatura;
        public Kontenerchlodniczy(double temperatura,string rodzaj, int masaladunku, int wysokosc, int wagalakontenera, int glebokosc, int maksymalnaladownosc) :
            base("C", masaladunku, wysokosc, wagalakontenera, glebokosc, maksymalnaladownosc)
        {
            this.temperatura = temperatura;
            this.rodzaj = rodzaj;
        }
        Dictionary<string, double> produkty = new Dictionary<string, double>()
        {
            { "Bananas", 13.3 },
            { "Chocolate", 18 },
            { "Fish", 2 },
            { "Meat", -15 },
            { "Ice cream", -18 },
            { "Frozen pizza", -30 },
            { "Cheese", 7.2 },
            { "Sausages", 5 },
            { "Butter", 20.5 },
            { "Eggs", 19 }
        };
        public bool CzyMoznaPrzechowywac(string produkt)
        {
            if (!produkty.ContainsKey(produkt))
            {
                Console.WriteLine("Nieznany produkt.");
                return false;
            }

            if (produkt != rodzaj)
            {
                Console.WriteLine($"Kontener jest przeznaczony tylko dla produktu: {rodzaj}.");
                return false;
            }

            double minimalnaTemperatura = produkty[produkt];

            if (temperatura < minimalnaTemperatura)
            {
                Console.WriteLine($"Temperatura w kontenerze ({temperatura}°C) jest za niska dla {produkt}. " +
                                  $"Zmieniam temperaturę na {minimalnaTemperatura}°C.");
                temperatura = minimalnaTemperatura;
            }

            return true;
        }
    }
}