// -----------------------------------------------------------------------
// <copyright file="Card.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Ex05.MemoryGame.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// The Memory Card Object
    /// </summary>
    public class Card
    {
        private string m_Sign;

        private bool v_IsHidden = true;

        public string Sign
        {
            get { return m_Sign; }
            set { m_Sign = value; }
        }

        public bool IsHidden
        {
            get { return v_IsHidden; }
        }

        public void Flip()
        {
            v_IsHidden = !v_IsHidden;
        }

        public bool IsPairWith(Card i_CardToCheck)
        {
            return m_Sign.CompareTo(i_CardToCheck.Sign) == 0;
        }
    }
}
