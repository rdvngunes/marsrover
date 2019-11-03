using MarsRover.Enums;
using MarsRover.Models;
using MarsRover.Services.Rotate;
using NUnit.Framework;
using System.Threading.Tasks;

namespace MarsRover.Test.Services.Rotate
{
    [TestFixture]
    public class RotateWesterviceTest
    {
        private RoverPositionModel _roverPositionModel;
        private RotateWestService _service;

        [SetUp]
        public void Setup()
        {
            //Given
            _service = new RotateWestService();
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
            Assert.AreEqual(result.X, 0);
            Assert.AreEqual(result.Y, 1);
        }

        [Test]
        public void It_Should_Return_South_When_Direction_Is_Left()
        {
            //when
            var result = _service.Left();

            //Then
            Assert.AreEqual(result,Direction.South);
        }

        [Test]
        public void It_Should_Return_North_When_Direction_Is_Right()
        {
            //when
            var result = _service.Right();

            //Then
            Assert.AreEqual(result, Direction.North);
        }
    }
}