using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Ex05.MemoryGame.Logic;

namespace Ex05.MemoryGame.WindowForm
{
    class MemCardButton : Button, IFlipedObserver
    {
        private MemSquare m_Square;

        public MemSquare Square
        {
            get { return m_Square; }
            set { 
                m_Square = value;
                m_Square.AttachObserver(this as IFlipedObserver);
            }
        }

        public void CardFliped(string i_PlayerColor, bool i_IsHidden)
        {
            if (!i_IsHidden)
            {
                this.Text = m_Square.Card.Sign;
                this.BackColor = Color.FromName(i_PlayerColor);
            }
            else
            {
                this.Text = string.Empty;
                this.BackColor = Color.Empty;
            }
        }
    }
}
