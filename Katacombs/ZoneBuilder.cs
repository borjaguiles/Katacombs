using System;

namespace Katacombs
{
    public class ZoneBuilder
    {
        public static IZoneConfiguration Build(string zoneName)
        {
            var zoneConfiguration = new ZoneConfiguration();
            var door = new Door(Direction.N, "White Door");
            zoneConfiguration.AddDoor(door);

            return zoneConfiguration;
        }
    }
}