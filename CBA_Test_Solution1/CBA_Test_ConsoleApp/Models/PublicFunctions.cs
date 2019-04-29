using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBA_Test_ConsoleApp.Models
{
    public static class PublicFunctions
    {
        public static bool IsWordMatchStartCharsList(string word, List<List<char>> startCharsList)
        {
            // check input
            if (string.IsNullOrEmpty(word) || null == startCharsList) return false;
            if (word.Length < startCharsList.Count() || 0 == startCharsList.Count()) return false;

            for (int i = 0; i < startCharsList.Count(); i++)
            {
                if (null == startCharsList[i]) return false;
                if (0 == startCharsList[i].Count()) return false;

                if (!startCharsList[i].Contains(word[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
