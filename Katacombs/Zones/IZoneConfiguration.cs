namespace Katacombs.Zones
{
    public interface IZoneConfiguration
    {
        string[] LookAtDirection(Direction direction = Direction.Unknown);
        string LookAtItem(string item);
        bool IsDoorUnlocked(string doorName);
        bool DoesDoorExist(string doorName);
        Direction GetDoorDirection(string door);
    }
}