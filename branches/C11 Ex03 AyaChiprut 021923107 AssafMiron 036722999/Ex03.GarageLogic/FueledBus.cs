using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    /// <summary>
    /// 
    /// </summary>
    class FueledBus
    {
        private Bus m_Vehicle;
        private const float k_MaxFuelLiters = 200;
        private const FuelTypedVehicle.eFuelType k_FuelType = FuelTypedVehicle.eFuelType.Soler;
        protected List<string> m_PropertiesForInput;

        public FueledBus()
        {
            m_Vehicle = new Bus();
        }

        public FueledBus(
            string i_Model,
            string i_LicenseNumber,
            float i_RemainingFuelLiters)
        {
            m_Vehicle = new Bus(i_Model, i_LicenseNumber, wheels, new FuelTypedVehicle(k_FuelType, k_MaxFuelLiters, i_RemainingFuelLiters));

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
