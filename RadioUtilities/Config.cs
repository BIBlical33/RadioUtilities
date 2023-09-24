using Exiled.API.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioUtilities
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        public bool Debug { get; set; } = false;

        [Description("Gives infinity radio battery")]
        public bool IsInfinityBatteryEnabled { get; set; } = true;
        
        [Description("Hide player names when using radio")]
        public bool IsUnknownTransmittingEnabled { get; set; } = true;
        
        [Description("Text to replace player names on the radio")]
        public string RadioCustomName { get; set; } = "Mhz.110";
    }
}
