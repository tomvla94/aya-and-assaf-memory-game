// -----------------------------------------------------------------------
// <copyright file="HumanPlayer.cs">
// Aya Chiprut 021923107 
// Assaf Miron 036722999
// </copyright>
// -----------------------------------------------------------------------

namespace C11_Ex02
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class HumanPlayer : Player
    {
        public HumanPlayer(string i_Name)
        {
            this.Name = i_Name;
            this.Score = 0;
        }

        /// <summary>
        /// Gets the Requested Input Squares 
        /// that the Player Wants to Show in the Game
        /// </summary>
        public void GetInputSquare()
        { }
    }
}
