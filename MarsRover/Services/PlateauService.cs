using MarsRover.Interfaces;
using MarsRover.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace MarsRover.Services
{
    public class PlateauService : IPlateauService
    {
        private PlateauModel _plateauModel;
        private readonly ILogger _logger;
        private List<RoverPositionModel> _roverPositionModels;

        public PlateauService(ILogger<PlateauService> logger)
        {
            _logger = logger;
        }

        public void Create(int width, int height)
        {
            var plateauModel = new PlateauModel
            {
                Width = width,
                Height = height
            };

            if (!IsValid(plateauModel))
            {
                var exception = new Exception("Plateau size not valid");
                _logger.LogError(exception.Message);
                throw exception;
            }

            _roverPositionModels = new List<RoverPositionModel>();
            _plateauModel = plateauModel;

            _logger.LogInformation($"Created plateau {width}x{height}");
        }

        public void AddMarsRover(RoverPositionModel roverPositionModel)
        {
            _roverPositionModels.Add(roverPositionModel);
        }

        public List<RoverPositionModel> GetMarsRovers()
        {
            return _roverPositionModels;
        }
        public PlateauModel GetCurrentPlateau()
        {
            return _plateauModel;
        }
        private static bool IsValid(PlateauModel plateauModel)
        {
            return plateauModel.Width > 0 && plateauModel.Height > 0;
        }
    }
}
