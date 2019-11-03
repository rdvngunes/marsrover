using MarsRover.Enums;
using MarsRover.Interfaces;
using MarsRover.Models;
using MarsRover.Services;
using MarsRover.Services.Rotate;
using NUnit.Framework;
using System.Collections.Generic;

namespace MarsRover.Test.Services
{
    [TestFixture]
    public class DirectionServiceTest
    {
        private Dictionary<Direction, IRotateService> _directionService;
        private RoverPositionModel _roverPositionModel;
        private DirectionService _service;

        [SetUp]
        public void Setup()
        {
            //Given
            _service = new DirectionService();
            _roverPositionModel = new RoverPositionModel
            {
                Direction = Direction.North,
                X = 1,
                Y = 1
            };

            _directionService = new Dictionary<Direction, IRotateService>
            {
                {Direction.North, new RotateNorthService()},
                {Direction.South, new RotateSouthService()},
                {Direction.West, new RotateWestService()},
                {Direction.East, new RotateEastService()}
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
            var result = _service.Left(_roverPositionModel.Direction);

            //Then
            Assert.AreEqual(result, Direction.West);
        }

        [Test]
        public void It_Should_Return_East_When_Direction_Is_Right()
        {
            //when
            var result = _service.Right(_roverPositionModel.Direction);

            //Then
            Assert.AreEqual(result, Direction.East);
        }
    }
}
