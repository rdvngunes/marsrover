using MarsRover.Commands;
using MarsRover.Enums;
using MarsRover.Interfaces;
using MarsRover.Models;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Test.Commands
{
    [TestFixture]
    public class CommandInvokerTest
    {
        private readonly Mock<IRoverService> _roverService;
        private readonly Mock<IDirectionService> _directionService;
        private readonly Mock<IPlateauService> _plateauService;
        private readonly Mock<ILogger<CommandInvoker>> _loggerMock;


        public CommandInvokerTest()
        {
            //Given
            _roverService = new Mock<IRoverService>();
            _directionService = new Mock<IDirectionService>();
            _plateauService = new Mock<IPlateauService>();
            _loggerMock = new Mock<ILogger<CommandInvoker>>();
        }

        [Test]
        public void InvokeAll_Should_Return_Command_List_When_Expected_Value()
        {
            //Given
            var commandStringBuilder = new StringBuilder();
            commandStringBuilder.AppendLine("5 5");
            commandStringBuilder.AppendLine("1 2 N");
            commandStringBuilder.Append("LRMMRL");

            var commandInvoker = new CommandInvoker(_plateauService.Object, _roverService.Object, _loggerMock.Object, _directionService.Object);

            //When
            var commands = commandInvoker.InvokeAll(commandStringBuilder.ToString());

            //Than
            Assert.AreEqual(commands.Count, 8);
            Assert.AreEqual(commands[0].GetType().Name,"CreatePlateauCommand");
            Assert.AreEqual(commands[1].GetType().Name,"CreateRoverCommand");
            Assert.AreEqual(commands[2].GetType().Name,"LeftCommand");
            Assert.AreEqual(commands[3].GetType().Name,"RightCommand");
            Assert.AreEqual(commands[4].GetType().Name,"MoveCommand");
            Assert.AreEqual(commands[5].GetType().Name,"MoveCommand");
            Assert.AreEqual(commands[6].GetType().Name,"RightCommand");
            Assert.AreEqual(commands[7].GetType().Name,"LeftCommand");

        }
    }
}
