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
                Console.Clear();
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
                    waitForUserResponse("Vehicle Entered the Garage.");
                    break;
                }

                case eMenuOption.PrintVehiclesList:
                {
                    printListOfTheVehicles();
                    waitForUserResponse();
                    break;
                }

                case eMenuOption.ChangeVehicleStatus:
                {
                    changeVehicleStatus();
                    waitForUserResponse();
                    break;
                }

                case eMenuOption.InflateTires:
                {
                    inflatesTiresOfAVehicle();
                    waitForUserResponse("All Vehicle Wheels are Inflated");
                    break;
                }

                case eMenuOption.RefuelVehicle:
                {
                    refuelAvehicle();
                    waitForUserResponse("The Vehicle is now Refuled");
                    break;
                }

                case eMenuOption.RechargeVehicle:
                {
                    rechargeAVehicle();
                    waitForUserResponse("The Vehicle is now Recharged");
                    break;
                }

                case eMenuOption.PrintVehicleDetails:
                {
                    printVehicleDetails();
                    waitForUserResponse();
                    break;
                }

                case eMenuOption.Exit:
                {
                    printExitMessage();
                    waitForUserResponse();
                    break;
                }
            }
        }

        private void waitForUserResponse(params string[] i_MessageToDisplay)
        {
            if (i_MessageToDisplay != null && i_MessageToDisplay.Length > 0)
            {
                foreach (string message in i_MessageToDisplay)
                {
                    Console.WriteLine();
                }
            }
            Console.Write("Press Any Key to Continue...");
            Console.ReadLine();
        }

        private void printExitMessage()
        {
            Console.WriteLine(string.Format("Thank you for Using the Garage Management System{0}Goodbye!", Environment.NewLine));
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
                float numOfHours;

                if (readLicenseNumberAndVerify(out licenseNumber))
                {
                    numOfHours = getNumOfHoursToRecharge();
                    m_GarageLogic.RechargeVehicle(licenseNumber, numOfHours);
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

        private float getNumOfHoursToRecharge()
        {
            float numericAmount;
            string chargeAmount;

            try
            {
                System.Console.Write("Enter number of hours to recharge: ");
                chargeAmount = System.Console.ReadLine();
                if (!float.TryParse(chargeAmount, out numericAmount))
                {
                    throw new FormatException("Number of hours must be numeric."); 
                }
            }
            catch (FormatException i_FormatException)
            {
                Console.WriteLine(i_FormatException.Message);
                numericAmount = getNumOfHoursToRecharge();
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
                    throw new FormatException("Amount of fuel must be numeric.");
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
                try
                {
                    Console.WriteLine(string.Format("Inflating...{0}",Environment.NewLine));
                    m_GarageLogic.InflateVehicleWheelAir(licenseNumber);
                    Console.WriteLine(string.Format("All Vehicle Wheels are Inflated to the Maximum.{0}",Environment.NewLine));
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
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

                //int licenseNumberNumeric;
                //// TODO: Fix, License Number is String...
                //if (!int.TryParse(licenseNumber, out licenseNumberNumeric))
                //{
                //    throw new FormatException("License number must be numeric.");
                //}
                if (!m_GarageLogic.IsVehicleExistInGarage(licenseNumber))
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
1. In repair.
2. Fixed.
3. Paid.
4. All vehicles.");
                userInput = Console.ReadLine();
                isLegal = int.TryParse(userInput, out userChoice);
                if (!isLegal || userChoice < 1 || userChoice > 4)
                {
                    throw new FormatException("Invalid choice");
                }

                stateNeeded = getNeededVehicleState(userChoice);
                Console.WriteLine("Printing All {0} Vehicles.", (stateNeeded != null ? stateNeeded.ToString() : "\b"));
                vehiclesLicenseList = m_GarageLogic.ListAllVehiclesInGarage(stateNeeded);
                if (vehiclesLicenseList.Count > 0)
                {
                    foreach (string vehicleLicense in vehiclesLicenseList)
                    {
                        Console.WriteLine(vehicleLicense);
                    }
                }
                else
                {
                    Console.WriteLine("No Vehicles in this Category");
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
            if(Enum.IsDefined(typeof(VehicleInGarage.eVehicleState), i_UserChoice - 1))
            {
                vehicleState = (VehicleInGarage.eVehicleState)Enum.Parse(typeof(VehicleInGarage.eVehicleState), (i_UserChoice - 1).ToString());
            }

            return vehicleState;
        }

        private VehicleFactory.eVehicleType? getNeededVehicleType(int i_UserChoice)
        {
            VehicleFactory.eVehicleType? vehicleType = null;
            if (Enum.IsDefined(typeof(VehicleFactory.eVehicleType), i_UserChoice))
            {
                vehicleType = (VehicleFactory.eVehicleType)Enum.Parse(typeof(VehicleFactory.eVehicleType), i_UserChoice.ToString());
            }

            return vehicleType;
        }

        private void insertVehicleToTheGarage()
        {
            string userInput;
            string[] vehicleTypes;
            int chosenOption;
            VehicleFactory.eVehicleType? vehicleType = null;
            Vehicle newVehicle;

            try
            {
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
            catch (ArgumentException i_ArgumentException)
            {
                Console.WriteLine(i_ArgumentException.Message);
            }
        }

        private string getOwnerPhoneNumber()
        {
            Console.WriteLine("What is your Phone Number?");
            return Console.ReadLine();
        }

        private string getOwnerName()
        {
            Console.WriteLine("What is your Name? (To record in our system as Owner Name)");
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
                index++;
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
