using Exiled.Events.EventArgs.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioUtilities
{
    internal class EventHandlers
    {
        public void OnUsingRadioBattery(UsingRadioBatteryEventArgs ev)
        {
            ev.IsAllowed = false;
        }
    
    
    }
}
