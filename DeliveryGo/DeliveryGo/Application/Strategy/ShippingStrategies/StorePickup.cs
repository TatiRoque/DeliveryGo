using DeliveryGo.Core.Shared.Contracts;
using DeliveryGo.Core.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryGo.Application.Strategy.ShippingStrategies
{
    public class StorePickup : IShippingStrategy
    {
        public string Name => "Retiro en Tienda (sin costo)";

        public ShippingType Type => ShippingType.StorePickup;

        // Retirar en tienda siempre es gratis
        public decimal CalculateShippingCost(decimal subtotal)
        {
            return 0m;
        }
        public void Ship(DeliveryGo.Core.Shared.Entities.Order order)
        {
            Console.WriteLine($"Order {order.Id} is ready for pickup in store.");
        }
    }
}
