// -----------------------------------------------------------------------
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
        public enum eOponnentType
        {
            Human,
            Computer
        }

        private MemBoard m_MemoryBoard = new MemBoard();
        private bool v_GameExists = false;
        private bool v_GameEnded = false;
        private int m_CurrentPlayingPlayerIndex;
        private List<Player> m_players = new List<Player>();
  
        public bool IsGameExists
        {
            get { return v_GameExists; }
        }

        public bool IsGameEnd
        {
            get { return v_GameEnded; }
        }

        public MemBoard Board
        {
            get { return m_MemoryBoard; }
        }

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
        public void InitializeMemoryGame()
        { 
            // Create the Memory Game
            CreateMemoryGame(0, 0);

            // Set who will be the Next Player to Play
            m_CurrentPlayingPlayerIndex = 0;
            
            // Set the Game is Started
            v_GameExists = true;
        }

        /// <summary>
        /// Initialize the Players
        /// </summary>
        /// <param name="i_PlayerName">Players Name Array</param>
        public void InitializePlayers(params string[] i_PlayerName)
        {
            if (i_PlayerName.Length == 1)
            {
                this.m_players.Add(new Player(i_PlayerName[0], Player.ePlayerType.Human));
                this.m_players.Add(new Player(Player.ePlayerType.Computer));
            }
            else if (i_PlayerName.Length == 2)
            {
                this.m_players.Add(new Player(i_PlayerName[0], Player.ePlayerType.Human));
                this.m_players.Add(new Player(i_PlayerName[1], Player.ePlayerType.Human));
            }   
        }

        /// <summary>
        /// Plays The Current Playing Player Turn
        /// </summary>
        public void PlayPlayerTurn() 
        {
            // TODO: This is the Do Move Function

            // Get User Input about Selected Squares
            // Verify Valid Input
            // Throw Error Messages if Input not Valid
            // Score The Player if Player is Correct
            // Change Turns
        }

        public string PrintGameBoard()
        {
            return m_MemoryBoard.PrintBoard();
        }
    }
}
