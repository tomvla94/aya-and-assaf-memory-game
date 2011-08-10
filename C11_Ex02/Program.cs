using System;
using System.Collections.Generic;
using System.Text;

namespace C11_Ex02
{
    class Program
    {
        /// <summary>
        /// Program Main
        /// </summary>
        public static void Main()
        {
            MemoryGame memGame = new MemoryGame();
            // Welcome To the Game
            Console.WriteLine("Hey, welcome to the Memory Game!");

            // Initialize the Game
            memGame.InitGame();

            // Print the Initialized Game Board
            Console.WriteLine(MemBL.Instance.PrintGameBoard());

            // Play the Game
            // Print Error Messages to Screen
            // When the Game is Over - Ask if To Play another Game
            Console.ReadLine();
        }
    }
}
