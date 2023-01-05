using Cme.ClassLib.Abstracts;
using System.Collections.Generic;
using System.Linq;

namespace Cme.Bll
{
    public class PalindromeBll
    {
        private IPalindromeDal _palindromeDal;

        public PalindromeBll(IPalindromeDal dal)
        {
            _palindromeDal = dal;
        }

        public bool IsPalindrome(string input)
        {
            bool result = true;

            for (int i = 0, j = input.Count() - 1; i < j; i++, j--)
            {
                if (input[i] != input[j])
                {
                    result = false;
                    break;
                }
            }

            _palindromeDal.SaveResult(input, result);

            return result;
        }

        public Dictionary<string, bool> GetPalindromeResults()
        {
            return _palindromeDal.GetPalindromeResults();
        }
    }
}
