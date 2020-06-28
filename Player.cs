using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class Player
    {
        public string Skin;
        public int Scores;
        public int Ox { get; set; }
                
        public int Oy { get; set; }

        public Player(string Symbol)
        {
            this.Skin = Symbol;
        }    
    }
}
