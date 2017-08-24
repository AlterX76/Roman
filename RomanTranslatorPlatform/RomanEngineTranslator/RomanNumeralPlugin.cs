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


        public static string Recursive(int number, int indexMap)
        {
            string ret = String.Empty;
            int index = -1;

            if (number <= 0) // base of recursive 
                return (ret);
            else if (number <= 3) //e.g. III
                return RomanNumeralMap[6].Value + Recursive(number - 1, 6);
            else if ((index = RomanNumeralMap.FindIndex(x => x.Key == number + 1)) != -1) // if one number to have an Key: 4
                return Recursive(RomanNumeralMap[index].Key - number, index) + RomanNumeralMap[index].Value;
            else if (number - (number % 10) > 0 && (index = RomanNumeralMap.FindIndex(x => x.Key == RomanNumeralMap[indexMap].Key - (number - (number % 10)))) != -1)
                return Recursive(RomanNumeralMap[index].Key, index) + RomanNumeralMap[indexMap].Value + Recursive(number % 10, 0);
            else
            {
                int temp = number / RomanNumeralMap[indexMap].Key;
                for (int i = temp; i > 0; --i)
                    ret += RomanNumeralMap[indexMap].Value;
            }
            return ret + Recursive(number % RomanNumeralMap[indexMap].Key, indexMap + 1);
        }
        /// <summary>
        /// Specialized method to convert number in Roman Numerals representation
        /// </summary>
        /// <param name="number">a digit</param>
        /// <returns>a roman Numeral representing number (e.g. XV)</returns>
        public String Execute(int number)
        {
            return (Recursive(number, 0));
        }
    }
}
