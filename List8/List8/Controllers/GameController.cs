using Microsoft.AspNetCore.Mvc;
using System;

namespace List8.Controllers
{
    public class GameController : Controller
    {
        private static int range = 1;
        private static int randValue = 0;
        private static int guessCount = 0;
        private static Random random = new Random();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Set(int n)
        {
            range = n;
            randValue = random.Next(0, n);
            ViewBag.Message = $"Range set to {n - 1}. Value changed. Try to guess it!";
            ViewBag.CssClass = "aqua-colored";
            return View("Game");
        }

        public IActionResult Draw()
        {
            randValue = random.Next(0, range);
            ViewBag.Message = $"Value is set. Try to guess it!";
            ViewBag.CssClass = "aqua-colored";
            return View("Game");
        }

        public IActionResult Guess(int guess) {
            guessCount++;
            if (guess < 0)
            {
                ViewBag.Message = $"Given number - {guess} is too small. Remember that the number is 0 or bigger.";
                ViewBag.CssClass = "blue-colored";
            }
            else
            {
                if (guess == randValue)
                {
                    ViewBag.Message = $"Correct number - {guess}! You tried {guessCount} times.";
                    ViewBag.CssClass = "green-colored";
                    guessCount = 0;
                }
                else if (guess < randValue)
                {
                    ViewBag.Message = $"Given number - {guess} is too small";
                    ViewBag.CssClass = "blue-colored";
                }
                else
                {
                    ViewBag.Message = $"Given number - {guess} is too big";
                    ViewBag.CssClass = "red-colored";
                }
            }
            return View("Game");
        }
    }
}
