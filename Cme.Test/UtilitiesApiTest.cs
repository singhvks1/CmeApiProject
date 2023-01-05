using CmeApiProject.Common;
using Xunit;

namespace Cme.Test
{
    public class UtilitiesApiTest
    {
        [Theory]
        [InlineData(" abab", false)]
        [InlineData("9madam", false)]
        [InlineData("Aba", true)]
        [InlineData("kayak", true)]
        public void IsValidInputTest(string input, bool result)
        {
            // Arrange       
            var response = Utilities.IsValidInput(input);

            // Assert           
            Assert.Equal(response, result);
        }
    }
}
