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
    }
}