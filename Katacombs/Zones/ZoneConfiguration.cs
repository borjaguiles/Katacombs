using System.Collections.Generic;

namespace Katacombs.Zones
{
    public class ZoneConfiguration : IZoneConfiguration, IMutableZoneConfiguration
    {
        private const string NothingInterestingToLookAtThere = "Nothing interesting to look at there!";
        private readonly ZoneDoors _zoneDoors;
        private Dictionary<Direction, Message> _looks;


        public ZoneConfiguration()
        {
            _looks = new Dictionary<Direction, Message>();
            _zoneDoors = new ZoneDoors();
        }

        public Message LookAtDirection(Direction direction = Direction.Unknown)
        {
            if (_looks.ContainsKey(direction))
            {
                return _looks[direction];
            }

            return new Message(NothingInterestingToLookAtThere);
        }

        public Message LookAtItem(string item)
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

        public void AddLook(Direction direction, Message text)
        {
            _looks.Add(direction, text);
        }
    }
}