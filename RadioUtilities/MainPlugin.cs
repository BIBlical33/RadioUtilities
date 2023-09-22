
using Exiled.API.Features;
using Exiled.API.Interfaces;
using Exiled.Events;

namespace RadioUtilities
{
    public class MainPlugin : Plugin<Config>
    {
        public override void OnEnabled()
        {
            EventHandlers eventHandlers = new EventHandlers();

            Exiled.Events.Handlers.Player.UsingRadioBattery += eventHandlers.OnUsingRadioBattery;
        }
        public override void OnDisabled()
        {
            EventHandlers eventHandlers = new EventHandlers();

            Exiled.Events.Handlers.Player.UsingRadioBattery -= eventHandlers.OnUsingRadioBattery;
        }

    }
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;
    }
}   