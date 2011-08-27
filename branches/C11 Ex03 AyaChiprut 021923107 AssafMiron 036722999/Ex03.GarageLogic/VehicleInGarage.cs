using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class VehicleInGarage
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
            m_VehicleState = eVehicleState.InRepair;
            m_Vehicle.InflateWheelsToMax();
            m_VehicleState = eVehicleState.Fixed;
        }

        public void Recharge(float i_NumOfHours)
        {
            if (m_Vehicle.Engine is BatteryTypedVehicle)
            {
                m_VehicleState = eVehicleState.InRepair;
                ((BatteryTypedVehicle)m_Vehicle.Engine).Charge(i_NumOfHours);
                m_VehicleState = eVehicleState.Fixed;
            }
            else
            {
                throw new FormatException("This is not an Electric Vehicle");
            }
        }

        public void Refuel(int i_Amount, FuelTypedVehicle.eFuelType i_FuelType)
        {
            m_VehicleState = eVehicleState.InRepair;
            ((FuelTypedVehicle)m_Vehicle.Engine).Refuel(i_Amount, i_FuelType);
        }

        public string GetDetails()
        {
            return m_Vehicle.GetDetails();
        }
    }
}

