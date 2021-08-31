using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mine_Sweeper
{
    class Board
    {
        private Cell[,] table;

        public Cell[,] Table { get => table; set => table = value; }

        public readonly int size;

        public Board(int size)
        {
            this.size = size;
            table = new Cell[size, size];
            CreateTable();
            FillMines();
            SetNumbers();
        }

        public void Select(int x, int y)
        {
            if (table[x, y].Symbol == '0')
                OpenEmptyCells(x, y);
            else
                table[x, y].IsSelected = true;
        }

        public bool isSelectable(int x, int y)
        {
            if (IsInBoard(x, y))
                if (!table[x, y].IsSelected)
                    return true;
            return false;
        }

        public void OpenEmptyCells(int x, int y)
        {
            table[x, y].IsSelected = true;
            
            Cell[] neighbors = GetNeighbors(x, y);

            foreach (Cell neighbor in neighbors)
            {

                if (table[neighbor.Row, neighbor.Col].Symbol == '0' &&
                    table[neighbor.Row, neighbor.Col].IsSelected == false)
                {
                    OpenEmptyCells(neighbor.Row, neighbor.Col);
                }
                else
                {
                    table[neighbor.Row, neighbor.Col].IsSelected = true;
                }
            }
        }

        public void SetNumbers()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if(table[i, j].Symbol != '*')
                    {
                        int NumOfMines = CountMines(GetNeighbors(i, j));
                        table[i, j].Symbol = IntToChar(NumOfMines);
                    }
                }
            }
        }

        public int CountMines(Cell[] neighbors)
        {
            int amount = 0;

            foreach (Cell cell in neighbors)
            {
                if (cell.Symbol == '*')
                    amount++;
            }
            return amount;
        }

        public Cell[] GetNeighbors(int x, int y)
        {
            LinkedList<Cell> neighbors = new();

            if (IsInBoard(x + 1, y + 1))
                neighbors.AddLast(table[x + 1, y + 1]);
            if (IsInBoard(x + 1, y - 1))
                neighbors.AddLast(table[x + 1, y - 1]);
            if (IsInBoard(x - 1, y + 1))
                neighbors.AddLast(table[x - 1, y + 1]);
            if (IsInBoard(x - 1, y - 1))
                neighbors.AddLast(table[x - 1, y - 1]);
            if (IsInBoard(x, y + 1))
                neighbors.AddLast(table[x, y + 1]);
            if (IsInBoard(x, y - 1))
                neighbors.AddLast(table[x, y - 1]);
            if (IsInBoard(x + 1, y))
                neighbors.AddLast(table[x + 1, y]);
            if (IsInBoard(x - 1, y))
                neighbors.AddLast(table[x - 1, y]);

            return neighbors.ToArray();
        }

        public bool IsInBoard(int x, int y)
        {
            if (x >= 0 && y >= 0 && x < size && y < size)
                return true;
            return false;
        }

        public void FillMines()
        {
            Random rand = new();

            for (int i = 0; i < size; i++)
            {
                bool mineLocated = false;

                while(!mineLocated)
                {
                    int randX = rand.Next(size);
                    int randY = rand.Next(size);

                    if(table[randX, randY].Symbol == '-')
                    {
                        table[randX, randY].Symbol = '*';
                        mineLocated = true;
                    }

                }
            }
        }

        public void CreateTable()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    table[i, j] = new Cell(i, j);
                }
            }
        }

        public void ShowTable(bool PlayMode)
        {
            Console.Write(" ");

            for (int i = 0; i < size; i++)
                Console.Write(" " + i);

            Console.WriteLine();

            for (int i = 0; i < size; i++)
            {
                Console.Write(i + " ");
                for (int j = 0; j < size; j++)
                {

                    if (PlayMode)
                    {
                        if (table[i, j].IsSelected)
                        {
                            if (table[i, j].Symbol == '*')
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("\u25cf ");
                                Console.ResetColor();
                            }
                            else
                            {
                                if (table[i, j].Symbol != '0')
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write(table[i, j].Symbol + " ");
                                Console.ResetColor();
                            }
                        }
                        else
                            Console.Write("\u25a0 ");
                    }
                    else
                    {
                        if (table[i, j].Symbol == '*')
                        {
                            if (table[i, j].IsSelected)
                                Console.ForegroundColor = ConsoleColor.Red;
                            else
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("\u25cf ");
                            Console.ResetColor();
                        }
                        else if (table[i, j].Symbol != '0')
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write(table[i, j].Symbol + " ");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.Write(table[i, j].Symbol + " ");
                        }
                    }
                }
                Console.WriteLine();
            }
        }

        public static char IntToChar(int value)
        {
            return (char)(value + 48);
        }
    }
}