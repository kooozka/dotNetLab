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
            printPersonalData(myPersonalData);

            //Task 2
            var @class = "It is class variable";
            Console.WriteLine(@class);

            //Task 3
            int[] firstArray = { 7, 1, 8, 12, 4, 6 };
            int[] secondArray = { 2, 9, 11, 5, 4, 7 };

            printArray<int>(firstArray);
            printArray<int>(secondArray);

            arraysPresentation(firstArray, secondArray);

            //Task 4
            var otherPersonalData = new { firstName = "Jan", secondName = "Kowalski", age = 33, salary = 6412.79 };
            Console.WriteLine($"Person: {otherPersonalData.firstName} {otherPersonalData.secondName}; Age: {otherPersonalData.age}; Earns: {otherPersonalData.salary}");

            //Task 5
            printBuisnessCard("Ryszard", "Rys", "X", 2, 20);
            printBuisnessCard("Jan", "Brzęczyszczykiewicz", "X", 2, 20);
            printBuisnessCard("Jakub", "Kozanecki", "X", 2, 20);
            printBuisnessCard("Olek", "Mak", "X", 2, 30);
            printBuisnessCard("Aleksandra");
            printBuisnessCard("Aleksandra", borderSign: "X");
            printBuisnessCard("Aleksandra", borderSign: "X", borderWidth: 4, minWidth: 25);
            printBuisnessCard("Eugeniusz", secondLine: "Mróz", borderSign: "|", borderWidth: 7);


        }

        private static void printPersonalData((string firstName, string secondName, int age, double salary) personalData)
        {
            Console.WriteLine("First way:");
            Console.WriteLine($"Person: {personalData.Item1} {personalData.Item2}; Age: {personalData.Item3}; Earns: {personalData.Item4}");

            Console.WriteLine("Second way:");
            Console.WriteLine($"Person: {personalData.firstName} {personalData.secondName}; Age: {personalData.age}; Earns: {personalData.salary}");

            Console.WriteLine("Third way:");
            var name = personalData.firstName + " " + personalData.secondName;
            var age = personalData.age;
            var salary = personalData.salary;
            Console.WriteLine("Person: " + name + "; Age: " + age + "; Earns: " + salary);
        }

        private static void arraysPresentation(int[] firstArray, int[] secondArray)
        {
            Console.WriteLine("First array:");
            printArray<int>(firstArray);
            Console.WriteLine("Second array:");
            printArray<int>(secondArray);

            Array.Sort(firstArray);
            Console.WriteLine("First array sorted:");
            printArray<int>(firstArray);

            Array.Copy(firstArray, secondArray, 2);
            Console.WriteLine("Second array with two first elements from the first one:");
            printArray<int>(secondArray);

            Array.Reverse(firstArray);
            Console.WriteLine("First array reversed:");
            printArray<int>(firstArray);

            Array.Resize(ref secondArray, 3);
            Console.WriteLine("Second array size change:");
            printArray<int>(secondArray);

            int firstIndex = Array.IndexOf(firstArray, 6);
            int secondIndex =  Array.IndexOf(firstArray, 100);

            Console.WriteLine("Index of an existing value: " + firstIndex);
            Console.WriteLine("Index of a non-existing value: " + secondIndex);
        }

        private static void printArray<T>(T[] array)
        {
            foreach (T obj in array)
            {
                Console.Write(obj.ToString() + " ");
            }
            Console.WriteLine();
        }

        private static void printBuisnessCard(string firstLine, string secondLine = "-", string borderSign = "#", int borderWidth = 2, int minWidth = 18)
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

                printBorderLine(borderSign, width, borderWidth);
                printContentLine(firstLine, firstLineWidth, width, borderSign, borderWidth);
                printContentLine(secondLine, secondLineWidth, width, borderSign, borderWidth);
                printBorderLine(borderSign, width, borderWidth);
            }
        }

        private static void printBorderLine(string borderSign, int width, int borderWidth)
        {
            string borderLine = new string(borderSign[0], width);
            for (int i = 0; i < borderWidth; i++)
            {
                Console.WriteLine(borderLine);
            }
        }

        private static void printContentLine(string content, int contentWidth, int width, string borderSign, int borderWidth)
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

        private static void printNeededSpaces(int neededSpaces)
        {
            for (int i = 0; i < neededSpaces; i++)
            {
                Console.Write(" ");
            }
        }

        
    }
}
