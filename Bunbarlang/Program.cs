using System.Runtime.CompilerServices;

namespace Bunbarlang
{
    internal class Program
    {
        
        static void Main(string[] args)
        {

            menü();
        }
        public static void menü()
        {
            string valasztas;
            Console.WriteLine("1. BlackJack\n2. Lovasverseny\n3. Slot\n4. Kijárat");
            valasztas = Console.ReadLine();
            switch (valasztas) 
            { 
                case "1": 
                    BlackJack game = new BlackJack(1000, 100); 
                    game.Jatek(); 
                    break; 
                case "2": 
                    LoversenyOOP loverseny = new LoversenyOOP(100, 1000); 
                    loverseny.Jatek(); 
                    break; 
                case "3": 
                    Slot slot = new Slot(); 
                    slot.Jatek(); 
                    break; 
                case "4": 
                    Environment.Exit(0); 
                    break; 
                default: 
                    Console.WriteLine("Hibás választás! Kérem válasszon egy helyes értéket!"); 
                    menü(); 
                    break; 
            }


        }
    }
}
