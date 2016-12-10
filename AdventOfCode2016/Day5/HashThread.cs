using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016.Day5
{
    public abstract class HashThread : IDisposable
    {
        #region Constants

        protected const string CONDITION = "00000";

        #endregion

        #region Fields

        protected readonly MD5 mdAlgorithm = MD5.Create();
        protected Func<Tuple<int, int>> getNewBoundaries;
        protected Action<char, int, int> resultFounded;
        protected Tuple<int, int> boundaries;
        protected readonly string password;
        public Task Task { get; set; }
        public int Id { get; set; }

        #endregion

        #region Protected Methods

        protected HashThread(Func<Tuple<int, int>> pFunc, Action<char, int, int> pAction, string pPassword, int id)
        {
            getNewBoundaries = pFunc;
            resultFounded = pAction;
            password = pPassword;
            Task = Task.Factory.StartNew(Start);
            Id = id;
        }

        protected abstract void Start();

        protected string ReturnBytesFromHashedPassword(int modifiedNumber, int length)
        {
            var bytes = mdAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(password + modifiedNumber));
            return BitConverter.ToString(bytes.Take(length).ToArray()).Replace("-", "");
        }

        #endregion

        #region Public Methods

        public void Dispose()
        {
            getNewBoundaries = null;
            resultFounded = null;
            boundaries = null;
        }

        #endregion
    }
}
