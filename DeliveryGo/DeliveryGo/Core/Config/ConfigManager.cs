using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryGo.Core.Config
{
    public class ConfigManager
    {
        private static readonly Lazy<ConfigManager> _instance = new(() => new ConfigManager());
        public static ConfigManager Instance => _instance.Value;
        private ConfigManager()
        {

            EnvioGratisDesde = 50000m;
            IVA = 0.21m;
        }
        public decimal EnvioGratisDesde { get; set; }
        public decimal IVA { get; set; }
    }
}
