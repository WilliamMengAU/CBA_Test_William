using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace CBA_Test_ConsoleApp.Models
{
    public class CountingRules
    {
        public const string RULES_DEFINE_FILE_NAME = "RulesDefine.json";
        public const string INPUT_FILE_NAME_DEFAULT = "InputTextFile.txt";

        public const string ERROR_NO_INPUT_FILE = "The input file is not found. Please check it.";
        public const string UNSUPPORTED_METHOD = "Unsupported method: ";
        public const string INPUT_RULE_ERROR = "Input rule error.";
        public const string APPLICATION_EXCEPTION = "Application Exception error.";

        public static readonly char[] SEPARATOR = new char[] { ' ', '\r', '\n', ',', '.', '(', ')', '{', '}', '/' };

        readonly ICountingMethods countingMethods;

        public CountingRules()
        {
            countingMethods = new CountingMethods();
        }

        public CountingRules(ICountingMethods countingMethods)
        {
            this.countingMethods = countingMethods;
        }

        public RulesDefine ReadRulesFormFile(string fileName = RULES_DEFINE_FILE_NAME)
        {
            RulesDefine inputRules = new RulesDefine();

            try
            {
                if (File.Exists(fileName))
                {
                    string inputStr = File.ReadAllText(fileName);

                    JavaScriptSerializer js = new JavaScriptSerializer();
                    inputRules = js.Deserialize<RulesDefine>(inputStr);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return inputRules;
        }

        public RulesDefine ReadRulesFormStr(string inputStr)
        {
            RulesDefine inputRules = new RulesDefine();

            try
            {
                if (!string.IsNullOrEmpty(inputStr))
                {
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    inputRules = js.Deserialize<RulesDefine>(inputStr);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return inputRules;
        }

        public ProcessRulesResult ProcessRules(List<string> words, RulesDefine inputRules)
        {
            ProcessRulesResult processRulesResult = new ProcessRulesResult();

            // input check
            if (null == words || null == inputRules) return processRulesResult;
            if (0 == words.Count() || null == inputRules.Rules) return processRulesResult;

            Type ICountingMethodsType = typeof(ICountingMethods);

            foreach (var rule in inputRules.Rules)
            {
                bool validRule = true;

                try
                {
                    if (null == rule) validRule = false;
                    else if (!rule.BasicValid()) validRule = false;

                    if (!rule.Enable)
                    {
                        processRulesResult.TotalDisabledRules++;
                        continue;
                    }

                    if (!validRule)
                    {
                        processRulesResult.TotalFailedRules++;
                        continue;
                    }

                    MethodInfo countingMethod = ICountingMethodsType.GetMethod(rule.RuleTypeName);

                    RuleResult ruleResult = new RuleResult();

                    if (null == countingMethod)
                    {
                        ruleResult.ResultCode = RuleResultCode.Error;
                        ruleResult.Message = UNSUPPORTED_METHOD + rule.RuleTypeName;
                    }
                    else
                    {
                        ruleResult = (RuleResult)countingMethod.Invoke(countingMethods, new object[] { words, rule });
                    }

                    Console.WriteLine(rule.RuleName + " --- " + ruleResult.ToJsonStr());

                    File.WriteAllText(rule.OutputFileName, ruleResult.OutputStr());

                    if (ruleResult.ResultCode == RuleResultCode.Success) processRulesResult.TotalSuccessRules++;
                    else processRulesResult.TotalFailedRules++;
                }
                catch (Exception e)
                {
                    processRulesResult.TotalFailedRules++;

                    Console.WriteLine(rule.RuleName + " --- ");
                    Console.WriteLine(CountingRules.APPLICATION_EXCEPTION);
                    Console.WriteLine(e.ToString());
                }
                finally
                {
                    processRulesResult.TotalRules++;
                }
            }

            int enabledRulesCount = processRulesResult.TotalRules - processRulesResult.TotalDisabledRules;

            if (enabledRulesCount == processRulesResult.TotalSuccessRules) processRulesResult.ResultCode = ProcessRulesResultCode.Success;
            else if(enabledRulesCount == processRulesResult.TotalFailedRules) processRulesResult.ResultCode = ProcessRulesResultCode.AllFailed;
            else processRulesResult.ResultCode = ProcessRulesResultCode.PartlyError;

            return processRulesResult;
        }

    }
}
