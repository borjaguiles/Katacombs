using System;
using System.Linq;
using Katacombs.Player;

namespace Katacombs
{
    public class Katacombs
    {
        private IPlayer _player;

        public Katacombs(IPlayer startingPlayer)
        {
            _player = startingPlayer;
        }

        public string[] Action(string command)
        {
            var action = GetActionFromCommand(command);
            if (action == GameAction.Look)
            {
                var direction = GetDirectionFromCommand(command);
                return new []{_player.Look(direction) };
            }

            if (action == GameAction.Open)
            {
                return _player.Open(GetOpenedItemFromCommand(command));
            }

            return new []{"I don't understand that. English please!" };
        }

        private string GetOpenedItemFromCommand(string command)
        {
            return String.Join(' ', command.Split(" ").Skip(1));
        }

        private string GetDirectionFromCommand(string command)
        {
            return command.Split(" ")[1];
        }

        private GameAction GetActionFromCommand(string command)
        {
            return Enum.Parse<GameAction>(command.Split(" ")[0]);
        }

        public string[] Start()
        {
            return _player.ZoneOverview();
        }
    }
}
