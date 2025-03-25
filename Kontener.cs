using System;

namespace ProjketAPBD1
{
    public abstract class Kontener
    {
        public static int id = 1;
        public int masaladunku { get; set; }
        public int wysokosc{ get; set; }
        public int wagalakontenera{ get; set; }
        public int glebokosc{ get; set; }
        public string numerseryjny{ get; set; }
        public int maksymalnaladownosc{ get; set; }
        public Statek statek { get; set; }

        public Kontener(string typ,int masaladunku, int wysokosc, int wagalakontenera, int glebokosc,int maksymalnaladownosc)
        {
            numerseryjny = $"KON-{typ}-{id++}";
            this.masaladunku = masaladunku;
            this.wysokosc = wysokosc;
            this.wagalakontenera = wagalakontenera;
            this.glebokosc = glebokosc;
            this.maksymalnaladownosc = maksymalnaladownosc;
        }

        public  void oproznijkontener(Kontener kontener)
        {
            kontener.masaladunku = 0;
        }

        public virtual void zaladujjkontener(int zaladunek)
        {
            if (masaladunku + zaladunek > maksymalnaladownosc)
            {
                throw new Exception("OverfillException");
            }else
            {
                masaladunku += zaladunek;
                
            }
            
        }
        public void wyswietlKontener()
        {
            Console.WriteLine($"Numer seryjny: {numerseryjny}");
            Console.WriteLine($"Masa ładunku: {masaladunku} kg");
            Console.WriteLine($"Wysokość: {wysokosc} m");
            Console.WriteLine($"Waga kontenera: {wagalakontenera} kg");
            Console.WriteLine($"Głębokość: {glebokosc} m");
            Console.WriteLine($"Maksymalna ładowność: {maksymalnaladownosc} kg");

            if (statek != null)
            {
                Console.WriteLine($"Statek: {statek.name}");
            }
            else
            {
                Console.WriteLine("Kontener nie jest załadowany na żadnym statku.");
            }

            Console.WriteLine("--------------------------------------------------");
        }
        
        
        
        
    }
}