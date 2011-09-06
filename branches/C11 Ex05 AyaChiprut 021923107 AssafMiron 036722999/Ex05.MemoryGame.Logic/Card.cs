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
        private List<IFlipedObserver> m_FlipedObservers = new List<IFlipedObserver>();

        public string Sign
        {
            get { return m_Sign; }
            set { m_Sign = value; }
        }

        public bool IsHidden
        {
            get { return v_IsHidden; }
            set { v_IsHidden = value; }
        }

        public void Flip()
        {
            v_IsHidden = !v_IsHidden;
            foreach (IFlipedObserver observer in m_FlipedObservers)
            {
                observer.CardFliped(v_IsHidden);
            }
        }

        public bool IsPairWith(Card i_CardToCheck)
        {
            return m_Sign.CompareTo(i_CardToCheck.Sign) == 0;
        }

        public void AttachObserver(IFlipedObserver i_Observer)
        {
            m_FlipedObservers.Add(i_Observer);
        }

        public void DetachObserver(IFlipedObserver i_Observer)
        {
            m_FlipedObservers.Remove(i_Observer);
        }
    }
}
