using System;
using System.Text;

namespace AmountConverter.Helper
{
    public static class Currency
    {
        public static string AmountInWords(decimal inputAmount)
        {
            var beforePoint = (int)Math.Floor(inputAmount);
            var beforeDotInWords = AmountInWords(beforePoint);

            beforeDotInWords += beforeDotInWords.ToLower() == "one" ? " dollar" : " dollars";

            var diff = (int)((inputAmount - beforePoint) * 100);
            var afterDotInWords = WordsForTwoDigitNums(diff, "");

            afterDotInWords += afterDotInWords.ToLower() == "one" ? " cent" : " cents";

            if (afterDotInWords != null && afterDotInWords.Trim() != "cents" && afterDotInWords.Trim() != "cent") //avoid blank cents
                return beforeDotInWords + " and " + afterDotInWords;

            return beforeDotInWords;
        }

        private static string AmountInWords(int num)
        {
            if (num == 0)
                return "zero";

            var sb = new StringBuilder("");

            if (num / 1000000 > 0)
            {
                sb.Append(AmountInWords(num / 1000000) + " million ");
                num %= 1000000;
            }

            if (num / 1000 > 0)
            {
                sb.Append(AmountInWords(num / 1000) + " thousand ");
                num %= 1000;
            }

            if (num / 100 > 0)
            {
                sb.Append(AmountInWords(num / 100) + " hundred ");
                num %= 100;
            }

            return WordsForTwoDigitNums(num, sb.ToString());

        }

        private static string WordsForTwoDigitNums(int number, string words)
        {
            if (number <= 0) return words;

            if (words != "")
                words += "";

            var unitsArray = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            
            var tensArray = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

            if (number < 20)
            {
                words += unitsArray[number];
            }
            else
            {
                words += tensArray[number / 10];

                if ((number % 10) > 0)
                    words += "-" + unitsArray[number % 10];
            }
            
            return words;
        }
    }
}
