using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryGo.Core.Shared.Entities;
using DeliveryGo.Core.Shared.Contracts;


namespace DeliveryGo.Core.Command.Commands
{
    public class RemoveItemCommand : ICommand
    {
        private readonly Cart _cart;
        private readonly string _sku;

        public RemoveItemCommand(Cart cart, string sku)
        {
            _cart = cart;
            _sku = sku;
        }

        public void Execute() => _cart.RemoveItem(_sku);
    }
}

