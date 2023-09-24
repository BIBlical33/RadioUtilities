using Exiled.API.Features;
using Exiled.API.Interfaces;
using System;
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

        private EventHandlers _handlers { get; set; }
        public override void OnEnabled()
        {
            Instance = this;
            _handlers = new EventHandlers(Config);



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

}