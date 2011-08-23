using System;
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

        private void inflatesTiresOfAVehicle()
        {
            string licenseNumber;
            if (readLicenseNumberAndVerify(out licenseNumber))
            {
                m_GarageLogic.InflateVehicleWheelAir(licenseNumber);
            }
        }

        private void changeVehicleStatus()
        {
            string licenseNumber;
            VehicleInGarage.eVehicleState neededState;

            if (readLicenseNumberAndVerify(out licenseNumber))
            {
                neededState = getNeededStateFromUser();
                m_GarageLogic.ChangeVehicleState(licenseNumber, neededState);
            }
        }

        private bool readLicenseNumberAndVerify(out string o_LicenseNumber)
        {
            bool isValidReturnValue = false;
            try
            {
                System.Console.WriteLine("Enter vehicle's license number: ");
                string licenseNumber = System.Console.ReadLine();

                int licenseNumberNumeric;
                if (!int.TryParse(licenseNumber, out licenseNumberNumeric))
                {
                    throw new FormatException("License number must be numeric.");
                }
                else if (!m_GarageLogic.IsVehicleExistInGarage(licenseNumber))
                {
                    throw new ArgumentException("Vehicle was not found");
                }
                else
                {
                    isValidReturnValue = true;
                }

                o_LicenseNumber = licenseNumber;
            }
            catch (FormatException formatException)
            {
                Console.WriteLine(formatException.Message);
                isValidReturnValue = readLicenseNumberAndVerify(out o_LicenseNumber);
            }
            catch (ArgumentException argumentException)
            {
                Console.WriteLine(argumentException.Message);
                isValidReturnValue = false;
            }

            return isValidReturnValue;
        }

        private VehicleInGarage.eVehicleState getNeededStateFromUser()
        {
            string[] statusOptions;
            string userChoice; 
            int chosenOption;
            VehicleInGarage.eVehicleState? state = null;
            VehicleInGarage.eVehicleState retState = VehicleInGarage.eVehicleState.InRepair;

            try
            {
                statusOptions = Enum.GetNames(typeof(VehicleInGarage.eVehicleState));
                Console.WriteLine("Choose state: ");
                printListOfStringsToTheUser(statusOptions);
                userChoice = Console.ReadLine();
                if (!int.TryParse(userChoice, out chosenOption) || chosenOption < 1 || chosenOption > 3)
                {
                    throw new FormatException("Invalid input Please try again");
                }
                else
                {
                    state = getNeededVehicleState(chosenOption);
                    if (state.HasValue)
                    {
                        retState = state.Value;
                    }
                }
            }
            catch (FormatException formatException)
            {
                Console.WriteLine(formatException.Message);
                changeVehicleStatus();
            }
            return retState;
        }

        private void printListOfTheVehicles()
        {
            string userInput;
            int userChoice;
            bool isLegal;
            VehicleInGarage.eVehicleState? stateNeeded = null;
            List<string> vehiclesLicenseList;

            try
            {
                Console.WriteLine(
    @"Print vehicles by status:
1. in repair.
2. fixed.
3. paid.
4. all vehicles.");
                userInput = Console.ReadLine();
                isLegal = int.TryParse(userInput, out userChoice);
                if (!isLegal || userChoice < 1 || userChoice > 4)
                {
                    throw new FormatException("Invalid choice");
                }

                stateNeeded = getNeededVehicleState(userChoice);
                vehiclesLicenseList = m_GarageLogic.ListAllVehiclesInGarage(stateNeeded);
                foreach (string vehicleLicense in vehiclesLicenseList)
                {
                    Console.WriteLine(vehicleLicense);
                }
            }
            catch (FormatException formatException)
            {
                Console.WriteLine(formatException.Message);
                printListOfTheVehicles();
            }
        }

        private VehicleInGarage.eVehicleState? getNeededVehicleState(int i_UserChoice)
        {
            VehicleInGarage.eVehicleState? vehicleState = null;
            if(Enum.IsDefined(typeof(VehicleInGarage.eVehicleState), i_UserChoice))
            {
                vehicleState = (VehicleInGarage.eVehicleState)Enum.Parse(typeof(VehicleInGarage.eVehicleState), i_UserChoice.ToString());
            }

            return vehicleState;
        }

        private void insertVehicleToTheGarage()
        {
            string userInput;
            string[] vehicleParameters;
            string[] vehicleTypes;

            try
            {
                Console.WriteLine("Enter the following info seperated by commas(,): ");
                Console.WriteLine("Model name, License number, Available energy precent");
                userInput = Console.ReadLine();
                vehicleParameters = userInput.Split(',');
                if (vehicleParameters.Length != 3)
                {
                    throw new FormatException("Invalid number of parameters");                    
                }

                vehicleTypes = Enum.GetNames(typeof(Ex03.GarageLogic.VehicleFactory.eVehicleType));
                Console.WriteLine("Choose the vehicle type: ");

                printListOfStringsToTheUser(vehicleTypes);

                userInput = Console.ReadLine();
                //...
            }
            catch (FormatException formatException)
            {
                Console.WriteLine(formatException.Message);
                insertVehicleToTheGarage();
            }
        }

        private void printListOfStringsToTheUser(string[] i_Options)
        {
            int index = 1;
            foreach (string vehicleType in i_Options)
            {
                Console.WriteLine("{0}. {1}", index, vehicleType);
            }
        }

        private eMenuOption? getMenuOptionFromInput(string i_UserChoice)
        {
            eMenuOption? retMenuOption = null;
            int choice;

            if (int.TryParse(i_UserChoice, out choice) && Enum.IsDefined(typeof(eMenuOption), choice))
            {
                retMenuOption = (eMenuOption)Enum.Parse(typeof(eMenuOption), i_UserChoice);
            }

            return retMenuOption;
        }
    }
}
