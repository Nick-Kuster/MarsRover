using MarsRover.Application.Enums;
using MarsRover.Application.Models;
using System.Collections.Generic;

namespace MarsRover.Application.Interfaces
{
    public interface IRoverService
    {
        Rover ExecuteRoverCommands(Rover inputRover, int gridWidth, int gridHeight);
    }
}
