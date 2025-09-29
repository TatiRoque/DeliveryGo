using DeliveryGo.Core.Shared.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryGo.Core.Command.Commands;

namespace DeliveryGo.Core.Command.Invokers
{
    public class CartEditor : ICartPort
    {
        public void ExecuteCommand(ICommand command) => command.Execute();
    }
}