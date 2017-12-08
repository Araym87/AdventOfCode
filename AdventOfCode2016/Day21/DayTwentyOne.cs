using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2016.General;

namespace AdventOfCode2016.Day21
{
    public class DayTwentyOne : DayResult
    {
        private const char SWAP = '%';
        protected override void FirstPart()
        {
            var input = "abcdefgh".ToCharArray();
            foreach (var line in AdventOfCodeReader.ReadReaderLineByLine(new StreamReader("Inputs\\input21.txt")))
            {
                var words = line.Split(new[] { ' ' }, StringSplitOptions.None);
                if (words[0] == "swap")
                {
                    if (words[1] == "position")
                    {
                        SwapPosition(Convert.ToInt32(words[2]), Convert.ToInt32(words[5]), input);
                    }
                    else
                    {
                        SwapLetter(words[2][0], words[5][0], input);
                    }
                }else if (words[0] == "rotate")
                {
                    if (words[1] == "left")
                    {
                        input = RotateLeft(Convert.ToInt32(words[2]), input);
                    }else if (words[1] == "right")
                    {
                        input = RotateRight(Convert.ToInt32(words[2]), input);
                    }
                    else
                    {
                        input = RotateBasedOn(words[6][0], input);
                    }
                }else if (words[0] == "reverse")
                {
                    input = Revers(Convert.ToInt32(words[2]), Convert.ToInt32(words[4]), input);
                }else if (words[0] == "move")
                {
                    input = Move(Convert.ToInt32(words[2]), Convert.ToInt32(words[5]), input);
                }
                
            }
            var s = new string(input);
            Console.WriteLine($"Current string is {s}");
        }

        protected override void SecondPart()
        {
            var input = "fbgdceah".ToCharArray();
            var items = AdventOfCodeReader.ReadReaderLineByLine(new StreamReader("Inputs\\input21.txt")).ToList();
                items.Reverse();
            foreach (var line in items)
            {
                var words = line.Split(new[] { ' ' }, StringSplitOptions.None);
                if (words[0] == "swap")
                {
                    if (words[1] == "position")
                    {
                        SwapPosition(Convert.ToInt32(words[2]), Convert.ToInt32(words[5]), input);
                    }
                    else
                    {
                        SwapLetter(words[2][0], words[5][0], input);
                    }
                }
                else if (words[0] == "rotate")
                {
                    if (words[1] == "left")
                    {
                        input = RotateRight(Convert.ToInt32(words[2]), input);
                    }
                    else if (words[1] == "right")
                    {
                        input = RotateLeft(Convert.ToInt32(words[2]), input);
                    }
                    else
                    {
                        input = RotateBasedOnBack(words[6][0], input);
                    }
                }
                else if (words[0] == "reverse")
                {
                    input = Revers(Convert.ToInt32(words[2]), Convert.ToInt32(words[4]), input);
                }
                else if (words[0] == "move")
                {
                    input = Move(Convert.ToInt32(words[5]), Convert.ToInt32(words[2]), input);
                }
                
            }
            var s = new string(input);
            Console.WriteLine($"Current string is {s}");
        }

        private char[] Move(int a, int b, char[] word)
        {
            var letter = word[a];
            var s = new string(word);
            s = s.Remove(a, 1);
            s = s.Insert(b, letter.ToString());

            return s.ToCharArray();
        }

        private char[] Revers(int low, int high, char[] word)
        {
            var left = word.Take(low);
            var right = word.Skip(high + 1);
            var middle = word.Skip(low).Take(high - low + 1);
            return left.Union(middle.Reverse()).Union(right).ToArray();
        }

        private void SwapPosition(int a, int b, char[] word)
        {
            var charA = word[a];
            var charB = word[b];
            word[a] = charB;
            word[b] = charA;
        }

        private void SwapLetter(char a, char b, char[] word)
        {
            for (var i = 0; i < word.Length; i++)
            {
                if (word[i] == a)
                    word[i] = SWAP;

                if (word[i] == b)
                    word[i] = a;
            }
            for (var i = 0; i < word.Length; i++)
            {
                if (word[i] == SWAP)
                    word[i] = b;
            }
        }

        private char[] RotateLeft(int step, char[] word)
        {
            var rotation = step%word.Length;
            var leftArray = word.Skip(rotation);
            var rightArray = word.Take(rotation);
            return leftArray.Union(rightArray).ToArray();
        }

        private char[] RotateRight(int step, char[] word)
        {
            var rotation = step % word.Length;
            var leftArray = word.Reverse().Take(rotation).Reverse();
            var rightArray = word.Take(word.Length - rotation);
            return leftArray.Union(rightArray).ToArray();
        }

        private char[] RotateBasedOn(char a, char[] word)
        {
            var index = 0;
            for (var i = 0; i < word.Length; i++)
            {
                if (word[i] == a)
                {
                    index = i;
                    break;
                }
            }

            var steps = index >= 4 ? index + 2 : index + 1;
            return RotateRight(steps, word);
        }

        private char[] RotateBasedOnBack(char a, char[] word)
        {
            var index = 0;
            for (var i = 0; i < word.Length; i++)
            {
                if (word[i] == a)
                {
                    index = i;
                    break;
                }
            }

            var steps = -1;
            switch (index)
            {
                case 0:
                    steps = 1;
                    break;
                case 1:
                    steps = 1;
                    break;
                case 2:
                    steps = 6;
                    break;
                case 3:
                    steps = 2;
                    break;
                case 4:
                    steps = 7;
                    break;
                case 5:
                    steps = 3;
                    break;
                case 6:
                    return word;
                case 7:
                    steps = 4;
                    break;

            }

            //switch (index)
            //{
            //    case 0:
            //        steps = 1;
            //        break;
            //    case 1:
            //        steps = 1;
            //        break;
            //    case 2:
            //        steps = 4;
            //        break;
            //    case 3:
            //        steps = 2;
            //        break;
            //    case 4:
            //        return word;
            //}

            return RotateLeft(steps, word);
        }

        protected override string GetStringDay()
        {
            return "Twenty One";
        }
    }
}
