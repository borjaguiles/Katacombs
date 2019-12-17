namespace Katacombs.Zones
{
    public class ZoneBuilder
    {
        public static IZoneConfiguration Build(string zoneName)
        {
            if (zoneName == "StartingZone")
            {
                var startingZone = new ZoneConfiguration();
                startingZone.SetName(zoneName);
                var door = new Door(Direction.N, "White Door");
                startingZone.AddDoor(door);
                var overview = new Message("LOST IN SHOREDITCH.",
                    "YOU ARE STANDING AT THE END OF BRICK LANE BEFORE A SMALL BRICK BUILDING CALLED THE OLD TRUMAN BREWERY. \r\nAROUND YOU IS A FOREST OF INDIAN RESTAURANTS. \r\nA SMALL STREAM OF CRAFTED BEER FLOWS OUT OF THE BUILDING AND DOWN A GULLY.");
                startingZone.AddLook(Direction.Unknown, overview);
                var northDescription = new Message("I CAN SEE A BRICK BUILDING WITH A SIGN SAYING \"TRUMAN BREWERY\" AND A WOODEN WHITE DOOR");
                startingZone.AddLook(Direction.N, northDescription);
                return startingZone;
            }

            if (zoneName == "Truman Brewery Hall 2")
            {
                var trumanBreweryHallTwo = new ZoneConfiguration();
                trumanBreweryHallTwo.SetName(zoneName);
                var door = new Door(Direction.N, "White Door");
                trumanBreweryHallTwo.AddDoor(door);
                return trumanBreweryHallTwo;
            }

            if (zoneName == "Truman Brewery Warehouse")
            {
                var trumanBreweryWarehouse = new ZoneConfiguration();
                trumanBreweryWarehouse.SetName(zoneName);
                var overview = new Message("Inside Truman Brewery's warehouse.",
                    "You're inside a warehouse filled with rows of beer kegs. You smell the putrid odor of death.");
                trumanBreweryWarehouse.AddLook(Direction.Unknown, overview);
                return trumanBreweryWarehouse;
            }

            var trumanBreweryHallOne = new ZoneConfiguration();
            trumanBreweryHallOne.SetName(zoneName);
            return trumanBreweryHallOne;
        }
    }
}