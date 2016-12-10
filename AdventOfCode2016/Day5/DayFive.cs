using System;
using AdventOfCode2016.General;

namespace AdventOfCode2016.Day5
{
    public class DayFive : DayResult
    {
        #region Fields

        private readonly char[] possibleItems = {'0', '1', '2', '3', '4', '5', '6', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F'};
        private readonly char[] password = { 'B', 'D', '5', '0', '6', 'C', '2', '5' };
        private readonly Random random = new Random();

        #endregion

        #region Protected Methods

        protected override void FirstPart()
        {
            var password = "uqwqemis";
            var manager = new ThreadManagerFirst(100000, 4400000, 8, password);
            ShowDynamicPassword(manager);

            Console.WriteLine();
        }

        protected override void SecondPart()
        {
            var password = "uqwqemis";
            var manager = new ThreadManagerSecond(100000, 4400000, 8, password);

            ShowDynamicPassword(manager);
            Console.WriteLine();
        }

        #endregion

        #region Private Methods

        private void ShowDynamicPassword(ThreadManager manager)
        {
            Console.CursorVisible = false;
            Console.Write("Password is ");
            var leftPosition = Console.CursorLeft;
            var topPosition = Console.CursorTop;
            while (!manager.IsFinished())
            {
                Console.SetCursorPosition(leftPosition, topPosition);
                var text = GetText().ToCharArray();
                var update = manager.GetPassword();
                for (var i = 0; i < update.Length; i++)
                {
                    if (update[i] == ' ')
                        continue;

                    text[i] = update[i];
                }
                Console.Write(new string(text));
                System.Threading.Thread.Sleep(25);
            }
            Console.CursorVisible = true;
        }

        private string GetText()
        {
            for (var i = 0; i < password.Length; i++)
            {
                password[i] = possibleItems[random.Next(0, possibleItems.Length - 1)];
            }

            return new string(password);
        }

        #endregion

        #region Overriden Methods

        protected override string GetStringDay()
        {
            return "Five";
        }

        #endregion
    }
}
