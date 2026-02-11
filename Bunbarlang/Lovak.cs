using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bunbarlang
{
    internal class Lovak
    {
        private string nev;
        private int gyorsasag;
        private string szin;

        public Lovak(string nev, int gyorsasag, string szin)
        {
            this.nev = nev;
            this.gyorsasag = gyorsasag;
            this.szin = szin;
        }

        public string Nev { get => nev; set => nev = value; }
        public int Gyorsasag { get => gyorsasag; set => gyorsasag = value; }
        public string Szin { get => szin; set => szin = value; }

        public void LoEro()
        {
            Random rnd = new Random();
            this.gyorsasag += rnd.Next(1, 10);
        }
    }
}
