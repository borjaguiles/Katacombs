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

        public Message Action(string command)
        {
            var action = GetActionFromCommand(command);
            if (action == GameAction.Look)
            {
                var direction = GetActionOptionFromCommand(command);
                return _player.Look(direction);
            }

            if (action == GameAction.Open)
            {
                return _player.Open(GetActionOptionFromCommand(command));
            }

            if (action == GameAction.Take)
            {
                return _player.Take(GetActionOptionFromCommand(command));
            }

            if (action == GameAction.Bag)
            {
                return _player.Bag();
            }

            if (action == GameAction.Go)
            {
                return _player.Go(GetDirectionFromCommand(command));
            }

            throw new NotImplementedException();
        }

        private string GetActionOptionFromCommand(string command)
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

        public Message Start()
        {
            return _player.ZoneOverview();
        }
    }
}
