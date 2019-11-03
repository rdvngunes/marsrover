using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Commands
{
    public interface ICommand
    {
        void Execute();
    }
}