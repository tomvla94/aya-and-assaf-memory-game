// -----------------------------------------------------------------------
// <copyright file="MemMessages.cs">
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
    /// Holds all the Game Messages
    /// </summary>
    public class MemMessages : Exception
    {
        string m_Message;
        public const string k_InvalidSquare = "The Square you chose is Invalid.\nPlease Choose a Square Between {0} and {1}";
        public const string k_InvalidBoardSize = "The Board Size is Invalid.\nChoose a {0} Size Between 4 and 6"; // Parameter Width or Height
        public const string k_BoradSizeNotEven = "The Board Size must be with Even number of Squares, {0}is Not Even.\nPlease Choose an Different Board Size.";
        public const string k_GameWinner = "We Have a Winner!\nThe Winner is {0}";
        public const string k_PlayerLost = "We are Sorry {0}, But you Lost...";

        public MemMessages(string i_ErrorMessage)
        {
            m_Message = i_ErrorMessage;
        }

        public string Message
        {
            get { return m_Message; }
        }

        public void PrintMessage()
        { }


    }
}
