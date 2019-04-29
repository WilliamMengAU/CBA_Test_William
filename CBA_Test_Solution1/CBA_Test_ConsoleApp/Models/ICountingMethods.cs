using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBA_Test_ConsoleApp.Models
{
    public interface ICountingMethods
    {
        RuleResult average_length_of_words_starting_with_chars(List<string> words, RuleDefine rule);
        RuleResult count_of_char_in_words_starting_with_chars(List<string> words, RuleDefine rule);
        RuleResult longest_words_starting_with_chars(List<string> words, RuleDefine rule);
        RuleResult count_of_sequence_of_words_starting_with_chars_list(List<string> words, RuleDefine rule);
    }
}
