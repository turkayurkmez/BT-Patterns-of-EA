using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosed
{

    //public enum CardType
    //{
    //    Standart,
    //    Silver,
    //    Gold
    //}

    public abstract class CardType
    {
       public abstract decimal CalcDiscount(decimal price);
        
    }

    public class StandartCard : CardType
    {
        public override decimal CalcDiscount(decimal price)
        {
            return price * .95m;
        }
    }

    public class SilverCard : CardType
    {
        public override decimal CalcDiscount(decimal price)
        {
            return price * .9m;
        }
    }

    public class GoldCard : CardType
    {
        public override decimal CalcDiscount(decimal price)
        {
            return price * .85m;
        }
    }


    public class PlatinumCard : CardType
    {
        public override decimal CalcDiscount(decimal price)
        {
            return price * .8m;
        }
    }



    public class Customer
    {
        public string Name { get; set; }
        public CardType Card { get; set; }

    }


    public class OrderManager
    {
        public Customer Customer { get; set; }
        public decimal GetDiscountedPrice(decimal price)
        {
            //switch (Customer.Card)
            //{
            //    case CardType.Standart:
            //        return price * .95m; ;
            //    case CardType.Silver:
            //        return price * 0.9m;
            //    case CardType.Gold:
            //        return price * 0.85m;
            //    default:
            //        throw new Exception("Geçersiz kart tipi");
            //}

            return Customer.Card.CalcDiscount(price);
        }
    }
}
