using Moq;
using Robot.Interfaces;
using Robot.Models;
using Robot.Services;
using System;
using Xunit;

namespace Robot.Tests
{
    public class RobotUnitTests
    {
        private readonly RobotService robotService;
        public RobotUnitTests()
        {
            robotService = new RobotService();
            robotService.SetStartingPoint(1, 1, Compass.North, new Models.MarsPlateauGrid(5, 5));
        }

        [Fact]
        public void Should_Return_Starting_Cordinates()
        {
            var currentPosition = robotService.GetCurrentPosition();

            Assert.Equal("1,1,North", currentPosition);

        }

        [Fact]
        public void Should_Return_1x4_West()
        {
            robotService.Move("FFRFLFLF");

            var currentPosition = robotService.GetCurrentPosition();

            Assert.Equal("1,4,West", currentPosition);

        }

        [Fact]
        public void Should_Throw_Exception_Invalid_Command()
        {
            var exception = Assert.Throws<Exception>(() => robotService.Move("A"));

            Assert.Equal("Invalid command A", exception.Message);
        }

        [Fact]
        public void Should_Throw_Exception_Moviment_outside_boundaries()
        {
            var exception = Assert.Throws<Exception>(() => robotService.Move("FFRFLFLFFFFFFFFFF"));

            Assert.Equal("You cannot make a move outside the borders 1X1 AND 5X5", exception.Message);
        }

        [Fact]
        public void Should_Throw_Exception_Moviment_Grid_Not_Initialized()
        {
            robotService.SetStartingPoint(2, 2, Compass.North, null);

            var exception = Assert.Throws<Exception>(() => robotService.Move("FFRFLFLFFFFFFFFFF"));

            Assert.Equal("Grid not initialized", exception.Message);
        }

        [Fact]
        public void Should_Throw_Exception_To_XorY_Initialized_AS_Zero()
        {
            var exception = Assert.Throws<Exception>(() => robotService.SetStartingPoint(0, 0, Compass.North, null));

            Assert.Equal("There is no 0,0 position", exception.Message);

        }
    }
}
