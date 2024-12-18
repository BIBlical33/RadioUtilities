using Exiled.Events.EventArgs.Player;
using System.Collections.Generic;

namespace RadioUtilities
{
    public class EventHandlers
    {
        private readonly Config _config;

        // Хранение оригинальных имен игроков
        private readonly Dictionary<string, string> originalNames = new();

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
                    // Сохраняем оригинальное имя игрока, если оно еще не сохранено
                    if (!originalNames.ContainsKey(ev.Player.UserId))
                    {
                        originalNames[ev.Player.UserId] = ev.Player.Nickname;
                    }

                    // Устанавливаем кастомное имя
                    ev.Player.CustomName = _config.RadioCustomName;
                }
                else
                {
                    // Восстанавливаем оригинальное имя, если оно было сохранено
                    if (originalNames.TryGetValue(ev.Player.UserId, out string originalName))
                    {
                        ev.Player.CustomName = originalName; // Восстанавливаем оригинальное имя
                        originalNames.Remove(ev.Player.UserId); // Удаляем из словаря
                    }
                }
            }
        }
    }
}
