﻿using MarsRover.Commands.Rotate;
using MarsRover.Enums;
using MarsRover.Interfaces;
using MarsRover.Models;
using Moq;
using NUnit.Framework;

namespace MarsRover.Test.Commands.Rotate
{
    [TestFixture]
    public class MoveCommandTest
    {
        private readonly Mock<IRoverService> _roverService;
        private readonly Mock<IDirectionService> _directionService;
        private RoverPositionModel _roverPositionModel;

        public MoveCommandTest()
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
        public void MoveCommand_Should_Call_Create_Method_When_Expected_Value()
        {
            //Given

            var moveCommand = new MoveCommand(_roverService.Object, _directionService.Object);

            //When
            moveCommand.Execute();

            //Than
            _directionService.Verify(mock => mock.Move(It.IsAny<RoverPositionModel>()), Times.Once);


        }
    }
}