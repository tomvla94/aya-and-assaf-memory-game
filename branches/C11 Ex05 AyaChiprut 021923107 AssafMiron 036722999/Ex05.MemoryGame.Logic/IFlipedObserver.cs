using System;
using System.Collections.Generic;
using System.Text;

namespace Ex05.MemoryGame.Logic
{
    public interface IFlipedObserver
    {
        void CardFliped(bool i_IsHidden);
    }
}
