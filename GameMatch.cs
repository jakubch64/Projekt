using System;

namespace TicTacToe
{
    public class GameMatch
    {
        public event MessageDelegate OnMessage;
        public event AttackDelegate OnAttack;

        private char[,] gameBoard;
        private Character player1;
        private Character player2;

        public GameMatch(Character p1, Character p2, Commentator comm)
        {
            player1 = p1;
            player2 = p2;
            gameBoard = new char[3, 3];

            // Subscription - connecting methods to events
            OnMessage += comm.Log;
            
            // Players listen for attacks
            OnAttack += player1.OnAttack;
            OnAttack += player2.OnAttack;
        }

        public void Start()
        {
            ClearBoard();
            
            // Check if event is not null before invoking
            if (OnMessage != null)
            {
                OnMessage("The match begins!");
            }

            int turnCounter = 0;
            bool keepPlaying = true;

            while (keepPlaying)
            {
                // Check if players are alive
                if (player1.Health.HP <= 0 || player2.Health.HP <= 0)
                {
                    keepPlaying = false;
                    break;
                }

                // Determine whose turn it is
                Character current = (turnCounter % 2 == 0) ? player1 : player2;
                Character opponent = (turnCounter % 2 == 0) ? player2 : player1;

                DisplayBoard();
                current.MakeMove(gameBoard);

                // Check if someone won the round
                if (CheckWin(current.Symbol))
                {
                    DisplayBoard();
                    int damage = 1;
                    
                    Console.WriteLine("!!! " + current.Name + " wins the round !!!");
                    
                    // Trigger the Attack event
                    if (OnAttack != null)
                    {
                        OnAttack(opponent, damage);
                    }

                    OnMessage("End of round. Health status:");
                    OnMessage(player1.Name + ": " + player1.Health);
                    OnMessage(player2.Name + ": " + player2.Health);

                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    ClearBoard();
                }
                else if (CheckDraw())
                {
                    DisplayBoard();
                    Console.WriteLine("Draw! No one takes damage.");
                    Console.ReadLine();
                    ClearBoard();
                }

                turnCounter++;
            }

            GameOver();
        }

        private void ClearBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    gameBoard[i, j] = ' ';
                }
            }
        }

        private void DisplayBoard()
        {
            Console.Clear();
            Console.WriteLine(" " + gameBoard[0,0] + " | " + gameBoard[0,1] + " | " + gameBoard[0,2]);
            Console.WriteLine("-----------");
            Console.WriteLine(" " + gameBoard[1,0] + " | " + gameBoard[1,1] + " | " + gameBoard[1,2]);
            Console.WriteLine("-----------");
            Console.WriteLine(" " + gameBoard[2,0] + " | " + gameBoard[2,1] + " | " + gameBoard[2,2]);
            Console.WriteLine();
        }

        private bool CheckWin(char s)
        {
            // Check rows
            if (gameBoard[0,0] == s && gameBoard[0,1] == s && gameBoard[0,2] == s) return true;
            if (gameBoard[1,0] == s && gameBoard[1,1] == s && gameBoard[1,2] == s) return true;
            if (gameBoard[2,0] == s && gameBoard[2,1] == s && gameBoard[2,2] == s) return true;

            // Check columns
            if (gameBoard[0,0] == s && gameBoard[1,0] == s && gameBoard[2,0] == s) return true;
            if (gameBoard[0,1] == s && gameBoard[1,1] == s && gameBoard[2,1] == s) return true;
            if (gameBoard[0,2] == s && gameBoard[1,2] == s && gameBoard[2,2] == s) return true;

            // Check diagonals
            if (gameBoard[0,0] == s && gameBoard[1,1] == s && gameBoard[2,2] == s) return true;
            if (gameBoard[0,2] == s && gameBoard[1,1] == s && gameBoard[2,0] == s) return true;

            return false;
        }

        private bool CheckDraw()
        {
            for(int i=0; i<3; i++)
            {
                for(int j=0; j<3; j++)
                {
                    if (gameBoard[i, j] == ' ') return false;
                }
            }
            return true;
        }

        private void GameOver()
        {
            Console.Clear();
            Console.WriteLine("GAME OVER");
            if (player1.Health.HP > 0)
            {
                Console.WriteLine("Winner: " + player1.Name);
            }
            else
            {
                Console.WriteLine("Winner: " + player2.Name);
            }
        }
    }
}