using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.XPath;
using AdventOfCode.SeventhDay;

namespace AdventOfCode
{
    class Program
    { 
        static void Main(string[] args)
        {
            //FirstDay();
            //SecondDayPartOne();
            //SecondDayPartTwo();
            //ThirdDayPartOne();
            //ThirdDayPartTwo();
            //FourthDayPartOne();
            //FourthDayPartTwo();
            //FifthDayPartOne();
            //FifthDayPartTwo();
            //SixthDayPartOne();
            //SixthDayPartTwo();
            //SeventhDayPartOne();
            //SeventhDayPartTwo();
            //EightDayPartOne();
            //EightDayPartTwo();
        }

        #region DayEight

        private static void EightDayPartOne()
        {
            string line;
            var file = new StreamReader("Inputs\\inputDayEight.txt");

            var stringCount = 0;
            var memoryCount = 0;
            while ((line = file.ReadLine()) != null)
            {
                stringCount += line.Length;
                memoryCount += Regex.Unescape(line.Substring(1, line.Length - 2)).Length;
            }

            file.Close();

            Console.WriteLine("" + (stringCount - memoryCount));
            Console.ReadLine();
        }

        private static void EightDayPartTwo()
        {
            string line;
            var file = new StreamReader("Inputs\\inputDayEight.txt");

            var stringCount = 0;
            var memoryCount = 0;
            while ((line = file.ReadLine()) != null)
            {
                memoryCount += line.Length;
                var regexQay = Regex.Escape(line);
                // Google magic
                using (var writer = new StringWriter())
                {
                    using (var provider = CodeDomProvider.CreateProvider("CSharp"))
                    {
                        provider.GenerateCodeFromExpression(new CodePrimitiveExpression(line), writer, null);
                        regexQay = writer.ToString();
                    }
                }
                stringCount += regexQay.Length;
            }

            file.Close();

            Console.WriteLine("" + (stringCount - memoryCount));
            Console.ReadLine();
        }

        #endregion

        #region DaySeven

        private static void SeventhDayPartOne()
        {
            var operations = Enum.GetValues(typeof(Operation)).Cast<Operation>().ToList();
            string line;
            var file = new StreamReader("Inputs\\inputDaySeven.txt");
            var items = new List<Node>();
            var knownResults = new Dictionary<string, ushort>();

            while ((line = file.ReadLine()) != null)
            {
                var parts = line.Split(new[] { "->" }, StringSplitOptions.RemoveEmptyEntries);
                var usedOperation = Operation.EQUALS;
                foreach (var operation in operations)
                {
                    if (!parts[0].Contains(operation.ToString())) continue;

                    usedOperation = operation;
                    parts[0] = parts[0].Replace(operation.ToString(), ";");
                    break;
                }

                var inputParams = parts[0].Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToList().Select(i => i.Trim()).ToList();
                var outputParam = parts[1].Trim();

                ushort values = 0;
                var resultFound = false;
                // Convert to short
                for (var i = 0; i < inputParams.Count; i++)
                {
                    if (!ushort.TryParse(inputParams[i], out values)) continue;

                    if (inputParams.Count == 1)
                    {
                        knownResults.Add(outputParam, values);
                        resultFound = true;
                    }
                    inputParams.RemoveAt(i--);
                    break;
                }
                if (resultFound) continue;

                items.Add(new Node
                {
                    Childs = inputParams.ToList(),
                    KnownChildValue = values,
                    Operation = usedOperation,
                    Root = outputParam
                });
            }

            while (!knownResults.ContainsKey("a"))
            {
                // Find all nodes, which can be counted
                var countableItems = items.Where(i => i.Childs.TrueForAll(j => knownResults.ContainsKey(j))).ToList();

                foreach (var countableItem in countableItems)
                {
                    var shorts = countableItem.Childs.Select(child => knownResults[child]).ToList();
                    if (countableItem.KnownChildValue.HasValue)
                        shorts.Add(countableItem.KnownChildValue.Value);

                    if (!knownResults.ContainsKey(countableItem.Root))
                        knownResults.Add(countableItem.Root, Computate(countableItem.Operation, shorts));

                    items.Remove(countableItem);
                }

                //Count(root, items, results, new List<string>());
            }
            file.Close();
            Console.WriteLine("" + knownResults["a"]);
            Console.ReadLine();
        }

        private static ushort Computate(Operation operation, IReadOnlyList<ushort> items)
        {
            switch (operation)
            {
                    case Operation.NOT: return (ushort) ~items[0];
                    case Operation.AND:
                    return (ushort) (items[0] & items[1]);
                    case Operation.OR: return (ushort)(items[0] | items[1]);
                    case Operation.LSHIFT: return (ushort)(items[0] << items[1]);
                    case Operation.RSHIFT: return (ushort)(items[0] >> items[1]);
                    case Operation.EQUALS: return items[0];
            }
            return 0;
        }

        private static void SeventhDayPartTwo()
        {
            var operations = Enum.GetValues(typeof(Operation)).Cast<Operation>().ToList();
            string line;
            var file = new StreamReader("Inputs\\inputDaySeven.txt");
            var items = new List<Node>();
            var knownResults = new Dictionary<string, ushort>();

            while ((line = file.ReadLine()) != null)
            {
                var parts = line.Split(new[] { "->" }, StringSplitOptions.RemoveEmptyEntries);
                var usedOperation = Operation.EQUALS;
                foreach (var operation in operations)
                {
                    if (!parts[0].Contains(operation.ToString())) continue;

                    usedOperation = operation;
                    parts[0] = parts[0].Replace(operation.ToString(), ";");
                    break;
                }

                var inputParams = parts[0].Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToList().Select(i => i.Trim()).ToList();
                var outputParam = parts[1].Trim();

                ushort values = 0;
                var resultFound = false;
                // Convert to short
                for (var i = 0; i < inputParams.Count; i++)
                {
                    if (!ushort.TryParse(inputParams[i], out values)) continue;

                    if (inputParams.Count == 1)
                    {
                        knownResults.Add(outputParam, values);
                        resultFound = true;
                    }
                    inputParams.RemoveAt(i--);
                    break;
                }
                if (resultFound) continue;

                items.Add(new Node
                {
                    Childs = inputParams.ToList(),
                    KnownChildValue = values,
                    Operation = usedOperation,
                    Root = outputParam
                });
            }

            var items2 = items.ToList();
            var results = knownResults.ToDictionary(knownResult => knownResult.Key, knownResult => knownResult.Value);
            while (!results.ContainsKey("a"))
            {
                // Find all nodes, which can be counted
                var countableItems = items.Where(i => i.Childs.TrueForAll(j => results.ContainsKey(j))).ToList();

                foreach (var countableItem in countableItems)
                {
                    var shorts = countableItem.Childs.Select(child => results[child]).ToList();
                    if (countableItem.KnownChildValue.HasValue)
                        shorts.Add(countableItem.KnownChildValue.Value);

                    if (!results.ContainsKey(countableItem.Root))
                        results.Add(countableItem.Root, Computate(countableItem.Operation, shorts));

                    items.Remove(countableItem);
                }
            }

            knownResults["b"] = results["a"];
            items = items2;
            while (!knownResults.ContainsKey("a"))
            {
                // Find all nodes, which can be counted
                var countableItems = items.Where(i => i.Childs.TrueForAll(j => knownResults.ContainsKey(j))).ToList();

                foreach (var countableItem in countableItems)
                {
                    var shorts = countableItem.Childs.Select(child => knownResults[child]).ToList();
                    if (countableItem.KnownChildValue.HasValue)
                        shorts.Add(countableItem.KnownChildValue.Value);

                    if (!knownResults.ContainsKey(countableItem.Root))
                        knownResults.Add(countableItem.Root, Computate(countableItem.Operation, shorts));

                    items.Remove(countableItem);
                }
            }

            file.Close();
            Console.WriteLine("" + knownResults["a"]);
            Console.ReadLine();
        }

        #endregion

        #region DaySix

        private static void SixthDayPartOne()
        {
            string line;
            var file = new StreamReader("Inputs\\inputDaySix.txt");
            var lights = new bool[1000,1000];
            
            while ((line = file.ReadLine()) != null)
            {
                bool? turnOn = null;
                if (line.StartsWith("turn on"))
                    turnOn = true;
                else if (line.StartsWith("turn off"))
                    turnOn = false;

                var items = line.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries).Where(i =>
                { return i.ToCharArray().All(letter => char.IsDigit(letter) || letter.Equals(',')); }).ToList();

                var coordinations = new[]
                {
                    new Point(0, 0),
                    new Point(0, 0)
                };

                // Parse coordinations
                for (var i = 0; i < items.Count; i++)
                {
                    var parsedCoord = items[i].Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries).ToList();
                    coordinations[i].X = Convert.ToInt32(parsedCoord[0]);
                    coordinations[i].Y = Convert.ToInt32(parsedCoord[1]);
                }

                for (var i = coordinations[0].X; i <= coordinations[1].X; i++)
                {
                    for (var j = coordinations[0].Y; j <= coordinations[1].Y; j++)
                    {
                        if (!turnOn.HasValue)
                            lights[j, i] = !lights[j, i];
                        else
                            lights[j, i] = turnOn.Value;
                    }
                }
            }

            var totalCount = lights.Cast<bool>().Count(light => light);

            file.Close();
            Console.WriteLine("" + totalCount);
            Console.ReadLine();
        }

        private static void SixthDayPartTwo()
        {
            string line;
            var file = new StreamReader("Inputs\\inputDaySix.txt");
            var lights = new int[1000, 1000];

            while ((line = file.ReadLine()) != null)
            {
                bool? turnOn = null;
                if (line.StartsWith("turn on"))
                    turnOn = true;
                else if (line.StartsWith("turn off"))
                    turnOn = false;

                var items = line.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Where(i =>
                { return i.ToCharArray().All(letter => char.IsDigit(letter) || letter.Equals(',')); }).ToList();

                var coordinations = new[]
                {
                    new Point(0, 0),
                    new Point(0, 0)
                };

                // Parse coordinations
                for (var i = 0; i < items.Count; i++)
                {
                    var parsedCoord = items[i].Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    coordinations[i].X = Convert.ToInt32(parsedCoord[0]);
                    coordinations[i].Y = Convert.ToInt32(parsedCoord[1]);
                }

                for (var i = coordinations[0].X; i <= coordinations[1].X; i++)
                {
                    for (var j = coordinations[0].Y; j <= coordinations[1].Y; j++)
                    {

                        if (!turnOn.HasValue)
                            lights[j, i] += 2;
                        else if(turnOn.Value)
                            lights[j, i] += 1;
                        else
                        {
                            if(lights[j, i] > 0)
                                lights[j, i] -= 1;
                        }
                    }
                }

            }

            var totalCount = lights.Cast<int>().Sum();

            file.Close();
            Console.WriteLine("" + totalCount);
            Console.ReadLine();
        }


        #endregion

        #region DayFive

        private static void FifthDayPartOne()
        {
            string line;
            var file = new StreamReader("Inputs\\inputDayFive.txt");
            var countOfNiceStrings = 0;
            while ((line = file.ReadLine()) != null)
            {
                if(Regex.IsMatch(line, "(ab|cd|pq|xy)"))
                    continue;

                if (Regex.Matches(line, "[aeiou]").Count >= 3 && Regex.IsMatch(line, @"(.)\1"))
                    countOfNiceStrings++;
            }         
            file.Close();

            Console.WriteLine("" + countOfNiceStrings);
            Console.ReadLine();
        }
        
        private static void FifthDayPartTwo()
        {
            string line;
            var file = new StreamReader("Inputs\\inputDayFive.txt");
            var countOfNiceStrings = 0;
            var first = 0;
            var second = 0;
            while ((line = file.ReadLine()) != null)
            {
                var firstCondition = false;
                var secondCondition = false;

                // First Condition
                for (var i = 0; i < line.Length - 1; i++)
                {
                    var pair = line.Substring(i, 2);

                    if (line.Substring(i + 2).Contains(pair))
                    {
                        firstCondition = true;
                        break;
                    }
                }

                // Second Condition
                for (int i = 0; i < line.Length; i++)
                {
                    if (i + 2 >= line.Length) break;

                    if (line[i].Equals(line[i + 2]))
                    {
                        secondCondition = true;
                        break;
                    }
                }

                if (firstCondition && secondCondition)
                    countOfNiceStrings++;

                if (firstCondition)
                    first++;

                if (secondCondition)
                    second++;
            }

            Console.WriteLine("" + countOfNiceStrings);
            Console.ReadLine();
        }

        #endregion

        #region DayFour

        private static void FourthDayPartOne()
        {
            const string input = "bgvyzdsv";
            var mdAlgorithm = MD5.Create();
            for (var i = 0; i < int.MaxValue; i++)
            {
                var bytes = mdAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input + i));
                var result = BitConverter.ToUInt16(bytes.Take(2).ToArray(), 0) + bytes[2];
                if (result < 8)
                {
                    Console.WriteLine(i);
                    Console.ReadLine();
                    break;
                }
            } 
        }

        private static void FourthDayPartTwo()
        {
            const string input = "bgvyzdsv";
            var mdAlgorithm = MD5.Create();
            for (var i = 0; i < int.MaxValue; i++)
            {
                var bytes = mdAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input + i));
                var result = BitConverter.ToUInt16(bytes.Take(2).ToArray(), 0) + bytes[2];
                if (result == 0)
                {
                    Console.WriteLine(i);
                    Console.ReadLine();
                    break;
                }
            }
        }

        #endregion

        #region DayThree

        private static void ThirdDayPartOne()
        {
            var hashSet = new HashSet<Point> {new Point(0, 0)};
            string line;
            var file = new StreamReader("Inputs\\inputDayThree.txt");
            var actualPosition = new Point(0,0);
            while ((line = file.ReadLine()) != null)
            {
                foreach (var sign in line)
                {
                    var x = 0;
                    var y = 0;
                    if (sign.Equals('<'))
                        x = -1;
                    else if (sign.Equals('>'))
                        x = +1;
                    else if (sign.Equals('v'))
                        y = +1;
                    else if (sign.Equals('^'))
                        y = -1;
                    else
                        break;

                    actualPosition.X = actualPosition.X + x;
                    actualPosition.Y = actualPosition.Y + y;
                    hashSet.Add(actualPosition);
                }
            }


            file.Close();

            Console.WriteLine(hashSet.Count);
            Console.ReadLine();
        }

        private static void ThirdDayPartTwo()
        {
            var hashSet = new HashSet<Point> {new Point(0, 0)};
            string line;
            var file = new StreamReader("Inputs\\inputDayThree.txt");

            var santas = new []
            {
                new Point(0, 0),
                new Point(0, 0)
            };

            var index = 0;
            while ((line = file.ReadLine()) != null)
            {
                foreach (var sign in line)
                {
                    var x = 0;
                    var y = 0;
                    if (sign.Equals('<'))
                        x = -1;
                    else if (sign.Equals('>'))
                        x = +1;
                    else if (sign.Equals('v'))
                        y = +1;
                    else if (sign.Equals('^'))
                        y = -1;
                    else
                        break;

                    santas[index % 2].X = santas[index % 2].X + x;
                    santas[index % 2].Y = santas[index % 2].Y + y;
                    hashSet.Add(santas[index % 2]);

                    index++;
                }
            }

            file.Close();
            Console.WriteLine(hashSet.Count);
            Console.ReadLine();
        }

        #endregion

        #region DayTwo

        private static void SecondDayPartOne()
        {
            string line;
            var file = new StreamReader("Inputs\\inputDayTwo.txt");
            var area = 0;
            while ((line = file.ReadLine()) != null)
            {
                var sizes = line.Split(new[] {"x"}, StringSplitOptions.RemoveEmptyEntries).ToList().ConvertAll(Convert.ToInt32);
                if (sizes.Count != 3)
                {
                    Console.WriteLine("Wrong input: {0}", line);
                    break;
                }
                
                var smallest = int.MaxValue;
                for (var i = 0; i <= sizes.Count-1; i++)
                {
                    for (var j = i+1; j <= sizes.Count-1; j++)
                    {
                        var rect = sizes[i] * sizes[j];
                        if (rect < smallest)
                            smallest = rect;
                        area += 2*rect;
                    }
                }
                area += smallest;
            }


            file.Close();

            Console.WriteLine(area);
            Console.ReadLine();
        }

        private static void SecondDayPartTwo()
        {
            string line;
            var file = new StreamReader("Inputs\\inputDayTwo.txt");
            var length = 0;
            while ((line = file.ReadLine()) != null)
            {
                var sizes = line.Split(new[] { "x" }, StringSplitOptions.RemoveEmptyEntries).ToList().ConvertAll(Convert.ToInt32);
                if (sizes.Count != 3)
                {
                    Console.WriteLine("Wrong input: {0}", line);
                    break;
                }

                sizes = sizes.OrderBy(i => i).ToList();
                var cubic = 1;
                sizes.ForEach(i => cubic *= i);
                length += 2*sizes[0] + 2*sizes[1] + cubic;
            }


            file.Close();

            Console.WriteLine(length);
            Console.ReadLine();
        }

        #endregion

        #region DayOne

        private static void FirstDay()
        {
            string line;
            var file = new StreamReader("Inputs\\inputDayOne.txt");
            var position = 1;
            var floor = 0;
            while ((line = file.ReadLine()) != null)
            { 
                foreach (var sign in line)
                {
                    if (sign.Equals('('))
                        floor++;
                    if (sign.Equals(')'))
                        floor--;

                    if (floor == -1)
                        break;

                    position++;
                }
            }
            file.Close();
            Console.WriteLine(position);
            Console.ReadLine();
        }

        #endregion
    }
}
