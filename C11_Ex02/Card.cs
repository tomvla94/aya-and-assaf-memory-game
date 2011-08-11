using System;
using System.Collections.Generic;
using System.Text;

namespace C11_Ex02
{
    public class Card
    {
        private string m_Sign;
        private bool v_IsHidden = true;

        public string Sign
        {
            get { return m_Sign; }
            set { m_Sign = value; }
        }

        public void Flip()
        {
            v_IsHidden = !v_IsHidden;
        }

        public bool IsPairWith(Card i_CardToCheck)
        {
            return (m_Sign.CompareTo(i_CardToCheck.Sign) == 0);
        }

        public bool IsHidden
        {
            get { return v_IsHidden; }
        }
    }
}
