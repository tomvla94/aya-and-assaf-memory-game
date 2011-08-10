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
            for (int i = 0; i < m_BoardHeight; i++)
            {
                for(int j = 0; j < m_BoardWidth; j += 2)
                {
                    char letter = (char)('B' + counter++);
                    m_Squares[i, j] = new MemSquare(i, j, letter.ToString());
                    m_Squares[i, j + 1] = new MemSquare(i, j, letter.ToString());
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
                throw new MemMessages(string.Format(MemMessages.k_InvalidBoardSize, "Width"));
            }
            
            // Check Height Valid Size
            if (i_Height < k_MinBoradSizeValue || i_Height > k_MaxBoradSizeValue)
            {
                retValue = false;
                throw new MemMessages(string.Format(MemMessages.k_InvalidBoardSize, "Height"));
            }
            
            // Verify that the Number of Squares is Even
            if((i_Width * i_Height) % 2 != 0)
            {
                retValue = false;
                throw new MemMessages(string.Format(MemMessages.k_BoradSizeNotEven, (i_Width * i_Height)));
            }
            
            // Every thing is OK
            retValue = true;

            return retValue;
        }

        /// <summary>
        /// Gets the Requested Square From the Board
        /// </summary>
        /// <param name="i_Row">Requested Square Row</param>
        /// <param name="i_Col">Requested Square Collumn</param>
        /// <returns>The Requested Square</returns>
        public MemSquare GetSquareAt(int i_Row, char i_Col)
        {
            MemSquare retRequestedSquare = null;

            // Return the Requested Square
            retRequestedSquare = m_Squares[i_Row, i_Col];

            return retRequestedSquare;
        }

        public bool IsLeagalSquare(int i_Row, int i_Col)
        {
            return (i_Row <= m_BoardHeight && i_Col <= m_BoardWidth);
        }

        /// <summary>
        /// Prepares the Game Board to be Printed
        /// </summary>
        /// <returns>The Game Board</returns>
        public string PrintBoard()
        {
            // Clear the Screen
            Screen.Clear();

            // Print the Header Row
            string retBoard = PrintHeadersRow();

            // Print Each Row with its Squares
            for(int i = 0; i < m_BoardHeight; i++)
            {
                retBoard += PrintSquareRow(i);
            }

            // Return the Board
            return retBoard;
        }

        /// <summary>
        /// Prepares the Header Row To be Printed
        /// </summary>
        /// <returns>The Header Row With Spacers Ready for Print</returns>
        private string PrintHeadersRow()
        {
            string spacer = new string(k_RowSpacer, (m_BoardWidth * 8) - 4);
            string retHeaderRow = "  ";
            
            // Loop the Number of time the Header Width And Write The ABC Headers
            for (int i = 0; i < m_BoardWidth; i++)
            {
                // Seperate Each Header Letter with Tab
                retHeaderRow += "   " + (char)('A' + i) + "   ";
            }

            // Add the Row Spacer
            retHeaderRow += "\n  " + spacer + "\n";

            return retHeaderRow;
        }

        /// <summary>
        /// Prepares the Squares Row to be Printed
        /// </summary>
        /// <param name="i_RowIndex">The Row Index to be Displayed</param>
        /// <returns>The Squares Row with Spacers Ready for Print</returns>
        private string PrintSquareRow(int i_RowIndex)
        {
            string spacer = new string(k_RowSpacer, (m_BoardWidth * 8) - 4);
            string retSquaresRow = (i_RowIndex + 1) + " " + k_ColSpacer;

            // Loop through the Row Squares and Print them Out
            for (int i = 0; i < m_BoardWidth; i++)
            {
                if (m_Squares[i, i_RowIndex].Card.IsHidden)
                {
                    retSquaresRow += "      " + k_ColSpacer;
                }
                else 
                {
                    retSquaresRow += "  " + m_Squares[i, i_RowIndex].Card.Sign + "  " + k_ColSpacer;
                }
            }
            
            // Add the Row Spacer
            retSquaresRow += "\n  " + spacer + "\n";

            return retSquaresRow;
        }
    }
}