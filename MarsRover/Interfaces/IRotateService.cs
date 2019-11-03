using MarsRover.Enums;
using MarsRover.Models;

namespace MarsRover.Interfaces
{
    public interface IRotateService
    {
        RoverPositionModel Move(RoverPositionModel roverPositionModel);

        public Direction Left();
        public Direction Right();
    }
}
