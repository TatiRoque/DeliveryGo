using DeliveryGo.Core.Command.Commands;
using DeliveryGo.Core.Shared.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryGo.Core.Shared.Contracts;

namespace DeliveryGo.Application.Services.Implementations
{
    public class OrderService
    {
        private readonly Stack<ICommand> undoStack = new();
        private readonly Stack<ICommand> redoStack = new();
        private readonly List<DeliveryGo.Core.Shared.Entities.Order> orders = new();

        public DeliveryGo.Core.Shared.Entities.Order CreateOrder(Cart cart)
        {
            var order = new DeliveryGo.Core.Shared.Entities.Order(cart);
            orders.Add(order);
            undoStack.Clear();
            redoStack.Clear();
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