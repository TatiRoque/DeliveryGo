using DeliveryGo.Core.Config;
using DeliveryGo.Core.Shared.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryGo.Core.Payment.Decorators
{
    public class TaxDecorator :IPayment
    {
        private readonly IPayment _innerPayment;

        public string Name => _innerPayment.Name + " + Tax";

        public TaxDecorator(IPayment innerPayment)
        {
            _innerPayment = innerPayment;
        }

        public bool ProcessPayment(decimal amount)
        {
            decimal amountWithTax = amount * (1 + ConfigManager.Instance.IVA);
            return _innerPayment.ProcessPayment(amountWithTax);
        }
    }
}
