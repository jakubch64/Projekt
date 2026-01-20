using System;

namespace TicTacToe
{
    // Inheritance from Character class
    public class Player : Character
    {
        public Player(string name, char symbol) : base(name, symbol)
        {
        }

        // Overriding the abstract method (Polymorphism)
        public override void MakeMove(char[,] board)
        {
            bool success = false;

            while (success == false)
            {
                Console.WriteLine("Turn: " + Name + " (" + Symbol + ")");
                Console.Write("Choose field 1-9: ");
                string input = Console.ReadLine();
                int fieldNumber;

                // Check if input is a number
                if (int.TryParse(input, out fieldNumber))
                {
                    if (fieldNumber >= 1 && fieldNumber <= 9)
                    {
                        // Convert 1-9 to array indexes
                        int row = (fieldNumber - 1) / 3;
                        int col = (fieldNumber - 1) % 3;

                        if (board[row, col] == ' ')
                        {
                            board[row, col] = Symbol;
                            success = true;
                        }
                        else
                        {
                            Console.WriteLine("--> This field is already taken!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("--> Please enter a number between 1 and 9.");
                    }
                }
                else
                {
                    Console.WriteLine("--> That is not a valid number!");
                }
            }
        }
    }
}