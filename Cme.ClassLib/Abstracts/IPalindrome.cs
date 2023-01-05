using System.Collections.Generic;

namespace Cme.ClassLib.Abstracts
{
    public interface IPalindromeDal
    {
        void SaveResult(string input, bool result);

        Dictionary<string, bool> GetPalindromeResults();
    }
}
