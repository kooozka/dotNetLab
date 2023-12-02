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
            ViewBag.Message = $"Range set to {n}; randVal: {randValue}";
            return View("Game");
        }

        public IActionResult Draw()
        {
            randValue = random.Next(0, range);
            ViewBag.Message = $"Rand value: {randValue}";

            return View("Game");
        }

        public IActionResult Guess(int guess) {
            guessCount++;
            if (guess == randValue)
            { 
                ViewBag.Message = $"Correct number - {guess}! You tried {guessCount} times.";
                guessCount = 0;
            } else if (guess < randValue)
            {
                ViewBag.Message = $"Given number - {guess} is too small";
            } else
            {
                ViewBag.Message = $"Given number - {guess} is too big";
            }
            return View("Game");
        }
    }
}
