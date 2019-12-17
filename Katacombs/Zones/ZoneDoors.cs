using System.Collections.Generic;
using System.Linq;

namespace Katacombs.Zones
{
    public class ZoneDoors
    {
        private readonly List<Door> _doors;

        public ZoneDoors()
        {
            _doors = new List<Door>();
        }

        public void Add(Door door)
        {
            _doors.Add(door);
        }

        public bool IsDoorUnlocked(string doorName)
        {
            return _doors.Any(door => door.NameIs(doorName) && door.IsUnlocked());
        }

        public bool DoesDoorExist(string doorName)
        {
            return _doors.Any(door => door.NameIs(doorName));
        }

        public Direction GetDoorDirection(string doorName)
        {
            var door = _doors.FirstOrDefault(gate => gate.NameIs(doorName));
            if (door == null)
            {
                return Direction.Unknown;
            }
            return door.GetDirection();
        }
    }
}