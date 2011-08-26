using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;

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

        private void printVehicleDetails()
        {
            string licenseNumber;
            string vehicleDeatails = string.Empty;

            if (readLicenseNumberAndVerify(out licenseNumber))
            {
                vehicleDeatails = m_GarageLogic.GetVehicleDetails(licenseNumber);
            }

            Console.WriteLine(vehicleDeatails);
        }

        private void rechargeAVehicle()
        {
            try
            {
                string licenseNumber;
                int numOfMinutes;

                if (readLicenseNumberAndVerify(out licenseNumber))
                {
                    numOfMinutes = getNumOfMinutesToRecharge();
                    m_GarageLogic.RechargeVehicle(licenseNumber, numOfMinutes);
                }
            }
            catch (ArgumentException i_ArgumentException)
            {
                Console.WriteLine(i_ArgumentException.Message);
            }
            catch (ValueOutOfRangeException i_ValueOutOfRangeException)
            {
                Console.WriteLine(i_ValueOutOfRangeException.Message);
            }
        }

        private int getNumOfMinutesToRecharge()
        {
            int numericAmount;
            string chargeAmount;

            try
            {
                System.Console.Write("Enter number of minutes to recharge: ");
                chargeAmount = System.Console.ReadLine();
                if (!int.TryParse(chargeAmount, out numericAmount))
                {
                    throw new FormatException("Number of minutes must be numeric."); 
                }
            }
            catch (FormatException i_FormatException)
            {
                Console.WriteLine(i_FormatException.Message);
                numericAmount = getNumOfMinutesToRecharge();
            }

            return numericAmount;
        }

        private void refuelAvehicle()
        {
            try
            {
                FuelTypedVehicle.eFuelType fuelType;
                string licenseNumber;
                int amountNeeded;

                if (readLicenseNumberAndVerify(out licenseNumber))
                {
                    fuelType = getNeededFuelTypeFromUser();
                    amountNeeded = getAmountOfFuelNeeded();
                    m_GarageLogic.RefuelVehicle(licenseNumber, fuelType, amountNeeded);
                }
            }
            catch (ArgumentException i_ArgumentException)
            {
                Console.WriteLine(i_ArgumentException.Message);
            }
            catch (ValueOutOfRangeException i_ValueOutOfRangeException)
            {
                Console.WriteLine(i_ValueOutOfRangeException.Message);
            }
        }

        private int getAmountOfFuelNeeded()
        {
            int numericAmount;
            string fuelAmount;

            try
            {
                System.Console.Write("Enter amount of fuel: ");
                fuelAmount = System.Console.ReadLine();
                if (!int.TryParse(fuelAmount, out numericAmount))
                {
                    throw new FormatException("amount of fuel must be numeric.");
                }
            }
            catch (FormatException i_FormatException)
            {
                Console.WriteLine(i_FormatException.Message);
                numericAmount = getAmountOfFuelNeeded();
            }

            return numericAmount;
        }

        private FuelTypedVehicle.eFuelType getNeededFuelTypeFromUser()
        {
            FuelTypedVehicle.eFuelType? fuelType;
            FuelTypedVehicle.eFuelType retFuelType = FuelTypedVehicle.eFuelType.Octan95;

            try
            {
                string fuelTypeString;
                string[] fuelOptions;
                int chosenOption;

                fuelOptions = Enum.GetNames(typeof(FuelTypedVehicle.eFuelType));
                Console.WriteLine("Choose fuel: ");
                printListOfStringsToTheUser(fuelOptions);
                fuelTypeString = Console.ReadLine();
                if (!int.TryParse(fuelTypeString, out chosenOption) || chosenOption < 1 || chosenOption > fuelOptions.Length)
                {
                    throw new FormatException("Invalid input Please try again");
                }
                else
                {
                    fuelType = getNeededFuelType(fuelTypeString);
                    if (fuelType.HasValue)
                    {
                        retFuelType = fuelType.Value;
                    }
                    else
                    {
                        throw new ArgumentException("type of fuel does not exist");
                    }
                }
            }
            catch (FormatException i_FormatException)
            {
                Console.WriteLine(i_FormatException.Message);
                fuelType = getNeededFuelTypeFromUser();
            }
            catch (ArgumentException i_ArgumentException)
            {
                Console.WriteLine(i_ArgumentException.Message);
                throw;
            }

            return retFuelType;
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
                // TODO: Fix, License Number is String...
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
            catch (FormatException i_FormatException)
            {
                Console.WriteLine(i_FormatException.Message);
                o_LicenseNumber = null;
                isValidReturnValue = readLicenseNumberAndVerify(out o_LicenseNumber);
            }
            catch (ArgumentException i_ArgumentException)
            {
                Console.WriteLine(i_ArgumentException.Message);
                o_LicenseNumber = null;
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
                if (!int.TryParse(userChoice, out chosenOption) || chosenOption < 1 || chosenOption > statusOptions.Length)
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
                    else
                    {
                        throw new ArgumentException("chosen state does not exist");
                    }
                }
            }
            catch (FormatException i_FormatException)
            {
                Console.WriteLine(i_FormatException.Message);
                changeVehicleStatus();
            }
            catch (ArgumentException i_ArgumentException)
            {
                Console.WriteLine(i_ArgumentException.Message);
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
            catch (FormatException i_FormatException)
            {
                Console.WriteLine(i_FormatException.Message);
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

        private VehicleFactory.eVehicleType? getNeededVehicleType(int i_UserChoice)
        {
            VehicleFactory.eVehicleType? vehicleType = null;
            if (Enum.IsDefined(typeof(VehicleInGarage.eVehicleState), i_UserChoice))
            {
                vehicleType = (VehicleFactory.eVehicleType)Enum.Parse(typeof(VehicleFactory.eVehicleType), i_UserChoice.ToString());
            }

            return vehicleType;
        }

        private void insertVehicleToTheGarage()
        {
            string userInput;
            string[] vehicleParameters;
            string[] vehicleTypes;
            int chosenOption;
            VehicleFactory.eVehicleType? vehicleType = null;
            Vehicle newVehicle;

            try
            {
                // TODO: Why do we need the Avilable Energy Precent? we calculate it
                Console.WriteLine("Enter the following info seperated by commas(,): ");
                Console.WriteLine("Model name, License number, Available energy precent");
                userInput = Console.ReadLine();
                vehicleParameters = userInput.Split(',');
                if (vehicleParameters.Length != 3)
                {
                    throw new FormatException("Invalid number of parameters");                    
                }

                vehicleTypes = Enum.GetNames(typeof(VehicleFactory.eVehicleType));
                Console.WriteLine("Choose the vehicle type: ");

                printListOfStringsToTheUser(vehicleTypes);

                userInput = Console.ReadLine();
                if (!int.TryParse(userInput, out chosenOption) || chosenOption < 1 || chosenOption > vehicleTypes.Length)
                {
                    throw new FormatException("Invalid input Please try again");
                }
                else
                {
                    vehicleType = getNeededVehicleType(chosenOption);
                    if (vehicleType.HasValue)
                    {
                        newVehicle = VehicleFactory.CreateVehicle(vehicleType);
                    }
                    else
                    {
                        throw new ArgumentException("chosen Type does not exist");
                    }
                }

                getInformationAboutTheVehicle(newVehicle);
                string ownerName = getOwnerName();
                string ownerPhone = getOwnerPhoneNumber();
                m_GarageLogic.AddVehicleToGarage(ownerName, ownerPhone, newVehicle);
            }
            catch (FormatException i_FormatException)
            {
                Console.WriteLine(i_FormatException.Message);
                insertVehicleToTheGarage();
            }
        }

        private string getOwnerPhoneNumber()
        {
            Console.WriteLine("What is your Name? (To record in our system as Owner Name)");
            return Console.ReadLine();
        }

        private string getOwnerName()
        {
            Console.WriteLine("What is your Phone Number?");
            return Console.ReadLine();
        }

        private void getInformationAboutTheVehicle(Vehicle newVehicle)
        {
            List<string> propertiesToAsk;
            List<string> propertiesToPass = new List<string>();

            propertiesToAsk = newVehicle.GetPropertiesForInput();
            foreach (string question in propertiesToAsk)
            {
                Console.WriteLine("Please enter {0}", question);
                propertiesToPass.Add(Console.ReadLine());
            }

            newVehicle.SetPropertiesFromInput(propertiesToPass);
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

        private FuelTypedVehicle.eFuelType? getNeededFuelType(string i_UserChoice)
        {
            FuelTypedVehicle.eFuelType retFuelType = FuelTypedVehicle.eFuelType.Octan95;
            int choice;

            if (int.TryParse(i_UserChoice, out choice) && Enum.IsDefined(typeof(FuelTypedVehicle.eFuelType), choice))
            {
                retFuelType = (FuelTypedVehicle.eFuelType)Enum.Parse(typeof(FuelTypedVehicle.eFuelType), i_UserChoice);
            }

            return retFuelType;
        }

        public int amountNeeded { get; set; }
    }
}
