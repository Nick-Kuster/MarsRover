using System;
using MarsRover.Application.Interfaces;
using MarsRover.Application.Models;
using MarsRover.Application.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRover.Application.Test
{
    [TestClass]
    public class RoverServiceUnitTests
    {
        private IRoverService _roverService;
        public RoverServiceUnitTests()
        {
            _roverService = new RoverService();
        }

        [TestMethod]
        [DataRow()]
        public void TestMethod1(int startX, int startY)
        {
            Rover rover = new Rover()
            {

            };
        }
    }
}
