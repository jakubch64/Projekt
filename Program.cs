using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Player p1 = new Player("Player One", 'X');
            Player p2 = new Player("Player Two", 'O');
            Commentator comm = new Commentator();
            
            GameMatch game = new GameMatch(p1, p2, comm);
            
            game.Start();

            Console.WriteLine("End of program.");
            Console.ReadKey();
        }
    }
}