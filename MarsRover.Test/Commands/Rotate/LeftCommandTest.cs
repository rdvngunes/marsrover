using MarsRover.Commands.Rotate;
using MarsRover.Enums;
using MarsRover.Interfaces;
using MarsRover.Models;
using Moq;
using NUnit.Framework;

namespace MarsRover.Test.Commands.Rotate
{
    [TestFixture]
    public class LeftCommandTest
    {
        private readonly Mock<IRoverService> _roverService;
        private readonly Mock<IDirectionService> _directionService;
        private RoverPositionModel _roverPositionModel;

        public LeftCommandTest()
        {
            //Given
            _roverService = new Mock<IRoverService>();
            _directionService = new Mock<IDirectionService>();

            _roverPositionModel = new RoverPositionModel
            {
                Direction = Direction.North,
                X = 1,
                Y = 1
            };
        }

        [Test]
        public void LeftCommand_Should_Call_Create_Method_When_Expected_Value()
        {
            //Given
            _roverService.Setup(s => s.GetCurrentRover()).Returns(new RoverPositionModel(1, 1, Direction.North));

            var rightCommand = new LeftCommand(_roverService.Object, _directionService.Object);

            //When
            rightCommand.Execute();

            //Than
            _directionService.Verify(mock => mock.Left(Direction.North), Times.Once);

        }
    }
}