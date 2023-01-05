using System.Text.RegularExpressions;

namespace CmeApiProject.Common
{
    public static class Utilities
    {
        public static bool IsValidInput(string input)
        {
            var isValid = false;

            //Checking input start with space or number
            isValid = !Regex.IsMatch(input, "^[0-9\\s]");

            return isValid;
        }
    }
}
