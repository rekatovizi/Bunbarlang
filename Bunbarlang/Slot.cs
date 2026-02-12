using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bunbarlang
{
    internal class Slot
    {
        int penz = 1000;
        int tet;
        string ujjatekvalaszto;
        string[] tomb = new string[5];

       

        public Slot()
        {
            this.penz = penz;
            this.tet = tet;
            this.tomb = tomb;
            this.ujjatekvalaszto = ujjatekvalaszto;
        }


        public int Penz { get => penz; set => penz = value; }
        public int Tet { get => tet; set => tet = value; }
        public string[] Tomb { get => tomb; set => tomb = value; }
        public string Ujjatekvalaszto { get => ujjatekvalaszto; set => ujjatekvalaszto = value; }

        public void Jatek()
        {
            do
            {
                do
                {
                    if (this.tet == 0)
                    {
                        Console.WriteLine($"Jelenlegi pénzed: {this.penz}");
                        Console.Write("Mennyi tétet szeretnél feltenni: ");

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Érvénytelen összeget adtál meg, kérlek adj meg hivatalos összeget: ");
                        Console.ResetColor();
                    }
                    this.tet = Convert.ToInt32(Console.ReadLine());
                }
                while (this.tet < 0 || this.tet > penz);

                Random rnd = new Random();

                List<string> szimbolumok = new List<string>() { "A", "B", "C", "D", "E", "G", "O", "M" };
                for (int i = 0; i < 5; i++)
                {
                    this.tomb[i] = szimbolumok[rnd.Next(0, szimbolumok.Count)];
                }

                int szamoloa = 0;
                int szamolob = 0;
                int szamoloc = 0;
                int szamolod = 0;
                int szamoloe = 0;
                int szamolog = 0;
                int szamoloo = 0;
                int szamolom = 0;
                foreach (var item in this.tomb)
                {
                    if (item == "A")
                    {
                        szamoloa++;
                    }
                    else if (item == "B")
                    {
                        szamolob++;
                    }
                    else if (item == "C")
                    {
                        szamoloc++;
                    }
                    else if (item == "D") 
                    {
                        szamolod++; 
                    } 
                    else if (item == "E") 
                    {
                        szamoloe++; 
                    } 
                    else if (item == "G") 
                    { 
                        szamolog++; 
                    } 
                    else if (item == "O") 
                    { 
                        szamoloo++; 
                    } 
                    else if (item == "M") 
                    { 
                        szamolom++; 
                    }
                }
                if (szamoloa > 3 || szamolob > 3 || szamoloc > 3 || szamolod > 3 || szamoloe > 3 || szamolog > 3 || szamoloo > 3 || szamolom > 3)
                {
                    Kiiratas();
                    Console.ForegroundColor= ConsoleColor.Cyan;
                    Console.WriteLine("Gratulálok, megnyerted a téted kétszeresét!");
                    Console.ResetColor();
                    this.penz += 2 * this.tet;
                }
                
                
                if (this.tomb[0] == "G" && this.tomb[1] == "O" && this.tomb[2] == "B" && this.tomb[3] == "M" && this.tomb[4] == "A")
                {
                    Kiiratas();
                    Console.ForegroundColor = ConsoleColor.Yellow;  
                    Console.WriteLine("Gratulálok megnyerted a Főnyereményt!!!!");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("GOBMA, a pénzed meg 500 szoroztuk");
                    Console.ResetColor();
                    this.penz *= 500;
                }
       
                else if (szamoloa < 3 && szamolob < 3 && szamoloc < 3 && szamolod < 3 && szamoloe < 3 && szamolog < 3 && szamolom < 3 & szamoloo < 3)
                {
                    Kiiratas();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Vesztettél, a tét kétszeresét elbukad!");
                    Console.ResetColor();
                    this.penz -= 2 * this.tet;
                }
                this.tet = 0;
                if (this.penz <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Vesztettél, nincs több pénzed a folytatáshoz!!");
                    Console.ResetColor();
                    Environment.Exit(0);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Jelenlegi pénzed: {this.penz}");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Szeretnél új játékot indtani(i/n): ");
                    Console.ResetColor();
                    this.ujjatekvalaszto = Console.ReadLine();
                }
            } while (this.ujjatekvalaszto == "i");
            //if (this.penz <= 0)
            //{
            //    Console.ForegroundColor = ConsoleColor.DarkRed;
            //    Console.WriteLine("Vesztettél, nincs több pénzed a folytatáshoz!!");
            //    Console.ResetColor();
            //    Environment.Exit(0);
            //}
        }

        public void Kiiratas() {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("A nyerő szimbólumok: "); 
            Console.ResetColor();
            for (int i = 0; i < 5; i++) 
                  { Console.Write(this.tomb[i] + " "); } 
                  Console.WriteLine(); 
                   }

    }
}
