using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Bunbarlang
{
    internal class LoversenyOOP
    {
        private List<Lovak> lovakok;
        private int palyahossz;
        private int penz;
        private int tet;

        public LoversenyOOP(int palyahossz, int penz, int tet)
        {
            this.palyahossz = palyahossz;
            this.penz = penz;
            this.tet = tet;
            this.lovakok = new List<Lovak>();
        }

        public int Palyahossz { get => palyahossz; set => palyahossz = value; }
        public int Penz { get => penz; set => penz = value; }
        public int Tet { get => tet; set => tet = value; }
        internal List<Lovak> Lovak { get => lovakok; set => lovakok = value; }

        public void LovakFeltoltese()
        {
            List<string> lovakNevei = new List<string>() { "Bucephalus", "Pegasus", "Shadowfax", "Rocinante", "Trabant" };
            List<string> szin = new List<string>() { "B", "P", "S", "R", "T" };
            for (int i = 0; i < lovakNevei.Count; i++)
            {
                lovakok.Add(new Lovak(lovakNevei[i], 0, szin[i]));
            }
        }
        public void Jatek()
        {
            LovakFeltoltese();
            do
            {
                foreach (var item in lovakok)
                {
                    item.LoEro();
                }
                Console.Clear();
                Console.WriteLine(this.ToString()); 
                Thread.Sleep(1000);
            } 
            while (lovakok.Max(x => x.Gyorsasag) < palyahossz);
            Lovak  max = new Lovak("",0,"");
            foreach (var item in lovakok)
            {
                if (item.Gyorsasag > max.Gyorsasag)
                {
                    max = item;
                }
            }
            Console.WriteLine($"A Győztes: {max.Nev}");
        }

        public override string ToString()
        {
            string s = "";
            foreach (var item in lovakok)
            {
                s += "\t|";
                for (int i = 0; i < this.palyahossz-item.Gyorsasag; i++)
                {
                    s += " ";
                }
                s += item.Szin+"\n";
            }
            return s;
        }
    }
}