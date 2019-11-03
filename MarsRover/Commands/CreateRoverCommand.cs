using MarsRover.Enums;
using MarsRover.Interfaces;
using MarsRover.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Commands
{
    public class CreateRoverCommand : ICommand
    {
        private readonly IRoverService _roverService;
        private readonly int _x;
        private readonly int _y;
        private readonly Direction _direction;
        private readonly IPlateauService _plateauService;


        public CreateRoverCommand(IRoverService roverService, IPlateauService plateauService, int x, int y, Direction direction)
        {
            _roverService = roverService;
            _x = x;
            _y = y;
            _direction = direction;
            _plateauService = plateauService;
        }

        public void Execute()
        {
            _roverService.CreateMarsRover(new RoverPositionModel(_x, _y, _direction), _plateauService);
        }
    }
}