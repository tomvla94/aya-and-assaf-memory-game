// -----------------------------------------------------------------------
// <copyright file="Player.cs">
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
    public class Player
    {
        private string m_Name;
        private int m_Score;

        /// <summary>
        /// Gets and Sets the Player Name
        /// </summary>
        public string Name
        {
            get { return m_Name;  }
            set { m_Name = value; }
        }

        /// <summary>
        /// Gets and Sets the Player Score
        /// </summary>
        public int Score
        {
            get { return m_Score;  }
            set { m_Score = value; }
        }
    }
}
