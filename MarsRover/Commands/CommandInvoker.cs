using MarsRover.Commands.Rotate;
using MarsRover.Enums;
using MarsRover.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MarsRover.Commands
{
    public class CommandInvoker : ICommandInvoker
    {
        private readonly Dictionary<string, CommandType> _commandTypeDictionary;

        private readonly IPlateauService _plateauService;
        private readonly IRoverService _roverService;
        private readonly ILogger _logger;
        private readonly IDirectionService _directionService;


        public CommandInvoker(IPlateauService plateauService, IRoverService roverService, ILogger<CommandInvoker> logger, IDirectionService directionService)
        {
            _plateauService = plateauService;
            _roverService = roverService;
            _logger = logger;
            _directionService = directionService;

            _commandTypeDictionary = new Dictionary<string, CommandType>
        {
            { @"^\d+ \d+$", CommandType.CreatePlateauCommand },
            { @"^\d+ \d+ [NSEW]$", CommandType.CreateMarsRoverCommand},
            { @"^[LMR]+$", CommandType.MoveRoverCommand }
        };

        }

        public List<ICommand> InvokeAll(string cmd)
        {
            var commandsString = cmd
                .Split(new[] { Environment.NewLine }, StringSplitOptions.None)
                .ToList();

            var result = new List<ICommand>();
            foreach (var commandString in commandsString)
            {
                result.AddRange(ParseCommand(commandString));
            }

            return result;
        }

        private List<ICommand> ParseCommand(string commandString)
        {
            var commandType = _commandTypeDictionary.FirstOrDefault(regexToCommandType => new Regex(regexToCommandType.Key).IsMatch(commandString));
            switch (commandType.Value)
            {
                case CommandType.CreatePlateauCommand:
                    return ParseCreatePlateauCommand(commandString);
                case CommandType.CreateMarsRoverCommand:
                    return ParseCreateMarsRoverCommand(commandString);
                case CommandType.MoveRoverCommand:
                    return ParseMoveRover(commandString);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private List<ICommand> ParseMoveRover(string commandString)
        {
            var result = new List<ICommand>();
            foreach (var cmd in commandString)
            {
                Enum.TryParse(cmd.ToString(), out Movement enumCmd);
                switch (enumCmd)
                {
                    case Movement.L:
                        result.Add(new LeftCommand(_roverService, _directionService));
                        break;
                    case Movement.R:
                        result.Add(new RightCommand(_roverService, _directionService));
                        break;
                    case Movement.M:
                        result.Add(new MoveCommand(_roverService, _directionService));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return result;
        }
        private List<ICommand> ParseCreatePlateauCommand(string command)
        {
            var arguments = command.Split();
            var width = int.Parse(arguments[0]);
            var height = int.Parse(arguments[1]);

            return new List<ICommand>()
            {
                new CreatePlateauCommand(_plateauService, width, height)
            };
        }

        private List<ICommand> ParseCreateMarsRoverCommand(string command)
        {
            var arguments = command.Split();
            var x = int.Parse(arguments[0]);
            var y = int.Parse(arguments[1]);
            var directionString = arguments[2];

            var direction = default(Direction);

            switch (directionString)
            {
                case "N":
                    direction = Direction.North;
                    break;
                case "S":
                    direction = Direction.South;
                    break;
                case "W":
                    direction = Direction.West;
                    break;
                case "E":
                    direction = Direction.East;
                    break;
            }
            return new List<ICommand>()
            {
                new CreateRoverCommand(_roverService,_plateauService,x,y,direction)
            };
        }
    }
}