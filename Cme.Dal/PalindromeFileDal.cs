using Cme.ClassLib.Abstracts;
using System;
using System.Collections.Generic;
using System.IO;

namespace Cme.Dal
{
    public class PalindromeFileDal : IPalindromeDal
    {
        private readonly string _fullFileName;

        public PalindromeFileDal()
        {
            _fullFileName = Path.Combine(Environment.CurrentDirectory, "PalindromeLog.txt");
        }

        public Dictionary<string, bool> GetPalindromeResults()
        {
            var data = new Dictionary<string, bool>();

            if (File.Exists(_fullFileName))
            {
                string[] palindromeResults = File.ReadAllLines(_fullFileName);

                foreach (string result in palindromeResults)
                {
                    var temp = result.Split(',');

                    if (!data.ContainsKey(temp[0]))
                    {
                        data.Add(temp[0], Convert.ToBoolean(temp[1]));
                    }
                }
            }            

            return data;
        }

        public void SaveResult(string input, bool result)
        {
            using (StreamWriter sw = File.AppendText(_fullFileName))
            {
                sw.WriteLine(input + "," + result);                
            }
        }
    }
}
