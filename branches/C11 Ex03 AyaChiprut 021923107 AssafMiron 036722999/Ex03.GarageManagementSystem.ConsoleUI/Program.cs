﻿// -----------------------------------------------------------------------
// <copyright file="Program.cs">
// Aya Chiprut 021923107 
// Assaf Miron 036722999
// </copyright>
// -----------------------------------------------------------------------

namespace Ex03.GarageManagementSystem.ConsoleUI
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// The Main Program Class
    /// </summary>
    public class Program
    {
        public static void Main()
        {
            GarageUI garageUI = new GarageUI();
            garageUI.Start();
        }
    }
}
