using MarsRover.Enums;
using MarsRover.Interfaces;
using MarsRover.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Services.Rotate
{
    public class RotateWestService : IRotateService
    {
        public RoverPositionModel Move(RoverPositionModel roverPositionModel)
        {

            roverPositionModel.X -= 1;
            return roverPositionModel;
        }

        public Direction Left()
        {
            return Direction.South;
        }

        public Direction Right()
        {
            return Direction.North;
        }
    }
}
