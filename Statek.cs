namespace ProjketAPBD1
{
    public class Statek
    {
        public String name{ get; }
        private int liczbakontenerow;
        private double prędkość;
        private int maksilosc;
        private int makswaga;
        private List<Kontener> kontenery = new List<Kontener>();

        public Statek(string name,int liczbakontenerow, double prędkość, int maksilosc, int makswaga)
        {
            this.name = name;
            this.liczbakontenerow = liczbakontenerow;
            this.prędkość = prędkość;
            this.maksilosc = maksilosc;
            this.makswaga = makswaga;
        }

        public double lacznawaga()
        {
            double lwaga = 0;
            foreach (var w in kontenery)
            {
                lwaga += w.maksymalnaladownosc;
            }

            return lwaga;
        }
        public void zaladujListeKontenerow(List<Kontener> konteneryDoZaladunku)
        {
            foreach (var kontener in konteneryDoZaladunku)
            {
                dodajKontener(kontener);
            }
        }

        public void dodajKontener(Kontener kontener)
        {
            if (kontener.statek != null)
            {
                Console.WriteLine("Kontener jest już na statku");               
            }
            else
            {


                if (liczbakontenerow < maksilosc & lacznawaga() < makswaga)
                {
                    kontenery.Add(kontener);
                    kontener.statek = this;
                }
                else
                {
                    Console.WriteLine("Nie możemy załadować tego kontenera");
                }
            }
        }

        public void usunKontener(Kontener kontener)
        {
            kontenery.Remove(kontener);
            kontener.statek = null;
        }

        public void zastapkontener(Kontener kontener1, Kontener kontener2)
        {
            kontenery.Remove(kontener1);
            kontenery.Add(kontener2);
        }

        public void wyswietlstatek()
        {
            if (kontenery.Count == 0)
            {
                Console.WriteLine("Nie ma kontenerow na statku "+name+".");
                return;
            }

            Console.WriteLine("Lista Kontenerów na statku "+ name+" :");

            foreach (var container in kontenery)
            {
                Console.WriteLine($"Numer seryjny: {container.numerseryjny}");
                Console.WriteLine($"Masa ładunku : {container.masaladunku}");
                Console.WriteLine($"Wysokosc : {container.wysokosc}");
                Console.WriteLine($"Waga Kontenera : {container.wagalakontenera}");
                Console.WriteLine($"Glebokosc : {container.glebokosc}");
                Console.WriteLine($"Maksymalna Ladownosc : {container.maksymalnaladownosc}");

                Console.WriteLine("----------------------------------------------------");
            }
            
            
        }
        public void rozladujStatek()
        {
            
            if (kontenery.Count == 0)
            {
                Console.WriteLine("Statek nie ma żadnych kontenerów do rozładowania.");
                return;
            } foreach (var kontener in kontenery.ToList()) 
            {
                usunKontener(kontener);
                Console.WriteLine($"Kontener {kontener.numerseryjny} został rozładowany.");
            }
            Console.WriteLine("Wszystkie kontenery zostały rozładowane.");
        }

        public void przenieskontener(Kontener kontener, Statek statek)
        {
            if (kontener.statek != this)
            {
                Console.WriteLine("Tego kontenera nie ma na tym statku");
                return;
            }

            if (statek.liczbakontenerow<statek.maksilosc && statek.lacznawaga() + kontener.maksymalnaladownosc <= statek.maksilosc)
            {
                usunKontener(kontener);
                statek.dodajKontener(kontener);
            }
            else
            {
                Console.WriteLine("Nie ma kontenerow na statku");
            }
        }
        public override string ToString()
        {
            return $"Statek: {name}, Kontenery: {liczbakontenerow}, Prędkość: {prędkość} , Max Ilość: {maksilosc}, Max Waga: {makswaga} kg";
        }

        public void zastapkontener(string numerseryjny, Kontener kontener)
        {
            var kontenerser = kontenery.FirstOrDefault(k => k.numerseryjny == numerseryjny);
            if (kontenerser == null)
            {
                Console.WriteLine($"Nie znaleziono kontenera.");
                return;
            }

            if (lacznawaga()-kontener.maksymalnaladownosc+kontener.maksymalnaladownosc >makswaga)
            {
                Console.WriteLine("Za duża waga");
            }
            kontenery.Remove(kontenerser);
            kontenery.Add(kontener);
        }
    }
}