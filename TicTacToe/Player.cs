namespace TicTacToe
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Player
    {
        // name of the player
        public string Name { get; set; }

        // this 1 or 2 for player 1 and player 2
        public int Position { get; set; }

        // this is the char they are using
        public char Token { get; set; }

        public Player(string inName, int inPosition, char inToken)
        {
            this.Name = inName;
            this.Position = inPosition;
            this.Token = inToken;
        }

        public Player()
        {
        }
    }
}
