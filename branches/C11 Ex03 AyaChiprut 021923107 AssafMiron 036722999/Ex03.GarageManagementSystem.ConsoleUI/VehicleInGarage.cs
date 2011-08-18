using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.GarageManagementSystem.ConsoleUI
{
    class VehicleInGarage
    {
        public enum eVehicleState
        { 
            InRepair,
            Fixed,
            Payed
        }

        private string m_OwnerName;
        private string m_OwnerPhoneNumber;
        private eVehicleState m_VehicleState;
        private Vehicle m_Vehicle;

        public VehicleInGarage(string i_OwnerName, string i_OwnerPhoneNumber, Vehicle i_Vehicle)
        {
            m_OwnerName = i_OwnerName;
            m_OwnerPhoneNumber = i_OwnerPhoneNumber;
            m_VehicleState = eVehicleState.InRepair;
            m_Vehicle = i_Vehicle;
        }

        public string OwnerName
        {
            get { return m_OwnerName; }
        }

        public string OwnerPhoneNumber
        {
            get { return m_OwnerPhoneNumber; }
        }

        public eVehicleState VehicleState
        {
            get { return m_VehicleState; }
            set { m_VehicleState = value; }
        }

        public string LicenseNumber
        {
            get { return m_Vehicle.LicenseNumber; }
        }

        public void Inflate()
        {
            m_Vehicle.InflateWheelsToMax();
        }

    }
}
