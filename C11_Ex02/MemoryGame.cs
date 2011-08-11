// -----------------------------------------------------------------------
// <copyright file="MemoryGame.cs">
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
    /// User Interface
    /// </summary>
    public class MemoryGame
    {
        MemBL m_MemoryLogic = new MemBL();
        private const char k_RowSpacer = '=';
        private const char k_ColSpacer = '|';

        internal void Run()
        {
            Console.WriteLine("Hey, welcome to the Memory Game!");
            Console.WriteLine("Please type your name: ");
            string playerName = Console.ReadLine();
            Player.ePlayerType oponnentChoice = getUserChoiceForOponnent();

            string secondPlayerName = null;
            if (oponnentChoice == Player.ePlayerType.Human)
            {
                Console.WriteLine("What is the second player name: ");
                secondPlayerName = Console.ReadLine();
            }

            m_MemoryLogic.InitializePlayers(playerName, secondPlayerName);

            bool userNewGameChoice = true;
            do
            {
                int width;
                int height;
                getUserChoiceForBoardSize(out width, out height);
                m_MemoryLogic.initRound(width, height);
                printGameBoard(m_MemoryLogic.Board);

                do
                {
                    MemSquare squareChoice = getUserChoiceForSquare();
                    if (squareChoice != null)
                    {
                        m_MemoryLogic.PlayPlayerTurn(squareChoice);
                        Screen.Clear();
                        printGameBoard(m_MemoryLogic.Board);
                    }
                    else
                    {
                        userNewGameChoice = false;
                    }

                    MemSquare matchSquareChoice = getUserChoiceForSquare();
                    if (matchSquareChoice != null)
                    {
                        m_MemoryLogic.PlayPlayerTurn(squareChoice);
                        Ex02.ConsoleUtils.Screen.Clear();
                        printGameBoard(m_MemoryLogic.Board);
                    }
                    else
                    {
                        userNewGameChoice = false;
                    }

                } while (!m_MemoryLogic.RoundFinished);

                printRoundSummary();

                userNewGameChoice = getUserChoiceForPlayingAnotherRound();

            } while (userNewGameChoice);

            printEndOfGameMessage();
        }

        private void printRoundSummary()
        {
            Console.WriteLine("the winner is : {0} with: {1} points against {2} points of {3}",
                m_MemoryLogic.Winner.Name, m_MemoryLogic.Winner.Score, m_MemoryLogic.Loser.Score, m_MemoryLogic.Loser.Name);
        }

        private bool getUserChoiceForPlayingAnotherRound()
        {
            Console.WriteLine("do you want to play another round? Y/N");
            string choice = Console.ReadLine();

            if (choice.ToLower().Equals("y"))
            {
                return true;
            }
            else if (choice.ToLower().Equals("n"))
            {
                return false;
            }
            else
            {
                Console.WriteLine("just y or no please");
                return getUserChoiceForPlayingAnotherRound();
            }
        }

        private MemSquare getUserChoiceForSquare()
        {
            MemSquare retSquare = null;
            Console.WriteLine("please choose a square (in the format of e4)");
            string retSquareStr = Console.ReadLine();

            if (retSquareStr.ToLower().Equals("q"))
            {
                return retSquare;
            }

            bool allGood = MemSquare.TryParse(retSquareStr, out retSquare);
            if (!allGood)
            {
                Console.WriteLine("please type a legal square");
                return getUserChoiceForSquare();
            }
            else
            {
                if (!m_MemoryLogic.Board.IsLeagalSquare(retSquare.Row, retSquare.Col))
                {
                    Console.WriteLine("the square is out of the bounds of the board, try again");
                        return getUserChoiceForSquare();
                }
                else
                {
                    if (!m_MemoryLogic.IsLegalMove(retSquare))
                    {
                        Console.WriteLine("not a legal move, try again");
                        return getUserChoiceForSquare();
                    }
                }
            }

            return retSquare;
        }

        private void printEndOfGameMessage()
        {
            Console.WriteLine("Thanks for playing :)");
        }

        private void getUserChoiceForBoardSize(out int i_Width, out int i_Height)
        {
            Console.WriteLine("Board Size: number of squares should be even");
            Console.WriteLine("please type the board height (4-6)");
            string heightStr = Console.ReadLine();

            bool allGood = int.TryParse(heightStr, out i_Height);
            if (!allGood || i_Height > 6 || i_Height < 4)
            {
                Console.WriteLine("just a number between 4 and 6 please");
                getUserChoiceForBoardSize(out i_Width, out i_Height);
            }
            else
            {
                Console.WriteLine("please type the board height (4-6)");
                string widthtStr = Console.ReadLine();
                allGood = int.TryParse(widthtStr, out i_Width);
                if (!allGood || i_Width > 6 || i_Width < 4)
                {
                    Console.WriteLine("just a number between 4 and 6 please");
                    getUserChoiceForBoardSize(out i_Width, out i_Height);
                }
            }
        }

        private Player.ePlayerType getUserChoiceForOponnent()
        {
            Console.WriteLine("do you want to play against the computer? Y/N");
            string choice = Console.ReadLine();

            if (choice.ToLower().Equals("y"))
            {
                return Player.ePlayerType.Computer;
            }
            else if (choice.ToLower().Equals("n"))
            {
                return Player.ePlayerType.Human;
            }
            else
            {
                Console.WriteLine("just y or n please");
                return getUserChoiceForOponnent();
            }
        }

        private void printGameBoard(MemBoard i_MemBoard)
        {
            // Clear the Screen
            Screen.Clear();

            // Print the Header Row
            string retBoard = printHeadersRow(i_MemBoard);

            // Print Each Row with its Squares
            for (int i = 0; i < i_MemBoard.Height; i++)
            {
                retBoard += printSquareRow(i_MemBoard, i);
            }

            // print the Board
            Console.WriteLine(retBoard);
        }

        /// <summary>
        /// Prepares the Header Row To be Printed
        /// </summary>
        /// <returns>The Header Row With Spacers Ready for Print</returns>
        private string printHeadersRow(MemBoard i_MemBoard)
        {
            string spacer = new string(k_RowSpacer, (i_MemBoard.Width * 8) - 4);
            string retHeaderRow = "  ";

            // Loop the Number of time the Header Width And Write The ABC Headers
            for (int i = 0; i < i_MemBoard.Width; i++)
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
        private string printSquareRow(MemBoard i_MemBoard, int i_RowIndex)
        {
            string spacer = new string(k_RowSpacer, (i_MemBoard.Width * 8) - 4);
            string retSquaresRow = (i_RowIndex + 1) + " " + k_ColSpacer;

            // Loop through the Row Squares and Print them Out
            for (int i = 0; i < i_MemBoard.Width; i++)
            {
                if (i_MemBoard[i_RowIndex, i].Card.IsHidden)
                {
                    retSquaresRow += "      " + k_ColSpacer;
                }
                else
                {
                    retSquaresRow += "  " + i_MemBoard[i_RowIndex, i].Card.Sign + "  " + k_ColSpacer;
                }
            }

            // Add the Row Spacer
            retSquaresRow += "\n  " + spacer + "\n";

            return retSquaresRow;
        }
    }
}
