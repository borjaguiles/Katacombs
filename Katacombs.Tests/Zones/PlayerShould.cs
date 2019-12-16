using Katacombs.Player;
using NSubstitute;
using Xunit;

namespace Katacombs.Tests.Zones
{
    public class PlayerShould
    {
        [Fact]
        public void TellPlayerTheresADoorNorth()
        {
            var zoneConfig = Substitute.For<IZoneConfiguration>();
            zoneConfig.LookAtDirection(Direction.N).Returns(new [] {"I CAN SEE A BRICK BUILDING WITH A SIGN SAYING \"TRUMAN BREWERY\" AND A WOODEN WHITE DOOR"});
            var player = new StartingPlayer(zoneConfig);
            var result = player.Look("N");
            Assert.Equal("I CAN SEE A BRICK BUILDING WITH A SIGN SAYING \"TRUMAN BREWERY\" AND A WOODEN WHITE DOOR", result);
        }
    }
}