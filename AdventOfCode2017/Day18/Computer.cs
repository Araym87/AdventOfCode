using System;
using System.Collections.Generic;
using System.Threading;

namespace AdventOfCode2017.Day18
{
    public class Computer
    {
        #region Properties

        /// <summary>
        /// Computer arguments
        /// </summary>
        public ComputerArgs ComputerArgs { get; set; }        

        /// <summary>
        /// List of instructions
        /// </summary>
        public List<Instruction> Instructions { get; set; } = new List<Instruction>();

        /// <summary>
        /// Input queue
        /// </summary>
        public Queue<long> InputQueue { get; set; }

        /// <summary>
        /// Action for sending instruction to another program
        /// </summary>
        public Action<long> SentInstruction { get; set; }

        /// <summary>
        /// Number of sent instructions
        /// </summary>
        public long SentInstructions { get; set; }

        /// <summary>
        /// Does the program waiting for instruction?
        /// </summary>
        public bool WaitingForInstruction { get; set; }

        #endregion

        #region Constructor

        public Computer()
        {
            ComputerArgs = new ComputerArgs
            {
                Register = new Dictionary<char, long>(),
                Pointer = 0,
                ReceiveAction = GetFromQueue,
                SendAction = InsertToAnotherComputerQueue
            };
            InputQueue = new Queue<long>();
        }

        #endregion

        #region Initialize

        public void Initialize(Action<long> insert)
        {
            SentInstruction = insert;
        }

        #endregion

        #region Public Methods

        public void AddInstruction(Instruction ins)
        {
            foreach (var register in ins.Register())
            {
                if(!ComputerArgs.Register.ContainsKey(register))
                    ComputerArgs.Register.Add(register, 0);
            }

            Instructions.Add(ins);
        }

        #endregion

        #region Run Method

        public long Run()
        {
            while (ComputerArgs.Pointer >= 0 && ComputerArgs.Pointer < Instructions.Count)
            {
                if (!Instructions[(int)ComputerArgs.Pointer].Process(ComputerArgs))
                    return ComputerArgs.LastFrequency;

            }

            throw new Exception("Computer did not sent frequency by recovery instruction");
        }

        public void RunSecond(CancellationTokenSource cancellationToken)
        {
            while (ComputerArgs.Pointer >= 0 && ComputerArgs.Pointer < Instructions.Count)
            {
                var instruction = Instructions[(int)ComputerArgs.Pointer];
                if (instruction.GetType() == typeof(Receive))
                {
                    while (InputQueue.Count == 0)
                    {                        
                        Thread.Sleep(50);
                        WaitingForInstruction = true;
                        if (cancellationToken.Token.IsCancellationRequested)
                            return;
                    }
                }
                WaitingForInstruction = false;
                instruction.Process(ComputerArgs);
            }
            // Hack for Finishing instructions
            WaitingForInstruction = true;
        }

        #endregion

        #region Communication

        public void InsertToAnotherComputerQueue(long value)
        {
            SentInstruction.Invoke(value);
            SentInstructions++;
        }

        public long GetFromQueue()
        {
            return InputQueue.Dequeue();
        }

        public void InsertToQueue(long value)
        {
            InputQueue.Enqueue(value);
        }

        #endregion
    }
}
