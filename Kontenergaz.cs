using System;

namespace ProjketAPBD1
{
    public class Kontenergaz:Kontener,IHazardNotifier
    { 
        public double cisnienie { get; }

        public Kontenergaz(int masaladunku, int wysokosc, int wagaKontenera, int glebokosc, int maksymalnaLadownosc, double cisnienie)
            : base("G", masaladunku, wysokosc, wagaKontenera, glebokosc, maksymalnaLadownosc)
        {
            this.cisnienie=cisnienie;
        }
        public  void oproznijkontener()
        {
            this.masaladunku = (int)(0.05*this.masaladunku);
        }

        public void powiadomienie(string wiadomosc)
        {
            Console.WriteLine("Powiadomienie o kontenerze"+id+" " + wiadomosc);
        }
        
    }
}