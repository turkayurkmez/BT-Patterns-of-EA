using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.EventBus
{
    /*
     * 1. Sipariş oluşturulur.
     * 2. Stok kontrolü yapılır.
     * 3. Yeterli stok varsa, ödeme mikroservisine yönlendirilir.
     * 4. Yeterli stok yoksa, olay order mikroservisine gönderilir.
     * 
     * 
     * Aşağıdaki olaylar, stok mikroservisinden fırlatılacak olaylardır.
     */
    public record StockAvailableEvent (StockAvailabeCommand Command): IntegrationEvent;

    public record StockAvailabeCommand(int OrderId, string CustomerId, string CreditCardInfo, decimal TotalPrice);

    public record StockNotAvailableEvent(StockNotAvailableCommand Command) : IntegrationEvent;

    public record StockNotAvailableCommand(int OrderId);


    public record ProductStockIncreasedEvent(ProductStockIncreasedCommand Command) : IntegrationEvent;

    public record ProductStockIncreasedCommand(Guid ProductId, int Quantity);


}
