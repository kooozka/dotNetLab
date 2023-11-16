using System;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool finish = false;
            while (!finish)
            {
                Console.WriteLine("Podaj współczynniki równania kwadratowego ax^2 + bx + c = 0");

                Console.Write("a: ");
                double a = Convert.ToDouble(Console.ReadLine());

                Console.Write("b: ");
                double b = Convert.ToDouble(Console.ReadLine());

                Console.Write("c: ");
                double c = Convert.ToDouble(Console.ReadLine());

                var solution = calculate(a, b, c);

                switch (solution.solutionsCount)
                {
                    case 0:
                        Console.WriteLine("No real solutions");
                        break;
                    case 1:
                        Console.WriteLine("One real solution: x1 = {0}", solution.x1);
                        break;
                    case 2:
                        Console.WriteLine($"Two real solutions: x1 = {solution.x1}, x2 = {solution.x2}");
                        break;
                }
                Console.Write("Do you want to continue? If so type yes: ");
                String input = Console.ReadLine().ToUpper();
                if (input != "YES")
                {
                    finish = true;
                }
            }

        }

        public static (int solutionsCount, string x1, string x2) calculate(double a, double b, double c)
        {
            if (a != 0 && b != 0)
            {
                double delta = b * b - 4 * a * c;
                if (delta > 0)
                {
                    double x1 = (Math.Sqrt(delta) - b) / (2 * a);
                    double x2 = (-Math.Sqrt(delta) - b) / (2 * a);
                    return (2, x1.ToString(), x2.ToString());
                }
                else if (delta == 0)
                {
                    double x = -b / (2 * a);
                    return (1, x.ToString(), "absent");
                }
                else
                {
                    return (0, "absent", "absent");
                }
            }
            else if (a != 0 && b == 0)
            {
                if ((-c / a) >= 0)
                {
                    double x1 = Math.Sqrt(-c / a);
                    double x2 = -Math.Sqrt(-c / a);
                    return (2, x1.ToString(), x2.ToString());
                }
                else
                {
                    return (0, "absent", "absent");
                }
            }
            else if (a == 0 && b != 0)
            {
                double x = c / b;
                return (1, x.ToString(), "absent");
            }
            else
            {
                return (0, "absent", "absent");
            }
        }
    }
}
