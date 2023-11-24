using System;

namespace List6
{
    internal class Program
    {
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

            arraysPresentation(firstArray, secondArray);   
            
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
    }
}
