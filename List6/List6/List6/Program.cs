using System;

namespace List6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var myPersonalData = ("Jakub", "Kozanecki", 21, 1250.50);
            printPersonalData(myPersonalData);
        }

        private static void printPersonalData((string firstName, string secondName, int age, double salary) personalData)
        {
            System.Console.WriteLine("First way:");
            System.Console.WriteLine($"Person: {personalData.Item1} {personalData.Item2}; Age: {personalData.Item3}; Earns: {personalData.Item4}");

            System.Console.WriteLine("Second way:");
            System.Console.WriteLine($"Person: {personalData.firstName} {personalData.secondName}; Age: {personalData.age}; Earns: {personalData.salary}");

            System.Console.WriteLine("Third way:");
            var name = personalData.firstName + " " + personalData.secondName;
            var age = personalData.age;
            var salary = personalData.salary;
            System.Console.WriteLine("Person: " + name + "; Age: " + age + "; Earns: " + salary);
        }
    }
}
