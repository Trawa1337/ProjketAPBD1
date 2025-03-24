using System;

namespace ProjketAPBD1
{
    public class Kontenerplyny:Kontener,IHazardNotifier
    {
        private bool czyniebezpieczny { get; }
        public Kontenerplyny( bool czyniebezpieczny, int masaladunku, int wysokosc, int wagalakontenera, int glebokosc, int maksymalnaladownosc) 
            : base("L", masaladunku, wysokosc, wagalakontenera, glebokosc, maksymalnaladownosc)
        {
            this.czyniebezpieczny=czyniebezpieczny;
        }
        public void powiadomienie(string wiadomosc)
        {
            Console.WriteLine("Powiadomienie o kontenerze"+id+" " + wiadomosc);
        }
        
        public void zaladujjkontener(int zaladunek)
        {
            if (czyniebezpieczny)
            {
                if (this.masaladunku + zaladunek >0.5*( this.maksymalnaladownosc))
                {
                    throw new Exception("OverfillException");
                }
                else
                {
                    this.masaladunku += zaladunek;
                }
            }
            else
            {
                if (this.masaladunku + zaladunek >0.9*( this.maksymalnaladownosc))
                {
                    throw new Exception("OverfillException");
                }
                else
                {
                    this.masaladunku += zaladunek;
                }
            }

        }

       
    }
}