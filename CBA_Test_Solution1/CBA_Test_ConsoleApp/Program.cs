using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CBA_Test_ConsoleApp.Models;

namespace CBA_Test_ConsoleApp
{
    class Program
    {
        public const ConsoleKey QUIT_KEY = ConsoleKey.Q;
        public const string PROMPT = "Press Q key to Exit.\r\nPress any key do another counting.";
        public const string PROMPT_REPLACE_INPUT = "The contents of InputTextFile.txt and RulesDefine.json can be replaced for do a new counting task.";

        static void Main(string[] args)
        {
            CountingRules countingRules = new CountingRules();

            string inputFileName = CountingRules.INPUT_FILE_NAME_DEFAULT;
            string rulesDefineFileName = CountingRules.RULES_DEFINE_FILE_NAME;

            do
            {
                try
                {
                    string inputStr = string.Empty;

                    if (!File.Exists(inputFileName))
                    {
                        Console.WriteLine(CountingRules.ERROR_NO_INPUT_FILE + " File name is " + inputFileName);
                        continue;
                    }
                    else
                    {
                        inputStr = File.ReadAllText(inputFileName);
                    }

                    RulesDefine inputRules = countingRules.ReadRulesFormFile(rulesDefineFileName);

                    var inputStrList = inputStr.Split(CountingRules.SEPARATOR, StringSplitOptions.RemoveEmptyEntries).ToList();

                    ProcessRulesResult processRulesResult = countingRules.ProcessRules(inputStrList, inputRules);

                    Console.WriteLine(processRulesResult.ToJsonStr());
                }
                catch (Exception e)
                {
                    Console.WriteLine(CountingRules.APPLICATION_EXCEPTION);
                    Console.WriteLine(e.ToString());
                }
                finally
                {
                    Console.WriteLine();
                    Console.WriteLine(PROMPT);
                    Console.WriteLine(PROMPT_REPLACE_INPUT);
                    Console.WriteLine();
                }

            } while (Console.ReadKey(true).Key != QUIT_KEY);

        }

    }
}
