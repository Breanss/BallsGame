using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallsGame
{
    internal class Tools
    {
        public int numberColor(Color color)
        {
            if (color == Color.Yellow)
                return 4;
            else if (color == Color.Orange)
                return 5;
            else if (color==Color.Brown)
                return 6;
            else if(color==Color.Aqua)
                return 7;
            else if(color==Color.Green)
                return 8;
            else if(color==Color.Pink)
                return 9;
            else if (color == Color.Blue)
                return 10;
            return -1;
        }
    }
}
