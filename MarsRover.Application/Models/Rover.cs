using MarsRover.Application.Enums;
using System;

namespace MarsRover.Application.Models
{
    public class Rover
    {
        public Guid ID { get; set; }
        public CardinalDirections FacingDirection { get; set; }
        public Location CurrentLocation { get; set; }
    }
}
