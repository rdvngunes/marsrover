using MarsRover.Commands;
using MarsRover.Enums;
using MarsRover.Interfaces;
using MarsRover.Models;
using Moq;
using NUnit.Framework;

namespace MarsRover.Test.Commands.Rotate
{
    [TestFixture]
    public class CreateRoverCommandTest
    {
        private RoverPositionModel _roverPositionModel;

        private readonly Mock<IPlateauService> _plateauService;
        private readonly Mock<IRoverService> _roverService;

        public  CreateRoverCommandTest()
        {
            //Given
            _plateauService = new Mock<IPlateauService>();
            _roverService = new Mock<IRoverService>();

            _roverPositionModel = new RoverPositionModel
            {
                Direction = Direction.North,
                X = 1,
                Y = 1
            };
        }

        [Test]
        public void CreateRover_Should_Call_Create_Method_When_Expected_Value()
        {
            //Given
            new CreateRoverCommand(_roverService.Object,
                                   _plateauService.Object,
                                   _roverPositionModel.X,
                                   _roverPositionModel.Y,
                                   _roverPositionModel.Direction).Execute();

            //Than
            _roverService.Verify(mock => mock.CreateMarsRover(It.IsAny<RoverPositionModel>(), _plateauService.Object), Times.Once);

        }
    }
}
