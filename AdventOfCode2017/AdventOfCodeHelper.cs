using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2017
{
    public static class AdventOfCodeHelper
    {
        /// <summary>
        /// Read File row by row
        /// </summary>
        /// <param name="filePath">File path</param>
        /// <returns>Row by row</returns>
        public static IEnumerable<string> FileReader(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }            
        }
    }
}
