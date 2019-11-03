using MarsRover.Enums;
using MarsRover.Interfaces;
using MarsRover.Models;
using MarsRover.Services.Rotate;
using System.Collections.Generic;

namespace MarsRover.Services
{
    public class DirectionService : IDirectionService
    {
        private readonly Dictionary<Direction, IRotateService> _directionService;

        public DirectionService()
        {
            _directionService = new Dictionary<Direction, IRotateService>
            {
                {Direction.North, new RotateNorthService()},
                {Direction.South, new RotateSouthService()},
                {Direction.West, new RotateWestService()},
                {Direction.East, new RotateEastService()}
            };
        }

        public RoverPositionModel Move(RoverPositionModel roverPositionModel)
        {
            return _directionService[roverPositionModel.Direction].Move(roverPositionModel);
        }

        public Direction Left(Direction direction)
        {
            return _directionService[direction].Left();
        }

        public Direction Right(Direction direction)
        {
            return _directionService[direction].Right();
        }
    }
}
