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

            if (number <= 0)
                return String.Empty;
            for (int index = 0; index < RomanNumeralMap.Count - 1; ++index)
            {
                if (number == 0)
                    break;
                for (int i = number / RomanNumeralMap[index].Key; i > 0; --i)
                    romanNumerals += RomanNumeralMap[index].Value;
                number = number % RomanNumeralMap[index].Key; // we get the left over
                if (number <= 3)
                {
                    while (number > 0)
                    {
                        romanNumerals += RomanNumeralMap[RomanNumeralMap.Count - 1].Value;
                        number--;
                    }
                }
                for (int innerIndex = index + 1; (number % (RomanNumeralMap[index].Key - 1) == 0) && innerIndex < RomanNumeralMap.Count; ++innerIndex)
                {
                    if (RomanNumeralMap[index].Key - RomanNumeralMap[innerIndex].Key == number)
                    {
                        romanNumerals += RomanNumeralMap[innerIndex].Value + RomanNumeralMap[index].Value;
                        number = 0;
                        break;
                    }
                }
            }
            return (romanNumerals);
        }
    }
}
