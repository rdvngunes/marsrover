using MarsRover.Enums;
using MarsRover.Interfaces;
using MarsRover.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Services.Rotate
{
    public class RotateEastService : IRotateService
    {
        public RoverPositionModel Move(RoverPositionModel roverPositionModel)
        {
            roverPositionModel.X += 1;
            return roverPositionModel;
        }

        public Direction Left()
        {
            return Direction.North;
        }

        public Direction Right()
        {
            return Direction.South;
        }
    }
}
