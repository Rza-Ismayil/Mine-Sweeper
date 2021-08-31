using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mine_Sweeper
{
    class Game
    {
        public Player player;

        public Game()
        {
            player = new();
        }

        public void PlayGame()
        {
            while(!IsGameOver() && !DidPlayerWin())
            {
                player.OpenCell();
            }
            player.board.ShowTable(false);
            CongratulateOrSorry();
        }

        public void CongratulateOrSorry()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            if(IsGameOver())
            {
                Console.WriteLine("Dear {0}, game over.", player.name);
            }
            else if(DidPlayerWin())
            {
                Console.WriteLine("Dear {0}, YOU WIN.", player.name);
            }
            Console.ResetColor();
        }

        public bool IsGameOver()
        {
            foreach (Cell cell in player.board.Table)
            {
                if(cell.IsSelected == true && cell.Symbol == '*')
                {
                    return true;
                }
            }
            return false;
        }

        public bool DidPlayerWin()
        {
            if(!IsGameOver())
            {
                foreach (Cell cell in player.board.Table)
                {
                    if(cell.IsSelected == false && cell.Symbol != '*')
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
    }

    
}
