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
            this.m_MemoryBoard.HideAllSquares();
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
        public bool PlayPlayerTurn(MemSquare i_SquareChoice) 
        {
            bool retPlayerScored = false;
            
            if (m_PrevSquareChosen == null)
            {
                // Flip the First Card
                m_MemoryBoard.FlipSquare(i_SquareChoice);

                m_PrevSquareChosen = i_SquareChoice;
                // Save the Show Card in the List
                m_ShowSquareCards.Add(m_MemoryBoard[i_SquareChoice.Row, i_SquareChoice.Col]);
            }
            else
            {
                // Flip the Second Card
                m_MemoryBoard.FlipSquare(i_SquareChoice);
                // Save the Show Card in the List
                m_ShowSquareCards.Add(m_MemoryBoard[i_SquareChoice.Row, i_SquareChoice.Col]);
                // Compare Pairs
                if (m_MemoryBoard[m_PrevSquareChosen.Row, m_PrevSquareChosen.Col].IsPairWith
                    (m_MemoryBoard[i_SquareChoice.Row, i_SquareChoice.Col]))
                {
                    m_players[m_CurrentPlayingPlayerIndex].Score++;
                    m_ShowSquareCards.Remove(m_MemoryBoard[i_SquareChoice.Row, i_SquareChoice.Col]);
                    m_ShowSquareCards.Remove(m_MemoryBoard[m_PrevSquareChosen.Row, m_PrevSquareChosen.Col]);
                    //m_NumberOfFoundCardPairs += 2;
                    retPlayerScored = true;
                }
                else
                {
                    changePlayerIndex();
                }

                m_PrevSquareChosen = null;          
            }
           

            return retPlayerScored;
        }

        private readonly List<MemSquare> m_ShowSquareCards = new List<MemSquare>();

        public void PlayComputerTurn(out MemSquare i_FirstSquare, out MemSquare i_SecondSquare, out bool i_PlayerScored)
        {
            i_FirstSquare = CompChooseRandomSquare();
            m_MemoryBoard.FlipSquare(i_FirstSquare);
            i_SecondSquare = CompFindMatch(i_FirstSquare.Card);
            m_MemoryBoard.FlipSquare(i_SecondSquare);
            i_PlayerScored = i_FirstSquare.Card.IsPairWith(i_SecondSquare.Card);
            if (i_PlayerScored)
            {
                m_ShowSquareCards.Remove(m_MemoryBoard[i_FirstSquare.Row, i_FirstSquare.Col]);
                m_ShowSquareCards.Remove(m_MemoryBoard[i_SecondSquare.Row, i_SecondSquare.Col]);
                CurrentPlayer.Score++;
            }
            else 
            {
                m_ShowSquareCards.Add(i_SecondSquare);
                changePlayerIndex();
            }           
        }

        private MemSquare CompFindMatch(Card i_FindCard)
        {
            MemSquare retFoundSquare = null;
            foreach (MemSquare seenSquare in m_ShowSquareCards)
            {
                if (IsLegalMove(seenSquare) && i_FindCard.IsPairWith(seenSquare.Card))
                {
                    retFoundSquare = seenSquare;
                    break;
                }
            }

            if (retFoundSquare == null)
            {
                Random rand = new Random();
                bool foundOption = false;
                while (!foundOption)
                {
                    int optionalRow = rand.Next(Board.Height);
                    int optionalCol = rand.Next(Board.Width);
                    if (isLegalMove(optionalRow, optionalCol))
                    {
                        retFoundSquare = m_MemoryBoard[optionalRow, optionalCol];
                        foundOption = true;
                    }
                }
            }

            return retFoundSquare;
        }

        private MemSquare CompChooseRandomSquare()
        {
            MemSquare retFoundSquare = null;
            Random rand = new Random();
            bool foundOption = false;
            while (!foundOption)
            {
                int optionalRow = rand.Next(Board.Height);
                int optionalCol = rand.Next(Board.Width);
                if (isLegalMove(optionalRow, optionalCol))
                {
                    retFoundSquare = m_MemoryBoard[optionalRow, optionalCol];
                    foundOption = true;
                }
            }

            return retFoundSquare;
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

        public Player CurrentPlayer
        {
            get { return m_players[m_CurrentPlayingPlayerIndex]; }
        }

        
        public bool RoundFinished
        {
            get
            {
                return m_MemoryBoard.NumberOfVisibleSquares >= m_MemoryBoard.Height * m_MemoryBoard.Width;
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

        private bool isLegalMove(int i_Row, int i_Col)
        {
            return m_MemoryBoard[i_Row, i_Col].Card.IsHidden;
        }

        public bool EndPlayerTurn(MemSquare i_FirstSquare, MemSquare i_SecondSquare, bool i_KeepCardsVisible)
        {
            bool retUserGotPoint = i_KeepCardsVisible;

            if (!i_KeepCardsVisible)
            {
                m_MemoryBoard[i_FirstSquare.Row,i_FirstSquare.Col].Card.Flip();
                m_MemoryBoard[i_SecondSquare.Row, i_SecondSquare.Col].Card.Flip();
            }

            return retUserGotPoint;
        }
    }
}
