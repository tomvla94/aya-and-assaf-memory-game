// -----------------------------------------------------------------------
// <copyright file="MemBL.cs">
// Aya Chiprut 021923107 
// Assaf Miron 036722999
// </copyright>
// -----------------------------------------------------------------------

namespace Ex05.MemoryGame.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// The Memory Game Logic
    /// </summary>
    public class MemGameBL
    {
        private readonly List<MemSquare> r_ShowSquareCards = new List<MemSquare>();
        private MemBoard m_MemoryBoard = new MemBoard();
        private Player[] m_Players = new Player[2];
        private MemSquare m_PrevSquareChosen = null;
        private int m_CurrentPlayingPlayerIndex = 0;

        public MemBoard Board
        {
            get { return m_MemoryBoard; }
        }

        public Player CurrentPlayer
        {
            get { return m_Players[m_CurrentPlayingPlayerIndex]; }
        }

        public Player FirstPlayer
        {
            get { return m_Players[0]; }
        }

        public Player SecondPlayer
        {
            get { return m_Players[1]; }
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
                return m_Players[0].Score > m_Players[1].Score ? m_Players[0] : m_Players[1];
            }
        }

        public Player Loser
        {
            get
            {
                return m_Players[0].Score < m_Players[1].Score ? m_Players[0] : m_Players[1];
            }
        }

        public int GetMaximumBoardSize()
        {
            return m_MemoryBoard.GetMaxSize();
        }

        public int GetMinimumBoardSize()
        {
            return m_MemoryBoard.GetMinSize();
        }

        /// <summary>
        /// Creates the Memory Game Board
        /// </summary>
        /// <param name="i_BoardWidth">The Board Width</param>
        /// <param name="i_BoardHeight">The Board Height</param>
        public void InitRound(int i_BoardHeight, int i_BoardWidth)
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
                this.m_Players[0] = new Player(i_PlayerNames[0], Player.ePlayerType.Human);
                this.m_Players[0].Color = Player.ePlayerColor.Green;
                this.m_Players[1] = new Player(Player.ePlayerType.Computer);
                this.m_Players[1].Color = Player.ePlayerColor.Cyan;
            }
            else if (i_PlayerNames.Length == 2)
            {
                this.m_Players[0] = new Player(i_PlayerNames[0], Player.ePlayerType.Human);
                this.m_Players[0].Color = Player.ePlayerColor.Green;
                this.m_Players[1] = new Player(i_PlayerNames[1], Player.ePlayerType.Human);
                this.m_Players[1].Color = Player.ePlayerColor.Blue;
            }
        }

        /// <summary>
        /// Plays The Current Human Playing Player Turn
        /// </summary>
        /// <param name="i_SquareChoice">The Players Chosen Square</param>
        /// <returns>True if the Player Scored a Point - Found a Match</returns>
        public bool PlayPlayerTurn(MemSquare i_SquareChoice)
        {
            bool retPlayerScored = false;

            // First Square Choise
            if (m_PrevSquareChosen == null)
            {
                // Flip the First Card
                m_MemoryBoard.FlipSquare(i_SquareChoice);

                // Save the Chosen Square
                m_PrevSquareChosen = i_SquareChoice;

                // Save the Shown Square in the List
                if (!r_ShowSquareCards.Contains(m_MemoryBoard[i_SquareChoice.Row, i_SquareChoice.Col]))
                {
                    r_ShowSquareCards.Add(m_MemoryBoard[i_SquareChoice.Row, i_SquareChoice.Col]);
                }
            }
            else
            {
                // Second Square Choise
                // Flip the Second Card
                m_MemoryBoard.FlipSquare(i_SquareChoice);

                // Save the Shown Square in the List
                if (!r_ShowSquareCards.Contains(m_MemoryBoard[i_SquareChoice.Row, i_SquareChoice.Col]))
                {
                    r_ShowSquareCards.Add(m_MemoryBoard[i_SquareChoice.Row, i_SquareChoice.Col]);
                }

                // Compare Pairs
                if (m_MemoryBoard[m_PrevSquareChosen.Row, m_PrevSquareChosen.Col].IsPairWith(m_MemoryBoard[i_SquareChoice.Row, i_SquareChoice.Col]))
                {
                    // Player Scored!
                    m_Players[m_CurrentPlayingPlayerIndex].Score++;

                    // Remove the Squares from the List
                    r_ShowSquareCards.Remove(m_MemoryBoard[i_SquareChoice.Row, i_SquareChoice.Col]);
                    r_ShowSquareCards.Remove(m_MemoryBoard[m_PrevSquareChosen.Row, m_PrevSquareChosen.Col]);

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

        /// <summary>
        /// Plays the Computer Turn
        /// </summary>
        /// <param name="i_FirstSquare">The First Chosen Square</param>
        /// <param name="i_SecondSquare">The Second Chosen Square</param>
        /// <param name="i_PlayerScored">Has the Computer Found a Match</param>
        public void PlayComputerTurn(out MemSquare i_FirstSquare, out MemSquare i_SecondSquare, out bool i_PlayerScored)
        {
            // Check if a pair was already seen on the board
            if (!aPairAlreadySeen(out i_FirstSquare))
            {
                // If Not Choose a Square randomly
                i_FirstSquare = compChooseRandomSquare();
            }

            // Check if the First Square Card was Seen on the Board
            if (!r_ShowSquareCards.Contains(i_FirstSquare))
            {
                r_ShowSquareCards.Add(i_FirstSquare);
            }

            // Flip the First Square Card
            m_MemoryBoard.FlipSquare(i_FirstSquare);

            // Find a Matching Square
            i_SecondSquare = compFindMatch(i_FirstSquare.Card);

            // Flip the Second Square Card
            m_MemoryBoard.FlipSquare(i_SecondSquare);

            // Check if the Computer Found a Match
            i_PlayerScored = i_FirstSquare.Card.IsPairWith(i_SecondSquare.Card);
            if (i_PlayerScored)
            {
                r_ShowSquareCards.Remove(m_MemoryBoard[i_FirstSquare.Row, i_FirstSquare.Col]);
                r_ShowSquareCards.Remove(m_MemoryBoard[i_SecondSquare.Row, i_SecondSquare.Col]);
                CurrentPlayer.Score++;
            }
            else
            {
                if (!r_ShowSquareCards.Contains(i_SecondSquare))
                {
                    r_ShowSquareCards.Add(i_SecondSquare);
                }

                changePlayerIndex();
            }
        }

        /// <summary>
        /// Checks if a pair was already seen on the board
        /// By any Playing Player
        /// </summary>
        /// <param name="i_Square">The Square Seen</param>
        /// <returns>If a Pair was seen or not</returns>
        private bool aPairAlreadySeen(out MemSquare i_Square)
        {
            i_Square = null;
            bool retVal = false;
            foreach (MemSquare seenSquare in r_ShowSquareCards)
            {
                foreach (MemSquare square in r_ShowSquareCards)
                {
                    if (seenSquare != square && seenSquare.IsPairWith(square))
                    {
                        i_Square = seenSquare;
                        retVal = true;
                    }
                }
            }

            return retVal;
        }

        /// <summary>
        /// Computer Tries to find a Match from the Seen Squares
        /// </summary>
        /// <param name="i_FindCard">The Card to Find aMatch To</param>
        /// <returns>The Matching Square if Found And a Random Square if Not Found</returns>
        private MemSquare compFindMatch(Card i_FindCard)
        {
            MemSquare retFoundSquare = null;
            foreach (MemSquare seenSquare in r_ShowSquareCards)
            {
                if (IsLegalMove(seenSquare) && i_FindCard.IsPairWith(seenSquare.Card))
                {
                    retFoundSquare = seenSquare;
                    break;
                }
            }

            // Check if a Match was Found
            if (retFoundSquare == null)
            {
                // Find A Random Square
                retFoundSquare = compChooseRandomSquare();
            }

            return retFoundSquare;
        }
        
        /// <summary>
        /// Finds a Random Valid Square on the Board
        /// </summary>
        /// <returns>The Chosen Square</returns>
        private MemSquare compChooseRandomSquare()
        {
            MemSquare retFoundSquare = null;
            Random rand = new Random();
            bool foundOption = false;
            while (!foundOption)
            {
                int optionalRow = rand.Next(Board.Height);
                int optionalCol = rand.Next(Board.Width);

                // Verify that the Move is Leagal
                if (isLegalMove(optionalRow, optionalCol))
                {
                    retFoundSquare = m_MemoryBoard[optionalRow, optionalCol];
                    foundOption = true;
                }
            }

            return retFoundSquare;
        }

        /// <summary>
        /// Changes the Current Player Index
        /// </summary>
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

        /// <summary>
        /// Checks if the Requested Move is Leagal
        /// </summary>
        /// <param name="i_ChosenSquare">The Requested Chosen Square</param>
        /// <returns>True if the Move is OK</returns>
        public bool IsLegalMove(MemSquare i_ChosenSquare)
        {
            return m_MemoryBoard[i_ChosenSquare.Row, i_ChosenSquare.Col].Card.IsHidden;
        }

        /// <summary>
        /// Checks if the Requested Move is Leagal
        /// </summary>
        /// <param name="i_Row">The Requested Row</param>
        /// <param name="i_Col">The Requested Collumn</param>
        /// <returns>True if the Move is OK</returns>
        private bool isLegalMove(int i_Row, int i_Col)
        {
            return m_MemoryBoard[i_Row, i_Col].Card.IsHidden;
        }

        /// <summary>
        /// Ends a Players Turn
        /// </summary>
        /// <param name="i_FirstSquare">The First Player Chosen Square</param>
        /// <param name="i_SecondSquare">The Second Player Chosen Square</param>
        /// <param name="i_KeepCardsVisible">To Keep the Cards Visible?</param>
        /// <returns>True if the cards are visible</returns>
        public bool EndPlayerTurn(MemSquare i_FirstSquare, MemSquare i_SecondSquare, bool i_KeepCardsVisible)
        {
            bool retUserGotPoint = i_KeepCardsVisible;

            if (!i_KeepCardsVisible)
            {
                m_MemoryBoard[i_FirstSquare.Row, i_FirstSquare.Col].Card.Flip();
                m_MemoryBoard[i_SecondSquare.Row, i_SecondSquare.Col].Card.Flip();
            }

            return retUserGotPoint;
        }
    }
}