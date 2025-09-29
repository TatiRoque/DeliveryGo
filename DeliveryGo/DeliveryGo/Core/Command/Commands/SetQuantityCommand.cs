using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryGo.Core.Shared.Entities;
using DeliveryGo.Core.Shared.Contracts;


namespace DeliveryGo.Core.Command.Commands
{
    public class SetQuantityCommand : ICommand
    {
        private readonly Cart _cart;
        private readonly string _sku;
        private readonly int _quantity;

        public SetQuantityCommand(Cart cart, string sku, int quantity)
        {
            _cart = cart;
            _sku = sku;
            _quantity = quantity;
        }

        public void Execute() => _cart.UpdateQuantity(_sku, _quantity);
    }
}

