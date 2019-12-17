using System;
using System.Collections.Generic;
using System.Text;
using Katacombs.Player;
using Katacombs.Zones;
using Xunit;

namespace Katacombs.Tests.Zone
{
    public class ZoneSwitcherShould
    {
        [Fact]
        public void MoveToTheTrumanBreweryFromTheStartingZone()
        {
            var zoneSwitcher = new ZoneSwitcher();
            var firstZone = ZoneBuilder.Build("StartingZone");
            var zone = zoneSwitcher.GetNextZone(firstZone, Direction.N);
            Assert.Equal("Truman Brewery Hall 1", zone.GetZoneName());
        }

        [Fact]
        public void MoveToTheTrumanBreweryThenMoveBackToTheStartingZone()
        {
            var zoneSwitcher = new ZoneSwitcher();
            var firstZone = ZoneBuilder.Build("StartingZone");
            var secondZone = zoneSwitcher.GetNextZone(firstZone, Direction.N);
            var thirdZone = zoneSwitcher.GetNextZone(secondZone, Direction.S);
            Assert.Equal("StartingZone", thirdZone.GetZoneName());
        }
    }
}
