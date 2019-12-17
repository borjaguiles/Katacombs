namespace Katacombs.Zones
{
    public interface IMutableZoneConfiguration
    {
        void AddDoor(Door door);
        void AddLook(Direction direction, Message text);
        void SetName(string zoneName);
    }
}