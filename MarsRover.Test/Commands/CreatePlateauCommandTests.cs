using MarsRover.Commands;
using MarsRover.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Test.Commands
{
    [TestFixture]
    public class CreatePlateauCommandTests
    {
        private readonly Mock<IPlateauService> _plateauService;

        public CreatePlateauCommandTests()
        {
            //Given
            _plateauService = new Mock<IPlateauService>();
        }

        [Test]
        public void CreatePlateauCommand_Should_Call_Create_Method_When_Expected_Value()
        {
            //Given
            var plateauService = new Mock<IPlateauService>();

            var createPlateauCommand = new CreatePlateauCommand(plateauService.Object, 5, 5);

            //When
            createPlateauCommand.Execute();

            //Than
            plateauService.Verify(mock => mock.Create(5, 5), Times.Once);

        }
    }
}
