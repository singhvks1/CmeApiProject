using Cme.Bll;
using CmeApiProject.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Threading.Tasks;

namespace CmeApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PalindromeController : ControllerBase
    {
        private IMemoryCache _cache;
        private readonly PalindromeBll _palindromeBll;

        public PalindromeController(IMemoryCache cache, PalindromeBll bll)
        {
            _cache = cache;
            _palindromeBll = bll;
        }

        // Testing URL example - https://localhost:44301/api/Palindrome?username=vijay&input=aba
        [HttpGet]
        public async Task<IActionResult> CheckPalindrome(string userName, string input)
        {
            if(!Utilities.IsValidInput(input))
            {
                return NotFound("Invalid input string");
            }

            if (! _cache.TryGetValue(input, out bool isPalindrome))
            {
                isPalindrome = _palindromeBll.IsPalindrome(input);
                _cache.Set(input, isPalindrome);
            }

            return Ok(isPalindrome); 
        }
    }
}
