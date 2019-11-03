using MarsRover.Commands;
using System.Collections.Generic;

namespace MarsRover.Interfaces
{
    public interface ICommandInvoker
    {
        List<ICommand> InvokeAll(string commandString);
    }
}