using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Application.Models
{
    public class Grid
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public List<Rover> Rovers { get; set; }
    }
}
