using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryGo.Core.Shared.Contracts;

namespace DeliveryGo.Core.Payment.Implementations
{
    public class CardPayment : IPayment
    {
        public string Name => "Credit Card";

        public bool ProcessPayment(decimal amount)
        {
            if (amount <= 0)
                return false;

            Console.WriteLine($"[CardPayment] Processed credit card payment of ${amount}");
            return true;
        }
    }
}
