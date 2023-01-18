using System;
using System.Collections.Generic;
using System.Drawing;


namespace BallsGame
{
    internal class RandomPoints
    {
        Random random;
        public RandomPoints(){
           random = new Random();
        }

        public Point randomPoint(List<Point> points)
        { 
            int randomPoint1 = random.Next(points.Count);
            Point point1 = points[randomPoint1];
            points.RemoveAt(randomPoint1);
            return point1;
        }
    }
}
