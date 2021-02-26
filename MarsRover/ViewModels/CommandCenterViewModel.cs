using System.ComponentModel.DataAnnotations;

namespace MarsRover.ViewModels
{
    public class CommandCenterViewModel
    {
        [Required]
        [RegularExpression("\\d+\\s\\d+", ErrorMessage = "Please enter only 2 digits separated by a space.")]
        [Display(Name = "Grid Input")]
        public string GridInput { get; set; }

        [Required]
        [RegularExpression("(?i)\\d+\\s\\d+\\s?[nesw]", ErrorMessage = "Please use only 2 digits and cardinal direction letters ('n', 'e', 's', 'w') separated by a space")]
        [Display(Name = "Rover 1 Starting Location")]
        public string RoverOneStartingLocation { get; set; }

        [Required]
        [RegularExpression("(?i)[mrl ]*", ErrorMessage = "Please use only commands 'm', 'r', and 'l' separated by a space")]
        [Display(Name = "Rover 1 Command String")]
        public string RoverOneCommandString { get; set; }

        [Required]
        [RegularExpression("(?i)\\d+\\s\\d+\\s[nesw]", ErrorMessage = "Please use only 2 digits and cardinal direction letters ('n', 'e', 's', 'w') separated by a space")]
        [Display(Name = "Rover 2 Starting Location")]
        public string RoverTwoStartingLocation { get; set; }

        [Required]
        [RegularExpression("(?i)[mrl ]*", ErrorMessage = "Please use only commands 'm', 'r', and 'l'")]
        [Display(Name = "Rover 2 Command String")]
        public string RoverTwoCommandString { get; set; }

        public string RoverOneEndingLocation { get; set; }
        public string RoverTwoEndingLocation { get; set; }
    }
}
