using System.Collections.Generic;
using Katacombs.Inventories;

namespace Katacombs.Zones
{
    public class ZoneConfiguration : IZoneConfiguration, IMutableZoneConfiguration
    {
        private const string NothingInterestingToLookAtThere = "Nothing interesting to look at there!";
        private readonly ZoneDoors _zoneDoors;
        private Dictionary<Direction, Message> _looks;
        private string _zoneName;


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
            return _zoneDoors.GetDoorDirection(door);
        }

        public string GetZoneName()
        {
            return _zoneName;
        }

        public Item GetItem(string itemName)
        {
            if (itemName != "White Key")
                return null;
            return new Item(itemName);
        }

        public void AddDoor(Door door)
        {
            _zoneDoors.Add(door);
        }

        public void AddLook(Direction direction, Message text)
        {
            _looks.Add(direction, text);
        }

        public void SetName(string zoneName)
        {
            _zoneName = zoneName;
        }
    }
}