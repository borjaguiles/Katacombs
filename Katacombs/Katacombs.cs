using System;
using System.Linq;

namespace Katacombs
{
    public class Katacombs
    {
        private readonly IInventory _inventory;
        private IZone _startingZone;

        public Katacombs(IInventory inventory, IZone startingZone)
        {
            _inventory = inventory;
            _startingZone = startingZone;
        }

        public string[] Action(string command)
        {
            var action = GetActionFromCommand(command);
            if (action == GameAction.Look)
            {
                var direction = GetDirectionFromCommand(command);
                return new []{_startingZone.Look(direction) };
            }

            return new []{"I don't understand that. English please!" };
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
            return _startingZone.ZoneOverview();
        }
    }
}
