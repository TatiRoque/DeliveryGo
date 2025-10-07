using DeliveryGo.Application.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryGo.Core.Shared.Contracts
{
    public interface IObserver
    {
        void OnOrderChanged(DeliveryGo.Core.Shared.Entities.Order order);
    }
}
