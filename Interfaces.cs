using System;

namespace TicTacToe
{
    // Delegate definitions
    public delegate void MessageDelegate(string content);
    public delegate void AttackDelegate(Character target, int damageAmount);

    // Interface for any character in the game
    public interface ICharacter
    {
        string Name { get; }
        void MakeMove(char[,] board);
    }
}