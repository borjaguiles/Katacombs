using System;

namespace Katacombs.Player
{
    public class StartingPlayer : IPlayer
    {
        private IZoneConfiguration _startingZone;
        private IZoneSwitcher _zoneSwitcher;

        public StartingPlayer(IZoneConfiguration startingZone, IZoneSwitcher zoneSwitcher)
        {
            _startingZone = startingZone;
            _zoneSwitcher = zoneSwitcher;
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
            if (!_startingZone.DoesDoorExist(door))
            {
                return new[] { "There's no door" };
            }

            var doorIsUnlocked = _startingZone.IsDoorUnlocked(door);
            if (doorIsUnlocked)
            {
                return Go(_startingZone.GetDoorDirection(door));
            }

            return new []{"There's no door"};
        }

        public string[] Go(Direction direction)
        {
            _startingZone = _zoneSwitcher.GetNextZone(_startingZone, direction);
            return this.ZoneOverview();
        }
    }
}