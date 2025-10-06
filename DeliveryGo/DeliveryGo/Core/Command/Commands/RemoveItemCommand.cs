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
        private readonly string _sku;
        private Item _removedItem;

        public RemoveItemCommand(string sku)
        {
            _sku = sku;
        }

        public void Execute(Cart cart)
        {
            foreach (var item in cart.Items)
            {
                if (item.Sku == _sku)
                {
                    _removedItem = item;
                    break;
                }
            }
            cart.RemoveItem(_sku);
        }

        public void ExecuteInverse(Cart cart)
        {
            if (_removedItem != null)
            {
                cart.AddItem(_removedItem.Sku, _removedItem.Name, _removedItem.Price, _removedItem.Quantity);
            }
        }
    }
}