using System;
using System.Collections.Generic;
using System.Text;

namespace DigitExtractorEngine.Plugins
{
    /// <summary>
    /// Plugin specialized in translation of digits to Roman Numerals
    /// </summary>
    public class RomanNumeralPlugin : Interfaces.IBaseDigitPlugin
    {
        /// <summary>
        /// List containing the numerals to be used for the translation
        /// </summary>
        static public List<KeyValuePair<int, String>> RomanNumeralMap = new List<KeyValuePair<int, string>>()
        {
             new KeyValuePair<int, string>(1000, "M")
            , new KeyValuePair<int, string>(500, "D")
            , new KeyValuePair<int, string>(100, "C")
            , new KeyValuePair<int, string>(50, "L")
            , new KeyValuePair<int, string>(10, "X")
            , new KeyValuePair<int, string>(5, "V")
            , new KeyValuePair<int, string>(1, "I")
        };

        /// <summary>
        /// Specialized method to convert number in Roman Numerals representation
        /// </summary>
        /// <param name="number">a digit</param>
        /// <returns>a roman Numeral representing number (e.g. XV)</returns>
        public String Execute(int number)
        {
            String romanNumerals = null;

            foreach (KeyValuePair<int, String> item in RomanNumeralMap)
            {
                if (number == 0)
                    break;
                for (int i = number / item.Key; i > 0; --i)
                    romanNumerals += item.Value;
                number = number % item.Key; // we get the left over
            }
            return (romanNumerals);
        }

    }
}
