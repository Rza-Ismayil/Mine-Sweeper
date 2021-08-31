using System;

namespace Mine_Sweeper
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.OutputEncoding = System.Text.Encoding.UTF8;

            Game game = new();

            while(true)
            {
                game.PlayGame();
                Console.WriteLine("Dear {0}, do you want to play again?(y/n): ", game.player.name);
                char answer = Console.ReadLine().ToLower()[0];
                while(answer != 'n' && answer != 'y')
                {
                    Console.WriteLine("Please enter a valid input.");
                    Console.WriteLine("Dear {0}, do you want to play again?(y/n): ", game.player.name);
                    answer = Console.ReadLine().ToLower()[0];
                }
                if (answer == 'n')
                    break;

                game.player.board = new(game.player.GetLevel());
            }
        }
    }
}
