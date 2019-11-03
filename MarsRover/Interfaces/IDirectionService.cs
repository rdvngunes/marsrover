using MarsRover.Enums;
using MarsRover.Models;

namespace MarsRover.Interfaces
{
    public interface IDirectionService
    {
        RoverPositionModel Move(RoverPositionModel roverPositionModel);
        Direction Left(Direction direction);
        Direction Right(Direction direction);

    }
}
