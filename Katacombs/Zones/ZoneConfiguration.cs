using System.Collections.Generic;

namespace Katacombs.Zones
{
    public class ZoneConfiguration : IZoneConfiguration, IMutableZoneConfiguration
    {
        private const string NothingInterestingToLookAtThere = "Nothing interesting to look at there!";
        private readonly ZoneDoors _zoneDoors;
        private string[] _zoneDescription;
        private Dictionary<Direction, string> _looks;


        public ZoneConfiguration()
        {
            _looks = new Dictionary<Direction, string>();
            _zoneDoors = new ZoneDoors();
        }

        public string[] LookAtDirection(Direction direction = Direction.Unknown)
        {
            if (direction != Direction.Unknown)
            {
                return new[] { _looks.ContainsKey(direction) ? _looks[direction] :  NothingInterestingToLookAtThere };
            }
            return _zoneDescription;
        }

        public string LookAtItem(string item)
        {
            throw new System.NotImplementedException();
        }

        public bool IsDoorUnlocked(string doorName)
        {
            return _zoneDoors.IsDoorUnlocked(doorName);
        }

        public bool DoesDoorExist(string doorName)
        {
            return _zoneDoors.DoesDoorExist(doorName);
        }

        public Direction GetDoorDirection(string door)
        {
            throw new System.NotImplementedException();
        }

        public void AddDoor(Door door)
        {
            _zoneDoors.Add(door);
        }

        public void AddLook(Direction direction, string[] text)
        {
            if (direction == Direction.Unknown)
            {
                _zoneDescription = text;
                return;
            }
            
            _looks.Add(direction, text[0]);

        }
    }
}