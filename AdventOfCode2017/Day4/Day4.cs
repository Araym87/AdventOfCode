using System;
using System.Linq;
using System.Text.RegularExpressions;
using AdventOfCode.Common.General;

namespace AdventOfCode2017.Day4
{
    public class Day4 : DayResult
    {
        #region Protected Methods

        protected override void FirstPart()
        {
            var count = 0;

            foreach (var line in AdventOfCodeHelper.FileReader("Inputs\\Input4.txt"))
            {
                var x = Regex.Matches(line, "\\b(\\w+)\\b(?=.*\\b\\1\\b)");
                if (x.Count > 0)
                    continue;

                count++;
            }

            Console.WriteLine($"Count of valid Passphrases is {count}");
        }

        protected override void SecondPart()
        {
            var wrong = 0;
            var numberOfLines = 0;
            foreach (var line in AdventOfCodeHelper.FileReader("Inputs\\Input4.txt"))
            {
                var words = line.Split(new[] { ' ' }, StringSplitOptions.None).GroupBy(i => i.Length);
                foreach (var word in words)
                {
                    var samelengthWords = word.ToList();
                    if (samelengthWords.Count <= 1)
                        continue;

                    for (var i = 0; i < samelengthWords.Count; i++)
                    {
                        var currentWord = samelengthWords[i].GroupBy(let => let)
                            .Select(g => new { Letter = g.Key, Count = g.Count() }).ToList();

                        for (var j = i + 1; j < samelengthWords.Count; j++)
                        {
                            var nextWord = samelengthWords[j].GroupBy(let => let)
                                .Select(g => new { Letter = g.Key, Count = g.Count() }).ToList();

                            var equals = true;
                            foreach (var item in currentWord)
                            {
                                if (nextWord.All(e => e.Letter != item.Letter) ||
                                    nextWord.First(e => e.Letter == item.Letter).Count != item.Count)
                                {
                                    equals = false;
                                    break;
                                }
                            }
                            if (equals)
                            {
                                wrong++;
                                goto aaa;
                            }
                        }
                    }
                }
                aaa:
                numberOfLines++;
            }

            Console.WriteLine($"Count of valid Passphrases is {numberOfLines - wrong}");
        }

        protected override string GetStringDay()
        {
            return "Four";
        }

        #endregion
    }
}
