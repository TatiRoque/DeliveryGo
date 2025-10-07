using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryGo.Core.Shared.Entities
{
    public class Cart
    {
        private readonly Dictionary<string, Item> _items = new();

        public IReadOnlyCollection<Item> Items => _items.Values;

        public void AddItem(string sku, string name, decimal price, int quantity)
        {
            if (_items.ContainsKey(sku))
                _items[sku].SetQuantity(_items[sku].Quantity + quantity);
            else
                _items[sku] = new Item(sku, name, price, quantity);
        }
        public void RemoveItem(string sku) => _items.Remove(sku);
        public void Clear()
        {
            _items.Clear();
        }
        public void UpdateQuantity(string sku, int quantity)
        {
            if (_items.ContainsKey(sku))
                _items[sku].SetQuantity(quantity);
        }

        public decimal GetTotal() => _items.Values.Sum(i => i.GetTotal());
    }
}
