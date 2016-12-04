using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2016.Day4
{
    public class Room
    {
        #region Fields

        private readonly string name;
        private readonly string checksum;
        
        #endregion

        #region Properties

        public string DecryptedName { get; set; }
        public int SectorId { get; set; }

        #endregion

        #region Constructor

        public Room(string pName, string pChecksum, int pSectorId)
        {
            name = pName;
            checksum = pChecksum;
            SectorId = pSectorId;
            DecryptedName = null;
        }

        #endregion

        #region Public Methods

        public bool IsRealRoom()
        {
            var nameCheckSum = FrequentialAnalysis().ToList().OrderByDescending(i => i.Value).ThenBy(j => j.Key).Take(5).Select(k => k.Key.ToString()).Aggregate((l,m)=> l + m);
            
            return checksum.Equals(nameCheckSum);
        }

        public void DecryptName()
        {
            var howManyMoves = SectorId%26;
            var realName = new StringBuilder();
            foreach (var letter in name)
            {
                if (letter == '-')
                {
                    realName.Append(' ');
                    continue;
                }

                var currentLetter = letter;
                for (var i = 0; i < howManyMoves; i++)
                {
                    if (currentLetter == 'z')
                    {
                        currentLetter = 'a';
                        continue;
                    }
                    currentLetter = (char)(currentLetter + 1);
                }

                realName.Append(currentLetter);
            }
            DecryptedName = realName.ToString();        
        }

        #endregion

        #region Private Methods

        private Dictionary<char, int> FrequentialAnalysis()
        {
            var result = new Dictionary<char, int>();
            foreach (var @char in name)
            {
                if(@char == '-')
                    continue;

                if(!result.ContainsKey(@char))
                    result.Add(@char, 0);

                result[@char] += 1;
            }

            return result;
        }

        #endregion

        #region Overriden Methods

        public override string ToString()
        {
            return DecryptedName ?? name;
        }

        #endregion
    }
}
