using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBA_Test_ConsoleApp.Models
{
    public class CountingMethods : ICountingMethods
    {
        public RuleResult average_length_of_words_starting_with_chars(List<string> words, RuleDefine rule)
        {
            RuleResult result = new RuleResult();

            // check input
            bool inputValid = true;
            if (null == words || null == rule) inputValid = false;
            else if (0 == words.Count() || !rule.BasicValid() || null == rule.StartCharsList) inputValid = false;
            else if (0 == rule.StartCharsList.Count()) inputValid = false;

            if (!inputValid)
            {
                result.ResultCode = RuleResultCode.Error;
                result.Message = CountingRules.INPUT_RULE_ERROR;
                return result;
            }

            int totalLength = 0;
            int wordsCount = 0;

            var startCharsList = rule.StartCharsList;

            foreach (var word in words)
            {
                if (PublicFunctions.IsWordMatchStartCharsList(word, startCharsList))
                {
                    totalLength += word.Length;
                    wordsCount++;
                }
            }

            result.ResultCode = RuleResultCode.Success;

            if (wordsCount > 0) result.Value = totalLength / (float)wordsCount;
            else result.Value = 0;

            return result;
        }

        public RuleResult count_of_char_in_words_starting_with_chars(List<string> words, RuleDefine rule)
        {
            RuleResult result = new RuleResult();

            // check input
            bool inputValid = true;
            if (null == words || null == rule) inputValid = false;
            else if (0 == words.Count() || !rule.BasicValid() || null == rule.StartCharsList || null == rule.CountTotalNumberChars) inputValid = false;
            else if (0 == rule.StartCharsList.Count() || 0 == rule.CountTotalNumberChars.Count()) inputValid = false;

            if (!inputValid)
            {
                result.ResultCode = RuleResultCode.Error;
                result.Message = CountingRules.INPUT_RULE_ERROR;
                return result;
            }

            int charCount = 0;

            var startCharsList = rule.StartCharsList;

            foreach (var word in words)
            {
                if (PublicFunctions.IsWordMatchStartCharsList(word, startCharsList))
                {
                    foreach (var c in word)
                    {
                        if (rule.CountTotalNumberChars.Contains(c))
                        {
                            charCount++;
                        }
                    }
                }
            }

            result.ResultCode = RuleResultCode.Success;
            result.Value = charCount;

            return result;
        }

        public RuleResult count_of_sequence_of_words_starting_with_chars_list(List<string> words, RuleDefine rule)
        {
            RuleResult result = new RuleResult();

            // check input
            bool inputValid = true;
            if (null == words || null == rule) inputValid = false;
            else if (0 == words.Count() || !rule.BasicValid() || null == rule.StartCharsList || null == rule.FollowingWordsStartCharsList) inputValid = false;
            else if (0 == rule.StartCharsList.Count() || 0 == rule.FollowingWordsStartCharsList.Count()) inputValid = false;

            if (!inputValid)
            {
                result.ResultCode = RuleResultCode.Error;
                result.Message = CountingRules.INPUT_RULE_ERROR;
                return result;
            }

            int countSequence = 0;

            var startCharsList = rule.StartCharsList;
            var FollowingWordsStartCharsList = rule.FollowingWordsStartCharsList;

            for (int i = 0; i < words.Count() - FollowingWordsStartCharsList.Count(); i++)
            {
                if (PublicFunctions.IsWordMatchStartCharsList(words[i], startCharsList))
                {
                    bool followinMatch = true;

                    for (int j = 0; j <  FollowingWordsStartCharsList.Count(); j++)
                    {
                        if (!PublicFunctions.IsWordMatchStartCharsList(words[i+1+j], FollowingWordsStartCharsList[j]))
                        {
                            followinMatch = false;
                        }
                    }

                    if (followinMatch) countSequence++;
                }
            }

            result.ResultCode = RuleResultCode.Success;
            result.Value = countSequence;

            return result;
        }

        public RuleResult longest_words_starting_with_chars(List<string> words, RuleDefine rule)
        {
            RuleResult result = new RuleResult();

            // check input
            bool inputValid = true;
            if (null == words || null == rule) inputValid = false;
            else if (0 == words.Count() || !rule.BasicValid() || null == rule.StartCharsList) inputValid = false;
            else if (0 == rule.StartCharsList.Count()) inputValid = false;

            if (!inputValid)
            {
                result.ResultCode = RuleResultCode.Error;
                result.Message = CountingRules.INPUT_RULE_ERROR;
                return result;
            }

            int longest = 0;

            var startCharsList = rule.StartCharsList;

            foreach (var word in words)
            {
                if (PublicFunctions.IsWordMatchStartCharsList(word, startCharsList))
                {
                    longest = Math.Max(longest, word.Length);
                }
            }

            result.ResultCode = RuleResultCode.Success;
            result.Value = longest;

            return result;
        }

    }
}
