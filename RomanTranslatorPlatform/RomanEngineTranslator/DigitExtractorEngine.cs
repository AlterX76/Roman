using DigitExtractorEngine.Interfaces;
using System;


namespace DigitExtractorEngine
{
    // Controller to elaborate digits
    public sealed class DigitExtractorEngine
    {
        /// <summary>
        ///  Static function to parse a string searching for number and execute custom operation
        /// </summary>
        /// <param name="text">string to be scanned</param>
        /// <param name="task">plugin that will handle each digit found in the string</param>
        static void Parse(String text, IBaseDigitPlugin task)
        {

        }
    }
}
