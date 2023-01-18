using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
   
    internal class Board { 
    
        private int[,] _cells;

        public Board()
        {
            this._cells = new int[9, 9];

        }

        public void setCells(int x, int y, int value)
        {
            _cells[x, y] = value;
        }

        public void setCellsTab(int[,] tab)
        {
            _cells = tab;
        }

        public int[,] getCells()
        {
            return _cells;
        }

    }
}
