using MarsRover.Interfaces;
using MarsRover.Models;
using Microsoft.Extensions.Logging;
using System;

namespace MarsRover.Services
{
    public class RoverService : IRoverService
    {
        private readonly ILogger _logger;

        private RoverPositionModel _roverPositionModel;

        public RoverService(ILogger<RoverService> logger)
        {
            _logger = logger;
        }

        public void CreateMarsRover(RoverPositionModel roverPositionModel, IPlateauService plateauService)
        {
            var plateauModel = plateauService.GetCurrentPlateau();
            if (!IsValid(roverPositionModel, plateauModel))
            {
                var exception = new Exception("Mars rover position not valid");
                _logger.LogError(exception.Message);
                throw exception;
            }

            _roverPositionModel = new RoverPositionModel
            {
                X = roverPositionModel.X,
                Y = roverPositionModel.Y,
                Direction = roverPositionModel.Direction
            };

            plateauService.AddMarsRover(_roverPositionModel);
            _logger.LogInformation($"Created Mars Rover {_roverPositionModel.X}x{_roverPositionModel.Y} - {_roverPositionModel.Direction}.");
        }

        public void ChangePosition(RoverPositionModel roverPositionModel)
        {
            _roverPositionModel = roverPositionModel;
            _logger.LogInformation($"Rover Position is  {_roverPositionModel.X}x{_roverPositionModel.Y} - {_roverPositionModel.Direction}.");
        }
        private static bool IsValid(RoverPositionModel roverPositionModel, PlateauModel plateauModel)
        {
            var isValidX = roverPositionModel.X >= 0 && roverPositionModel.X <= plateauModel.Width;
            var isValidY = roverPositionModel.Y >= 0 && roverPositionModel.Y <= plateauModel.Height;
            return isValidX && isValidY;
        }

        public RoverPositionModel GetCurrentRover()
        {
            return _roverPositionModel;
        }
    }
}