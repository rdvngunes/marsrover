using MarsRover.Enums;
using MarsRover.Models;
using MarsRover.Services;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRover.Test.Services
{
    [TestFixture]
    public class PlateauServiceTest
    {
        private readonly PlateauService _plateauService;
        private readonly Mock<ILogger<PlateauService>> _loggerMock;
        private RoverPositionModel _roverPositionModel;

        public PlateauServiceTest()
        {
            //Given
            _loggerMock = new Mock<ILogger<PlateauService>>();
            _plateauService = new PlateauService(_loggerMock.Object);

            _roverPositionModel = new RoverPositionModel
            {
                Direction = Direction.North,
                X = 1,
                Y = 1
            };
        }

        [Test]
        public void Create_Should_Throw_InvalidSizeException_When_Negative_Size()
        {
            //When
            var exception = new Exception("Plateau size not valid");

            //When
            var ex = Assert.Throws<Exception>(() => _plateauService.Create(-1,5));

            //Than
            Assert.AreEqual("Plateau size not valid", ex.Message);
        }

        [Test]
        public void Create_Should_Create_Plateau_When_Expected_Size()
        {
            //When
            _plateauService.Create(5, 5);
             //Than

             Assert.AreEqual(_plateauService.GetCurrentPlateau().Width,5);
            Assert.AreEqual(_plateauService.GetCurrentPlateau().Height,5);
        }

        [Test]
        public void AddMarsRover_Should_Add_Mars_Rover_Plateau_When_One_Expected_Value()
        {
            //Given
            _plateauService.Create(6, 6);
            //When
            _plateauService.AddMarsRover(_roverPositionModel);

            //Than
            Assert.AreEqual(_plateauService.GetMarsRovers().Count, 1);
            Assert.AreEqual(_plateauService.GetMarsRovers().Last().X, _roverPositionModel.X);
            Assert.AreEqual(_plateauService.GetMarsRovers().Last().Y, _roverPositionModel.Y);
            Assert.AreEqual(_plateauService.GetMarsRovers().Last().Direction, _roverPositionModel.Direction);
        }

        [Test]
        public void AddMarsRover_Should_Add_Mars_Rover_Plateau_When_Second_Expected_Value()
        {
            //Given
           _plateauService.Create(6, 6);
           _plateauService.AddMarsRover(new RoverPositionModel
            {
                Direction = Direction.North,
                X = 1,
                Y = 1
            });

            //When
            _plateauService.AddMarsRover(_roverPositionModel);

             //Than
            Assert.AreEqual(_plateauService.GetMarsRovers().Count,2);
            Assert.AreEqual(_plateauService.GetMarsRovers().Last().X,_roverPositionModel.X);
            Assert.AreEqual(_plateauService.GetMarsRovers().Last().Y,_roverPositionModel.Y);
            Assert.AreEqual(_plateauService.GetMarsRovers().Last().Direction,_roverPositionModel.Direction);

        }
    }
}
