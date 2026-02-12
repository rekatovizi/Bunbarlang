using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bunbarlang
{
    internal class BlackJack
    {
        private int penz;
        private int tet;
        private string ujjatekvalaszto;
        private Pakli pakli = new Pakli(new List<Kartya>());
        List<Kartya> jatekosKartyak = new List<Kartya>();
        List<Kartya> osztoKartyak = new List<Kartya>();

        public BlackJack(int penz, int tet)
        {
            this.penz = penz;
            this.tet = tet;
            this.ujjatekvalaszto = ujjatekvalaszto;

        }

        public int Penz { get => penz; set => penz = value; }
        public int Tet { get => tet; set => tet = value; }
        public Pakli Pakli { get => pakli; set => pakli = value; }
        public string Ujjatekvalaszto { get => ujjatekvalaszto; set => ujjatekvalaszto = value; }

        public void Jatek()
        {   do
            {
                do
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"Jelenlegi pénzed: {this.penz}");
                    Console.ResetColor();
                    Console.Write("Mennyi tétet szeretnél feltenni: ");
                    this.tet = Convert.ToInt32(Console.ReadLine());
                    if (this.tet <= 0 || this.tet > this.penz)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Hibás tét! Kérem adjon meg egy helyes értéket!");
                        Console.ResetColor();
                    }
                } while (this.tet <= 0 || this.tet > this.penz);
                this.ujjatekvalaszto = "";
                pakli.Feltoltes();
                jatekosKartyak.Add(pakli.Huzas());
                osztoKartyak.Add(pakli.Huzas());
                jatekosKartyak.Add(pakli.Huzas());
                osztoKartyak.Add(pakli.Huzas());
                Console.WriteLine("Játékos kártyái:\n");
                Console.ForegroundColor = ConsoleColor.Green;
                foreach (var kartya in jatekosKartyak)
                {
                    Console.WriteLine(kartya);
                }
                Console.ResetColor();
                Console.WriteLine("\nOszto kártyái:\n");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(osztoKartyak[0] + "\n?");
                Console.ResetColor();
                Console.WriteLine(Kor());
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Szeretnél új játékot kezdeni? (i/n)"); 
                Console.ResetColor();
                this.ujjatekvalaszto = Console.ReadLine(); 
                jatekosKartyak.Clear(); 
                osztoKartyak.Clear();

            } while (this.ujjatekvalaszto == "i" && this.penz>0);
            if (this.penz <= 0 || this.ujjatekvalaszto == "i") 
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Nincs több pénzed, nem tudsz játszani!"); 
                Console.ResetColor();
            }
        }

        public string Kor()
        {
            Kartya pl = new Kartya(Szin.TREFF, Figura.ASZ);
            int Ossz = 0;
            int OsztoOssz = 0;
            string valasz = "";
            foreach (var kartya in jatekosKartyak)
            {
                Ossz += FiguraErtek(kartya);
                if (pl.Figuraja == kartya.Figuraja)
                {
                    AszVan(Ossz);
                }
                
            }
            foreach (var kartya in osztoKartyak)
            {
                OsztoOssz += FiguraErtek(kartya);
                if (pl.Figuraja == kartya.Figuraja)
                {
                    AszVan(OsztoOssz);
                }
            }

            //Kiiratas(Ossz, OsztoOssz);

            if (Ossz == 21)
            {
                if (OsztoOssz == 21)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    return "Döntetlen!";
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    penz += tet * 2;
                    return "Nyertél BlackJack-kel!";             
                }
            }
            else if (Ossz > 21)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                penz -= tet;
                return "Vesztettél!";    
            }
            else if (OsztoOssz > 21)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                penz += 2*tet;
                return "Nyertél, az osztó túllépte a 21-et!";   
            }
            
            
            do
            {
                Console.WriteLine("Szeretnél húzni? (i/n)");
                valasz = Console.ReadLine();
            } while (valasz != "n" && valasz != "i");
            
            if (valasz == "i")
            {
                jatekosKartyak.Add(pakli.Huzas());
                
                if (Ossz > 21)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    penz -= tet;
                    //Kiiratas(Ossz, OsztoOssz);
                    return "Vesztettél!";
                }
                else if (OsztoOssz < 17)
                {
                    osztoKartyak.Add(pakli.Huzas());
                }
            }

            
            if (valasz == "n")
            {
                while (OsztoOssz < 17)
                {
                    osztoKartyak.Add(pakli.Huzas());
                    OsztoOssz = 0;
                    foreach (var kartya in osztoKartyak)
                    {
                        OsztoOssz += FiguraErtek(kartya);
                        Kartya pl2 = new Kartya(Szin.TREFF, Figura.ASZ);
                        if (pl2.Figuraja == kartya.Figuraja)
                        {
                            AszVan(OsztoOssz);
                        }
                    }
                }
                Kiiratas(Ossz, OsztoOssz);
                if (OsztoOssz > 21)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    penz += 2 * tet;
                    return "Nyertél, az osztó túllépte a 21-et!";
                }
                else if (OsztoOssz > Ossz)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    penz -= tet;
                    return "Vesztettél!";
                }
                else if (OsztoOssz < Ossz)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    penz += 2 * tet;
                    return "Nyertél!";
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    return "Döntetlen!";
                }
            }
            Console.WriteLine("A játékos lapjai:\n");
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var kartya in jatekosKartyak)
            {
                Console.WriteLine(kartya);
            }
            Console.ResetColor();
            Console.WriteLine("\nAz osztó lapjai:\n");
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (var kartya in osztoKartyak)
            {
                Console.WriteLine(kartya);
            }
            Console.ResetColor();

            return Kor();
        }

        public int AszVan(int ossz)
        {
            if (ossz > 21)
            {
                ossz -= 10;
            }
            return ossz;
        }
        public int FiguraErtek(Kartya k)
        {
            int ertek = 0;
            if (Convert.ToInt32(k.Figuraja) % 10 == 0)
            {
                ertek = 10;
            }
            else
            {
                ertek = Convert.ToInt32(k.Figuraja);
            }
            return ertek;
        }

        private void Kiiratas(int ossz, int oszto)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"A kártyáid értéke {ossz}.");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Az osztó kártyáinak értéke {oszto}");
            Console.ResetColor();
        }

        public override string ToString()
        {
            return $"{this.penz}";
        }
    }
}

