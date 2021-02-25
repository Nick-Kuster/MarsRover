using MarsRover.Application.Enums;
using MarsRover.Application.Interfaces;
using MarsRover.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Application.Services
{
    public class RoverService : IRoverService
    {
        public void MoveRover(Rover rover, Grid grid, int numberOfMoves)
        {
            switch (rover.FacingDirection)
            {
                case CardinalDirections.North:
                    rover.CurrentLocation.YCoordinate += numberOfMoves;
                    break;
                case CardinalDirections.East:
                    rover.CurrentLocation.XCoordinate += numberOfMoves;
                    break;
                case CardinalDirections.South:
                    rover.CurrentLocation.YCoordinate -= numberOfMoves;
                    break;
                case CardinalDirections.West:
                    rover.CurrentLocation.XCoordinate -= numberOfMoves;
                    break;
                default:
                    throw new Exception("Rover facing direction is set to an invalid cardinal direction.");
            }
        }

        public void TurnRover(Rover rover, TurningDirections turnDirection, int numberOfTurns)
        {
            if(turnDirection == TurningDirections.Left)
            {
                rover.FacingDirection = 0 ? 3 : rover.FacingDirection - numberOfTurns
            }
            else if(turnDirection == TurningDirections.Right)
            {
                rover.FacingDirection += numberOfTurns;
            }
            else
            {
                throw new Exception("Invalid turn direction passed.");
            }
        }
    }
}
