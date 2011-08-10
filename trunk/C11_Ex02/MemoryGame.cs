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

        /// <summary>
        /// Get information from the user
        /// </summary>
        public void InitGame()
        {
            // Get Player Name
            // Get number of Players in the Game
            GetPlayersInfoFromUser();
            GetBoardInfoFromUser();
        }

        private void GetBoardInfoFromUser()
        {
            bool isLegal;
            string userInput;
            int height = 0;
            int width = 0;
            // TODO: Let the User Choose Other Sizes in the Same Format
            // Use Check Input From Board (or Something) 
            Console.WriteLine("please choose the board size: (4x4, 4X6, 6X4, 6X6)");
            do
            {
                userInput = getUserInput();
                if (userInput.Equals("4X4", StringComparison.OrdinalIgnoreCase))
                {
                    isLegal = true;
                    width = 4;
                    height = 4;
                }
                else if (userInput.Equals("4X6", StringComparison.OrdinalIgnoreCase))
                {
                    isLegal = true;
                    width = 4;
                    height = 6;
                }
                else if (userInput.Equals("6X4", StringComparison.OrdinalIgnoreCase))
                {
                    isLegal = true;
                    width = 6;
                    height = 4;
                }
                else if (userInput.Equals("6X6", StringComparison.OrdinalIgnoreCase))
                {
                    isLegal = true;
                    width = 6;
                    height = 6;
                }
                else
                {
                    isLegal = false;
                    Console.WriteLine("wrong input, please choose the board size: (4x4, 4X6, 6X4, 6X6)");
                }
            } 
            while (!isLegal);

            m_MemoryLogic.CreateMemoryGame(width, height);
        }

        private void GetPlayersInfoFromUser()
        {
            int numOfHumanPlayers = 0;
            string userInput;
            bool isLegal;
            Console.WriteLine("Please type your name: ");
            string playerName = Console.ReadLine();
            Console.WriteLine(playerName + ", Do you want to play against the computer? Y/N: ");

            do
            {
                userInput = getUserInput();
                if (userInput.Equals("y", StringComparison.OrdinalIgnoreCase))
                {
                    isLegal = true;
                    numOfHumanPlayers = 1;
                }
                else if (userInput.Equals("n", StringComparison.OrdinalIgnoreCase))
                {
                    isLegal = true;
                    numOfHumanPlayers = 2;
                }  
                else
                {
                    isLegal = false;
                    Console.WriteLine("wrong input, do you want to play against the computer? Y/N: ");
                }
            } while (!isLegal);

            if (numOfHumanPlayers == 2)
            {
                Console.WriteLine("What is the second player name: ");
                string secondPlayerName = Console.ReadLine();

                // Construct Players (Both Humans)
                m_MemoryLogic.InitializePlayers(playerName, secondPlayerName);
            }
            else
            {
                // Construct Players (Human and Computer)
                m_MemoryLogic.InitializePlayers(playerName);
            }
        }

        /// <summary>
        /// Gets the user input, if the user input is 'Q' - Exiting the application
        /// </summary>
        /// <returns></returns>
        private string getUserInput()
        {
            string userInput = Console.ReadLine();

            if (userInput.Equals("q", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("You chose to quit the game.");
                endGame();
            }

            return userInput;
        }

        private static void endGame()
        {
            throw new NotImplementedException();
        }

       
        /// <summary>
        /// Gets the Number of Players From Console
        /// </summary>
        /// <returns></returns>
        public int GetNumberOfPlayers()
        {
            return 0;
        }

        public string PrintGameBoard()
        {
            return m_MemoryLogic.PrintGameBoard();
        }
    }
}
