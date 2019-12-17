using System;
using Katacombs.Zones;

namespace Katacombs.Player
{
    public interface IZoneSwitcher
    {
        IZoneConfiguration GetNextZone(IZoneConfiguration currentZone, Direction direction);
    }

    public class ZoneSwitcher : IZoneSwitcher
    {
        public IZoneConfiguration GetNextZone(IZoneConfiguration currentZone, Direction direction)
        {
            if (currentZone.GetZoneName() == "StartingZone" && direction == Direction.N)
            {
                return ZoneBuilder.Build("Truman Brewery Hall 1");
            }

            if (currentZone.GetZoneName() == "Truman Brewery Hall 1" && direction == Direction.S)
            {
                return ZoneBuilder.Build("StartingZone");
            }

            throw new NotImplementedException();
            
        }
    }
}