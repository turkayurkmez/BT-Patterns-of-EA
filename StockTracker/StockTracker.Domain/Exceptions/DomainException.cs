using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.Domain.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException(string message) : base(message)
        {
        }
    }

    public class StockException : DomainException
    {
        public StockException(string message) : base(message)
        {
        }

        public static StockException InsuficcientStock(string name, int quantity)
        {
            return new StockException($"{name} için yeterli stok bulunmamaktadır. Mevcut stok: {quantity}. Talep karşılanamıyor");
        }

        public static StockException NegativeQuantity(string name, int quantity)
        {
          return new StockException($"{name} için negatif miktar girilemez. Girilen miktar: {quantity}");
        }
    }
}
