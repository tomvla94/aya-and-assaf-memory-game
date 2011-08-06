﻿// -----------------------------------------------------------------------
// <copyright file="MemBL.cs">
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
    public class MemBL
    {
        #region Fields

        private MemBoard m_MemoryBoard = new MemBoard();
        private bool v_GameExists = false;
        private bool v_GameEnded = false;
        private int m_CurrentPlayingPlayerIndex;
        private List<Player> m_players = new List<Player>();

        #endregion
        
        #region Instance

        private static MemBL s_MemBLInstance;
        public static MemBL Instance
        {
            get
            {
                if (s_MemBLInstance == null)
                {
                    s_MemBLInstance = new MemBL();
                }
                return s_MemBLInstance;
            }
        }

        #endregion

        /// <summary>
        /// Creates the Memory Game Board
        /// </summary>
        /// <param name="i_BoardWidth">The Board Width</param>
        /// <param name="i_BoardHeight">The Board Height</param>
        public void CreateMemoryGame(int i_BoardWidth, int i_BoardHeight)
        {
            this.m_MemoryBoard.BuildBoard(i_BoardWidth, i_BoardHeight);
        }

        /// <summary>
        /// Initializes the Memory Board Game.
        /// Creates The Board and Sets other Important Variables
        /// </summary>
        public void InitializeMemoryGame( ) 
        { 
            // Create the Memory Game
            CreateMemoryGame(0, 0);

            // Set who will be the Next Player to Play
            m_CurrentPlayingPlayerIndex = 0;
            
            // Set the Game is Started
            v_GameExists = true;
        }

        /// <summary>
        /// initialize players- human against computer
        /// </summary>
        /// <param name="i_playerName"></param>
        public void InitializePlayers(string i_PlayerName)
        {
            this.m_players.Add(new HumanPlayer(i_PlayerName));
            this.m_players.Add(new ComputerizedPlayer());
        }

        /// <summary>
        /// initialize players- human against human
        /// </summary>
        /// <param name="i_FirstPlayerName">The First Players' Name</param>
        /// <param name="i_SecondPlayerName">The Second Players' Name</param>
        public void InitializePlayers(string i_FirstPlayerName, string i_SecondPlayerName)
        {
            this.m_players.Add(new HumanPlayer(i_FirstPlayerName));
            this.m_players.Add(new HumanPlayer(i_SecondPlayerName));
        }

        /// <summary>
        /// Plays The Current Playing Player Turn
        /// </summary>
        public void PlayPlayerTurn() 
        {
            // Get User Input about Selected Squares
            // Verify Valid Input
            // Throw Error Messages if Input not Valid
            // Score The Player if Player is Correct
            // Change Turns
        }
    }
}
