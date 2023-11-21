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
                double a;
                if (!double.TryParse(Console.ReadLine(), out a))
                {
                    Console.WriteLine("Błędne dane dla 'a'. Spróbuj ponownie.");
                    continue; // Kontynuuj pętlę od nowa
                }

                Console.Write("b: ");
                double b;
                if (!double.TryParse(Console.ReadLine(), out b))
                {
                    Console.WriteLine("Błędne dane dla 'b'. Spróbuj ponownie.");
                    continue; // Kontynuuj pętlę od nowa
                }

                Console.Write("c: ");
                double c;
                if (!double.TryParse(Console.ReadLine(), out c))
                {
                    Console.WriteLine("Błędne dane dla 'c'. Spróbuj ponownie.");
                    continue; // Kontynuuj pętlę od nowa
                }

                var solution = calculate(a, b, c);

                switch (solution.solutionsCount)
                {
                    case 0:
                        Console.WriteLine("Brak rzeczywistych rozwiązań");
                        break;
                    case 1:
                        Console.WriteLine("Jedno rzeczywiste rozwiązanie: x1 = {0}", solution.x1);
                        break;
                    case 2:
                        Console.WriteLine($"Dwa rzeczywiste rozwiązania: x1 = {solution.x1}, x2 = {solution.x2}");
                        break;
                }

                Console.Write("Czy chcesz kontynuować? Jeśli tak, wpisz 'tak': ");
                string input = Console.ReadLine().ToUpper();
                if (input != "TAK")
                {
                    finish = true;
                }
            }
        }

        public static (int solutionsCount, string x1, string x2) calculate(double a, double b, double c)
        {
            if (a != 0)
            {
                double delta = b * b - 4 * a * c;

                if (delta > 0)
                {
                    double sqrtDelta = Math.Sqrt(delta);

                    double x1 = (-b + sqrtDelta) / 2 * a;
                    double x2 = (-b - sqrtDelta) / 2 * a;

                    return (2, x1.ToString(), x2.ToString());
                }
                else if (delta == 0)
                {
                    double x = -b / (2 * a);
                    return (1, x.ToString(), "absent");
                }
                else if (b == 0)
                {
                    double x = Math.Sqrt(-c / a);
                    double x1 = x;
                    double x2 = -x;

                    return (x >= 0 ? 2 : 0, x1.ToString(), x2.ToString());
                }
                else
                {
                    return (0, "absent", "absent");
                }
            }
            else if (b != 0)
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
