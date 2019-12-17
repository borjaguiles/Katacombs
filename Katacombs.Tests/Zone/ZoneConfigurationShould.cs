﻿using Katacombs.Zones;
using Xunit;

namespace Katacombs.Tests.Zone
{
    public class ZoneConfigurationShould
    {
        private IZoneConfiguration _zoneConfig;

        [Fact]
        public void TellTheUserTheDoorIsOpenWhenTheWhiteDoorIsUnlocked()
        {
            _zoneConfig = ZoneBuilder.Build("StartingZone");
            Assert.True(_zoneConfig.IsDoorUnlocked("White Door"));
        }

        [Fact]
        public void TellTheUserTheDoorExists()
        {
            _zoneConfig = ZoneBuilder.Build("StartingZone");
            Assert.True(_zoneConfig.DoesDoorExist("White Door"));
        }

        [Fact]
        public void TellTheUserTheDoorDoesNotExists()
        {
            _zoneConfig = ZoneBuilder.Build("StartingZone");
            Assert.False(_zoneConfig.DoesDoorExist("Red Door"));
        }

        [Fact]
        public void TellThePlayerTheDescriptionOfTheZone()
        {
            _zoneConfig = ZoneBuilder.Build("StartingZone");
            var result = _zoneConfig.LookAtDirection();

            Assert.Equal("LOST IN SHOREDITCH.", result[0]);
            Assert.Equal(
                "YOU ARE STANDING AT THE END OF BRICK LANE BEFORE A SMALL BRICK BUILDING CALLED THE OLD TRUMAN BREWERY. \r\nAROUND YOU IS A FOREST OF INDIAN RESTAURANTS. \r\nA SMALL STREAM OF CRAFTED BEER FLOWS OUT OF THE BUILDING AND DOWN A GULLY.",
                result[1]);
        }

        [Fact]
        public void TellThePlayerTheDescriptionOfWhateverIsSouth()
        {
            _zoneConfig = ZoneBuilder.Build("StartingZone");
            var result = _zoneConfig.LookAtDirection(Direction.S);
            Assert.Equal("Nothing interesting to look at there!", result[0]);
        }

        [Fact]
        public void TellThePlayerTheresAWhiteDoorNorthOfTheStartingZone()
        {
            _zoneConfig = ZoneBuilder.Build("StartingZone");
            var result = _zoneConfig.LookAtDirection(Direction.N);
            Assert.Equal("I CAN SEE A BRICK BUILDING WITH A SIGN SAYING \"TRUMAN BREWERY\" AND A WOODEN WHITE DOOR", result[0]);
        }
    }
}