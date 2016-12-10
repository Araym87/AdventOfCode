using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2016.Day5
{
    public class ThreadManagerFirst : ThreadManager
    {
        #region Fields

        private readonly Dictionary<int, char> foundedLetters;

        #endregion

        #region Constructor

        public ThreadManagerFirst(int pSizeOfStep, int whenStart, int numberOfThreads, string pass) : base(pSizeOfStep, whenStart, numberOfThreads, pass)
        {
            foundedLetters = new Dictionary<int, char>();
        }

        #endregion

        #region Overriden Methods

        protected override HashThread CreateHashThread(Func<Tuple<int, int>> pFunc, Action<char, int, int> pAction,
            string pPassword, int id)
        {
            return new HashThreadFirst(pFunc, pAction, pPassword, id);
        }

        protected override int MoveCurrentStep()
        {
            if (currentStep == 4600000)
                return currentStep = 6800000;

            if (currentStep == 8200000)
                return currentStep = 13200000;

            if (currentStep == 15000000)
                return currentStep = 16500000;

            return currentStep;
        }

        protected override void FoundedLetter(char item, int position, int positionInString)
        {
            lock (resultLock)
            {
                foundedLetters.Add(position, item);
                if (foundedLetters.Count >= 8)
                    hasEnough = true;
            }
        }

        public override char[] GetPassword()
        {
            return foundedLetters.OrderBy(i => i.Key).Select(j => j.Value).Take(8).ToArray();
        }

    #endregion
}
}
