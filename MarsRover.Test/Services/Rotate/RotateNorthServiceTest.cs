using MarsRover.Enums;
using MarsRover.Models;
using MarsRover.Services.Rotate;
using NUnit.Framework;
using System.Threading.Tasks;

namespace MarsRover.Test.Services.Rotate
{
    [TestFixture]
    public class RotateNorthServiceTest
    {
        private RoverPositionModel _roverPositionModel;
        private RotateNorthService _service;

        [SetUp]
        public void Setup()
        {
            //Given
            _service = new RotateNorthService();
            _roverPositionModel = new RoverPositionModel
            {
                Direction = Direction.North,
                X = 1,
                Y = 1
            };
        }

        [Test]
        public void It_Should_Return_RoverPositionModel_When_Rover_Is_Move()
        {
            //when
            var result = _service.Move(_roverPositionModel);

            //Then
            Assert.AreEqual(result.Direction, Direction.North);
            Assert.AreEqual(result.X, 1);
            Assert.AreEqual(result.Y, 2);
        }

        [Test]
        public void It_Should_Return_West_When_Direction_Is_Left()
        {
            //when
            var result = _service.Left();

            //Then
            Assert.AreEqual(result,Direction.West);
        }

        [Test]
        public void It_Should_Return_East_When_Direction_Is_Right()
        {
            //when
            var result = _service.Right();

            //Then
            Assert.AreEqual(result, Direction.East);
        }
    }
}