﻿// -----------------------------------------------------------------------
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
        private const char k_RowSpacer = '=';
        private const char k_ColSpacer = '|';
        private MemBL m_MemoryLogic = new MemBL();

        /// <summary>
        /// The Memory Game Run Function
        /// </summary>
        public void Run()
        {
            Console.WriteLine("Hey, welcome to the Memory Game!");
            Console.WriteLine("Please type your name: ");
            string playerName = Console.ReadLine();
            string secondPlayerName = null;
            bool continueGame = true; 
            
            // Get the Opponent Type
            Player.ePlayerType oponnentChoice = getUserChoiceForOponnent();
            if (oponnentChoice == Player.ePlayerType.Human)
            {
                Console.WriteLine("What is the second player name: ");
                secondPlayerName = Console.ReadLine();
            }

            if (secondPlayerName != null)
            {
                m_MemoryLogic.InitializePlayers(playerName, secondPlayerName);
            }
            else 
            {
                m_MemoryLogic.InitializePlayers(playerName);
            }

            do
            {             
                int width;
                int height;

                // Get the Requested Board Size
                getUserChoiceForBoardSize(out width, out height);

                // Initialize a Game Round
                m_MemoryLogic.initRound(width, height);
                printGameBoard(m_MemoryLogic.Board);

                do
                {
                    // Start a Memory Game Round
                    bool keepCardsVisible = false;
                    MemSquare firstSquareChoise = null;
                    MemSquare matchSquareChoice = null;

                    // Inform the Players Turn
                    Console.WriteLine("{0}'s Turn:", m_MemoryLogic.CurrentPlayer.Name);

                    // Check if the Player is Human
                    if (m_MemoryLogic.CurrentPlayer.Type == Player.ePlayerType.Human)
                    {
                        firstSquareChoise = getUserChoiceForSquare();
                        if (firstSquareChoise != null)
                        {
                            keepCardsVisible = m_MemoryLogic.PlayPlayerTurn(firstSquareChoise);
                            Screen.Clear();
                            printGameBoard(m_MemoryLogic.Board);
                        }
                        else
                        {
                            continueGame = false;
                        }

                        // Verify that the Player wants to Keep Playing
                        if (continueGame)
                        {
                            matchSquareChoice = getUserChoiceForSquare();
                            if (matchSquareChoice != null)
                            {
                                keepCardsVisible = m_MemoryLogic.PlayPlayerTurn(matchSquareChoice);
                                Screen.Clear();
                                printGameBoard(m_MemoryLogic.Board);
                            }
                            else
                            {
                                continueGame = false;
                            }
                        }
                    }
                    else
                    {
                        m_MemoryLogic.PlayComputerTurn(out firstSquareChoise, out matchSquareChoice, out keepCardsVisible);
                        printGameBoard(m_MemoryLogic.Board);
                    }

                    // Verify that the Player wants to Keep Playing
                    if (continueGame)
                    {
                        bool showUserPointsMessage = m_MemoryLogic.EndPlayerTurn(firstSquareChoise, matchSquareChoice, keepCardsVisible);
                        if (showUserPointsMessage)
                        {
                            Console.WriteLine("Hey You Found a Match! :)");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Sorry... No Match here.");
                            Console.ReadLine();
                        }

                        printGameBoard(m_MemoryLogic.Board);
                    }
                } 
                while (!m_MemoryLogic.RoundFinished && continueGame);

                printRoundSummary();

                // Check if the User wants another Round
                continueGame = getUserChoiceForPlayingAnotherRound();
            } 
            while (continueGame);

            // Game is Over - Print the End Game Message
            printEndOfGameMessage();
        }

        /// <summary>
        /// Checks if the User wants to Play another Round
        /// </summary>
        /// <returns>True if The User Wants to Play another Round</returns>
        private bool getUserChoiceForPlayingAnotherRound()
        {
            bool retPlayAnotherRound = false;
            Console.WriteLine("Do you want to play another round? Y/N");
            string choice = Console.ReadLine();

            if (choice.ToLower().Equals("y"))
            {
                retPlayAnotherRound = true;
            }
            else if (choice.ToLower().Equals("n"))
            {
                retPlayAnotherRound = false;
            }
            else
            {
                Console.WriteLine("Just Y or N please");
                return getUserChoiceForPlayingAnotherRound();
            }

            return retPlayAnotherRound;
        }

        /// <summary>
        /// Requests the User for a Square
        /// </summary>
        /// <returns>The Requested Square</returns>
        private MemSquare getUserChoiceForSquare()
        {
            MemSquare retSquare = null;
            Console.WriteLine("Please choose a square (in the format of e4)");
            string retSquareStr = Console.ReadLine();

            if (retSquareStr.ToLower().Equals("q"))
            {
                return retSquare;
            }

            bool allGood = MemSquare.TryParse(retSquareStr, out retSquare);
            if (!allGood)
            {
                Console.WriteLine("Please type a legal square");
                return getUserChoiceForSquare();
            }
            else
            {
                if (!m_MemoryLogic.Board.IsLeagalSquare(retSquare.Row, retSquare.Col))
                {
                    Console.WriteLine("The square is out of the bounds of the board, try again");
                        return getUserChoiceForSquare();
                }
                else
                {
                    if (!m_MemoryLogic.IsLegalMove(retSquare))
                    {
                        Console.WriteLine("Not a legal move, try again");
                        return getUserChoiceForSquare();
                    }
                }
            }

            return retSquare;
        }

        /// <summary>
        /// Requests The User for a Game Board Size
        /// </summary>
        /// <param name="i_Width">The Requested Width</param>
        /// <param name="i_Height">The Requested Height</param>
        private void getUserChoiceForBoardSize(out int i_Width, out int i_Height)
        {
            Console.WriteLine("Board Size: number of squares should be even");
            Console.WriteLine("Please type the board height (4-6)");
            string heightStr = Console.ReadLine();

            bool allGood = int.TryParse(heightStr, out i_Height);
            if (!allGood || i_Height > 6 || i_Height < 4)
            {
                Console.WriteLine("Just a number between 4 and 6 please");
                getUserChoiceForBoardSize(out i_Width, out i_Height);
            }
            else
            {
                Console.WriteLine("Please type the board Width (4-6)");
                string widthtStr = Console.ReadLine();
                allGood = int.TryParse(widthtStr, out i_Width);
                if (!allGood || i_Width > 6 || i_Width < 4)
                {
                    Console.WriteLine("Just a number between 4 and 6 please");
                    getUserChoiceForBoardSize(out i_Width, out i_Height);
                }
            }
        }

        /// <summary>
        /// Asks the User for its Opponent Type
        /// </summary>
        /// <returns>The Opponent Type (Human / Computer)</returns>
        private Player.ePlayerType getUserChoiceForOponnent()
        {
            Console.WriteLine("Do you want to play against the computer? Y/N");
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
                Console.WriteLine("Just Y or N please");
                return getUserChoiceForOponnent();
            }
        }

        /// <summary>
        /// Prints the Round Summary
        /// </summary>
        private void printRoundSummary()
        {
            if (m_MemoryLogic.Winner != m_MemoryLogic.Loser)
            {
                Console.WriteLine(
                    "The winner is : {0} with: {1} points against {2} points of {3}",
                    m_MemoryLogic.Winner.Name, 
                    m_MemoryLogic.Winner.Score, 
                    m_MemoryLogic.Loser.Score, 
                    m_MemoryLogic.Loser.Name);
            }
            else
            {
                Console.WriteLine("Its a Tie!\nEverybody is a Winner! :)");
            }
        }

        /// <summary>
        /// Prints the End Game Message
        /// </summary>
        private void printEndOfGameMessage()
        {
            Console.WriteLine("Thanks for playing :)");
        }

        /// <summary>
        /// Prints the Game Board
        /// </summary>
        /// <param name="i_MemBoard">The Game Board Object</param>
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
                // Seperate Each Header Letter with Spaces
                retHeaderRow += string.Format("   {0}   ", (char)('A' + i));
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
                string sign = null;
                if (i_MemBoard[i_RowIndex, i].Card.IsHidden)
                {
                    sign = " ";
                }
                else
                {
                    sign = i_MemBoard[i_RowIndex, i].Card.Sign;
                }

                retSquaresRow += string.Format("  {0}   " + k_ColSpacer, sign);
            }

            // Add the Row Spacer
            retSquaresRow += "\n  " + spacer + "\n";

            return retSquaresRow;
        }
    }
}