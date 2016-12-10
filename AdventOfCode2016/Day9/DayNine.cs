using System;
using System.IO;
using System.Text;
using AdventOfCode2016.General;

namespace AdventOfCode2016.Day9
{
    public class DayNine : DayResult
    {
        #region Constants

        private const char LEFT_PARENTHESIS = '(';
        private const char RIGHT_PARENTHESIS = ')';
        private const char DELIMITIER = 'x';

        #endregion

        #region Protected Methods

        protected override void FirstPart()
        {
            var sum = 0;
            foreach (var line in AdventOfCodeReader.ReadReaderLineByLine(new StreamReader("Inputs\\input9.txt")))
            {
                var result = line;
                var nasobek = new StringBuilder();
                var inPar = false;
                
                for (var i = 0; i < result.Length; i++)
                {
                    if (result[i] == LEFT_PARENTHESIS)
                    {
                        inPar = true;
                        continue;
                        
                    }
                    if (result[i] == RIGHT_PARENTHESIS)
                    {
                        inPar = false;
                        var split = nasobek.ToString().Split(new[] {DELIMITIER}, StringSplitOptions.RemoveEmptyEntries);
                        var letters = Convert.ToInt32(split[0]);
                        sum += letters * Convert.ToInt32(split[1]);
                        i += letters;
                        nasobek.Clear();
                        continue;

                    }
                    if (inPar)
                        nasobek.Append(result[i]);
                    else
                        sum++;
                }
            }
            Console.WriteLine($"Length of decompressed string is {sum}");
        }

        protected override void SecondPart()
        {
            long sum = 0;
            foreach (var line in AdventOfCodeReader.ReadReaderLineByLine(new StreamReader("Inputs\\input9.txt")))
            {
                sum = Recursion(line);
            }
            Console.WriteLine($"Length of brutally decompressed file is {sum}");
        }

        #endregion

        #region Private Methods

        private long Recursion(string result)
        {
            var inPar = false;
            var parContent = new StringBuilder();
            long sum = 0;
            for (var i = 0; i < result.Length; i++)
            {
                if (result[i] == LEFT_PARENTHESIS)
                {
                    inPar = true;
                    continue;
                }
                if (result[i] == RIGHT_PARENTHESIS)
                {
                    inPar = false;
                    var split = parContent.ToString().Split(new[] { DELIMITIER }, StringSplitOptions.RemoveEmptyEntries);
                    var stringLength = Convert.ToInt32(split[0]);

                    sum += Recursion(result.Substring(i + 1, stringLength)) * Convert.ToInt32(split[1]);
                    i = i + stringLength;
                    parContent.Clear();
                    continue;
                }
                if (inPar)
                    parContent.Append(result[i]);
                else
                    sum++;
            }

            return sum;
        }

        #endregion

        #region Overriden Methods

        protected override string GetStringDay()
        {
            return "Nine";
        }

        #endregion
    }
}
