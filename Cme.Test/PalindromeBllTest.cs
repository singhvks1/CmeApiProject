using Cme.Bll;
using Cme.ClassLib.Abstracts;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace Cme.Test
{
    public class PalindromeBllTest
    {
        [Theory]
        [InlineData("Aba", false)]
        [InlineData("abab", false)]
        [InlineData("madam", true)]
        [InlineData("kayak", true)]       
        public void IsPalindromeTest(string input, bool result)
        {
            // Mock
            var dal = new Mock<IPalindromeDal>();
            dal.Setup(x => x.SaveResult(string.Empty, true));
            dal.Setup(x => x.GetPalindromeResults()).Returns(new Dictionary<string, bool>());

            // Arrange
            var bll = new PalindromeBll(dal.Object);
            var response = bll.IsPalindrome(input);
           
            // Assert           
            Assert.Equal(response, result);            
        }
    }
}
