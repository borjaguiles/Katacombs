using System;

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
            throw new NotImplementedException();
        }
    }
}