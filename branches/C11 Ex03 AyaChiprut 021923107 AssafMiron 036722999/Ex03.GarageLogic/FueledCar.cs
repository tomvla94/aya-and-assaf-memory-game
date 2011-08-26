-﻿// -----------------------------------------------------------------------
// <copyright file="FueledCar.cs">
// Aya Chiprut 021923107 
// Assaf Miron 036722999
// </copyright>
// -----------------------------------------------------------------------

namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class FueledCar
    {
        private Car m_Vehicle;
        private const float k_MaxFuelLiters = 45;
        private const FuelTypedVehicle.eFuelType k_FuelType = FuelTypedVehicle.eFuelType.Octan95;
        protected List<string> m_PropertiesForInput;

        public FueledCar()
        {
            m_Vehicle = new Car();
        }

        public FueledCar(
            string i_Model,
            string i_LicenseNumber,
            Car.eCarColor i_CarColor,
            int i_NumOfDoors,
            float i_RemainingFuelLiters)
        {
            m_Vehicle = new Car(i_Model, i_LicenseNumber, wheels, new FuelTypedVehicle(k_FuelType, k_MaxFuelLiters, i_RemainingFuelLiters), i_CarColor, i_NumOfDoors);

            m_PropertiesForInput = new List<string>();
        }

        public List<string> GetPropertiesForInput()
        {
            return m_PropertiesForInput;
        }

        public void SetPropertiesFromInput(List<string> io_PropertiesFromUser)
        {
            m_Vehicle.SetPropertiesFromInput(io_PropertiesFromUser);
        }

        public string GetDetails()
        {
            return m_Vehicle.GetDetails();
        }
    }
}