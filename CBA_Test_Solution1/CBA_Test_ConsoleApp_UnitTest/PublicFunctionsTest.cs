using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using CBA_Test_ConsoleApp.Models;

namespace CBA_Test_ConsoleApp_UnitTest
{
    [TestClass]
    public class PublicFunctionsTest
    {
        [TestMethod]
        [DataRow("abcedf", "[ [\"a\", \"A\"] ]", true)]
        [DataRow("abcedf", "[ [\"a\", \"b\"] ]", true)]
        [DataRow("abcedf", "[ [\"b\", \"B\"] ]", false)]
        [DataRow("abcedf", "[ [\"a\", \"A\"], [\"b\", \"B\", \"c\"] ]", true)]
        [DataRow("abcedf", "[ [\"a\", \"A\"], [\"c\", \"C\"] ]", false)]
        [DataRow("abcedf", "[ [\"a\", \"A\"], [\"b\", \"B\"], [\"c\", \"C\"] ]", true)]
        [DataRow("ab", "[ [\"a\", \"A\"], [\"b\", \"B\"], [\"c\", \"C\"] ]", false)]
        public void TestMethod_IsWordMatchStartCharsList(string word, string startCharsListStr, bool expected)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<List<char>> startCharsList = js.Deserialize<List<List<char>>>(startCharsListStr);
            
            bool result = PublicFunctions.IsWordMatchStartCharsList(word, startCharsList);

            Assert.AreEqual(expected, result);
        }
    }
}
