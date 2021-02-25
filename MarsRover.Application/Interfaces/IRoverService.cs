using MarsRover.Application.Enums;
using MarsRover.Application.Models;

namespace MarsRover.Application.Interfaces
{
    public interface IRoverService
    {
        void MoveRover(Rover rover, Grid grid, int numberOfMoves);
        void TurnRover(Rover rover, TurningDirections turnDirection, int numberOfTurns);
    }
}
