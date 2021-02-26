using MarsRover.Application.Enums;
using MarsRover.Application.Interfaces;
using MarsRover.Application.Models;
using MarsRover.Application.Extensions;
using MarsRover.Interfaces;
using MarsRover.ViewModels;
using System;
using System.Linq;

namespace MarsRover.Services
{
    public class CommandCenterService : ICommandCenterService
    {
        private readonly IRoverService _roverService;

        public CommandCenterService(IRoverService roverService)
        {
            _roverService = roverService;
        }

        public CommandCenterViewModel ExecuteCommands(CommandCenterViewModel model)
        {
            string[] roverOneStartingLocationArray = model.RoverOneStartingLocation?.ToStringArray();
            string[] roverOneCommandArray = model.RoverOneCommandString?.Select(x => x.ToString().ToLower()).ToArray();
            string[] roverTwoStartingLocationArray = model.RoverTwoStartingLocation?.ToStringArray();
            string[] roverTwoCommandArray = model.RoverTwoCommandString?.Select(x => x.ToString().ToLower()).ToArray();
            string[] gridCoordinateArray = model.GridInput?.ToStringArray();

            Rover roverOne = new Rover()
            {
                XCoordinate = Convert.ToInt32(roverOneStartingLocationArray[0]),
                YCoordinate = Convert.ToInt32(roverOneStartingLocationArray[1]),
                FacingDirection = ConvertStringToCardinalDirection(roverOneStartingLocationArray[2]),
                Command = roverOneCommandArray
            };

            Rover roverTwo = new Rover()
            {
                XCoordinate = Convert.ToInt32(roverTwoStartingLocationArray[0]),
                YCoordinate = Convert.ToInt32(roverTwoStartingLocationArray[1]),
                FacingDirection = ConvertStringToCardinalDirection(roverTwoStartingLocationArray[2]),
                Command = roverTwoCommandArray.Select(x => x.ToString()).ToArray()
            };

            int gridwidth = Convert.ToInt32(gridCoordinateArray[1]) + 1;
            int gridHeight = Convert.ToInt32(gridCoordinateArray[0]) + 1;

            roverOne = _roverService.ExecuteRoverCommands(roverOne, gridwidth, gridHeight);
            roverTwo = _roverService.ExecuteRoverCommands(roverTwo, gridwidth, gridHeight);

            model.RoverOneEndingLocation = $"{roverOne.XCoordinate} {roverOne.YCoordinate} {roverOne.FacingDirection}";
            model.RoverTwoEndingLocation = $"{roverTwo.XCoordinate} {roverTwo.YCoordinate} {roverTwo.FacingDirection}";

            return model;
        }

        private CardinalDirection ConvertStringToCardinalDirection(string input)
        {
            switch (input)
            {
                case "n":
                    return CardinalDirection.North;
                case "e":
                    return CardinalDirection.East;
                case "s":
                    return CardinalDirection.South;
                case "w":
                    return CardinalDirection.West;
                default:
                    throw new Exception("An invalid facing direction was entered.");
            }
        }
    }
}
