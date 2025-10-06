using DeliveryGo.Core.Shared.Entities;
using DeliveryGo.Application.Services.Implementations;
using DeliveryGo.Core.Payment.Factories;
using DeliveryGo.Core.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryGo.Application.Facade
{
    public class CheckoutFacade
    {
        private readonly Cart _cart;
        private readonly OrderService _orderService;
        private readonly ShippingService _shippingService;
        private Order _lastOrder;

        public CheckoutFacade(Cart cart, OrderService orderService, ShippingService shippingService)
        {
            _cart = cart ?? throw new ArgumentNullException(nameof(cart));
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
            _shippingService = shippingService ?? throw new ArgumentNullException(nameof(shippingService));
        }

        public bool Checkout(PaymentType paymentType, ShippingType shippingType)
        {
            if (_cart.Items.Count == 0)
                return false;

            decimal total = _cart.GetTotal();
            var payment = PaymentFactory.CreatePayment(paymentType);
            bool paymentSuccess = payment.Pay(total);
            if (!paymentSuccess) return false;

            _shippingService.ApplyShippingStrategy(shippingType, _cart);
            _lastOrder = _orderService.CreateOrder(_cart);
            _cart.Clear();
            return true;
        }

        public void Undo() => _orderService.Undo();
        public void Redo() => _orderService.Redo();
        public Order GetLastOrder() => _lastOrder;
    }
}
