using DeliveryGo.Core.Command.Commands;
using DeliveryGo.Core.Shared.Contracts;
using DeliveryGo.Core.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryGo.Core.Command.Invokers
{
    public class CartEditor : ICartPort
    {
        private readonly Cart _cart;
        private readonly Stack<ICommand> _undoStack = new();
        private readonly Stack<ICommand> _redoStack = new();

        public CartEditor(Cart cart)
        {
            _cart = cart;
        }

        public void ExecuteCommand(ICommand command)
        {
            command.Execute(_cart);
            _undoStack.Push(command);
            _redoStack.Clear();
        }

        public void Undo()
        {
            if (_undoStack.Count == 0) return;
            var command = _undoStack.Pop();
            command.ExecuteInverse(_cart);
            _redoStack.Push(command);
        }

        public void Redo()
        {
            if (_redoStack.Count == 0) return;
            var command = _redoStack.Pop();
            command.Execute(_cart);
            _undoStack.Push(command);
        }
    }
}
