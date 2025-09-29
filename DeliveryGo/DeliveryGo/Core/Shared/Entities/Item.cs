using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryGo.Core.Shared.Entities
{
    public class Item
    {
        public string Sku { get; }
        public string Name { get; }
        public decimal Price { get; }
        public int Quantity { get; private set; }

        public Item(string sku, string name, decimal price, int quantity)
        {
            Sku = sku;
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public void SetQuantity(int quantity) => Quantity = quantity;
        public decimal GetTotal() => Price * Quantity;
    }

}

