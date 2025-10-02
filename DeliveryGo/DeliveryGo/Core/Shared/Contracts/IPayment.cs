using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryGo.Core.Shared.Contracts
{
    public interface IPayment
    {
        bool ProcessPayment(decimal amount);
        string Name { get; }

    }
}
