using Microsoft.AspNetCore.Mvc;
using System;

namespace List8.Controllers
{
    public class ToolController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Solve(double a, double b, double c)
        {
            var result = calculate(a, b, c);
            switch (result.solutionsCount) {
                case 0:
                    ViewBag.Message = "No real solutions";
                    break;
                case 1:
                    ViewBag.Message = $"One real solution x = {result.x1}";
                    break;
                case 2:
                    ViewBag.Message = $"Two real solutions: x1 = {result.x1}, x2 = {result.x2}";
                    break;
                default:
                    ViewBag.Message = $"Identity equation";
                    break;
            }
            return View();
        }

        private static (int solutionsCount, double x1, double x2) calculate(double a, double b, double c)
        {
            if (a != 0)
            {
                double delta = b * b - 4 * a * c;

                if (delta > 0)
                {
                    double sqrtDelta = Math.Sqrt(delta);

                    double x1 = (-b + sqrtDelta) / 2 * a;
                    double x2 = (-b - sqrtDelta) / 2 * a;

                    return (2, x1, x2);
                }
                else if (delta == 0)
                {
                    double x = -b / (2 * a);
                    return (1, x, -1);
                }
                else if (b == 0)
                {
                    double x = Math.Sqrt(-c / a);
                    double x1 = x;
                    double x2 = -x;

                    return (x >= 0 ? 2 : 0, x1, x2);
                }
                else
                {
                    return (0, -1, -1);
                }
            }
            else if (b != 0)
            {
                double x = -c / b;
                return (1, x, -1);
            }
            else if (a == 0 && b == 0 && c == 0)
            {
                return (int.MaxValue, -1, -1);
            }
            else
            {
                return (0, -1, -1);
            }
        }
    }
}
