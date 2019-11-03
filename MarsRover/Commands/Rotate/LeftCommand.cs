using MarsRover.Interfaces;

namespace MarsRover.Commands.Rotate
{
    public class LeftCommand : ICommand
    {
        private readonly IRoverService _roverService;
        private readonly IDirectionService _directionService;

        public LeftCommand(IRoverService marsRoverService, IDirectionService directionManagerStrategy)
        {
            _roverService = marsRoverService;
            _directionService = directionManagerStrategy;
        }
        public void Execute()
        {
            var roverPosition = _roverService.GetCurrentRover();
            roverPosition.Direction = _directionService.Left(roverPosition.Direction);
            _roverService.ChangePosition(roverPosition);
        }
    }
}