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

        [TestMethod]
        public void NonValidNumbersTestUnit()
        {
             Assert.IsTrue(_romanTranslator.Execute(0) == "", "Zero doesn't exist in Roman schema");
            Assert.IsTrue(_romanTranslator.Execute(-10) == "", "Negative numbers don't exist in Roman schema");
        }

        [TestMethod]
        public void SpecialNumbersTestUnit()
        {
            Assert.IsTrue(_romanTranslator.Execute(1) == "I", "Not a valid translation!"); // TDD: works
            Assert.IsTrue(_romanTranslator.Execute(2) == "II", "Not a valid translation!"); // TDD: works
            Assert.IsTrue(_romanTranslator.Execute(3) == "III", "Not a valid translation!"); // TDD: works
            Assert.IsTrue(_romanTranslator.Execute(4) == "IV", "Not a valid translation!"); // TDD: works
            Assert.IsTrue(_romanTranslator.Execute(5) == "V", "Not a valid translation!"); // TDD: works
            Assert.IsTrue(_romanTranslator.Execute(6) == "VI", "Not a valid translation!"); // TDD: works
            Assert.IsTrue(_romanTranslator.Execute(7) == "VII", "Not a valid translation!"); // TDD: works
            Assert.IsTrue(_romanTranslator.Execute(8) == "VIII", "Not a valid translation!"); // TDD: works
            Assert.IsTrue(_romanTranslator.Execute(9) == "IX", "Not a valid translation!"); // TDD: works
            Assert.IsTrue(_romanTranslator.Execute(10) == "X", "Not a valid translation!"); // TDD: works
            Assert.IsTrue(_romanTranslator.Execute(11) == "XI", "Not a valid translation!"); // TDD: works
            Assert.IsTrue(_romanTranslator.Execute(12) == "XII", "Not a valid translation!"); // TDD: works
            Assert.IsTrue(_romanTranslator.Execute(13) == "XIII", "Not a valid translation!"); // TDD: works
            Assert.IsTrue(_romanTranslator.Execute(14) == "XIV", "Not a valid translation!"); // TDD: works
            Assert.IsTrue(_romanTranslator.Execute(18) == "XVIII", "Not a valid translation!"); // TDD: works
            Assert.IsTrue(_romanTranslator.Execute(19) == "XIX", "Not a valid translation!"); // TDD: works
            Assert.IsTrue(_romanTranslator.Execute(27) == "XXVII", "Not a valid translation!"); // TDD: works
            Assert.IsTrue(_romanTranslator.Execute(28) == "XXVIII", "Not a valid translation!"); // TDD: works
            Assert.IsTrue(_romanTranslator.Execute(29) == "XXIX", "Not a valid translation!"); // TDD: works
            Assert.IsTrue(_romanTranslator.Execute(30) == "XXX", "Not a valid translation!"); // TDD: works
            Assert.IsTrue(_romanTranslator.Execute(38) == "XXXVIII", "Not a valid translation!"); // TDD: works
            Assert.IsTrue(_romanTranslator.Execute(38) == "XXXVIII", "Not a valid translation!"); // TDD: works
            Assert.IsTrue(_romanTranslator.Execute(90) == "XC", "Not a valid translation!"); // TDD: working
            Assert.IsTrue(_romanTranslator.Execute(91) == "XCI", "Not a valid translation!"); // TDD: working
            Assert.IsTrue(_romanTranslator.Execute(92) == "XCII", "Not a valid translation!"); // TDD: working
            Assert.IsTrue(_romanTranslator.Execute(93) == "XCIII", "Not a valid translation!"); // TDD: working
            Assert.IsTrue(_romanTranslator.Execute(94) == "XCIV", "Not a valid translation!"); // TDD: working
            Assert.IsTrue(_romanTranslator.Execute(95) == "XCV", "Not a valid translation!"); // TDD: working
            Assert.IsTrue(_romanTranslator.Execute(98) == "XCVIII", "Not a valid translation!"); // TDD: working
            Assert.IsTrue(_romanTranslator.Execute(901) == "CMI", "Not a valid translation!"); // TDD: working
            Assert.IsTrue(_romanTranslator.Execute(2111) == "MMCXI", "Not a valid translation!"); // TDD: working
            Assert.IsTrue(_romanTranslator.Execute(3159) == "MMMCLIX", "Not a valid translation!"); // TDD: not working: result: MMMCLCIX
        }

    }
}
