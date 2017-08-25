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
            {
                int indexPrev = RomanNumeralMap.FindLastIndex(x => RomanNumeralMap[index].Key - x.Key == number - (number > 100 ? number % 100 : (number > 1000 ? number % 1000 : (number < 10 ? 0 : number % 10))));
                return Recursive(RomanNumeralMap[indexPrev].Key, index) + RomanNumeralMap[index].Value + Recursive(Math.Abs(RomanNumeralMap[index].Key - RomanNumeralMap[indexPrev].Key - number), 0);
            }
            else if (RomanNumeralMap.FindAll(x => x.Key == number).Count == 0 &&
                (number > 1000 && (index = RomanNumeralMap.FindAll(x => x.Key != number - (number % 1000) && x.Key != number % 1000 && x.Key != number % 100 && x.Key != number % 10).FindIndex(x => x.Key == RomanNumeralMap[indexMap].Key - (number - (number % 1000)))) != -1
                || number > 100 && (index = RomanNumeralMap.FindAll(x => x.Key != number - (number % 100) &&  x.Key != number % 100 && x.Key != number % 10).FindIndex(x => x.Key == RomanNumeralMap[indexMap].Key - (number - (number % 100)))) != -1
                || (index = RomanNumeralMap.FindAll(x => x.Key != number - (number < 10 ? 0 : (number % 10)) && x.Key != number % 10).FindIndex(x => x.Key == RomanNumeralMap[indexMap].Key - (number - (number < 10 ? 0 : (number % 10))))) != -1))
            {
                return Recursive(RomanNumeralMap[index].Key, index) + RomanNumeralMap[indexMap].Value + Recursive(Math.Abs(RomanNumeralMap[indexMap].Key - RomanNumeralMap[index].Key - number), 0);
            }
            else
            {
                int temp = number / RomanNumeralMap[indexMap].Key;
                if (temp > 0) index = 0;
                for (int i = temp; i > 0; --i)
                    ret += RomanNumeralMap[indexMap].Value;
            }
            return ret + Recursive(number % RomanNumeralMap[indexMap].Key, index == 0 ? index : indexMap + 1);
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
