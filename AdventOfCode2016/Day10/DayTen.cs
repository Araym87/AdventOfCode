using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode2016.General;

namespace AdventOfCode2016.Day10
{
    public class DayTen : DayResult
    {
        #region Constants

        private const int FIRST_CHIP = 61;
        private const int SECOND_CHIP = 17;

        #endregion

        #region Fields

        private readonly Dictionary<int, Bot> bots = new Dictionary<int, Bot>();
        private readonly Dictionary<int, int> output = new Dictionary<int, int>();

        #endregion

        #region Protected Methods

        protected override void FirstPart()
        {
            ClearDictionaries();

            foreach (var line in AdventOfCodeReader.ReadReaderLineByLine(new StreamReader("Inputs\\input10.txt")))
            {
                ProcessLineOfInput(line);
            }

            var topItem = bots.OrderByDescending(i => i.Value.Chips.Count).First().Value;
            while (topItem.Chips.Count == 2)
            {
                if (topItem.Chips.Contains(FIRST_CHIP) && topItem.Chips.Contains(SECOND_CHIP))
                    break;

                var lowBot = topItem.LowOutput ? null : CreateBotIfNotExist(bots, topItem.Low);
                var highBot = topItem.HighOutput ? null : CreateBotIfNotExist(bots, topItem.High);
                highBot?.Chips.Add(topItem.Chips.Max());
                lowBot?.Chips.Add(topItem.Chips.Min());
                topItem.Chips.Clear();
                topItem = bots.OrderByDescending(i => i.Value.Chips.Count).First().Value;
            }
            Console.WriteLine($"Bot to handle combination is {topItem.ID}");
        }

        protected override void SecondPart()
        {
            ClearDictionaries();
            foreach (var line in AdventOfCodeReader.ReadReaderLineByLine(new StreamReader("Inputs\\input10.txt")))
            {
                ProcessLineOfInput(line);
            }

            var topItem = bots.OrderByDescending(i => i.Value.Chips.Count).First().Value;
            while (topItem.Chips.Count == 2)
            {
                var lowBot = topItem.LowOutput ? null : CreateBotIfNotExist(bots, topItem.Low);
                var highBot = topItem.HighOutput ? null : CreateBotIfNotExist(bots, topItem.High);
                if (lowBot == null)
                {
                    output.Add(topItem.Low, topItem.Chips.Min());
                }
                if (highBot == null)
                {
                    output.Add(topItem.High, topItem.Chips.Max());
                }
                highBot?.Chips.Add(topItem.Chips.Max());
                lowBot?.Chips.Add(topItem.Chips.Min());
                topItem.Chips.Clear();
                topItem = bots.OrderByDescending(i => i.Value.Chips.Count).First().Value;
            }
            var res = output.Where(i => i.Key < 3).Select(j => j.Value).Aggregate((x, y) => x * y);
            Console.WriteLine($"Result of multiplying of first three output is {res}");
        }

        #endregion

        #region Private Methods

        private void ClearDictionaries()
        {
            bots.Clear();
            output.Clear();    
        }

        private void ProcessLineOfInput(string line)
        {
            var words = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (words[0] == "value")
            {
                var botId = Convert.ToInt32(words.Last());
                var bot = CreateBotIfNotExist(bots, botId);

                bot.Chips.Add(Convert.ToInt32(words[1]));
            }
            else
            {
                var bot = CreateBotIfNotExist(bots, Convert.ToInt32(words[1]));
                bot.Low = Convert.ToInt32(words[6]);
                bot.LowOutput = words[5] != "bot";
                bot.High = Convert.ToInt32(words[11]);
                bot.HighOutput = words[10] != "bot";
            }
        }

        private Bot CreateBotIfNotExist(Dictionary<int, Bot> bots, int botId)
        {
            Bot bot;
            if (bots.ContainsKey(botId))
            {
                bot = bots[botId];
            }
            else
            {
                bot = new Bot{ ID = botId};
                bots.Add(botId, bot);
            }

            return bot;
        }

        #endregion

        #region Overriden Methods

        protected override string GetStringDay()
        {
            return "Ten";
        }

        #endregion
    }
}
