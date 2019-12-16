namespace Katacombs
{
    public interface IZoneConfiguration
    {
        string[] LookAtDirection(Direction direction = Direction.Unknown);
        string LookAtItem(string item);
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
    }
}