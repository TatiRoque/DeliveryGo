using DeliveryGo.Core.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryGo.Core.Shared.Contracts
{
    public interface ICommand
    {
        void Execute(Cart cart);        // Aplica la acción
        void ExecuteInverse(Cart cart); // Deshace la acción

    }
}
