using System;

namespace Katacombs.Player
{
    public class StartingPlayer : IPlayer
    {
        private IZoneConfiguration _startingZone;

        public StartingPlayer(IZoneConfiguration startingZone)
        {
            _startingZone = startingZone;
        }
        public string[] ZoneOverview()
        {
            return _startingZone.LookAtDirection();
        }

        public string Look(string option)
        {
            var direction = Enum.Parse<Direction>(option);
            if (direction != Direction.Unknown)
            {
                return _startingZone.LookAtDirection(direction)[0];
            }

            var item = _startingZone.LookAtItem(option);

            if (!String.IsNullOrWhiteSpace(item))
            {
                return item;
            }

            return "Nothing interesting to look at there!";
        }

        public string[] Open(string door)
        {
            throw new System.NotImplementedException();
        }
    }
}