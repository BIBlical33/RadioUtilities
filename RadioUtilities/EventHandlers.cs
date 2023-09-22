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
        Config config = new Config();
        public void OnUsingRadioBattery(UsingRadioBatteryEventArgs ev)
        {
            if (config.IsInfinityBatteryEnabled)
            {
                ev.IsAllowed = false;
            }
        }

        public void OnTransmitting(TransmittingEventArgs ev)
        {
            if (config.IsUnknownTransmittingEnabled)
            {
                if (ev.Player.IsTransmitting)
                {
                    ev.Player.CustomName = config.RadioCustomName;
                }
                else
                {
                    ev.Player.CustomName = null;
                }
            }
        }
    }
}
