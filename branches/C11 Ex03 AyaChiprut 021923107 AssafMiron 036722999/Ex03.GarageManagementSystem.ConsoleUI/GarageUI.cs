﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageManagementSystem.ConsoleUI
{
    public class GarageUI
    {
        private enum eMenuOption
        {
            InsertVehicle = 1,
            PrintVehiclesList = 2,
            ChangeVehicleStatus = 3,
            InflateTires = 4,
            RefuelVehicle = 5,
            RechargeVehicle = 6,
            PrintVehicleDetails = 7,
            Exit = 8,
        }

        private GarageBL m_GarageLogic = new GarageBL();

        internal void Start()
        {
            System.Console.WriteLine("Welcome to the Garage Management System");
            eMenuOption? chosenOption = null;
            string userChoice = null;
            do
            {
                System.Console.Write(
@"What would you like to do?

1. Insert vehicle into garage.
2. Print list of vehicles in the garage.
3. Change status of a vehicle.
4. Inflate tires of a vehicle.
5. Refuel vehicle.
6. Recharge vehicle.
7. Print vehicle details according to license number.
8. Exit.

Enter your choice: ");

                userChoice = Console.ReadLine();
                chosenOption = getMenuOptionFromInput(userChoice);
                if (chosenOption != null)
                {
                    handleUserChoice(chosenOption);
                }
            }

            while (chosenOption != eMenuOption.Exit);
        }

        private void handleUserChoice(eMenuOption? chosenOption)
        {
            switch (chosenOption)
            {
                case eMenuOption.InsertVehicle:
                {
                    insertVehicleToTheGarage();
                    break;
                }
                case eMenuOption.PrintVehiclesList:
                {
                    printListOfTheVehicles();
                    break;
                }
                case eMenuOption.ChangeVehicleStatus:
                {
                    changeVehicleStatus();
                    break;
                }
                case eMenuOption.InflateTires:
                {
                    inflatesTiresOfAVehicle();
                    break;
                }
                case eMenuOption.RefuelVehicle:
                {
                    refuelAvehicle();
                    break;
                }
                case eMenuOption.RechargeVehicle:
                {
                    rechargeAVehicle();
                    break;
                }
                case eMenuOption.PrintVehicleDetails:
                {
                    printVehicleDetails();
                    break;
                }
                case eMenuOption.Exit:
                {
                    break;
                }
            }
        }

        private void insertVehicleToTheGarage()
        {
            string userInput;
            string[] vehicleParameters;
            string[] vehicleTypes;

            Console.WriteLine("Enter the following info seperated by commas(,): ");
            Console.WriteLine("Model name, License number, Available energy precent");
            userInput = Console.ReadLine();
            vehicleParameters = userInput.Split(',');
            if (vehicleParameters.Length != 3)
            {
                Console.WriteLine("Invalid number of parameters");
                insertVehicleToTheGarage();
            }

            vehicleTypes = Enum.GetNames(typeof(Ex03.GarageLogic.VehicleFactory.eVehicleType));
            Console.WriteLine("Choose the vehicle type: ");

            int index = 1;
            foreach (string vehicleType in vehicleTypes)
            {
                Console.WriteLine("{0}. {1}", index, vehicleType);
            }

            userInput = Console.ReadLine();
            //...
        }

        private eMenuOption? getMenuOptionFromInput(string i_UserChoice)
        {
            eMenuOption? retMenuOption = null;
            if(Enum.IsDefined(typeof(eMenuOption), i_UserChoice))
            {
                retMenuOption = (eMenuOption)Enum.Parse(typeof(eMenuOption), i_UserChoice);
            }

            return retMenuOption;
        }
    }
}
