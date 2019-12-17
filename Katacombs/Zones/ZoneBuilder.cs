namespace Katacombs.Zones
{
    public class ZoneBuilder
    {
        public static IZoneConfiguration Build(string zoneName)
        {
            var zoneConfiguration = new ZoneConfiguration();
            var door = new Door(Direction.N, "White Door");
            zoneConfiguration.AddDoor(door);
            var overview = new[]
            {
                "LOST IN SHOREDITCH.",
                "YOU ARE STANDING AT THE END OF BRICK LANE BEFORE A SMALL BRICK BUILDING CALLED THE OLD TRUMAN BREWERY. \r\nAROUND YOU IS A FOREST OF INDIAN RESTAURANTS. \r\nA SMALL STREAM OF CRAFTED BEER FLOWS OUT OF THE BUILDING AND DOWN A GULLY."
            };
            zoneConfiguration.AddLook(Direction.Unknown, overview);
            return zoneConfiguration;
        }
    }
}