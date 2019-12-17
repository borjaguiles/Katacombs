﻿using Katacombs.Player;
using Katacombs.Zones;
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
            zoneConfig.LookAtDirection(Direction.N).Returns(new Message("I CAN SEE A BRICK BUILDING WITH A SIGN SAYING \"TRUMAN BREWERY\" AND A WOODEN WHITE DOOR"));
            var player = new StartingPlayer(zoneConfig, Substitute.For<IZoneSwitcher>());
            var message = player.Look("N");
            Assert.Equal("I CAN SEE A BRICK BUILDING WITH A SIGN SAYING \"TRUMAN BREWERY\" AND A WOODEN WHITE DOOR", message.ToString());
        }

        [Fact]
        public void TellPlayerTheresNothingWhenLookingSouth()
        {
            var zoneConfig = Substitute.For<IZoneConfiguration>();
            zoneConfig.LookAtDirection(Direction.S).Returns(new Message("Nothing interesting to look at there!"));
            var player = new StartingPlayer(zoneConfig, Substitute.For<IZoneSwitcher>());
            var message = player.Look("S");
            Assert.Equal("Nothing interesting to look at there!", message.ToString());
        }

        [Fact]
        public void GoToNextZoneWhenOpeningADoor()
        {
            var zoneConfig = Substitute.For<IZoneConfiguration>();
            zoneConfig.DoesDoorExist("White Door").Returns(true);
            zoneConfig.IsDoorUnlocked("White Door").Returns(true);
            zoneConfig.GetDoorDirection("White Door").Returns(Direction.N);

            var secondZoneConfig = Substitute.For<IZoneConfiguration>();
            secondZoneConfig.LookAtDirection().Returns(new Message("Inside the Truman Brewery", "You are in a large room, in front of you is a big counter and to the left some beer kegs. \r\n There's a key dropped on the floor."));

            var zoneSwitcher = Substitute.For<IZoneSwitcher>();
            zoneSwitcher.GetNextZone(zoneConfig, Direction.N).Returns(secondZoneConfig);
            var player = new StartingPlayer(zoneConfig, zoneSwitcher);
            var message = player.Open("White Door");
            Assert.Equal("Inside the Truman Brewery\r\nYou are in a large room, in front of you is a big counter and to the left some beer kegs. \r\n There's a key dropped on the floor.", message.ToString());
        }
    }
}