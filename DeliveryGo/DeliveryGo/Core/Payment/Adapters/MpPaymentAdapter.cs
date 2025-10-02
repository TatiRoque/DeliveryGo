using DeliveryGo.Core.Shared.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryGo.Core.Payment.Adapters
{
    public class MpPaymentAdapter : IPayment
    {
        private readonly FakeMpSdk _sdk;

        public MpPaymentAdapter(FakeMpSdk sdk)
        {
            _sdk = sdk;
        }
        public string Name => "MercadoPago (Adapter)";
        public bool ProcessPayment(decimal amount)
        {
            return _sdk.Charge(amount);
        }
    }
}
