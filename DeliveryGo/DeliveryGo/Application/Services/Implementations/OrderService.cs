using DeliveryGo.Application.Order.Builders;
using DeliveryGo.Core.Command.Commands;
using DeliveryGo.Core.Shared.Contracts;
using DeliveryGo.Core.Shared.Entities;
using DeliveryGo.Core.Shared.Enums;
using System;
using System.Collections.Generic;

namespace DeliveryGo.Application.Services.Implementations
{
    public class OrderService
    {
        private readonly Stack<ICommand> undoStack = new();
        private readonly Stack<ICommand> redoStack = new();
        private readonly List<DeliveryGo.Core.Shared.Entities.Order> orders = new();
        private readonly List<IObserver> observers = new();

        public void Subscribe(IObserver observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);
        }

        public void Unsubscribe(IObserver observer)
        {
            if (observers.Contains(observer))
                observers.Remove(observer);
        }

        private void NotifyObservers(DeliveryGo.Core.Shared.Entities.Order order)
        {
            foreach (var observer in observers)
            {
                observer.OnOrderChanged(order);
            }
        }
        public DeliveryGo.Core.Shared.Entities.Order CreateOrder(Cart cart)
        {
            var builder = new OrderBuilder().WithCart(cart);
            var order = builder.Build();
            orders.Add(order);
            undoStack.Clear();
            redoStack.Clear();
            NotifyObservers(order);
            return order;
        }

        public void ExecuteCommand(ICommand command, Cart cart)
        {
            command.Execute(cart);
            undoStack.Push(command);
            redoStack.Clear();
        }

        public void Undo(Cart cart)
        {
            if (undoStack.Count == 0) return;
            var command = undoStack.Pop();
            command.ExecuteInverse(cart);
            redoStack.Push(command);
        }

        public void Redo(Cart cart)
        {
            if (redoStack.Count == 0) return;
            var command = redoStack.Pop();
            command.Execute(cart);
            undoStack.Push(command);
        }
        public IReadOnlyList<DeliveryGo.Core.Shared.Entities.Order> GetOrders() => orders.AsReadOnly();
    }
}
