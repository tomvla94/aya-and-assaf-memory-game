using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Ex05.MemoryGame.Logic;

namespace Ex05.MemoryGame.WindowForm
{
    public class MemCardButton : Button, IFlipedObserver
    {
        private MemSquare m_Square;

        /// <summary>
        /// Gets the Square Property
        /// Sets the Input Sqaure and Attach it as an IFlipedObserver
        /// </summary>
        public MemSquare Square
        {
            get { return m_Square; }
            set 
            { 
                m_Square = value;
                m_Square.AttachObserver(this as IFlipedObserver);
            }
        }

        /// <summary>
        /// Shows the Result of the Fliped card on the MemCardButton
        /// </summary>
        /// <param name="i_PlayerColor">Used for a back color of the button</param>
        /// <param name="i_IsHidden">The card hidden state</param>
        public void CardFliped(string i_PlayerColor, bool i_IsHidden)
        {
            if (!i_IsHidden)
            {
                this.Text = m_Square.Card.Sign;
                this.BackColor = Color.FromName(i_PlayerColor);
                this.Enabled = false;
            }
            else
            {
                this.Text = string.Empty;
                this.BackColor = Color.Empty;
                this.Enabled = true;
            }
        }
    }
}
