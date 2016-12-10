using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2016.Day5
{
    public class ThreadManagerSecond : ThreadManager
    {
        #region Fields

        private readonly Dictionary<int, Dictionary<int, char?>> foundedLetters;

        #endregion

        #region Constructor

        public ThreadManagerSecond(int pSizeOfStep, int whenStart, int numberOfThreads, string pass) : base(pSizeOfStep, whenStart, numberOfThreads, pass)
        {
            foundedLetters = new Dictionary<int, Dictionary<int, char?>>();
        }

        #endregion

        #region Overriden Methods

        protected override int MoveCurrentStep()
        {
            if (currentStep == 4600000)
                return currentStep = 7500000;

            if (currentStep == 8200000)
                return currentStep = 13200000;

            if (currentStep == 13200000)
                return currentStep = 17500000;

            if (currentStep == 17800000)
                return currentStep = 19000000;

            if (currentStep == 19000000)
                return currentStep = 20400000;

            if (currentStep == 20800000)
                return currentStep = 21400000;

            if (currentStep == 22000000)
                return currentStep = 26000000;

            return currentStep;
        }

        protected override HashThread CreateHashThread(Func<Tuple<int, int>> pFunc, Action<char, int, int> pAction, string pPassword, int id)
        {
            return new HashThreadSecond(pFunc, pAction, pPassword, id);
        }

        protected override void FoundedLetter(char item, int position, int positionInString)
        {
            lock (resultLock)
            {
                if (positionInString == -1 || positionInString > 7 || foundedLetters.ContainsKey(positionInString) || foundedLetters.Count == 8)
                    return;

                if(!foundedLetters.ContainsKey(positionInString))
                    foundedLetters.Add(positionInString, new Dictionary<int, char?>());

                var dict = foundedLetters[positionInString];
                dict.Add(position, item);

                if (foundedLetters.Count >= 8)
                    hasEnough = true;
            }
        }

        public override char[] GetPassword()
        {
            var returnChars = new [] {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '};
            foreach (var foundedLetter in foundedLetters)
            {
                returnChars[foundedLetter.Key] = foundedLetter.Value.OrderBy(i => i.Key).First().Value ?? ' ';
            }
            return returnChars;
        }

        #endregion
    }
}
