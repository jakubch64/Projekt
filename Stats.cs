using System;

namespace TicTacToe
{
    public struct Stats
    {
        public int HP { get; private set; }

        public Stats(int hp)
        {
            this.HP = hp;
        }
        public static Stats operator -(Stats s, int damage)
        {
            int newHp = s.HP - damage;
            
            // Prevent negative HP
            if (newHp < 0)
            {
                newHp = 0;
            }

            return new Stats(newHp);
        }

        public override string ToString()
        {
            return HP.ToString() + " HP";
        }
    }
}