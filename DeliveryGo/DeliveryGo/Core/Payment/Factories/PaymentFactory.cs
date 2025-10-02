using DeliveryGo.Core.Payment.Implementations;
using DeliveryGo.Core.Shared.Contracts;
using System;
using System.Collections.Generic;
using System.Linq; 
using System.Text;
using System.Threading.Tasks;

namespace DeliveryGo.Core.Payment.Factories
{
    public class PaymentFactory 
    {
        public static IPayment Create(string type)
        {
            return type.ToLower() switch
            {
                "creditcard" => new CardPayment(),
                "banktransfer" => new BankTransferPayment(),
                "mp" => new MpPayment(),
                _ => throw new ArgumentException("Invalid payment type")
            };
        }
    }
}
