using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using CBA_Test_ConsoleApp.Models;

namespace CBA_Test_ConsoleApp_UnitTest
{
    [TestClass]
    public class ICountingMethodsTest
    {
        [TestMethod]
        public void TestMethod_average_length_of_words_starting_with_chars()
        {
            ICountingMethods iCountingMethods = new CountingMethods();

            RuleResult ruleResult = iCountingMethods.average_length_of_words_starting_with_chars(
                TestInputVariables.TestInputWordsList,
                TestInputVariables.rule_average_length_of_words_starting_with_a
                );

            Assert.AreEqual(RuleResultCode.Success, ruleResult.ResultCode);
            Assert.AreEqual("4.6", ruleResult.OutputStr());
        }
    }
}
