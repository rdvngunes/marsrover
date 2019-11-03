using MarsRover.Enums;
using MarsRover.Interfaces;
using MarsRover.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Services.Rotate
{
    public class RotateNorthService : IRotateService
    {
        public RoverPositionModel Move(RoverPositionModel roverPositionModel)
        {
            roverPositionModel.Y += 1;
            return roverPositionModel;
        }

        public Direction Left()
        {
            return Direction.West;
        }

        public Direction Right()
        {
            return Direction.East;
        }

    }
}
