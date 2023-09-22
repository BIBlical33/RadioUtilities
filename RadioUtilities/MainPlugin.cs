using System.ComponentModel;
using Exiled.API.Features;
using Exiled.API.Interfaces;
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

        [Description("Enable or disable Unknown Transmitting (Basically when you transmit it shows Unknown instead of your Nick)")]
        public bool IsUnknownTransmittingEnabled { get; set; } = true;
    }
}   