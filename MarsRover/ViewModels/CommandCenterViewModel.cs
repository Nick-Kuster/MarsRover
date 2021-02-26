using System.ComponentModel.DataAnnotations;

namespace MarsRover.ViewModels
{
    public class CommandCenterViewModel
    {
        [Required]
        [RegularExpression("[0-9]\\s?[0-9]", ErrorMessage = "Please enter only 2 digits.")]
        [Display(Name = "Grid Input")]
        public string GridInput { get; set; }

        [Required]
        [RegularExpression("(?i)[0-9]\\s?[0-9]\\s?[nesw]", ErrorMessage = "Please use only 2 digits and cardinal direction letters ('n', 'e', 's', 'w')")]
        [Display(Name = "Rover 1 Starting Location")]
        public string RoverOneStartingLocation { get; set; }

        [Required]
        [RegularExpression("(?i)[mrl ]*", ErrorMessage = "Please use only commands 'm', 'r', and 'l'")]
        [Display(Name = "Rover 1 Command String")]
        public string RoverOneCommandString { get; set; }

        [Required]
        [RegularExpression("(?i)[0-9]\\s?[0-9]\\s?[nesw]", ErrorMessage = "Please use only 2 digits and cardinal direction letters ('n', 'e', 's', 'w')")]
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
