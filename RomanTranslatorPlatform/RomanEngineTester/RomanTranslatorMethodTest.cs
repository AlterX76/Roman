using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

using DigitExtractorEngine.Plugins;

namespace RomanEngineTester
{
    /// <summary>
    /// Unit tests for the pure translator from digits to Roman numerals
    /// </summary>
    [TestClass]
    public class RomanTranslatorMethodTest
    {
        RomanNumeralPlugin _romanTranslator = new RomanNumeralPlugin();
        /// <summary>
        /// Very basic test just translating and checking the array values
        /// </summary>
        [TestMethod]
        public void BaseTestUnit()
        {
            foreach (KeyValuePair<int, String> item in RomanNumeralPlugin.RomanNumeralMap)
            {
                Assert.AreSame(_romanTranslator.Execute(item.Key), item.Value);
            }
        }

        /// <summary>
        /// sum of all main numbers to result as "MDCLXVI"
        /// </summary>
        /// <remarks>
        /// Source: http://win.sinapsi.org/public/ConversioneNumeriRomani.htm
        /// 
        /// NOTE: nice testing would get digits and compare elaborations coming from our function and the engine from URL
        /// </remarks>
        [TestMethod]
        public void TotalNumbersTestUnit()
        {
            int total = 0;
            foreach (KeyValuePair<int, String> item in RomanNumeralPlugin.RomanNumeralMap)
                total += item.Key;
            Assert.IsTrue(_romanTranslator.Execute(total) == "MDCLXVI", "Total base value is not \"MDCLXVI\"");
        }
    }
}
