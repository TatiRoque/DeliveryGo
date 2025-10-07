using DeliveryGo.Core.Shared.Entities;
using DeliveryGo.Core.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryGo.Application.Order.Builders
{
    public class OrderBuilder
    {
        private Cart _cart;

        public OrderBuilder WithCart(Cart cart)
        {
            _cart = cart;
            return this;
        }

        public DeliveryGo.Core.Shared.Entities.Order Build()
        {
            if (_cart == null)
                throw new InvalidOperationException("Cart must be provided to build an order.");

            return new DeliveryGo.Core.Shared.Entities.Order(_cart);
        }
    }
}
