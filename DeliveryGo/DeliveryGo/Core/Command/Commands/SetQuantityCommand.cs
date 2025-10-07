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
        private readonly string _sku;
        private readonly int _quantity;
        private int _previousQuantity;

        public SetQuantityCommand(string sku, int quantity)
        {
            _sku = sku;
            _quantity = quantity;
        }

        public void Execute(Cart cart)
        {
            var item = cart.Items.FirstOrDefault(i => i.Sku == _sku);
            if (item != null)
            {
                _previousQuantity = item.Quantity;
                cart.UpdateQuantity(_sku, _quantity);
            }
        }

        public void ExecuteInverse(Cart cart)
        {
            cart.UpdateQuantity(_sku, _previousQuantity);
        }
    }
}

