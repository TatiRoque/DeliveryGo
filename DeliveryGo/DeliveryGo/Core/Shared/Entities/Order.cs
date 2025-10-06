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
        public Cart Cart { get; private set; }
        public decimal TotalAmount { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public OrderStatus Status { get; private set; }

        public Order(Cart cart)
        {
            Id = Guid.NewGuid();
            Cart = cart ?? throw new ArgumentNullException(nameof(cart));
            TotalAmount = cart.GetTotal(); // Calcula el total usando Cart
            CreatedAt = DateTime.UtcNow;
            Status = OrderStatus.Pending;
        }

        public void UpdateStatus(OrderStatus newStatus)
        {
            Status = newStatus;
        }
    }
}