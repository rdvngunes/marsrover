using MarsRover.Enums;
using MarsRover.Interfaces;
using MarsRover.Models;

namespace MarsRover.Services.Rotate
{
    public class RotateSouthService : IRotateService
    {
        public RoverPositionModel Move(RoverPositionModel roverPositionModel)
        {
            roverPositionModel.Y -= 1;
            return roverPositionModel;
        }

        public Direction Left()
        {
            return Direction.East;
        }

        public Direction Right()
        {
            return Direction.West;
        }
    }
}
