using System;

namespace TicTacToe
{
    public class Commentator
    {
        public void Log(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("[COMMENTATOR]: " + message);
            Console.ResetColor();
        }
    }
}