using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

using CBA_Test_ConsoleApp.Models;

namespace CBA_Test_ConsoleApp_UnitTest
{
    public class TestInputVariables
    {
        const string RuleFile_average_length_of_words_starting_with = "rule_average_length_of_words_starting_with_a.json";

        static JavaScriptSerializer js = new JavaScriptSerializer();

        public static List<string> TestInputWordsList = new List<string> {
            "aaa", "abc", "abcdefg",
            "bece", "beaa", "bcce",
            "cabcdefghijklmnopqr",
            "cccc", "abcde", "cc", "abcde"
        };

        public static RuleDefine rule_average_length_of_words_starting_with_a = js.Deserialize<RuleDefine>(File.ReadAllText(RuleFile_average_length_of_words_starting_with));



    }
}
