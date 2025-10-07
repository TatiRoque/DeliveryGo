using DeliveryGo.Application.Services.Implementations;
using DeliveryGo.Core.Shared.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryGo.Application.Order.Observers
{
    public class LogisticsObserver : IObserver
    {
        public void OnOrderChanged(DeliveryGo.Core.Shared.Entities.Order order)
        {
            Console.WriteLine($"[Logistics] New order created: Id = {order.Id}.");
        }
    }
}
