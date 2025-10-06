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
        private readonly int _newQuantity;
        private int _previousQuantity;

        public SetQuantityCommand(string sku, int newQuantity)
        {
            _sku = sku;
            _newQuantity = newQuantity;
        }

        public void Execute(Cart cart)
        {
            foreach (var item in cart.Items)
            {
                if (item.Sku == _sku)
                {
                    _previousQuantity = item.Quantity;
                    item.SetQuantity(_newQuantity);
                    break;
                }
            }
        }

        public void ExecuteInverse(Cart cart)
        {
            foreach (var item in cart.Items)
            {
                if (item.Sku == _sku)
                {
                    item.SetQuantity(_previousQuantity);
                    break;
                }
            }
        }
    }
}

