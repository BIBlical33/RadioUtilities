using Exiled.Events.EventArgs.Player;

using System.Collections.Generic;

namespace RadioUtilities
{
    public class EventHandlers
    {
        private readonly Config _config;

        private readonly Dictionary<int, string> originalNames = new();

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
                    if (!originalNames.ContainsKey(ev.Player.Id))
                    {
                        originalNames[ev.Player.Id] = ev.Player.CustomName;
                    }

                    ev.Player.CustomName = _config.RadioCustomName;
                }
                else
                {
                    if (originalNames.TryGetValue(ev.Player.Id, out string originalName))
                    {
                        ev.Player.CustomName = originalName;
                        originalNames.Remove(ev.Player.Id);
                    }
                }
            }
        }

        public void OnRoundStarted()
        {
            originalNames.Clear();
        }
    }
}
