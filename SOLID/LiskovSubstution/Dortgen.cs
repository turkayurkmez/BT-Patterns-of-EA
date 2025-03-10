using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstution
{

    public interface IAlanHesapla
    {
        int AlanHesapla();
    }

    public class Dortgen : IAlanHesapla
    {
        public virtual int En { get; set; }
        public virtual int Boy { get; set; }

        public int AlanHesapla()
        {
            return En * Boy;
        }
    }

    public class Kare :IAlanHesapla //: Dortgen
    {

        public int KenarUzunlugu { get; set; }

        public int AlanHesapla()
        {
           return KenarUzunlugu * KenarUzunlugu;
        }


        //public override int Boy { get => base.Boy; set { base.Boy = value; base.En = value; } }
        //public override int En { get => base.En; set { base.En = value; base.Boy = value; } }

    }
}
