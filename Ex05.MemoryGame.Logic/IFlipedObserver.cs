using System;
using System.Collections.Generic;
using System.Text;

namespace Ex05.MemoryGame.Logic
{
    public interface IFlipedObserver
    {
        void CardFliped(string i_PlayerColor, bool i_IsHidden);
    }
}
