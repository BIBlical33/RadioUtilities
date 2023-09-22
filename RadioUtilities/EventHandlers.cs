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

        // Should work! I'm unable to test it now :/
        public void OnTransmitting(TransmittingEventArgs ev)
        {
            if (MainPlugin.Instance.Config.IsUnknownTransmittingEnabled)
            {
                
            }
            
            if (ev.Player.IsTransmitting)
            {
                ev.Player.CustomName = "Mhz.110";
            }
            else
            {
                ev.Player.CustomName = null;
            }
        }
    }
}
