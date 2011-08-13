﻿// -----------------------------------------------------------------------
// <copyright file="MemBoard.cs">
// Aya Chiprut 021923107 
// Assaf Miron 036722999
// </copyright>
// -----------------------------------------------------------------------

namespace C11_Ex02
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Ex02.ConsoleUtils;
    
    /// <summary>
    /// The Game Board Functions,
    /// Creates and Prints the Game Board.
    /// Holds the Game Board Squares.
    /// </summary>
    public class MemBoard
    {
        private const int k_MinBoradSizeValue = 4;
        private const int k_MaxBoradSizeValue = 6;
        private const char k_RowSpacer = '=';
        private const char k_ColSpacer = '|';
        private MemSquare[,] m_Squares;
        private int m_BoardWidth;
        private int m_BoardHeight;

        /// <summary>
        /// Build The Memory Game Board
        /// </summary>
        /// <param name="i_Width">The Board Width</param>
        /// <param name="i_Height">The Board Height</param>
        public void BuildBoard(int i_Width, int i_Height)
        {
            // Check if the Input is Valid
            if (CheckInput(i_Width, i_Height))
            {
                // Save the Board Width and Height
                m_BoardWidth = i_Width;
                m_BoardHeight = i_Height;

                // Use the MemSquare Class to Build Each Square in the Game
                m_Squares = new MemSquare[i_Height, i_Width];

                // Create the Squares in the Array
                CreateSquares();
            }
        }

        private void CreateSquares()
        {
            int counter = m_BoardWidth + 1;
            for (int i = 0; i < m_BoardHeight; i += 2)
            {
                for (int j = 0; j < m_BoardWidth; j++)
                {
                    char letter = (char)('B' + counter++);
                    m_Squares[i, j] = new MemSquare(i, j, letter.ToString());
                    m_Squares[i + 1, j] = new MemSquare(i, j, letter.ToString());
                }
            }

            RandomizeSquares();
        }

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

            UpdateSquares();
        }

        private void SwapSquares(ref MemSquare i_LeftSquare, ref MemSquare i_RightSquare)
        {
            MemSquare tempSquare;
            tempSquare = i_LeftSquare;
            i_LeftSquare = i_RightSquare;
            i_RightSquare = tempSquare;
        }

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
        private bool CheckInput(int i_Width, int i_Height)
        {
            bool retValue = false;

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

            // Every thing is OK
            retValue = true;

            return retValue;
        }

        public bool IsLeagalSquare(int i_Row, int i_Col)
        {
            return (i_Row <= m_BoardHeight && i_Col < m_BoardWidth);
        }

        /// <summary>
        /// number of visible squares
        /// </summary>
        public int NumberOfVisibleSquares
        {
            get
            {
                return countNumberOfVisibleSquares();
            }
        }

        /// <summary>
        /// count the number of visible squares
        /// </summary>
        /// <returns></returns>
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

        public MemSquare this[int i_Row, int i_Col]
        {
            get
            {
                return m_Squares[i_Row, i_Col];
            }
        }

        internal void FlipSquare(MemSquare i_SquareChoice)
        {
            m_Squares[i_SquareChoice.Row, i_SquareChoice.Col].Card.Flip();
        }

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

        internal void HideAllSquares()
        {
            foreach (MemSquare square in m_Squares)
            {
                if (!square.Card.IsHidden)
                {
                    square.Card.Flip();
                }
            }
        }
    }
}