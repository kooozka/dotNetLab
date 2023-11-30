using System;

namespace List6
{
    internal class Program
    {
        private const int SPACES = 3;
        static void Main(string[] args)
        {
            //Task 1
            var myPersonalData = ("Jakub", "Kozanecki", 21, 1250.50);
            PrintPersonalData(myPersonalData);

            //Task 2
            var @class = "It is class variable";
            Console.WriteLine(@class);

            //Task 3
            int[] firstArray = { 7, 1, 8, 12, 4, 6 };
            int[] secondArray = { 2, 9, 11, 5, 4, 7 };

            PrintArray<int>(firstArray);
            PrintArray<int>(secondArray);

            ArraysPresentation(firstArray, secondArray);

            //Task 4
            var otherPersonalData = new { firstName = "Jan", secondName = "Kowalski", age = 33, salary = 6412.79 };
            DisplayAnonymousType(otherPersonalData);

            //Task 5
            PrintBuisnessCard("Ryszard", "Rys", "X", 2, 20);
            PrintBuisnessCard("Jan", "Brzęczyszczykiewicz", "X", 2, 20);
            PrintBuisnessCard("Jakub", "Kozanecki", "X", 2, 20);
            PrintBuisnessCard("Olek", "Mak", "X", 2, 30);
            PrintBuisnessCard("Aleksandra");
            PrintBuisnessCard("Aleksandra", borderSign: "X");
            PrintBuisnessCard("Aleksandra", borderSign: "X", borderWidth: 4, minWidth: 25);
            PrintBuisnessCard("Eugeniusz", secondLine: "Mróz", borderSign: "|", borderWidth: 7);

            //Task 6
            CountMyTypes("brzdac", 7, 22.12, -6, 4, 'h', "abc", "chrzascz", '#', -7.12);
        }

        private static void PrintPersonalData((string firstName, string secondName, int age, double salary) personalData)
        {
            Console.WriteLine("First way:");
            Console.WriteLine($"Person: {personalData.Item1} {personalData.Item2}; Age: {personalData.Item3}; Earns: {personalData.Item4}");

            Console.WriteLine("Second way:");
            Console.WriteLine($"Person: {personalData.firstName} {personalData.secondName}; Age: {personalData.age}; Earns: {personalData.salary}");

            Console.WriteLine("Third way:");
            (string firstName, string secondName, int age, double salary) info = personalData;

        }

        private static void ArraysPresentation(int[] firstArray, int[] secondArray)
        {
            Console.WriteLine("First array:");
            PrintArray<int>(firstArray);
            Console.WriteLine("Second array:");
            PrintArray<int>(secondArray);

            Array.Sort(firstArray);
            Console.WriteLine("First array sorted:");
            PrintArray<int>(firstArray);

            Array.Copy(firstArray, secondArray, 2);
            Console.WriteLine("Second array with two first elements from the first one:");
            PrintArray<int>(secondArray);

            Array.Reverse(firstArray);
            Console.WriteLine("First array reversed:");
            PrintArray<int>(firstArray);

            Array.Resize(ref secondArray, 3);
            Console.WriteLine("Second array size change:");
            PrintArray<int>(secondArray);

            int firstIndex = Array.IndexOf(firstArray, 6);
            int secondIndex =  Array.IndexOf(firstArray, 100);

            Console.WriteLine("Index of an existing value: " + firstIndex);
            Console.WriteLine("Index of a non-existing value: " + secondIndex);
        }

        private static void PrintArray<T>(T[] array)
        {
            foreach (T obj in array)
            {
                Console.Write(obj.ToString() + " ");
            }
            Console.WriteLine();
        }

        private static void DisplayAnonymousType(dynamic anonymousObject)
        {
            Console.WriteLine($"Name: {anonymousObject.firstName} {anonymousObject.secondName}");
        }

        private static void PrintBuisnessCard(string firstLine, string secondLine = "-", string borderSign = "#", int borderWidth = 2, int minWidth = 18)
        {
            if (borderWidth < 0)
            {
                Console.WriteLine("Border cannot be negative!");
            }
            else
            {
                int firstLineWidth = firstLine.Length + 2 * SPACES + 2 * borderWidth;
                int secondLineWidth = secondLine.Length + 2 * SPACES + 2 * borderWidth;
                int width = Math.Max(minWidth, Math.Max(firstLineWidth, secondLineWidth));

                PrintBorderLine(borderSign, width, borderWidth);
                PrintContentLine(firstLine, firstLineWidth, width, borderSign, borderWidth);
                PrintContentLine(secondLine, secondLineWidth, width, borderSign, borderWidth);
                PrintBorderLine(borderSign, width, borderWidth);
            }
        }

        private static void PrintBorderLine(string borderSign, int width, int borderWidth)
        {
            string borderLine = new string(borderSign[0], width);
            for (int i = 0; i < borderWidth; i++)
            {
                Console.WriteLine(borderLine);
            }
        }

        private static void PrintContentLine(string content, int contentWidth, int width, string borderSign, int borderWidth)
        {
             /*string borderr = new string(borderSign[0], borderWidth);
             int neededSpacesr = width - contentWidth;
             Console.Write(borderr);
             if (neededSpacesr % 2 != 0)
             {
                 printNeededSpaces(SPACES - 1 + neededSpacesr / 2);
             }
             else
             {
                 printNeededSpaces(SPACES + neededSpacesr / 2);
             }
             Console.Write(content);
             printNeededSpaces(SPACES + neededSpacesr / 2);
             Console.Write(borderr);
             Console.WriteLine();*/
             string border = new string(borderSign[0], borderWidth);
             int neededSpaces = width - contentWidth;
             int spacesBeforeContent = SPACES + neededSpaces / 2 + (neededSpaces % 2 != 0 ? +1 : 0);
             int spacesAfterContent = SPACES + neededSpaces / 2;

             Console.WriteLine(string.Concat(border, new string(' ', spacesBeforeContent), content, new string(' ', spacesAfterContent), border));
        }

        private static void CountMyTypes(params object[] tab)
        {
            int evenIntCount = 0;
            int positiveDoubleCount = 0;
            int longStringCount = 0;
            int otherTypesCount = 0;

            foreach (object o in tab)
            {
                switch (o)
                {
                    case int number when number % 2 == 0:
                        evenIntCount++;
                        break;
                    case double realNumber when realNumber > 0:
                        positiveDoubleCount++;
                        break;
                    case string str when str.Length >= 5:
                        longStringCount++;
                        break;
                    default:
                        otherTypesCount++;
                        break;
                }
            }
            Console.WriteLine($"Even ints: {evenIntCount}; Positive double: {positiveDoubleCount}; At least 5-chars long strings: {longStringCount}; other types: {otherTypesCount}");
        }
        
    }
}
