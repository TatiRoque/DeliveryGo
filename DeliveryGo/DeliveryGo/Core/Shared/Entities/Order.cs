using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using DeliveryGo.Core.Shared.Enums;

namespace DeliveryGo.Core.Shared.Entities
{
    public class Order
    {
        public Guid Id { get; private set; }
        public List<CartItem> Items { get; private set; }
        public decimal TotalAmount { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public OrderStatus Status { get; private set; }

        public Order(List<CartItem> items, decimal totalAmount)
        {
            Id = Guid.NewGuid();
            Items = new List<CartItem>(items);
            TotalAmount = totalAmount;
            CreatedAt = DateTime.UtcNow;
            Status = OrderStatus.Pending; // 👈 Enum en vez de string
        }

        public void UpdateStatus(OrderStatus newStatus)
        {
            // Más adelante podés agregar validaciones de transición de estados
            Status = newStatus;
        }
    }
}
