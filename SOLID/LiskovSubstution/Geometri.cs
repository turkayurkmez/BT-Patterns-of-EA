using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstution
{
    public class Geometri
    {
        public int Alan(IAlanHesapla sekil)
        {
            return sekil.AlanHesapla();
        }
    }
}
