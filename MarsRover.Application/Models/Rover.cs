using MarsRover.Application.Enums;

namespace MarsRover.Application.Models
{
    public class Rover
    {
        public CardinalDirection FacingDirection { get; set; }
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public string[] Command { get; set; }
    }
}
