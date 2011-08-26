using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    /// <summary>
    /// 
    /// </summary>
    class ElectricMotorcycle
    {
        private Motorcycle m_Vehicle;
        private const float k_MaxBatteryHours = 1.8F;
        protected List<string> m_PropertiesForInput;

        public ElectricMotorcycle(
            string i_Model,
            string i_LicenseNumber,
            float i_RemainingBatteryHours)
        {
            List<Wheel> wheels = new List<Wheel>();
            m_Vehicle = new Motorcycle(i_Model, i_LicenseNumber, wheels, new BatteryTypedVehicle(k_MaxBatteryHours, i_RemainingBatteryHours));

            m_PropertiesForInput = new List<string>();
        }

        public List<string> GetPropertiesForInput()
        {
            return m_PropertiesForInput;
        }

        public void SetPropertiesFromInput(List<string> i_PropertiesFromUser)
        {
            m_Vehicle.SetPropertiesFromInput(i_PropertiesFromUser);
        }

        public string GetDetails()
        {
            return m_Vehicle.GetDetails();
        }
    }
}
