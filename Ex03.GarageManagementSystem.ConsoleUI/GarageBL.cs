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
            string retMessage = null;
            bool foundVehicle = false;
            foreach(VehicleInGarage inGarageVehicle in m_VehiclesInGarage)
            {
                if (inGarageVehicle.LicenseNumber == i_Vehicle.LicenseNumber)
                {
                    retMessage = string.Format("The Vehicle is allready in the Garage.{0}Switching the Vehicle to be Repaired.", Environment.NewLine);
                    foundVehicle = true;
                    inGarageVehicle.VehicleState = VehicleInGarage.eVehicleState.InRepair;
                }
            }

            if (!foundVehicle)
            {
                retMessage = "";
                m_VehiclesInGarage.Add(new VehicleInGarage(i_OwnerName, i_OwnerPhoneNumber, i_Vehicle));
            }
            
            return retMessage;
        }

        public List<string> ListAllVehiclesInGarage(params VehicleInGarage.eVehicleState[] i_FilterVehicleStates)
        {
            List<string> retLicenseNumberList = new List<string>();
            if (i_FilterVehicleStates != null)
            {
                foreach (VehicleInGarage vehicle in m_VehiclesInGarage)
                {
                    foreach (VehicleInGarage.eVehicleState filterVehicleStates in i_FilterVehicleStates)
                    {
                        if (vehicle.VehicleState == filterVehicleStates)
                        {
                            retLicenseNumberList.Add(vehicle.LicenseNumber);
                        }
                    }
                    
                }
            }
            else 
            {
                foreach (VehicleInGarage vehicle in m_VehiclesInGarage)
                {
                    retLicenseNumberList.Add(vehicle.LicenseNumber);
                }
            }

            return retLicenseNumberList;
        }

        public bool ChangeVehicleState(string i_LicenseNumber, VehicleInGarage.eVehicleState i_NewVehicleState)
        {
            bool retChangeSucceeded = false;
            VehicleInGarage vehicleToUpdate = SearchVehicleInGarage(i_LicenseNumber);

            if (vehicleToUpdate != null)
            {
                vehicleToUpdate.VehicleState = i_NewVehicleState;
                retChangeSucceeded = true;
            }
            else
            {
                retChangeSucceeded = false;
            }

            return retChangeSucceeded;
        }

        public bool InflateVehicleWheelAir(string i_LicenseNumber)
        {
            bool retInfalteSucceeded = false;
            VehicleInGarage vehicleToInflate = SearchVehicleInGarage(i_LicenseNumber);
            if (vehicleToInflate != null)
            {
                vehicleToInflate.Inflate();
                retInfalteSucceeded = true;
            }

            return retInfalteSucceeded;
        }

        private VehicleInGarage SearchVehicleInGarage(string i_LicenseNumber)
        {
            VehicleInGarage retVehicle = null;
            foreach (VehicleInGarage vehicle in m_VehiclesInGarage)
            {
                if (vehicle.LicenseNumber == i_LicenseNumber)
                {
                    retVehicle = vehicle;
                    break;
                }
            }

            return retVehicle;
        }
    }
}
