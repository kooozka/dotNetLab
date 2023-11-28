using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using static LinqExamples.StudentWithTopics;

namespace LinqExamples
{


    public class Department
    {
        public int Id { get; set; }
        public String Name { get; set; }

        public Department(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public override string ToString()
        {
            return $"{Id,2}), {Name,11}";
        }

    }

    public enum Gender
    {
        Female,
        Male
    }

    public class StudentWithTopics
    {
        public int Id { get; set; }
        public int Index { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public bool Active { get; set; }
        public int DepartmentId { get; set; }

        public List<string> Topics { get; set; }
        public StudentWithTopics(int id, int index, string name, Gender gender, bool active,
            int departmentId, List<string> topics)
        {
            this.Id = id;
            this.Index = index;
            this.Name = name;
            this.Gender = gender;
            this.Active = active;
            this.DepartmentId = departmentId;
            this.Topics = topics;
        }

        public class Topic
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public Topic(int id, string name)
            {
                Id = id;
                Name = name;
            }
        }

        public class Student
        {
            public int Id { get; set; }
            public int Index { get; set; }
            public string Name { get; set; }
            public Gender Gender { get; set; }
            public bool Active { get; set; }
            public int DepartmentId { get; set; }

            public List<int> TopicsIds { get; set; }
            public Student(int id, int index, string name, Gender gender, bool active,
                int departmentId, List<int> topicsIds)
            {
                this.Id = id;
                this.Index = index;
                this.Name = name;
                this.Gender = gender;
                this.Active = active;
                this.DepartmentId = departmentId;
                this.TopicsIds = topicsIds;
            }

            public override string ToString()
            {
                var result = $"{Id,2}) {Index,5}, {Name,11}, {Gender,6},{(Active ? "active" : "no active"),9},{DepartmentId,2}, topics: ";
                foreach (var str in TopicsIds)
                    result += str + ", ";
                return result;
            }
        }

        public static class Generator
        {
            public static int[] GenerateIntsEasy()
            {
                return new int[] { 5, 3, 9, 7, 1, 2, 6, 7, 8 };
            }

            public static int[] GenerateIntsMany()
            {
                var result = new int[10000];
                Random random = new Random();
                for (int i = 0; i < result.Length; i++)
                    result[i] = random.Next(1000);
                return result;
            }

            public static List<string> GenerateNamesEasy()
            {
                return new List<string>() {
                "Nowak",
                "Kowalski",
                "Schmidt",
                "Newman",
                "Bandingo",
                "Miniwiliger"
            };
            }
            public static List<StudentWithTopics> GenerateStudentsWithTopicsEasy()
            {
                return new List<StudentWithTopics>() {
            new StudentWithTopics(1,12345,"Nowak", Gender.Female,true,1,
                    new List<string>{"C#","PHP","algorithms"}),
            new StudentWithTopics(2, 13235, "Kowalski", Gender.Male, true,1,
                    new List<string>{"C#","C++","fuzzy logic"}),
            new StudentWithTopics(3, 13444, "Schmidt", Gender.Male, false,2,
                    new List<string>{"Basic","Java"}),
            new StudentWithTopics(4, 14000, "Newman", Gender.Female, false,3,
                    new List<string>{"JavaScript","neural networks"}),
            new StudentWithTopics(5, 14001, "Bandingo", Gender.Male, true,3,
                    new List<string>{"Java","C#"}),
            new StudentWithTopics(6, 14100, "Miniwiliger", Gender.Male, true,2,
                    new List<string>{"algorithms","web programming"}),
            new StudentWithTopics(11,22345,"Nowak", Gender.Female,true,2,
                    new List<string>{"C#","PHP","algorithms"}),
            new StudentWithTopics(12, 23235, "Nowak", Gender.Male, true,1,
                    new List<string>{"C#","C++","fuzzy logic"}),
            new StudentWithTopics(13, 23444, "Schmidt", Gender.Male, false,1,
                    new List<string>{"Basic","Java"}),
            new StudentWithTopics(14, 24000, "Newman", Gender.Female, false,1,
                    new List<string>{"JavaScript","neural networks"}),
            new StudentWithTopics(15, 24001, "Bandingo", Gender.Male, true,3,
                    new List<string>{"Java","C#"}),
            new StudentWithTopics(16, 24100, "Bandingo", Gender.Male, true,2,
                    new List<string>{"algorithms","web programming"}),
            };
            }

            public static List<Topic> generateTopics()
            {
                return new List<Topic>
                {
                    new Topic(1, "C#"),
                    new Topic(2, "PHP"),
                    new Topic(3, "algorithms"),
                    new Topic(4, "web programming"),
                    new Topic(5, "Java"),
                    new Topic(6, "Basic"),
                    new Topic(7, "neural networks"),
                    new Topic(8, "fuzzy logic"),
                    new Topic(9, "JavaScript"),
                    new Topic(10, "C++")
                };
            }


            public static List<Department> GenerateDepartmentsEasy()
            {
                return new List<Department>() {
            new Department(1,"Computer Science"),
            new Department(2,"Electronics"),
            new Department(3,"Mathematics"),
            new Department(4,"Mechanics")
            };
            }

        }
        class Program
        {
            //Task 1
            public static void SortAndGroupStudents(List<StudentWithTopics> students, int groupSize)
            {
                PrintTitle($"Sorted and grouped students. Group size: {groupSize}");

                var sortedStudents = students
                    .OrderBy(s => s.Name)
                    .ThenBy(s => s.Index)
                    .ToList();

                var groupedStudents = sortedStudents
                    .Select((s, index) => new { Student = s, GroupNumber = index / groupSize })
                    .GroupBy(item => item.GroupNumber, item => item.Student)
                    .Select(group => group.ToList())
                    .ToList();

                foreach (var studentGroup in groupedStudents)
                {
                    Console.WriteLine("---------------------------------------------------------------------------");
                    foreach (var student in studentGroup)
                    {
                        Console.WriteLine(student);
                    }
                }
                Console.WriteLine("---------------------------------------------------------------------------");
            }

            //Task 2
            public static void SortTopics(List<StudentWithTopics> students)
            {
                PrintTitle("Sorted topics");

                var sortedTopics = students
                    .SelectMany(s => s.Topics)
                    .GroupBy(topic => topic)
                    .OrderByDescending(group => group.Count())
                    .Select(group => group.Key)
                    .ToList();

                foreach (var topic in sortedTopics)
                {
                    Console.WriteLine(topic);
                }
            }

            public static void SortTopicsII(List<StudentWithTopics> students)
            {
                PrintTitle("Sorted and grouped topics");

                var sortedTopics = students
                  .SelectMany(s => s.Topics.Select(topic => new { Gender = s.Gender, Topic = topic }))
                  .GroupBy(st => new { st.Gender, st.Topic })
                  .OrderBy(group => group.Key.Gender)
                  .ThenByDescending(group => group.Count())
                  .ThenBy(group => group.Key.Topic);

                string currentGender = null;

                foreach (var group in sortedTopics)
                {
                    if (currentGender != group.Key.Gender.ToString())
                    {
                        Console.WriteLine("---------------------------------------------------------------------------");
                        Console.WriteLine($"Płeć: {group.Key.Gender}");
                        Console.WriteLine("---------------------------------------------------------------------------");
                        currentGender = group.Key.Gender.ToString();
                    }
                    Console.WriteLine($"  Przedmiot: {group.Key.Topic}, Częstość występowania: {group.Count()}");
                }

            }

            //Task 3
            public static List<Student> GetStudentsFromStudentsWithTopicsI(List<StudentWithTopics> studentsWithTopics)
            {
                PrintTitle("Students from Students With Topics #1");

                var students = studentsWithTopics
                    .Select(swt => new Student(
                        swt.Id,
                        swt.Index,
                        swt.Name,
                        swt.Gender,
                        swt.Active,
                        swt.DepartmentId,
                        GetTopicsIds(swt.Topics))).ToList();

                students.ForEach(s => Console.WriteLine(s));
                return students;
            }

            private static List<int> GetTopicsIds(List<string> topicsNames)
            {
                List<Topic> topics = Generator.generateTopics();
                List<int> topicsIds = new List<int>();

                topicsNames.ForEach(topicName => topicsIds.Add(FindTopicId(topicName, topics)));
                return topicsIds;
            }

            private static int FindTopicId(string topicName, List<Topic> topics)
            {
                foreach (Topic topic in topics)
                {
                    if (topic.Name == topicName)
                    {
                        return topic.Id;
                    }
                }
                return -1;
            }

            public static List<Student> GetStudentsFromStudentsWithTopicsII(List<StudentWithTopics> studentsWithTopics)
            {
                PrintTitle("Students from Students With Topics #1");

                var students =  studentsWithTopics
                    .Select(swt => new Student(
                        swt.Id,
                        swt.Index,
                        swt.Name,
                        swt.Gender,
                        swt.Active,
                        swt.DepartmentId,
                    GenerateTopics(swt.Topics))).ToList();

                students.ForEach(s => Console.WriteLine(s));
                return students;
            }

            private static List<int> GenerateTopics(List<string> topicsNames)
            {
                return topicsNames.Select(topicsName => topicsName.GetHashCode()).ToList();
            }

            private static void PrintTitle(string title)
            {
                Console.WriteLine();
                Console.WriteLine(title);
                Console.WriteLine();
            }


            static void Main()
            {
                //Task 1
                List<StudentWithTopics> students = Generator.GenerateStudentsWithTopicsEasy();
                SortAndGroupStudents(students, 2);
                SortAndGroupStudents(students, 3);
                SortAndGroupStudents(students, 5);

                //Task 2
                SortTopics(students);
                SortTopicsII(students);

                //Task3
                GetStudentsFromStudentsWithTopicsI(students);
                GetStudentsFromStudentsWithTopicsII(students);
            }
        }
    }
}
