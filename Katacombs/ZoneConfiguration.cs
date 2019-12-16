namespace Katacombs
{
    public interface IZoneConfiguration
    {
        string[] LookAtDirection(Direction direction = Direction.Unknown);
        string LookAtItem(string item);
        bool IsDoorUnlocked(string doorName);
        Direction GetDoorDirection(string door);
    }

    public class ZoneConfiguration : IZoneConfiguration
    {
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
            throw new System.NotImplementedException();
        }

        public Direction GetDoorDirection(string door)
        {
            throw new System.NotImplementedException();
        }
    }
}