using DeliveryGo.Core.Shared.Contracts;
using DeliveryGo.Core.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryGo.Application.Strategy.ShippingStrategies
{
    public class MailShipping : IShippingStrategy
    {
        public string Name => "Correo (a todo el país)";

        public ShippingType Type => ShippingType.Mail;

        // envío gratis si supera $50.000, si no cuesta $3.500
        public decimal CalculateShippingCost(decimal subtotal)
        {
            return subtotal >= 50000m ? 0m : 3500m;
        }
    }
}
