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
        private MemBoard m_MemoryBoard = new MemBoard();
        private bool v_GameExists = false;
        private bool v_GameEnded = false;
        private int m_CurrentPlayingPlayerIndex = 0;
        private Player[] m_players = new Player[2];
  
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
        public void initRound(int i_BoardWidth, int i_BoardHeight)
        {
            this.m_MemoryBoard.BuildBoard(i_BoardWidth, i_BoardHeight);
        }

        /// <summary>
        /// Initialize the Players
        /// </summary>
        /// <param name="i_PlayerNames">Players Name Array</param>
        public void InitializePlayers(params string[] i_PlayerNames)
        {
            if (i_PlayerNames.Length == 1)
            {
                this.m_players[0] = new Player(i_PlayerNames[0], Player.ePlayerType.Human);
                this.m_players[1] = new Player(Player.ePlayerType.Computer);
            }
            else if (i_PlayerNames.Length == 2)
            {
                this.m_players[0] = new Player(i_PlayerNames[0], Player.ePlayerType.Human);
                this.m_players[1] = new Player(i_PlayerNames[1], Player.ePlayerType.Human);
            }   
        }

        private MemSquare m_PrevSquareChosen = null;

        /// <summary>
        /// Plays The Current Playing Player Turn
        /// </summary>
        public void PlayPlayerTurn(MemSquare i_SquareChoice) 
        {
            m_MemoryBoard.FlipSquare(i_SquareChoice);

            if (m_PrevSquareChosen == null)
            {
                m_PrevSquareChosen = i_SquareChoice;
            }
            else 
            {
                if (m_MemoryBoard[m_PrevSquareChosen.Row, m_PrevSquareChosen.Col].IsPairWith
                    (m_MemoryBoard[i_SquareChoice.Row, i_SquareChoice.Col]))
                {
                    m_players[m_CurrentPlayingPlayerIndex].Score++;
                }
                else
                {
                    m_MemoryBoard.FlipSquare(i_SquareChoice);
                    m_MemoryBoard.FlipSquare(i_SquareChoice);
                    changePlayerIndex();
                    if (m_players[m_CurrentPlayingPlayerIndex].Type == Player.ePlayerType.Computer)
                    {
                        playComputerTurn();
                    }
                }
            }
        }

        private void playComputerTurn()
        {
            throw new NotImplementedException();
        }

        private void changePlayerIndex()
        {
            if (m_CurrentPlayingPlayerIndex == 0)
            {
                m_CurrentPlayingPlayerIndex = 1;
            }
            else
            {
                m_CurrentPlayingPlayerIndex = 0;
            }
        }

        public bool RoundFinished
        {
            get
            {
                return m_MemoryBoard.NumberOfVisibleSquares > 0;
            }
        }

        public Player Winner
        {
            get
            {
                return m_players[0].Score > m_players[1].Score ? m_players[0] : m_players[1];
            }
        }

        public Player Loser
        {
            get
            {
                return m_players[0].Score < m_players[1].Score ? m_players[0] : m_players[1];
            }
        }

        public bool IsLegalMove(MemSquare i_ChosenSquare)
        {
            return m_MemoryBoard[i_ChosenSquare.Row, i_ChosenSquare.Col].Card.IsHidden;               
        }
    }
}
