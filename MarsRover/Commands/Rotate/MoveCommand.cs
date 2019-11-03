using MarsRover.Interfaces;

namespace MarsRover.Commands.Rotate
{
    public class MoveCommand : ICommand
    {

        private readonly IRoverService _roverService;
        private readonly IDirectionService _directionService;

        public MoveCommand(IRoverService marsRoverService, IDirectionService directionManagerStrategy)
        {
            _roverService = marsRoverService;
            _directionService = directionManagerStrategy;
        }

        public void Execute()
        {
            var roverPosition = _roverService.GetCurrentRover();
            _directionService.Move(roverPosition);
            _roverService.ChangePosition(roverPosition);
        }
    }
}