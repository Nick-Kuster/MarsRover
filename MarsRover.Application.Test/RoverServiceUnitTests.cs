using System;
using Shouldly;
using MarsRover.Application.Enums;
using MarsRover.Application.Interfaces;
using MarsRover.Application.Models;
using MarsRover.Application.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRover.Application.Extensions;

namespace MarsRover.Application.Test
{
    [TestClass]
    public class RoverServiceUnitTests
    {
        private IRoverService _roverService;
        private Rover _roverOne;
        private Rover _roverTwo;

        public RoverServiceUnitTests()
        {
            _roverService = new RoverService();
            _roverOne = new Rover()
            {
                XCoordinate = 1,
                YCoordinate = 2,
                FacingDirection = CardinalDirection.North
            };

            _roverTwo = new Rover()
            {
                XCoordinate = 3,
                YCoordinate = 3,
                FacingDirection = CardinalDirection.East
            };
        }

        [TestMethod]
        [DataRow("LMLMLMLMM", 1, 3, CardinalDirection.North)]
        [DataRow("LMLMLMLMMM", 1, 4, CardinalDirection.North)]
        [DataRow("LMLMLMLMML", 1, 3, CardinalDirection.West)]
        [DataRow("LMLMLMLMMR", 1, 3, CardinalDirection.East)]
        public void ExecuteRoverCommands_RoverOneInput_ShouldReturnCorrectPosition(string roverOneCommand, int endingX, int endingY, CardinalDirection endingDirection)
        {
            _roverOne.Command = roverOneCommand.ToStringArray();
            _roverOne = _roverService.ExecuteRoverCommands(_roverOne, 6, 6);
            _roverOne.XCoordinate.ShouldBe(endingX);
            _roverOne.YCoordinate.ShouldBe(endingY);
            _roverOne.FacingDirection.ShouldBe(endingDirection);
        }

        [TestMethod]
        [DataRow("MMRMMRMRRM", 5, 1, CardinalDirection.East)]
        [DataRow("MMRMMRMRRMM", 6, 1, CardinalDirection.East)]
        [DataRow("MMRMMRMRRML", 5, 1, CardinalDirection.North)]
        [DataRow("MMRMMRMRRMR", 5, 1, CardinalDirection.South)]
        public void ExecuteRoverCommands_RoverTwoInput_ShouldReturnCorrectPosition(string roverOneCommand, int endingX, int endingY, CardinalDirection endingDirection)
        {
            _roverTwo.Command = roverOneCommand.ToStringArray();
            _roverTwo = _roverService.ExecuteRoverCommands(_roverTwo, 6, 6);
            _roverTwo.XCoordinate.ShouldBe(endingX);
            _roverTwo.YCoordinate.ShouldBe(endingY);
            _roverTwo.FacingDirection.ShouldBe(endingDirection);
        }
        
        [TestMethod]
        [DataRow("MMRMMRMRRMMMMM")]
        [DataRow("MMRMMRMRRMMMMM")]
        public void ExecuteRoverCommands_InvalidMovement_ShouldThrowError(string roverOneCommand)
        {
            _roverTwo.Command = roverOneCommand.ToStringArray();
            Should.Throw<Exception>(() => _roverService.ExecuteRoverCommands(_roverTwo, 3, 3));
            
        }
    }
}
