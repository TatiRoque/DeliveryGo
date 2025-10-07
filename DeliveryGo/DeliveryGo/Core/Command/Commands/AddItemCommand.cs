using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryGo.Core.Shared.Entities;
using DeliveryGo.Core.Shared.Contracts;

namespace DeliveryGo.Core.Command.Commands
{
    public class AddItemCommand : ICommand
    {
        private readonly Cart _cart;
        private readonly string _sku;
        private readonly string _name;
        private readonly decimal _price;
        private readonly int _quantity;
        public AddItemCommand(Cart cart, string sku, string name, decimal price, int quantity)
        {
            _cart = cart ?? throw new ArgumentNullException(nameof(cart));
            _sku = sku;
            _name = name;
            _price = price;
            _quantity = quantity;
        }
        public void Execute(Cart cart)
        {
            cart.AddItem(_sku, _name, _price, _quantity);
        }
        public void ExecuteInverse(Cart cart)
        {
            cart.RemoveItem(_sku);
        }
    }
}

