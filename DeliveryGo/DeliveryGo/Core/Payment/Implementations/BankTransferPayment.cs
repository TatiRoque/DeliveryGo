using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryGo.Core.Shared.Contracts;

namespace DeliveryGo.Core.Payment.Implementations
{
    public class BankTransferPayment : IPayment
    {
        public string Name => "Bank Transfer";

        public bool ProcessPayment(decimal amount)
        {
            if (amount <= 0)
                return false;

            if (amount > 1000)
            {
                return true;
                Console.WriteLine("[TransferPayment] Please forward the payment proof to the seller. ");
            }

            Console.WriteLine($"[TransferPayment] Processed bank transfer of ${amount}");
            return true;
        }
    }
}
