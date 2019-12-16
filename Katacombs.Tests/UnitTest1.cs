using System;
using Xunit;

namespace Katacombs.Tests
{
    public class UnitTest1
    {
        private Katacombs _katacombs;

        [Fact]
        public void PlayerLooksSouthThenLooksNorthOpensDoorPicksUpKeysOpensBagGoesNorthFailsLooksEastGoesEastUseKeyOpenDoor()
        {
            var bag = new Inventory();
            var startingZone = new Zone();
            _katacombs = new Katacombs(bag, startingZone);
            _katacombs.Action("Look S");
            _katacombs.Action("Look N");
            _katacombs.Action("Open Door");
            _katacombs.Action("Pick Key");
            _katacombs.Action("Bag");
            _katacombs.Action("Go N");
            _katacombs.Action("Look E");
            _katacombs.Action("Go E");
            _katacombs.Action("Use Key");
            string[] result = _katacombs.Action("Open Door");
            Assert.Equal("Inside Truman Brewery's warehouse.", result[0]);
            Assert.Equal("You're inside a warehouse filled with rows of beer kegs. You smell the putrid odor of death.", result[1]);
        }
    }
}
