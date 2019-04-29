using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBA_Test_ConsoleApp.Models
{
    using StartCharsList = List<List<char>>;

    public class RulesDefine
    {
        public List<RuleDefine> Rules { get; set; }
    }

    //- The StartCharsList supports multi chars match. StartCharsList[i] match word[i].
    //- The FollowingWordsStartCharsList supports multi following words match.
    //  FollowingWordsStartCharsList[i] match word[i+1].

    public class RuleDefine
    {
        #region properties

        public string RuleName { get; set; }

        public string RuleTypeName { get; set; }

        public bool Enable { get; set; } = true;

        public StartCharsList StartCharsList { get; set; }

        public List<StartCharsList> FollowingWordsStartCharsList { get; set; }

        public List<char> CountTotalNumberChars { get; set; }

        public string OutputFileName { get; set; }

        #endregion

        #region functions

        public bool BasicValid()
        {
            return !(string.IsNullOrEmpty(RuleTypeName) || string.IsNullOrEmpty(OutputFileName));
        }

        #endregion
    }
}
