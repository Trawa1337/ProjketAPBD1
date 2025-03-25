using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjketAPBD1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<Statek> statekList = new List<Statek>();
            List<Kontener> kontenerList = new List<Kontener>();
            while (true)
            {
                WyswietlListe();

                Console.WriteLine("\nNaciśnij ENTER, aby otworzyć menu...");
                Console.ReadLine();

                Console.Clear();
                Console.WriteLine("Możliwe akcje:");
                Console.WriteLine("1. Dodaj kontenerowiec");
                if (statekList.Count != 0)
                {
                    Console.WriteLine("3. Usuń kontenerowiec");
                }

                Console.WriteLine("2. Dodaj kontener");
                if (statekList.Count != 0)
                {
                    Console.WriteLine("3. Usuń kontenerowiec");
                }

                if (kontenerList.Count != 0)
                {
                    Console.WriteLine("4. Usuń kontener");
                }

                if (kontenerList.Count != 0 && statekList.Count != 0)
                {
                    Console.WriteLine("5. Dodaj kontener do statku");
                    Console.WriteLine("6. Usuń kontener ze statku");
                }

                Console.WriteLine("7. Wyjdź");

                Console.Write("\nWybierz opcję: ");
                string input = Console.ReadLine();


                switch (input)
{
    case "1":
        Console.Write("Podaj nazwę kontenerowca: ");
        string nazw = Console.ReadLine();
        Console.Write("Podaj liczbę kontenerów: ");
        int liczba = int.Parse(Console.ReadLine());
        Console.Write("Podaj prędkość: ");
        double predkosc = double.Parse(Console.ReadLine());
        Console.Write("Podaj maksymalną ilość: ");
        int maxilosc = int.Parse(Console.ReadLine());
        Console.Write("Podaj maksymalną wagę: ");
        int makswaga = int.Parse(Console.ReadLine());
        Statek statek = new Statek(nazw, liczba, predkosc, maxilosc, makswaga);
        statekList.Add(statek);
        break;

    case "2":
        Console.Clear();
        Console.WriteLine("\nWybierz Kontener który chcesz stworzyć: ");
        Console.WriteLine("1. Kontener na płyny");
        Console.WriteLine("2. Kontener na gaz");
        Console.WriteLine("3. Kontener chłodniczy");
        string kontener = Console.ReadLine();

        switch (kontener)
        {
            case "1":
                Console.Write("Czy jest bezpieczny: ");
                bool bezp = bool.Parse(Console.ReadLine());
                Console.Write("Podaj masę ładunku: ");
                int masa1 = int.Parse(Console.ReadLine());
                Console.Write("Podaj wysokość: ");
                int wysokosc1 = int.Parse(Console.ReadLine());
                Console.Write("Podaj wagę kontenera: ");
                int waga1 = int.Parse(Console.ReadLine());
                Console.Write("Podaj głębokość: ");
                int glebokosc1 = int.Parse(Console.ReadLine());
                Console.Write("Podaj maksymalną ładowność: ");
                int maksymalnaladownosc1 = int.Parse(Console.ReadLine());

                Kontenerplyny kontenerplyny = new Kontenerplyny(bezp, masa1, wysokosc1, waga1, glebokosc1, maksymalnaladownosc1);
                kontenerList.Add(kontenerplyny);
                Console.Clear();
                WyswietlListe();
                break;

            case "2":
                Console.Write("Podaj Ciśnienie: ");
                double cis = double.Parse(Console.ReadLine());
                Console.Write("Podaj masę ładunku: ");
                int masa2 = int.Parse(Console.ReadLine());
                Console.Write("Podaj wysokość: ");
                int wysokosc2 = int.Parse(Console.ReadLine());
                Console.Write("Podaj wagę kontenera: ");
                int waga2 = int.Parse(Console.ReadLine());
                Console.Write("Podaj głębokość: ");
                int glebokosc2 = int.Parse(Console.ReadLine());
                Console.Write("Podaj maksymalną ładowność: ");
                int maksymalnaladownosc2 = int.Parse(Console.ReadLine());

                Kontenergaz kontenergaz = new Kontenergaz(masa2, wysokosc2, waga2, glebokosc2, maksymalnaladownosc2, cis);
                kontenerList.Add(kontenergaz);
                Console.Clear();
                WyswietlListe();
                break;

            case "3":
                Console.Write("Podaj Temperaturę: ");
                double temperatura = double.Parse(Console.ReadLine());
                Console.Write("Podaj nazwę Produktu: ");
                string nazwa = Console.ReadLine();
                Console.Write("Podaj masę ładunku: ");
                int masa3 = int.Parse(Console.ReadLine());
                Console.Write("Podaj wysokość: ");
                int wysokosc3 = int.Parse(Console.ReadLine());
                Console.Write("Podaj wagę kontenera: ");
                int waga3 = int.Parse(Console.ReadLine());
                Console.Write("Podaj głębokość: ");
                int glebokosc3 = int.Parse(Console.ReadLine());
                Console.Write("Podaj maksymalną ładowność: ");
                int maksymalnaladownosc3 = int.Parse(Console.ReadLine());

                Kontenerchlodniczy kontenerchlodniczy = new Kontenerchlodniczy(temperatura, nazwa, masa3, wysokosc3, waga3, glebokosc3, maksymalnaladownosc3);
                kontenerchlodniczy.CzyMoznaPrzechowywac(nazwa);
                kontenerList.Add(kontenerchlodniczy);
                Console.Clear();
                WyswietlListe();
                break;

            default:
                Console.WriteLine("Niepoprawny wybór.");
                break;
        }
        break;

    case "3":
        Console.Write("Podaj nazwę kontenerowca do usunięcia: ");
        string nazwaDoUsuniecia = Console.ReadLine();
        Statek statekDoUsuniecia = statekList.FirstOrDefault(s => s.name == nazwaDoUsuniecia);

        if (statekDoUsuniecia != null)
        {
            statekList.Remove(statekDoUsuniecia);
            Console.WriteLine("Kontenerowiec został usunięty!");
        }
        else
        {
            Console.WriteLine("Nie znaleziono kontenerowca o podanej nazwie.");
        }
        break;

    case "4":
        Console.Write("Podaj numer seryjny kontenera do usunięcia: ");
        string numerSeryjnyDoUsuniecia = Console.ReadLine();
        Kontener kontenerDoUsuniecia = kontenerList.FirstOrDefault(k => k.numerseryjny == numerSeryjnyDoUsuniecia);

        if (kontenerDoUsuniecia != null)
        {
            kontenerList.Remove(kontenerDoUsuniecia);
            Console.WriteLine("Kontener został usunięty!");
        }
        else
        {
            Console.WriteLine("Nie znaleziono kontenera o podanym numerze seryjnym.");
        }
        break;

    case "5":
        Console.WriteLine("Podaj numer seryjny konetera który chesz dodac");
        string seryjny= Console.ReadLine();
        Kontener szuaknykontener =kontenerList.FirstOrDefault(k => k.numerseryjny == seryjny);
        if (szuaknykontener == null)
        {
            Console.WriteLine("Nie ma takeigo Kontenera");
            Console.Read();
            break;
        }
        Console.WriteLine("Podaj nazwę statku do którego chcesz przypisac");
        string statku = Console.ReadLine();
        Statek wybranystatek= statekList.FirstOrDefault(st => st.name == statku);
        if (wybranystatek == null)
        {
            Console.WriteLine("Nie ma takeigo statku");
            Console.Read();
            break;
        }
       wybranystatek.dodajKontener(szuaknykontener);
        wybranystatek.wyswietlstatek();
       
        Console.Read();
        
        
        break;

    case "6":
        Console.WriteLine("Podaj numer seryjny konetera który chesz usunac");
        string sery= Console.ReadLine();
        Kontener szuaknykontener1 =kontenerList.FirstOrDefault(k => k.numerseryjny == sery);
        if (szuaknykontener1 == null)
        {
            Console.WriteLine("Nie ma takeigo Kontenera");
            Console.Read();
            break;
        }
        Console.WriteLine("Podaj nazwę statku z którego chesz usunąć");
        string statek1 = Console.ReadLine();
        Statek wybranystatek1= statekList.FirstOrDefault(st => st.name == statek1);
        if (wybranystatek1 == null)
        {
            Console.WriteLine("Nie ma takeigo statku");
            Console.Read();
            break;
        }
        wybranystatek1.usunKontener(szuaknykontener1);
        wybranystatek1.wyswietlstatek();
       
        Console.Read();
        break;

    case "7":
        break; 

    default:
        Console.WriteLine("Niepoprawny wybór.");
        break;
}
                void WyswietlListe()
                {
                    Console.Clear(); // Czyści ekran

                    Console.WriteLine("Lista kontenerowców:");
                    if (statekList.Count == 0)
                    {
                        Console.WriteLine("Brak");
                    }
                    else
                    {
                        foreach (var s in statekList)
                        {
                            Console.WriteLine(s);
                        }
                    }

                    Console.WriteLine("\nLista kontenerów:");
                    if (kontenerList.Count == 0)
                    {
                        Console.WriteLine("Brak");
                    }
                    else
                    {
                        foreach (var k in kontenerList)
                        {
                            Console.WriteLine(k.numerseryjny
                            );
                        }
                    }
                }

               







            }

        }
    }
}
