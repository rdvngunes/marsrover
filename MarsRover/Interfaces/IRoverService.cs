using MarsRover.Models;

namespace MarsRover.Interfaces
{
    public interface IRoverService
    {
        void CreateMarsRover(RoverPositionModel roverPositionModel, IPlateauService plateauService);
        RoverPositionModel GetCurrentRover();
        void ChangePosition(RoverPositionModel roverPositionModel);

    }
}