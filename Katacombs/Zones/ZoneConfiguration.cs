namespace Katacombs.Zones
{
    public class ZoneConfiguration : IZoneConfiguration, IMutableZoneConfiguration
    {
        private readonly ZoneDoors _zoneDoors;
        private string[] _zoneDescription;

        public ZoneConfiguration()
        {
            _zoneDoors = new ZoneDoors();
        }

        public string[] LookAtDirection(Direction direction = Direction.Unknown)
        {
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
            }
        }
    }
}