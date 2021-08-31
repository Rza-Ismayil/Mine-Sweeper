using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mine_Sweeper
{
    class Player
    {
        public string name;
        public Board board;

        public Player()
        {
            Console.Write("Please, enter your name: ");
            name = Console.ReadLine();
            board = new(GetLevel());
        }

        public void OpenCell()
        {
            string input; 
            int[] inputs = new int[2];
            int row = -1;
            int col = -1;

            bool ValidInputEntered = false;

            while(!ValidInputEntered)
            {
                board.ShowTable(true);
                Console.Write("Dear {0}, please enter the coordinates you want to open as rown and column (ex. 3 4): ",name);
                input = Console.ReadLine();

                if (SetInputIfValid(input, inputs))
                {
                    row = inputs[0];
                    col = inputs[1];
                    if (board.isSelectable(row, col))
                    {
                        board.Select(row, col);
                        ValidInputEntered = true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("The cell is already been selected.");
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter in valid format and in bounds (ex. 1 7)");
                    Console.ResetColor();
                }
            }   
        }

        public bool SetInputIfValid(string input, int[] output)
        {
            string[] inputs = input.Split(' ');
            if (inputs.Length != 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Dear {0}, more or less than 2 inputs is not valid! Only 2 inputs must be written", name);
                Console.ResetColor();
                return false;
            }

            if (!int.TryParse(inputs[0], out _))
            {
                return false;
            }
            else
            {
                if (int.Parse(inputs[0]) < 0 || int.Parse(inputs[0]) >= board.size)
                    return false;
            }

            if (!int.TryParse(inputs[1], out _))
            {
                return false;
            }
            else
            {
                if (int.Parse(inputs[1]) < 0 || int.Parse(inputs[1]) >= board.size)
                    return false;
            }

            output[0] = int.Parse(inputs[0]);
            output[1] = int.Parse(inputs[1]);

            return true;
        }

        public int GetLevel()
        {
            bool isLevelSelected = false;

            int size = -1;

            while(!isLevelSelected)
            {
                Console.Write("Dear {0}, select a level (easy, medium, hard): ", name);

                string level = Console.ReadLine().ToLower();

                if(level.Equals("easy"))
                {
                    isLevelSelected = true;
                    size = 5;
                }
                else if(level.Equals("medium"))
                {
                    isLevelSelected = true;
                    size = 10;
                }
                else if(level.Equals("hard"))
                {
                    isLevelSelected = true;
                    size = 16;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Dear {0}, choose a valid level (easy, medium, hard): ", name);
                    Console.ResetColor();
                }
            }
            return size;
        }

        public static int CharNumToIndex(char number)
        {
            return number - 48;
        }
    }

}
