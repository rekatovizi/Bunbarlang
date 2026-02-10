using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bunbarlang
{
    internal class Kartya
    {
        private Szin szine;
        private Figura figuraja;


        public Kartya(Szin szine, Figura figuraja)
        {
            this.szine = szine;
            this.figuraja = figuraja;
        }

        internal Szin Szine { get => szine; set => szine = value; }
        internal Figura Figuraja { get => figuraja; set => figuraja = value; }



        public override string ToString()
        {
            return $"{figuraja} of {szine}";
        }
    }
}
