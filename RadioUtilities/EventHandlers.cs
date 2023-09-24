using Exiled.Events.EventArgs.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioUtilities
{
    public class EventHandlers
    {
        private readonly Config _config;
        public EventHandlers(Config config) => _config = config;
        

        public void OnUsingRadioBattery(UsingRadioBatteryEventArgs ev)
        {
            if (_config.IsInfinityBatteryEnabled)
            {
                ev.IsAllowed = false;
            }
        }

        public void OnTransmitting(TransmittingEventArgs ev)
        {
            if (_config.IsUnknownTransmittingEnabled)
            {
                if (ev.Player.IsTransmitting)
                {
                    ev.Player.CustomName = _config.RadioCustomName;
                }
                else
                {
                    ev.Player.CustomName = null;
                }
            }
        }
    }
}
