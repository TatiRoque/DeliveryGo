using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryGo.Core.Shared.Contracts;

namespace DeliveryGo.Core.Shared.Contracts
{
    public interface IShippingService
    {
        // Calcula el costo de envío usando la estrategia actual
        decimal CalculateShippingCost(decimal subtotal);

        // Permite cambiar la estrategia en tiempo de ejecución
        void SetShippingStrategy(IShippingStrategy strategy);

        // Obtiene el nombre de la estrategia actual (para mostrar al usuario)
        string GetCurrentStrategyName();
    }
}
