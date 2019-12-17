using System;
using Katacombs.Inventories;
using Katacombs.Zones;

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
        public Message ZoneOverview()
        {
            return _startingZone.LookAtDirection();
        }

        public Message Look(string option)
        {
            var direction = Enum.Parse<Direction>(option);
            if (direction != Direction.Unknown)
            {
                return _startingZone.LookAtDirection(direction);
            }

            var item = _startingZone.LookAtItem(option);

            if (!String.IsNullOrWhiteSpace(item.ToString()))
            {
                return item;
            }

            return new Message("Nothing interesting to look at there!");
        }

        public Message Open(string door)
        {
            if (!_startingZone.DoesDoorExist(door))
            {
                return new Message("There's no door");
            }

            var doorIsUnlocked = _startingZone.IsDoorUnlocked(door);

            if (doorIsUnlocked)
            {
                return Go(_startingZone.GetDoorDirection(door));
            }

            return new Message("There's no door");
        }

        public Message Go(Direction direction)
        {
            _startingZone = _zoneSwitcher.GetNextZone(_startingZone, direction);
            return ZoneOverview();
        }

        public Message Take(string item)
        {
            var loot = _startingZone.GetItem(item);
            return new Message(loot.GetName()+ ": Taken");
        }
    }
}