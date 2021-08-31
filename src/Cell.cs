using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mine_Sweeper
{
    class Cell
    {
        private int row;
        private int col;
        private char symbol;
        private bool isSelected;

        public int Row { get => row; set => row = value; }
        public int Col { get => col; set => col = value; }
        public char Symbol { get => symbol; set => symbol = value; }
        public bool IsSelected { get => isSelected; set => isSelected = value; }

        public Cell(int row, int col, char symbol)
        {
            this.row = row;
            this.col = col;
            this.symbol = symbol;
            isSelected = false;
        }

        public Cell(int row, int col)
        {
            this.row = row;
            this.col = col;
            symbol = '-';
            isSelected = false;
        }
    }
}
