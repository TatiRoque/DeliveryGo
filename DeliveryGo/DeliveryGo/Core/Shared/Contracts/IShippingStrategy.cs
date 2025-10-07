using DeliveryGo.Core.Shared.Entities;
using DeliveryGo.Core.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryGo.Core.Shared.Contracts
{
    public interface IShippingStrategy
    {
        decimal CalculateShippingCost(decimal subtotal);
        string Name { get; }
        ShippingType Type { get; }
        void Ship(Order order);
    }
}
