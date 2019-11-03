using MarsRover.Commands;
using MarsRover.Interfaces;
using MarsRover.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {

            ServiceProvider serviceProvider = new ServiceCollection()
                   .AddLogging()
                   .AddScoped<IPlateauService, PlateauService>()
                   .AddScoped<IRoverService, RoverService>()
                   .AddScoped<ICommandInvoker, CommandInvoker>()
                   .AddScoped<IDirectionService, DirectionService>()

                   .BuildServiceProvider();

            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });

            var commandStringBuilder = new StringBuilder();
            commandStringBuilder.AppendLine("5 5");
            commandStringBuilder.AppendLine("1 2 N");
            commandStringBuilder.AppendLine("LMLMLMLMM");
            commandStringBuilder.AppendLine("3 3 E");
            commandStringBuilder.Append("MMRMMRMRRM");

            var commandInvoker = serviceProvider.GetService<ICommandInvoker>();
            var plateau = serviceProvider.GetService<IPlateauService>();

            List<ICommand> commands = null;

            try
            {
                commands = commandInvoker.InvokeAll(commandStringBuilder.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            if (commands != null)
            {
                foreach (var command in commands)
                {
                    command.Execute();
                }

            }

            foreach (var roverPositionModel in plateau.GetMarsRovers())
            {
                Console.WriteLine($"{roverPositionModel.X}x{roverPositionModel.Y} - {roverPositionModel.Direction}");
            }
            Console.ReadLine();

        }
    }
}