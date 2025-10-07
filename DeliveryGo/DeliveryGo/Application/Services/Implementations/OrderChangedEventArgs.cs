using DeliveryGo.Core.Shared.Enums;
using System;

namespace DeliveryGo.Application.Services.Implementations
{
    public class OrderChangedEventArgs
    {
        public Guid OrderId { get; }
        public DateTime When { get; }

        public OrderChangedEventArgs(Guid orderId, DateTime when)
            => (OrderId, When) = (orderId, when);
    }
}
