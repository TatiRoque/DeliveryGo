using DeliveryGo.Core.Shared.Contracts;
using DeliveryGo.Core.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryGo.Application.Strategy.ShippingStrategies
{
    public class MotorcycleShipping : IShippingStrategy 
    {
        public string Name => "Envío en Moto (rápido en la ciudad)";

        public ShippingType Type => ShippingType.Motorcycle;

        // costo fijo para envío en moto
        public decimal CalculateShippingCost(decimal subtotal)
        {
            return 1200m;
        }
    }
}
