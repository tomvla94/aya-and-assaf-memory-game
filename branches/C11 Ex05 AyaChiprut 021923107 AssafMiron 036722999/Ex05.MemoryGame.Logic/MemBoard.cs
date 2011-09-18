// -----------------------------------------------------------------------
// <copyright file="MemBoard.cs">
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
    /// The Game Board Functions,
    /// Creates and Prints the Game Board.
    /// Holds the Game Board Squares.
    /// </summary>
    public class MemBoard
    {
        private const int k_MinBoradSizeValue = 4;
        private const int k_MaxBoradSizeValue = 6;
        private MemSquare[,] m_Squares;
        private int m_BoardWidth;
        private int m_BoardHeight;

        public int Width
        {
            get
            {
                return m_BoardWidth;
            }
        }

        public int Height
        {
            get
            {
                return m_BoardHeight;
            }
        }

        public int GetMaxSize()
        {
            return k_MaxBoradSizeValue;
        }

        public int GetMinSize()
        {
            return k_MinBoradSizeValue;
        }

        public int NumberOfVisibleSquares
        {
            get
            {
                return countNumberOfVisibleSquares();
            }
        }

        public MemSquare this[int i_Row, int i_Col]
        {
            get
            {
                return m_Squares[i_Row, i_Col];
            }
        }

        /// <summary>
        /// Build The Memory Game Board
        /// </summary>
        /// <param name="i_Width">The Board Width</param>
        /// <param name="i_Height">The Board Height</param>
        public void BuildBoard(int i_Width, int i_Height)
        {
            // Check if the Input is Valid
            if (checkInput(i_Width, i_Height))
            {
                // Save the Board Width and Height
                m_BoardWidth = i_Width;
                m_BoardHeight = i_Height;

                // Use the MemSquare Class to Build Each Square in the Game
                m_Squares = new MemSquare[i_Height, i_Width];

                // Create the Squares in the Array
                createSquares();
            }
        }

        /// <summary>
        /// Create the Squares on the Board
        /// </summary>
        private void createSquares()
        {
            int counter = m_BoardWidth + 1;
            int numOfTimesLetterUsed = 1;
            for (int i = 0; i < m_BoardHeight; i ++)
            {
                for (int j = 0; j < m_BoardWidth; j++)
                {
                    char letter = (char)('B' + counter);
                    m_Squares[i, j] = new MemSquare(i, j, letter.ToString());
                    
                    if (numOfTimesLetterUsed == 2)
                    {
                        counter++;
                        numOfTimesLetterUsed = 1;
                    }
                    else
                    {
                        numOfTimesLetterUsed++;
                    }
                }
            }

            // Randomize the Squares Position on the Board
            RandomizeSquares();
        }

        /// <summary>
        /// Randomizes the Square Position on the Board
        /// </summary>
        private void RandomizeSquares()
        {
            Random rand = new Random();
            for (int i = 0; i < m_BoardHeight; i++)
            {
                for (int j = 0; j < m_BoardWidth; j++)
                {
                    SwapSquares(ref m_Squares[rand.Next(i), j], ref m_Squares[i, rand.Next(j)]);
                }
            }

            // Update the Square New Position 
            UpdateSquares();
        }

        /// <summary>
        /// Swap Squares Position
        /// </summary>
        /// <param name="i_LeftSquare">The Left Square</param>
        /// <param name="i_RightSquare">The Right Square</param>
        private void SwapSquares(ref MemSquare i_LeftSquare, ref MemSquare i_RightSquare)
        {
            MemSquare tempSquare;
            tempSquare = i_LeftSquare;
            i_LeftSquare = i_RightSquare;
            i_RightSquare = tempSquare;
        }

        /// <summary>
        /// Updates the Correct Squares Position on the Board
        /// </summary>
        private void UpdateSquares()
        {
            for (int i = 0; i < m_BoardHeight; i++)
            {
                for (int j = 0; j < m_BoardWidth; j++)
                {
                    m_Squares[i, j].Row = i;
                    m_Squares[i, j].Col = j;
                }
            }
        }

        /// <summary>
        /// Checks the User Input for the Board Size
        /// </summary>
        /// <param name="i_Width">The Board Width</param>
        /// <param name="i_Height">The Board Height</param>
        /// <returns>True if the Board Dimentions are OK</returns>
        private bool checkInput(int i_Width, int i_Height)
        {
            bool retValue = true;

            // Check Width Valid Size
            if (i_Width < k_MinBoradSizeValue || i_Width > k_MaxBoradSizeValue)
            {
                retValue = false;
            }

            // Check Height Valid Size
            if (i_Height < k_MinBoradSizeValue || i_Height > k_MaxBoradSizeValue)
            {
                retValue = false;
            }

            // Verify that the Number of Squares is Even
            if ((i_Width * i_Height) % 2 != 0)
            {
                retValue = false;
            }

            return retValue;
        }

        /// <summary>
        /// Checks if the Requested Square is a Valid Square on the Board
        /// </summary>
        /// <param name="i_Row">Requested Row</param>
        /// <param name="i_Col">Requested Collumn</param>
        /// <returns>True if the Square is On the Board</returns>
        public bool IsLeagalSquare(int i_Row, int i_Col)
        {
            return i_Row <= m_BoardHeight && i_Col < m_BoardWidth;
        }

        /// <summary>
        /// Count the number of visible squares
        /// </summary>
        /// <returns>The Number of Visible Square</returns>
        private int countNumberOfVisibleSquares()
        {
            int visibleSquaresCounter = 0;
            for (int row = 0; row < m_BoardHeight; row++)
            {
                for (int col = 0; col < m_BoardWidth; col++)
                {
                    if (!m_Squares[row, col].Card.IsHidden)
                    {
                        visibleSquaresCounter++;
                    }
                }
            }

            return visibleSquaresCounter;
        }

        /// <summary>
        /// Flips a Square
        /// </summary>
        /// <param name="i_SquareChoice">The Square to Flip</param>
        public void FlipSquare(string i_PlayerColor, MemSquare i_SquareChoice)
        {
            if (i_SquareChoice != null)
            {
                m_Squares[i_SquareChoice.Row, i_SquareChoice.Col].Card.Flip(i_PlayerColor);
            }
        }

        /// <summary>
        /// Hides All Squares on the Board
        /// </summary>
        internal void HideAllSquares()
        {
            string noPlayerColor = string.Empty;
            foreach (MemSquare square in m_Squares)
            {
                if (!square.Card.IsHidden)
                {
                    square.Card.Flip(noPlayerColor);
                }
            }
        }
    }
}
