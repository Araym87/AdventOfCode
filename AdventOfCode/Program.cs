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
using AdventOfCode.FifteenthDay;
using AdventOfCode.FourteenthDay;
using AdventOfCode.NinthDay;
using AdventOfCode.SeventhDay;
using AdventOfCode.ThirteenthDay;
using AdventOfCode.TwelfthDay;

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
            //NinthDay();
            //TenthDay(40);
            //TenthDay(50);
            //EleventhDay("cqjxjnds");
            //EleventhDay(EleventhDay("cqjxjnds", false));
            //TwelfthDayPartOne();
            //TwelfthDayPartTwo();
            //ThirteenthDay();
            //ThirteenthDay(true);
            //FourteenthDayPartOne();
            //FourteenthDayPartTwo();
            //FifteenthDayPartOne();
            //FifteenthDayPartTwo();
            Console.ReadLine();
        }

        #region DayFifteen

        private static void FifteenthDayPartOne()
        {
            const int SPOONS = 100;
            string line;
            var file = new StreamReader("Inputs\\inputDayFifteen.txt");
            var ingredients = new List<Ingredient>();

            while ((line = file.ReadLine()) != null)
            {
                var parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                ingredients.Add(new Ingredient
                {
                    Name = parts[0].Trim(':'),
                    Capacity = Convert.ToInt32(parts[2].Trim(',')),
                    Durability = Convert.ToInt32(parts[4].Trim(',')),
                    Flavor = Convert.ToInt32(parts[6].Trim(',')),
                    Texture = Convert.ToInt32(parts[8].Trim(',')),
                    Calories = Convert.ToInt32(parts[10].Trim()),

                });
            }
            var maximum = long.MinValue;
            for (int ingedientOne = 0; ingedientOne <= SPOONS; ingedientOne++)
            {
                for (int ingedientTwo = 0; ingedientTwo <= SPOONS - (ingedientOne); ingedientTwo++)
                {
                    for (int ingedientThree = 0; ingedientThree <= SPOONS - (ingedientOne + ingedientTwo); ingedientThree++)
                    {
                        var ingredientFour = SPOONS - (ingedientOne + ingedientTwo + ingedientThree);

                        var totalCapacity = ingredients[0].Capacity*ingedientOne + ingredients[1].Capacity * ingedientTwo +
                                        ingredients[2].Capacity*ingedientThree + ingredients[3].Capacity * ingredientFour;

                        var totalDurability = ingredients[0].Durability * ingedientOne + ingredients[1].Durability * ingedientTwo +
                                        ingredients[2].Durability * ingedientThree + ingredients[3].Durability * ingredientFour;

                        var totalFlavor = ingredients[0].Flavor * ingedientOne + ingredients[1].Flavor * ingedientTwo +
                                        ingredients[2].Flavor * ingedientThree + ingredients[3].Flavor * ingredientFour;

                        var totalTexture = ingredients[0].Texture * ingedientOne + ingredients[1].Texture * ingedientTwo +
                                        ingredients[2].Texture * ingedientThree + ingredients[3].Texture * ingredientFour;
                        totalTexture = totalTexture < 0 ? 0 : totalTexture;
                        totalFlavor = totalFlavor < 0 ? 0 : totalFlavor;
                        totalDurability = totalDurability < 0 ? 0 : totalDurability;
                        totalCapacity = totalCapacity < 0 ? 0 : totalCapacity;

                        var total = (long) (totalTexture*totalFlavor*totalDurability*totalCapacity);
                        if (maximum < total)
                            maximum = total;
                    }
                }
            }

            file.Close();
            Console.WriteLine($"Maximum score is {maximum}");
        }

        private static void FifteenthDayPartTwo()
        {
            const int SPOONS = 100;
            string line;
            var file = new StreamReader("Inputs\\inputDayFifteen.txt");
            var ingredients = new List<Ingredient>();

            while ((line = file.ReadLine()) != null)
            {
                var parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                ingredients.Add(new Ingredient
                {
                    Name = parts[0].Trim(':'),
                    Capacity = Convert.ToInt32(parts[2].Trim(',')),
                    Durability = Convert.ToInt32(parts[4].Trim(',')),
                    Flavor = Convert.ToInt32(parts[6].Trim(',')),
                    Texture = Convert.ToInt32(parts[8].Trim(',')),
                    Calories = Convert.ToInt32(parts[10].Trim()),

                });
            }
            var maximum = long.MinValue;
            for (var ingedientOne = 0; ingedientOne <= SPOONS; ingedientOne++)
            {
                for (var ingedientTwo = 0; ingedientTwo <= SPOONS - (ingedientOne); ingedientTwo++)
                {
                    for (var ingedientThree = 0; ingedientThree <= SPOONS - (ingedientOne + ingedientTwo); ingedientThree++)
                    {
                        var ingredientFour = SPOONS - (ingedientOne + ingedientTwo + ingedientThree);
                        var totalCalories = ingredients[0].Calories * ingedientOne + ingredients[1].Calories * ingedientTwo +
                                        ingredients[2].Calories * ingedientThree + ingredients[3].Calories * ingredientFour;

                        if (totalCalories != 500)
                            continue;

                        var totalCapacity = ingredients[0].Capacity * ingedientOne + ingredients[1].Capacity * ingedientTwo +
                                        ingredients[2].Capacity * ingedientThree + ingredients[3].Capacity * ingredientFour;

                        var totalDurability = ingredients[0].Durability * ingedientOne + ingredients[1].Durability * ingedientTwo +
                                        ingredients[2].Durability * ingedientThree + ingredients[3].Durability * ingredientFour;

                        var totalFlavor = ingredients[0].Flavor * ingedientOne + ingredients[1].Flavor * ingedientTwo +
                                        ingredients[2].Flavor * ingedientThree + ingredients[3].Flavor * ingredientFour;

                        var totalTexture = ingredients[0].Texture * ingedientOne + ingredients[1].Texture * ingedientTwo +
                                        ingredients[2].Texture * ingedientThree + ingredients[3].Texture * ingredientFour;

                        totalTexture = totalTexture < 0 ? 0 : totalTexture;
                        totalFlavor = totalFlavor < 0 ? 0 : totalFlavor;
                        totalDurability = totalDurability < 0 ? 0 : totalDurability;
                        totalCapacity = totalCapacity < 0 ? 0 : totalCapacity;
                        totalCalories = totalCalories < 0 ? 0 : totalCalories;

                        var total = (long)(totalTexture * totalFlavor * totalDurability * totalCapacity);
                        if (maximum < total)
                            maximum = total;
                    }
                }
            }

            file.Close();
            Console.WriteLine($"Maximum score is {maximum}, while calories equals 500");
        }

        #endregion

        #region DayFourteen

        private static void FourteenthDayPartOne()
        {
            const int TIME = 2503;
            string line;
            var file = new StreamReader("Inputs\\inputDayFourteen.txt");
            var results = new Dictionary<string, int>();

            while ((line = file.ReadLine()) != null)
            {
                var parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var reindeer = parts[0].Trim();
                var speed = Convert.ToInt32(parts[3].Trim());
                var rideTime = Convert.ToInt32(parts[6].Trim());
                var relaxTime = Convert.ToInt32(parts[parts.Length - 2].Trim());

                var secondsOfRide = 0;
                var restOfTime = TIME%(rideTime + relaxTime);
                secondsOfRide = restOfTime > rideTime ? rideTime : restOfTime;

                var cycles = Math.Floor(((decimal)TIME /(rideTime + relaxTime)));
                secondsOfRide += (int)cycles*rideTime;
                results.Add(reindeer, secondsOfRide * speed);
            }

            file.Close();
            Console.WriteLine($"Biggest distance is {results.Values.OrderByDescending(i => i).ToList()[0]} km");
        }

        private static void FourteenthDayPartTwo()
        {
            const int TIME = 2503;
            string line;
            var file = new StreamReader("Inputs\\inputDayFourteen.txt");
            var reindeers = new List<Reindeer>();

            while ((line = file.ReadLine()) != null)
            {
                var parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                reindeers.Add(new Reindeer
                {
                    Name = parts[0].Trim(),
                    Speed = Convert.ToInt32(parts[3].Trim()),
                    RideTime = Convert.ToInt32(parts[6].Trim()),
                    RelaxTime = Convert.ToInt32(parts[parts.Length - 2].Trim())
                });
            }

            for (var i = 1; i <= TIME; i++)
            {
                reindeers.ForEach(r => r.RideOrRelax(i));
                var max = int.MinValue;
                foreach (var reindeer in reindeers.OrderByDescending(r => r.Distance))
                {
                    if (max <= reindeer.Distance)
                    {
                        max = reindeer.Distance;
                        reindeer.Points++;
                    }
                    else
                        break;
                }
            }

            file.Close();
            Console.WriteLine($"The most points have {reindeers.OrderByDescending(r => r.Points).First().Name} with {reindeers.OrderByDescending(r => r.Points).First().Points} points");
        }

        #endregion


        #region DayThirteen

        private static void ThirteenthDay(bool addMe = false)
        {
            string line;
            var file = new StreamReader("Inputs\\inputDayThirteen.txt");

            var allPersons = new List<Person>();
            while ((line = file.ReadLine()) != null)
            {
                var parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var happy = Convert.ToInt32(parts[3]);
                happy *= parts[2].Equals("lose") ? -1 : 1;
                var persons = new List<string>
                {
                    parts[0],
                    parts[parts.Length - 1].Trim('.'),
                };
                var i = 0;
                foreach (var person in persons)
                {
                    var personExist = allPersons.FirstOrDefault(p => p.Name.Equals(person));
                    if (personExist == null)
                    {
                        personExist = new Person() {Name = person};
                        allPersons.Add(personExist);
                    }
                    if(i == 0)
                        personExist.Relations.Add(persons[1], happy);

                    i++;
                }
            }

            if (addMe)
            {
                var newPerson = new Person {Name = "Araym"};
                foreach (var person in allPersons)
                {
                    person.Relations.Add(newPerson.Name, 0);
                    newPerson.Relations.Add(person.Name, 0);
                }
                allPersons.Add(newPerson);
            }

            var biggestHappiness = int.MinValue;
            foreach (var person in allPersons)
            {
                Combinations(allPersons, person, new List<string>(), allPersons.Count, 0, ref biggestHappiness);
            }

            file.Close();

            Console.WriteLine($"Biggest happiness is {biggestHappiness}");
            
        }

        private static void Combinations(List<Person> allPersons, Person actualPerson, List<string> sittedPersons, int totalPersons, int totalHappiness, ref int biggestHappiness)
        {
            sittedPersons.Add(actualPerson.Name);
            if (sittedPersons.Count.Equals(totalPersons))
            {
                totalHappiness += CountHappiness(actualPerson, allPersons.First(p => p.Name.Equals(sittedPersons[0])));

                if (totalHappiness > biggestHappiness)
                    biggestHappiness = totalHappiness;
                return;
            }

            foreach (var relation in actualPerson.Relations.Where(relation => !sittedPersons.Exists(p => p.Equals(relation.Key))))
            {                
                Combinations(allPersons, allPersons.First(p => p.Name.Equals(relation.Key)), sittedPersons.ToList(), totalPersons, totalHappiness + CountHappiness(actualPerson, allPersons.First(p => p.Name.Equals(relation.Key))), ref biggestHappiness);
            }
        }

        private static int CountHappiness(Person person1, Person person2)
        {
            var happy = person1.Relations[person2.Name];
            happy += person2.Relations[person1.Name];

            return happy;
        }

        #endregion

        #region DayTwelve

      

        private static void TwelfthDayPartOne()
        {
            var file = new StreamReader("Inputs\\inputDayTwelve.txt");

            var line = file.ReadLine();
            line = Regex.Replace(line, "\"[A-Za-z1-9]*\"", "");
            var m = Regex.Matches(line, "-?\\d+");
            var sum = 0;
            foreach (Match match in m)
            {
                int value;
                if (int.TryParse(match.Value, out value))
                    sum += value;
            }

            file.Close();
            Console.WriteLine($"Sum is {sum}");
            
        }


        private static List<StringItem> found;
        private static List<StringItem> foundCurly;

        private static void TwelfthDayPartTwo()
        {
            const string CURLY_BRACKETS = "\\{[^\\{\\}]+\\}";
            const string BRACKETS = "\\[[^\\[\\]]+\\]";
            var file = new StreamReader("Inputs\\inputDayTwelve.txt");
            found = new List<StringItem>();
            foundCurly = new List<StringItem>();
            var line = file.ReadLine();

            // Change all [] to guid, because it does not change my result
            while (Regex.IsMatch(line, BRACKETS))
            {
                line = Regex.Replace(line, BRACKETS, m => Replacement(m.Captures[0].Value));
            }

            var g = Guid.NewGuid();
            found.Add(new StringItem
            {
                Content = line,
                Guid = g
            });

            line = g.ToString();

            // Go through every [] to find {} with Red and delete them
            for (var i = found.Count - 1; i >= 0; i--)
            {
                while (Regex.IsMatch(found[i].Content, CURLY_BRACKETS))
                {
                    found[i].Content = Regex.Replace(found[i].Content, CURLY_BRACKETS, m => ReplacementCurly(m.Captures[0].Value));
                }
                for (var j = foundCurly.Count - 1; j >= 0;j--)
                {
                    found[i].Content = Regex.Replace(found[i].Content, foundCurly[j].Guid.ToString(), foundCurly[j].Content);
                }
                foundCurly.Clear();

                line = Regex.Replace(line, found[i].Guid.ToString(), found[i].Content);
            }

            // Just count it, same asi Part 1
            line = Regex.Replace(line, "\"[A-Za-z1-9]*\"", "");
            var matches = Regex.Matches(line, "-?\\d+");
            var sum = 0;
            foreach (Match match in matches)
            {
                int value;
                if (int.TryParse(match.Value, out value))
                    sum += value;
            }

            file.Close();
            Console.WriteLine($"Sum is {sum}");
            
        }

        private static string Replacement(string r)
        {
            var guid = Guid.NewGuid();

            found.Add(new StringItem
            {
                Content = r,
                Guid = guid
            });
            return string.Format(guid.ToString());
        }

        private static string ReplacementCurly(string r)
        {
            var guid = Guid.NewGuid();
            var replace = guid.ToString();
            if (r.Contains("red"))
                replace = string.Empty;
            else
                foundCurly.Add(new StringItem
                {
                    Content = r,
                    Guid = guid
                });
            return replace;
        }

        #endregion

        #region DayEleven

        private static string EleventhDay(string input, bool write = true)
        {
            var array = new List<char>(input.ToList());
            var index = array.Count - 1;
            while (true)
            {
                if (array.Count(i => i.Equals('z')) == array.Count)
                {
                    array.Insert(0, 'a');
                    array.Add('a');
                    index = 0;
                }

                if (array[index] != 'z')
                    array[index] = IterateChar(array[index]);
                else
                {
                    // Go back and check, where i Can iterate
                    for (int i = index-1;i >= 0; i--)
                    {
                        if (array[i] != 'z')
                        {
                            array[i] = IterateChar(array[i]);
                            for (int j = i+1; j < array.Count; j++)
                            {
                                array[j] = 'a';
                            }
                            index = array.Count - 1;
                            break;
                        }
                    }
                }

                // Check sequence of three increasing letters
                var sequnece = 0;
                for (int i = 1; i < array.Count; i++)
                {
                    if (array[i] - array[i - 1] == 1)
                        sequnece++;
                    else
                        sequnece = 0;

                    if (sequnece == 2)
                        break;
                }

                // Check doubled letters
                var doubled = 0;
                var foundDouble = '-';
                for (int i = 1; i < array.Count; i++)
                {
                    if (array[i] - array[i - 1] == 0 && !array[i-1].Equals(foundDouble))
                    {
                        doubled++;
                        foundDouble = array[i];
                    }

                    if (doubled == 2)
                        break;
                }


                if (sequnece == 2 && doubled == 2)
                    break;
            }

            var result = new string(array.ToArray());
            if (write)
            {
                Console.WriteLine(result);
                
            }

            return result;
        }

        private static char IterateChar(char actualLetter)
        {
            var skipLetters = new List<char> { 'i', 'o', 'l' };
            do
            {
                actualLetter++;
            } while (skipLetters.Exists(i => i.Equals(actualLetter)));

            return actualLetter;
        }

        #endregion

        #region DayTen

        private static void TenthDay(int iterations)
        {
            var input = "3113322113";

            for (var i = 0; i < iterations; i++)
            {
                var newInput = new StringBuilder();
                var numberOfSameChar = 1;
                var lastChar = char.MaxValue;
                foreach (var @char in input)
                {
                    if (lastChar.Equals(char.MaxValue))
                    {
                        lastChar = @char;
                        continue;
                    }
                    if (@char.Equals(lastChar))
                    {
                        numberOfSameChar++;
                        continue;
                    }

                    newInput.Append($"{numberOfSameChar}{lastChar}");
                    lastChar = @char;
                    numberOfSameChar = 1;
                }
                newInput.Append($"{numberOfSameChar}{lastChar}");
                input = newInput.ToString();
            }

            Console.WriteLine($"Length of result: {input.Length}");
            
        }

        #endregion

        #region DayNine

        private static void NinthDay()
        {
            string line;
            var file = new StreamReader("Inputs\\inputDayNine.txt");

            var cities = new List<City>();
            while ((line = file.ReadLine()) != null)
            {
                var parts = line.Split(new[] {'='}, StringSplitOptions.RemoveEmptyEntries);
                var citiesString =
                    parts[0].Split(new[] {" to "}, StringSplitOptions.RemoveEmptyEntries).Select(i => i.Trim()).ToList();

                var route = new Route {Distance = int.Parse(parts[1].Trim())};
                foreach (var city in citiesString)
                {
                    var cityExist = cities.FirstOrDefault(c => c.Name.Equals(city));
                    if (cityExist == null)
                    {
                        cityExist = new City {Name = city};
                        cities.Add(cityExist);
                    }
                    if (route.City1 == null)
                    {
                        cityExist.OneWays.Add(route);
                        route.City1 = cityExist;
                    }
                    else
                    {
                        cityExist.OneWays.Add(new Route
                        {
                            City1 = cityExist,
                            City2 = route.City1,
                            Distance = route.Distance
                        });
                        route.City2 = cityExist;
                    }
                }
            }

            var shortestDistance = int.MaxValue;
            var longestDistance = int.MinValue;
            foreach (var city in cities)
            {
                Travel(city, new List<string>(), cities.Count, 0, ref shortestDistance, ref longestDistance);
            }

            file.Close();

            Console.WriteLine($"Shortest distance is {shortestDistance}");
            Console.WriteLine($"Longest distance is {longestDistance}");
            
        }

        private static void Travel(City actualCity, ICollection<string> visitedCities, int totalCities, int distance, ref int shortestDistance, ref int longestDistance)
        {
            // Cannot use, because I am looking also for the longest route
            //if(distance > shortestDistance)
            //    return;
            visitedCities.Add(actualCity.Name);
            if (visitedCities.Count.Equals(totalCities))
            {
                if (distance < shortestDistance)
                    shortestDistance = distance;
                if (distance > longestDistance)
                    longestDistance = distance;
                return;
            }

            foreach (var route in actualCity.OneWays.Where(route => !visitedCities.Contains(route.City2.Name)))
            {
                Travel(route.City2, visitedCities.ToList(), totalCities, distance + route.Distance, ref shortestDistance, ref longestDistance);
            }
        }

        #endregion

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
                foreach (var operation in operations.Where(operation => parts[0].Contains(operation.ToString())))
                {
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

            Computate(knownResults, items);
            using (StreamWriter outputFile = new StreamWriter("Lucaso.txt"))
            {
                foreach (var i in knownResults.OrderBy(i => i.Key))
                    outputFile.WriteLine(i.Key + "->" + i.Value);
            }
            file.Close();
            
            Console.WriteLine($"Signal on wire a is {knownResults["a"]}");
            
        }

        private static void Computate(Dictionary<string, ushort> knownResults, List<Node> items)
        {
            while (!knownResults.ContainsKey("a"))
            {
                // Find all nodes, which can be counted
                var countableItems = items.Where(i => i.Childs.TrueForAll(j => knownResults.ContainsKey(j))).ToList();

                foreach (var countableItem in countableItems)
                {
                    var shorts = countableItem.Childs.Select(child => knownResults[child]).ToList();
                    if (countableItem.KnownChildValue.HasValue)
                        shorts.Add(countableItem.KnownChildValue.Value);

                    if (countableItem.Childs.Exists(i => i.Length == 3))
                        shorts.Reverse();
                    if (!knownResults.ContainsKey(countableItem.Root))
                        knownResults.Add(countableItem.Root, Calculate(countableItem.Operation, shorts));

                    items.Remove(countableItem);
                }
            }
        }

        private static ushort Calculate(Operation operation, IReadOnlyList<ushort> items)
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
                foreach (var operation in operations.Where(operation => parts[0].Contains(operation.ToString())))
                {
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
            Computate(results, items);

            knownResults["b"] = results["a"];
            items = items2;
            Computate(knownResults, items);

            file.Close();
            Console.WriteLine($"Signal on wire a is {knownResults["a"]}");
            
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
            
        }

        #endregion
    }
}
