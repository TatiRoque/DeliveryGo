using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryGo.Core.Payment.Adapters
{
    public class FakeMpSdk
    {
        public bool Charge(decimal amount)
        {
            if (amount <= 0) return false;
            return true;
        }
    }
}
