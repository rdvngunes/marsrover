using MarsRover.Interfaces;

namespace MarsRover.Commands.Rotate
{
    public class RightCommand : ICommand
    {
        private readonly IRoverService _roverService;
        private readonly IDirectionService _directionService;

        public RightCommand(IRoverService marsRoverService, IDirectionService directionManagerStrategy)
        {
            _roverService = marsRoverService;
            _directionService = directionManagerStrategy;
        }

        public void Execute()
        {
            var roverPosition = _roverService.GetCurrentRover();
            roverPosition.Direction = _directionService.Right(roverPosition.Direction);
            _roverService.ChangePosition(roverPosition);
        }
    }
}