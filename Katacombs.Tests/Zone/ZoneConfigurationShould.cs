using Katacombs.Zones;
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
            var message = _zoneConfig.LookAtDirection();

            Assert.Equal("LOST IN SHOREDITCH.\r\nYOU ARE STANDING AT THE END OF BRICK LANE BEFORE A SMALL BRICK BUILDING CALLED THE OLD TRUMAN BREWERY. \r\nAROUND YOU IS A FOREST OF INDIAN RESTAURANTS. \r\nA SMALL STREAM OF CRAFTED BEER FLOWS OUT OF THE BUILDING AND DOWN A GULLY.",
                message.ToString());
        }

        [Fact]
        public void TellThePlayerTheDescriptionOfWhateverIsSouth()
        {
            _zoneConfig = ZoneBuilder.Build("StartingZone");
            var message = _zoneConfig.LookAtDirection(Direction.S);
            Assert.Equal("Nothing interesting to look at there!", message.ToString());
        }

        [Fact]
        public void TellThePlayerTheresAWhiteDoorNorthOfTheStartingZone()
        {
            _zoneConfig = ZoneBuilder.Build("StartingZone");
            var message = _zoneConfig.LookAtDirection(Direction.N);
            Assert.Equal("I CAN SEE A BRICK BUILDING WITH A SIGN SAYING \"TRUMAN BREWERY\" AND A WOODEN WHITE DOOR", message.ToString());
        }

        [Fact]
        public void TellThePlayerWhereTheDoorIsLocated()
        {
            _zoneConfig = ZoneBuilder.Build("StartingZone");
            var doorDirection = _zoneConfig.GetDoorDirection("White Door");
            Assert.Equal(Direction.N, doorDirection);
        }

        [Fact]
        public void TellThePlayerTheDoorDirectionIsUnknownWhenTheDoorDoesNotExist()
        {
            _zoneConfig = ZoneBuilder.Build("StartingZone");
            var doorDirection = _zoneConfig.GetDoorDirection("Blue Door");
            Assert.Equal(Direction.Unknown, doorDirection);
        }

        [Fact]
        public void GiveThePlayerTheItemItRequested()
        {
            _zoneConfig = ZoneBuilder.Build("Truman Brewery Hall 1");
            var item = _zoneConfig.GetItem("White Key");
            Assert.Equal("White Key", item.GetName());
        }

        [Fact]
        public void GiveThePlayerNothingWhenTheItemDoesNotExist()
        {
            _zoneConfig = ZoneBuilder.Build("Truman Brewery Hall 1");
            var item = _zoneConfig.GetItem("Blue Key");
            Assert.Null(item);
        }
    }
}