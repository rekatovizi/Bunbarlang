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
        private string ujjatekvalaszto;
        private string fogadas;

        public LoversenyOOP(int palyahossz, int penz)
        {
            this.palyahossz = palyahossz;
            this.penz = penz;
            this.tet = tet;
            this.lovakok = new List<Lovak>();
            this.ujjatekvalaszto = ujjatekvalaszto;
            this.fogadas = fogadas;
        }

        public int Palyahossz { get => palyahossz; set => palyahossz = value; }
        public int Penz { get => penz; set => penz = value; }
        public int Tet { get => tet; set => tet = value; }
        internal List<Lovak> Lovak { get => lovakok; set => lovakok = value; }
        public string Ujjatekvalaszto { get => ujjatekvalaszto; set => ujjatekvalaszto = value; }
        public string Fogadas { get => fogadas; set => fogadas = value; }

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
            do
            {
                do
                {
                    LovakFeltoltese();
                    Console.WriteLine("Versenyző lovak");
                    foreach (var item in lovakok) 
                    { 
                        Console.Write($"{item.Nev}  "); 
                    }
                    Console.WriteLine();
                    this.ujjatekvalaszto = "";
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"Jelenlegi pénzed: {this.penz}");
                    Console.ResetColor();
                    Console.Write("Mennyi tétet szeretnél feltenni: ");
                    this.tet = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Melyik Lóra szeretnél fogadni? ");
                    this.fogadas = Console.ReadLine();
                    if (this.tet <= 0 || this.tet > this.penz || (fogadas.ToLower().Trim() != "bucephalus" && fogadas.ToLower().Trim() != "pegasus" && fogadas.ToLower().Trim() != "shadowfax" && fogadas.ToLower().Trim() != "rocinante" && fogadas.ToLower().Trim() != "trabant"))
                    {
                        Console.ForegroundColor = ConsoleColor.Red; 
                        Console.WriteLine("Hibás tét vagy ló! Kérem adjon meg egy helyes értékeket!"); 
                        Console.ResetColor();
                    }
                } while (this.tet <= 0 || this.tet > this.penz || (fogadas.ToLower().Trim()!= "bucephalus" && fogadas.ToLower().Trim() != "pegasus" && fogadas.ToLower().Trim() != "shadowfax" && fogadas.ToLower().Trim() != "rocinante" && fogadas.ToLower().Trim() != "trabant") );
                
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
                Lovak max = new Lovak("", 0, "");
                foreach (var item in lovakok)
                {
                    if (item.Gyorsasag > max.Gyorsasag)
                    {
                        max = item;
                    }
                }
                Console.WriteLine($"A Győztes: {max.Nev}");
                if (max.Nev.ToLower() == this.fogadas.ToLower().Trim()) 
                { 
                    Console.ForegroundColor = ConsoleColor.Green;
                    penz += 2 * tet;
                    Console.WriteLine($"Gratulálok! Nyertél!"); 
                    Console.ResetColor();  
                } 
                else 
                { 
                    Console.ForegroundColor = ConsoleColor.Red;
                    penz -= 2 * tet;
                    Console.WriteLine($"Sajnálom! Vesztettél!"); 
                    Console.ResetColor(); 
                } 
                Console.Write("Szeretnél újra játszani? (i/n): "); 
                this.ujjatekvalaszto = Console.ReadLine();
                this.lovakok.Clear();
                this.fogadas = "";
                this.tet = 0;
            } while (this.ujjatekvalaszto == "i" && this.penz > 0);
            if (this.penz <= 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Nincs több pénzed, nem tudsz játszani!");
                Console.ResetColor();
                Thread.Sleep(2000);
                Program.menü();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Köszönöm, hogy játszottál!");
                Console.ResetColor();
                Thread.Sleep(2000);
                Program.menü();
            }
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