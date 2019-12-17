using System.Collections.Generic;
using Katacombs.Inventories;
using Katacombs.Player;
using NSubstitute;
using Xunit;

namespace Katacombs.Tests.Game
{
    public class KatacombsShould
    {
        private Katacombs _katacombs;
        private Inventory _bag;
        private IPlayer player;

        public KatacombsShould()
        {
            _bag = new Inventory();
            player = Substitute.For<IPlayer>();
            _katacombs = new Katacombs(player);
        }

        [Fact]
        public void TellPlayerTheIntroWhenStarting()
        {
            
            player.ZoneOverview().Returns(new Message("LOST IN SHOREDITCH.",
                "YOU ARE STANDING AT THE END OF BRICK LANE BEFORE A SMALL BRICK BUILDING CALLED THE OLD TRUMAN BREWERY. \r\nAROUND YOU IS A FOREST OF INDIAN RESTAURANTS. \r\nA SMALL STREAM OF CRAFTED BEER FLOWS OUT OF THE BUILDING AND DOWN A GULLY."));
            var message = _katacombs.Start();
            Assert.Equal("LOST IN SHOREDITCH.\r\nYOU ARE STANDING AT THE END OF BRICK LANE BEFORE A SMALL BRICK BUILDING CALLED THE OLD TRUMAN BREWERY. \r\nAROUND YOU IS A FOREST OF INDIAN RESTAURANTS. \r\nA SMALL STREAM OF CRAFTED BEER FLOWS OUT OF THE BUILDING AND DOWN A GULLY.", message.ToString());
        }

        [Fact]
        public void TellPlayerTheresNothingToSeeSouth()
        {
            
            player.Look("S").Returns(new Message("Nothing interesting to look at there!"));
            var message = _katacombs.Action("Look S");
            Assert.Equal("Nothing interesting to look at there!", message.ToString());
        }

        [Fact]
        public void TellPlayerTheresADoorWhenLookingNorth()
        {
            
            player.Look("N").Returns(new Message("I CAN SEE A BRICK BUILDING WITH A SIGN SAYING \"TRUMAN BREWERY\" AND A WOODEN WHITE DOOR"));
            var message = _katacombs.Action("Look N");
            Assert.Equal("I CAN SEE A BRICK BUILDING WITH A SIGN SAYING \"TRUMAN BREWERY\" AND A WOODEN WHITE DOOR", message.ToString());
        }

        [Fact]
        public void MovePlayerToNextZoneWhenOpeningTheDoor()
        {
            
            player.Open("Door").Returns(new Message("Inside the Truman Brewery", "You are in a large room, in front of you is a big counter and to the left some beer kegs. \r\n There's a key dropped on the floor."));
            var message = _katacombs.Action("Open Door");
            Assert.Equal("Inside the Truman Brewery\r\nYou are in a large room, in front of you is a big counter and to the left some beer kegs. \r\n There's a key dropped on the floor.", message.ToString());
        }

        [Fact]
        public void PlayerTakesKeyFromTheFloor()
        {
            player.Take("White Key").Returns(new Message("White Key: Taken"));
            var message = _katacombs.Action("Take White Key");
            Assert.Equal("White Key: Taken", message.ToString());
        }

        [Fact]
        public void ShowThePlayersInventory()
        {
            player.Bag().Returns(new Message("The bag contains: A White Key"));
            var bag = _katacombs.Action("Bag");
            Assert.Equal("The bag contains: A White Key", bag.ToString());
        }
    }
}
