using Exiled.API.Features;
using Exiled.API.Interfaces;
using System.ComponentModel;
using Player = Exiled.Events.Handlers.Player;

namespace RadioUtilities
{
    public class MainPlugin : Plugin<Config>
    {
        public override string Author => "BuildBoy12-SL";

        public override string Name => "RadioUtilities";

        public override string Prefix => Name;

        public static MainPlugin Instance;

        private EventHandlers _handlers;

        public override void OnEnabled()
        {
            Instance = this;

            _handlers = new EventHandlers();


            Player.UsingRadioBattery += _handlers.OnUsingRadioBattery;
            Player.Transmitting += _handlers.OnTransmitting;


            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            Player.UsingRadioBattery -= _handlers.OnUsingRadioBattery;
            Player.Transmitting -= _handlers.OnTransmitting;

            _handlers = null;

            base.OnDisabled();
        }

    }
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        public bool Debug { get; set; } = false;

        public bool IsInfinityBatteryEnabled { get; set; } = true;

        public bool IsUnknownTransmittingEnabled { get; set; } = true;

        public string RadioCustomName { get; set; } = "Mhz.110";
    }
}