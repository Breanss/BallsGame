using System;
using System.Collections.Generic;

namespace BallsGame
{
    internal class RandomColors
    {
        Random random;
        public RandomColors()
        {
            random = new Random();
        }

        public List<int> randomColors()
        {
            List<int> colors = new List<int>
            {
                random.Next(0, 7),
                random.Next(0, 7),
                random.Next(0, 7)
            };

            return colors;
        }
    }
}
