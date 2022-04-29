using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie1_wpf.MVVM.Model
{
    
    public class Maszyna
    {
        private List<string> Tablica { get; set; }

        public Maszyna()
        {
            Tablica = new List<string>();
        }
        public void Dodaj(string kupon) 
        {
            Tablica.Add(kupon);
        }
        public string Wyjmij() 
        {
            Random random = new Random();
            var randomIndex = random.Next(0,Tablica.Count-1);
            var tempVal = Tablica[randomIndex];
            Tablica.RemoveAt(randomIndex);
            return tempVal;
        }

        public bool Pusta() 
        {
            if (Tablica.Count == 0)
                return true;
            else
                return false;
        }

        public string Zawartosc() 
        {
            string zawartosc = "";
            foreach (string kupon in Tablica) 
            {
                zawartosc +=kupon + ", ";  
            }
            return zawartosc;
        }
    }
}
