using MarsRover.Application.Enums;
using MarsRover.Application.Interfaces;
using MarsRover.Application.Models;
using System;

namespace MarsRover.Application.Services
{
    public class RoverService : IRoverService
    {
        public Rover ExecuteRoverCommands(Rover inputRover, int gridWidth, int gridHeight)
        {
            foreach(var input in inputRover.Command)
            {
                if(input == "m")
                {
                    MoveRover(inputRover, gridWidth, gridHeight);
                }
                if(input == "l" || input == "r")
                {
                    TurningDirection direction = ConvertStringToTurningDirection(input);
                    TurnRover(inputRover, direction);
                }
            }
            return inputRover;
        }

        private void MoveRover(Rover rover, int gridWidth, int gridHeight)
        {
            if (ValidateMovement(rover, gridWidth, gridHeight))
            {
                switch (rover.FacingDirection)
                {
                    case CardinalDirection.North:
                        rover.YCoordinate++;
                        break;
                    case CardinalDirection.East:
                        rover.XCoordinate++;
                        break;
                    case CardinalDirection.South:
                        rover.YCoordinate--;
                        break;
                    case CardinalDirection.West:
                        rover.XCoordinate--;
                        break;
                    default:
                        throw new Exception("Rover facing direction is set to an invalid cardinal direction.");
                }
            }
            else
            {
                throw new Exception($"Could not move rover to coordinate specified");
            }
        }

        private void TurnRover(Rover rover, TurningDirection turnDirection)
        {
            if (turnDirection == TurningDirection.Left)
            {
                if(rover.FacingDirection == CardinalDirection.North)
                {
                    rover.FacingDirection = CardinalDirection.West;
                }
                else
                {
                    rover.FacingDirection -= 1;
                }
            }
            else if (turnDirection == TurningDirection.Right)
            {
                if (rover.FacingDirection == CardinalDirection.West)
                {
                    rover.FacingDirection = CardinalDirection.North;
                }
                else
                {
                    rover.FacingDirection += 1;
                }
            }
            else
            {
                throw new Exception("Invalid turn direction passed.");
            }
        }

        private TurningDirection ConvertStringToTurningDirection(string input)
        {
            switch (input)
            {
                case "l":
                    return TurningDirection.Left;
                case "r":
                    return TurningDirection.Right;
                default:
                    throw new Exception("Invalid turning direction found.");
            }
        }

        private bool ValidateMovement(Rover rover, int gridWidth, int gridHeight)
        {
            bool valid = true;
            switch (rover.FacingDirection)
            {
                case CardinalDirection.North:
                    if (rover.YCoordinate + 1 > gridHeight)
                    {
                        valid = false;
                    };
                    break;
                case CardinalDirection.East:
                    if (rover.XCoordinate + 1 > gridWidth)
                    {
                        valid = false;
                    };
                    break;
                case CardinalDirection.South:
                    if (rover.YCoordinate - 1 < 0)
                    {
                        valid = false;
                    };
                    break;
                case CardinalDirection.West:
                    if (rover.YCoordinate - 1 < 0)
                    {
                        valid = false;
                    };
                    break;
                default:
                    break;
            }

            return valid;
        }    
    }
}
