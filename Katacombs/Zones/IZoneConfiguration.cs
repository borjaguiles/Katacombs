using System.Collections.Generic;

namespace Katacombs.Zones
{
    public interface IZoneConfiguration
    {
        Message LookAtDirection(Direction direction = Direction.Unknown);
        Message LookAtItem(string item);
        bool IsDoorUnlocked(string doorName);
        bool DoesDoorExist(string doorName);
        Direction GetDoorDirection(string door);
        string GetZoneName();
    }
}