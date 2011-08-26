using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    /// <summary>
    /// 
    /// </summary>
    class ElectricCar
    {
        private Car m_Vehicle;
        private const float k_MaxBatteryHours = 2.5F;
        protected List<string> m_PropertiesForInput;

        public ElectricCar()
        {
            m_Vehicle = new Car();
        }

        public ElectricCar(
            string i_Model,
            string i_LicenseNumber,
            Car.eCarColor i_CarColor,
            int i_NumOfDoors,
            float i_RemainingBatteryHours)
        {
            m_Vehicle = new Car(i_Model, i_LicenseNumber, wheels, new BatteryTypedVehicle(k_MaxBatteryHours, i_RemainingBatteryHours), i_CarColor, i_NumOfDoors);

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
