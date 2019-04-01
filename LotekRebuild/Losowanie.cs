using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotekRebuild
{
    class Losowanie
    {
        public int Indeks { get; set; }
        public DateTime Data { get; set; }
        public int[] Wyniki { get; set; } = new int[6];
    }
}
