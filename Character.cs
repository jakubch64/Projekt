using System;

namespace TicTacToe
{
    public abstract class Character : ICharacter
    {
        public string Name { get; protected set; }
        public char Symbol { get; protected set; }
        public Stats Health { get; protected set; }

        public Character(string name, char symbol)
        {
            Name = name;
            Symbol = symbol;
            Health = new Stats(3);
        }

        // Abstract method - child class must implement how to move
        public abstract void MakeMove(char[,] board);

        // Method to handle the Attack event
        public void OnAttack(Character target, int damage)
        {
            if (target == this)
            {
                Health = Health - damage;
            }
        }
    }
}