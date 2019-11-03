using MarsRover.Enums;
using MarsRover.Interfaces;
using MarsRover.Models;
using MarsRover.Services;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Test.Services
{
    [TestFixture]
    public class RoverServiceTest
    {
        private readonly RoverService _roverService;
        private readonly Mock<IPlateauService> _plateauService;
        private readonly Mock<ILogger<RoverService>> _loggerMock;
        private RoverPositionModel _roverPositionModel;

        public RoverServiceTest()
        {
            //Given
            _plateauService = new Mock<IPlateauService>();
            _loggerMock = new Mock<ILogger<RoverService>>();
            _roverService = new RoverService(_loggerMock.Object);

            _roverPositionModel = new RoverPositionModel
            {
                Direction = Direction.North,
                X = 1,
                Y = 1
            };
        }


        [Test]
        public void CreateRover_Should_Throw_InvalidPosition_When_Negative_Or_Extreme()
        {
            //Given
            _plateauService.Setup(foo => foo.GetCurrentPlateau()).Returns(new PlateauModel
            {
                Width = -1,
                Height = 5
            });

            var exception = new Exception("Mars rover position not valid");

            //When
            var ex = Assert.Throws<Exception>(() => _roverService.CreateMarsRover(_roverPositionModel, _plateauService.Object));


            //Than
            Assert.AreEqual("Mars rover position not valid", ex.Message);
        }

        [Test]
        public void CreateMarsRover_Should_Create_Mars_Rover_When_Expected_Position()
        {
            //Given
            _plateauService.Setup(foo => foo.GetCurrentPlateau()).Returns(new PlateauModel
            {
                Width = 5,
                Height = 5
            });

            //When
            _roverService.CreateMarsRover(_roverPositionModel, _plateauService.Object);

            var currentRoverPositionModel = _roverService.GetCurrentRover();
            //Than
            Assert.AreEqual(currentRoverPositionModel.X, _roverPositionModel.X);
            Assert.AreEqual(currentRoverPositionModel.Y, _roverPositionModel.Y);
            Assert.AreEqual(currentRoverPositionModel.Direction, _roverPositionModel.Direction);

        }

        [Test]
        public void ChangePosition_Should_Change_Position_When_Expected_Position()
        {
            //Given
            _plateauService.Setup(foo => foo.GetCurrentPlateau()).Returns(new PlateauModel
            {
                Width = 5,
                Height = 5
            });

            //When
            _roverService.ChangePosition(_roverPositionModel);

            var currentRoverPositionModel = _roverService.GetCurrentRover();

            //Than
            Assert.AreEqual(currentRoverPositionModel.X, _roverPositionModel.X);
            Assert.AreEqual(currentRoverPositionModel.Y, _roverPositionModel.Y);
            Assert.AreEqual(currentRoverPositionModel.Direction, _roverPositionModel.Direction);



        }

    }
}
