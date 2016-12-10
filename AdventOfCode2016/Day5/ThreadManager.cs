using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2016.Day5
{
    public abstract class ThreadManager
    {
        #region Fields

        protected readonly object resultLock = new object();
        protected bool hasEnough;  
        private readonly int sizeOfStep;
        protected int currentStep;
        private readonly List<HashThread> tasks;

        #endregion

        #region Constructor

        protected ThreadManager(int pSizeOfStep,int whenStart, int numberOfThreads, string pass)
        {
            sizeOfStep = pSizeOfStep;
            currentStep = whenStart;

            tasks = new List<HashThread>();
            for (var i = 0; i < numberOfThreads; i++)
            {
                // ReSharper disable once VirtualMemberCallInConstructor
                tasks.Add(CreateHashThread(NewBoundaries, FoundedLetter, pass, i));
            }
        }

        #endregion

        #region Abstract Mthods

        protected abstract int MoveCurrentStep();

        protected abstract HashThread CreateHashThread(Func<Tuple<int, int>> pFunc, Action<char, int, int> pAction,
            string pPassword, int id);

        protected abstract void FoundedLetter(char item, int position, int positionInString);

        public abstract char[] GetPassword();

        #endregion

        #region Private Methods

        private Tuple<int, int> NewBoundaries()
        {
            return hasEnough ? null : new Tuple<int, int>(currentStep = MoveCurrentStep(), currentStep += sizeOfStep);
        } 

        #endregion

        #region Public Methods

        public bool IsFinished()
        {
            return tasks.All(i => i.Task.IsCompleted);
        }

        #endregion
    }
}
