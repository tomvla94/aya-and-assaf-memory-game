using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;
namespace Ex03.GarageManagementSystem.ConsoleUI
{
    class GarageBL
    {
        private List<VehicleInGarage> m_VehiclesInGarage;

        public string AddVehicleToGarage(string i_OwnerName, string i_OwnerPhoneNumber, Vehicle i_Vehicle)
        {
            string retMessage;
            bool foundVehicle = false;
            foreach(VehicleInGarage inGarageVehicle in m_VehiclesInGarage)
            {
                if (inGarageVehicle.LicenseNumber == i_Vehicle.LicenseNumber)
                {
                    retMessage = "The Vehicle is allready in the Garage.{0}Switching the Vehicle to be Repaired.";
                    foundVehicle = true;
                    inGarageVehicle.VehicleState = VehicleInGarage.eVehicleState.InRepair;
                }
            }

            if (!foundVehicle)
            {
                retMessage = "";
                m_VehiclesInGarage.Add(new VehicleInGarage(i_OwnerName, i_OwnerPhoneNumber, i_Vehicle);
            }
            
            return retMessage;
        }
    }
}
