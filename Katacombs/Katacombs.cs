using System;
using System.Linq;
using Katacombs.Inventories;
using Katacombs.Zones;

namespace Katacombs
{
    public class Katacombs
    {
        private readonly IInventory _inventory;
        private IZone _currentZone;

        public Katacombs(IInventory inventory, IZone startingZone)
        {
            _inventory = inventory;
            _currentZone = startingZone;
        }

        public string[] Action(string command)
        {
            var action = GetActionFromCommand(command);
            if (action == GameAction.Look)
            {
                var direction = GetDirectionFromCommand(command);
                return new []{_currentZone.Look(direction) };
            }

            if (action == GameAction.Open)
            {
                _currentZone = _currentZone.Open(GetOpenedItemFromCommand(command));
                return _currentZone.ZoneOverview();
            }

            return new []{"I don't understand that. English please!" };
        }

        private string GetOpenedItemFromCommand(string command)
        {
            return String.Join(' ', command.Split(" ").Skip(1));
        }

        private Direction GetDirectionFromCommand(string command)
        {
            return Enum.Parse<Direction>(command.Split(" ")[1]);
        }

        private GameAction GetActionFromCommand(string command)
        {
            return Enum.Parse<GameAction>(command.Split(" ")[0]);
        }

        public string[] Start()
        {
            return _currentZone.ZoneOverview();
        }
    }
}
