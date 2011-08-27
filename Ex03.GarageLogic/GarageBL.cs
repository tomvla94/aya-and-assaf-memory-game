using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class GarageBL
    {
        private List<VehicleInGarage> m_VehiclesInGarage;

        public GarageBL()
        {
            m_VehiclesInGarage = new List<VehicleInGarage>();
        }

        public void AddVehicleToGarage(string i_OwnerName, string i_OwnerPhoneNumber, Vehicle i_Vehicle)
        {
            bool foundVehicle = false;
            foreach(VehicleInGarage inGarageVehicle in m_VehiclesInGarage)
            {
                if (inGarageVehicle.LicenseNumber == i_Vehicle.LicenseNumber)
                {
                    foundVehicle = true;
                    inGarageVehicle.VehicleState = VehicleInGarage.eVehicleState.InRepair;
                    throw new ArgumentException(
                        string.Format(
                        "The Vehicle is allready in the Garage.{0}Switching the Vehicle to be Repaired.",
                        Environment.NewLine));
                }
            }

            if (!foundVehicle)
            {
                m_VehiclesInGarage.Add(new VehicleInGarage(i_OwnerName, i_OwnerPhoneNumber, i_Vehicle));
            }
        }

        public List<string> ListAllVehiclesInGarage(VehicleInGarage.eVehicleState? i_FilterVehicleState)
        {
            List<string> retLicenseNumberList = new List<string>();
            if (i_FilterVehicleState != null)
            {
                foreach (VehicleInGarage vehicle in m_VehiclesInGarage)
                {
                    if (vehicle.VehicleState == i_FilterVehicleState)
                    {
                        retLicenseNumberList.Add(vehicle.LicenseNumber);
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

        public bool RechargeVehicle(string i_LicenseNumber, float i_NumOfHours)
        {
            bool retRechargeSucceeded = false;
            VehicleInGarage vehicleToRecharge = SearchVehicleInGarage(i_LicenseNumber);
            if (vehicleToRecharge != null)
            {
                vehicleToRecharge.Recharge(i_NumOfHours);
                retRechargeSucceeded = true;
            }

            return retRechargeSucceeded;
        }

        public bool RefuelVehicle(string i_LicenseNumber, FuelTypedVehicle.eFuelType i_FuelType, int i_AmountNeeded)
        {
            bool retRefuelSucceeded = false;
            VehicleInGarage vehicleToRefuel = SearchVehicleInGarage(i_LicenseNumber);
            if (vehicleToRefuel != null)
            {
                vehicleToRefuel.Refuel(i_AmountNeeded, i_FuelType);
                retRefuelSucceeded = true;
            }

            return retRefuelSucceeded;
        }

        public bool IsVehicleExistInGarage(string i_LicenseNumber)
        {
            bool retVehicleFound = false;
            VehicleInGarage vehicleToSearch = SearchVehicleInGarage(i_LicenseNumber);
            if (vehicleToSearch != null)
            {
                retVehicleFound = true;
            }

            return retVehicleFound;
        }

        public string GetVehicleDetails(string i_LicenseNumber)
        {
            VehicleInGarage vehicleToSearch = SearchVehicleInGarage(i_LicenseNumber);
            string retVehicleDetails = string.Empty;
            if (vehicleToSearch != null)
            {
                retVehicleDetails = vehicleToSearch.GetDetails();
            }

            return retVehicleDetails;
        }
    }
}
