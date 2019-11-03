using MarsRover.Models;
using System.Collections.Generic;

namespace MarsRover.Interfaces
{
    public interface IPlateauService
    {
        void Create(int width, int height);
        PlateauModel GetCurrentPlateau();
        List<RoverPositionModel> GetMarsRovers();
        void AddMarsRover(RoverPositionModel roverPositionModel);

    }
}
