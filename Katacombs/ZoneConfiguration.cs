namespace Katacombs
{
    public interface IZoneConfiguration
    {
        string[] LookAtDirection(Direction direction = Direction.Unknown);
        string LookAtItem(string item);
        bool IsDoorUnlocked(string doorName);
        bool DoesDoorExist(string doorName);
        Direction GetDoorDirection(string door);
    }

    public class ZoneConfiguration : IZoneConfiguration, IMutableZoneConfiguration
    {
        private readonly ZoneDoors _zoneDoors;

        public ZoneConfiguration()
        {
            _zoneDoors = new ZoneDoors();
        }

        public string[] LookAtDirection(Direction direction = Direction.Unknown)
        {
            throw new System.NotImplementedException();
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
    }
}