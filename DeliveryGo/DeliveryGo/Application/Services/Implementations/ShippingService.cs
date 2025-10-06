using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryGo.Core.Shared.Contracts;

namespace DeliveryGo.Application.Services.Implementations
{
    public class ShippingService : IShippingService
    {
        // Referencia a la estrategia actual
        private IShippingStrategy _currentStrategy;

        // Constructor: recibe la estrategia inicial
        public ShippingService(IShippingStrategy initialStrategy)
        {
            _currentStrategy = initialStrategy ?? throw new ArgumentNullException(nameof(initialStrategy));
        }

        // Calcula el costo delegando en la estrategia actual
        public decimal CalculateShippingCost(decimal subtotal)
        {
            return _currentStrategy.CalculateShippingCost(subtotal);
        }

        // Cambia la estrategia en runtime
        public void SetShippingStrategy(IShippingStrategy strategy)
        {
            _currentStrategy = strategy ?? throw new ArgumentNullException(nameof(strategy));
            Console.WriteLine($"[ShippingService] Estrategia cambiada a: {_currentStrategy.Name}");
        }

        // Devuelve el nombre de la estrategia actual
        public string GetCurrentStrategyName()
        {
            return _currentStrategy.Name;
        }
    }
}