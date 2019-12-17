using Katacombs.Player;
using Katacombs.Zones;
using Xunit;

namespace Katacombs.Tests.Game
{
    public class KatacombsShouldAcceptance
    {
        private Katacombs _katacombs;

        [Fact]
        public void PlayerLooksSouthThenLooksNorthOpensDoorPicksUpKeysOpensBagGoesNorthFailsLooksEastGoesEastUseKeyOpenDoor()
        {
            var player = new StartingPlayer(ZoneBuilder.Build("StartingZone"), new ZoneSwitcher());
            _katacombs = new Katacombs(player);
            _katacombs.Start();
            _katacombs.Action("Look S");
            _katacombs.Action("Look N");
            _katacombs.Action("Open White Door");
            _katacombs.Action("Take Key");
            _katacombs.Action("Bag");
            _katacombs.Action("Go N");
            _katacombs.Action("Look E");
            _katacombs.Action("Go E");
            _katacombs.Action("Use Key");
            var message = _katacombs.Action("Open Door");
            Assert.Equal("Inside Truman Brewery's warehouse.\r\nYou're inside a warehouse filled with rows of beer kegs. You smell the putrid odor of death.", message.ToString());
        }
    }
}