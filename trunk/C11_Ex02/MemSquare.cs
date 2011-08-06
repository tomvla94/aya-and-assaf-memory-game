// -----------------------------------------------------------------------
// <copyright file="MemSquare.cs">
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
    public class MemSquare
    {
        private string m_MemoryLetter;
        private bool v_IsHidden = false;

        /// <summary>
        /// Construct the Memory Game Square
        /// </summary>
        /// <param name="i_Leter"></param>
        public MemSquare(string i_Leter)
        {
            m_MemoryLetter = i_Leter;
        }

        public bool IsHidden
        {
            get { return v_IsHidden; }
        }

        public string MemoryLetter
        {
            get { return m_MemoryLetter; }
        }

        /// <summary>
        /// Shows the Square on the Board
        /// </summary>
        public void ShowSquare() 
        {
            v_IsHidden = false;
        }

        /// <summary>
        /// Hides the Square from the Board
        /// </summary>
        public void HideSquare() 
        {
            v_IsHidden = true;
        }
    }
}