using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using CBA_Test_ConsoleApp.Models;


namespace CBA_Test_ConsoleApp_UnitTest
{
    [TestClass]
    public class CountingRulesTest
    {

        [TestMethod]
        [DataRow(TestInputVariables.RulesDefineFileName_Test, 4)]
        public void TestMethod_ReadRulesFormFile(string rulesDefineFileName, int rulesCount)
        {
            CountingRules countingRules = new CountingRules();

            RulesDefine inputRules = countingRules.ReadRulesFormFile(rulesDefineFileName);

            Assert.AreEqual(rulesCount, inputRules.Rules.Count());
        }

        [TestMethod]
        [DataRow(TestInputVariables.RulesDefineFileName_Test, "Counting rule 1", "4.6")]
        [DataRow(TestInputVariables.RulesDefineFileName_Test, "Counting rule 2", "4")]
        [DataRow(TestInputVariables.RulesDefineFileName_Test, "Counting rule 3", "19")]
        [DataRow(TestInputVariables.RulesDefineFileName_Test, "Counting rule 4", "2")]
        public void TestMethod_GetMethodAndInvoke(string rulesDefineFileName, string ruleName, string expetedOutput)
        {
            var words = TestInputVariables.TestInputWordsList;

            CountingRules countingRules = new CountingRules();
            CountingMethods countingMethods = new CountingMethods();
            Type ICountingMethodsType = typeof(ICountingMethods);

            RulesDefine inputRules = countingRules.ReadRulesFormFile(rulesDefineFileName);

            var query = from r in inputRules.Rules
                        where r.RuleName == ruleName
                        select r;

            var rule = query.First();

            MethodInfo countingMethod = ICountingMethodsType.GetMethod(rule.RuleTypeName);

            RuleResult ruleResult = (RuleResult)countingMethod.Invoke(countingMethods, new object[] { words, rule });

            Assert.AreEqual(RuleResultCode.Success, ruleResult.ResultCode);
            Assert.AreEqual(expetedOutput, ruleResult.OutputStr());
        }
    }
}
