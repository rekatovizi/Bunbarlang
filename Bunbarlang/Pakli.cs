using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bunbarlang
{
    internal class Pakli
    {
        List<Kartya> kartyak;

        public Pakli(List<Kartya> kartyak)
        {
            this.kartyak = kartyak;
        }

        internal List<Kartya> Kartyak { get => kartyak; set => kartyak = value; }

        public void Feltoltes()
        {
            foreach (Szin szin in Enum.GetValues(typeof(Szin)))
            {
                foreach (string figura in Enum.GetNames(typeof(Figura)))
                {
                    Figura a = (Figura)Enum.Parse(typeof(Figura), figura);
                    kartyak.Add(new Kartya(szin, a));
                }
            }
        }
        
        public Kartya Huzas() 
        { 
            Random rnd = new Random();
            int index = rnd.Next(kartyak.Count());
            //Console.WriteLine(index);
            Kartya huzottKartya = kartyak[index];
            //Console.WriteLine(huzottKartya);
            kartyak.RemoveAt(index);
            return huzottKartya;
        }

        public override string ToString()
        {
            string s = "";
            foreach (var kartya in kartyak)
            {
                s += kartya.ToString() + "\n";
            }
            return s;
        }
    }
}
