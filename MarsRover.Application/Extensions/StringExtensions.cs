using System.Linq;

namespace MarsRover.Application.Extensions
{
    public static class StringExtensions
    {
        public static string[] ToStringArray(this string input)
        {
            return input.Replace(" ", "")
                        .ToLower()
                        .Select(x => x.ToString())
                        .ToArray();
        }
    }
}
