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
        int m_NumberOfHumanPlayers = 0;
        MemBL m_MemoryLogic = new MemBL();

        internal void Run()
        {
            Console.WriteLine("Hey, welcome to the Memory Game!");
            Console.WriteLine("Please type your name: ");
            string playerName = Console.ReadLine();
            Console.WriteLine(playerName + ", Do you want to play against the computer? Y/N: ");
            MemBL.eOponnentType oponnentChoice = getUserChoiceForOponnent();

            string secondPlayerName = null;
            if (oponnentChoice == MemBL.eOponnentType.Human)
            {
                Console.WriteLine("What is the second player name: ");
                secondPlayerName = Console.ReadLine();
            }

            m_MemoryLogic.initGame(playerName, secondPlayerName, oponnentChoice);

            bool userNewGameChoice = true;
            do
            {
                int width;
                int height;
                getUserChoiceForBoardSize(out width, out height);
                m_MemoryLogic.initRound(width, height);

                PrintGameBoard();

                do
                {
                    MemSquare squareChoice = getUserChoiceForSquare();
                    if (squareChoice != null)
                    {
                        m_MemoryLogic.DoMove(squareChoice);
                        Ex02.ConsoleUtils.Screen.Clear();
                        PrintGameBoard();
                    }
                    else
                    {
                        userNewGameChoice = false;
                    }

                    MemSquare matchSquareChoice = getUserChoiceForSquare();
                    if (matchSquareChoice != null)
                    {                       
                        m_MemoryLogic.DoMove(squareChoice);
                        Ex02.ConsoleUtils.Screen.Clear();
                        PrintGameBoard();
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
                    if (!m_MemoryLogic.isLegalMove(retSquare))
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

        private MemBL.eOponnentType getUserChoiceForOponnent()
        {
            Console.WriteLine("do you want to play against the computer? Y/N");
            string choice = Console.ReadLine();

            if (choice.ToLower().Equals("y"))
            {
                return MemBL.eOponnentType.Computer;
            }
            else if (choice.ToLower().Equals("n"))
            {
                return MemBL.eOponnentType.Human;
            }
            else
            {
                Console.WriteLine("just y or n please");
                return getUserChoiceForOponnent();
            }
        }

        public string PrintGameBoard()
        {
            return m_MemoryLogic.PrintGameBoard();
        }

        
    }
}
