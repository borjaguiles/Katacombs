using System;

namespace Katacombs
{
    public class Katacombs
    {
        private readonly IInventory _inventory;
        private IZone _startingZone;

        public Katacombs(IInventory inventory, IZone startingZone)
        {
            _inventory = inventory;
            _startingZone = startingZone;
        }

        public string[] Action(string action)
        {
            return new[] {"Nothing interesting to look at there!"};
        }

        public string[] Start()
        {
            return _startingZone.ZoneOverview();
        }
    }
}
