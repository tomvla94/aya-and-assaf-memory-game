using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    /// <summary>
    /// 
    /// </summary>
    class FueledMotorcycle
    {
        private Motorcycle m_Vehicle;
        private const float k_MaxFuelLiters = 6;
        private const FuelTypedVehicle.eFuelType k_FuelType = FuelTypedVehicle.eFuelType.Octan98;
        protected List<string> m_PropertiesForInput;

        public FueledMotorcycle(
            string i_Model,
            string i_LicenseNumber,
            float i_RemainingFuelLiters)
        {
            List<Wheel> wheels = new List<Wheel>(); // TODO: Complete Wheels List
            m_Vehicle = new Motorcycle(i_Model, i_LicenseNumber, wheels, new FuelTypedVehicle(k_FuelType, k_MaxFuelLiters, i_RemainingFuelLiters));

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
