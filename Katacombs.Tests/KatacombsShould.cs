using System;
using System.Collections.Generic;
using Katacombs.Inventories;
using Katacombs.Player;
using NSubstitute;
using Xunit;

namespace Katacombs.Tests
{
    public class KatacombsShould
    {
        private Katacombs _katacombs;
        private Inventory _bag;
        private StartingPlayer _startingStartingPlayer;

        public KatacombsShould()
        {
            _bag = new Inventory();
            _startingStartingPlayer = new StartingPlayer(Substitute.For<IZoneConfiguration>());
            _katacombs = new Katacombs(_startingStartingPlayer);
        }

        [Fact]
        public void PlayerLooksSouthThenLooksNorthOpensDoorPicksUpKeysOpensBagGoesNorthFailsLooksEastGoesEastUseKeyOpenDoor()
        {
            _startingStartingPlayer = new StartingPlayer(ZoneBuilder.Build("StartingZone"));
            _katacombs.Start();
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

        [Fact]
        public void TellPlayerTheIntroWhenStarting()
        {
            var player = Substitute.For<IPlayer>();
            player.ZoneOverview().Returns(new[]
            {
                "LOST IN SHOREDITCH.",
                "YOU ARE STANDING AT THE END OF BRICK LANE BEFORE A SMALL BRICK BUILDING CALLED THE OLD TRUMAN BREWERY. \r\nAROUND YOU IS A FOREST OF INDIAN RESTAURANTS. \r\nA SMALL STREAM OF CRAFTED BEER FLOWS OUT OF THE BUILDING AND DOWN A GULLY."
            });
            _katacombs = new Katacombs(player);
            var result = _katacombs.Start();
            Assert.Equal("LOST IN SHOREDITCH.", result[0]);
            Assert.Equal("YOU ARE STANDING AT THE END OF BRICK LANE BEFORE A SMALL BRICK BUILDING CALLED THE OLD TRUMAN BREWERY. \r\nAROUND YOU IS A FOREST OF INDIAN RESTAURANTS. \r\nA SMALL STREAM OF CRAFTED BEER FLOWS OUT OF THE BUILDING AND DOWN A GULLY.", result[1]);
        }

        [Fact]
        public void TellPlayerTheresNothingToSeeSouth()
        {
            var player = Substitute.For<IPlayer>();
            player.Look("S").Returns("Nothing interesting to look at there!");
            _katacombs = new Katacombs(player);
            var result = _katacombs.Action("Look S");
            Assert.Equal("Nothing interesting to look at there!", result[0]);
        }

        [Fact]
        public void TellPlayerTheresADoorWhenLookingNorth()
        {
            var player = Substitute.For<IPlayer>();
            player.Look("N").Returns("I CAN SEE A BRICK BUILDING WITH A SIGN SAYING \"TRUMAN BREWERY\" AND A WOODEN WHITE DOOR");
            _katacombs = new Katacombs(player);
            var result = _katacombs.Action("Look N");
            Assert.Equal("I CAN SEE A BRICK BUILDING WITH A SIGN SAYING \"TRUMAN BREWERY\" AND A WOODEN WHITE DOOR", result[0]);
        }

        [Fact]
        public void MovePlayerToNextZoneWhenOpeningTheDoor()
        {
            var player = Substitute.For<IPlayer>();
            player.Open("Door").Returns(new[] { "Inside the Truman Brewery", "You are in a large room, in front of you is a big counter and to the left some beer kegs. \r\n There's a key dropped on the floor." });
            _katacombs = new Katacombs(player);
            var result = _katacombs.Action("Open Door");
            Assert.Equal("Inside the Truman Brewery", result[0]);
            Assert.Equal("You are in a large room, in front of you is a big counter and to the left some beer kegs. \r\n There's a key dropped on the floor.", result[1]);
        }
    }
}
