using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.EventBus
{
   public record OrderCreatedEvent(OrderCreatedCommand Command) : IntegrationEvent;

    public record OrderCreatedCommand(int OrderId, string CustomerId, string CreditCardInfo, IEnumerable<OrderItem> OrderItems);

    public record OrderItem(int ProductId, int Quantity, decimal Price);
}
