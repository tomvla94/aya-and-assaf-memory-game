﻿// -----------------------------------------------------------------------
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

        public FueledCar(
            string i_Model,
            string i_LicenseNumber,
            string i_WheelManufacturer,
            float i_WheelCurrentAirPressure,
            Car.eCarColor i_CarColor,
            int i_NumOfDoors,
            float i_RemainingFuelLiters)
        {
            List<Wheel> wheels = new List<Wheel>(); // TODO: Complete Wheels List
            m_Vehicle = new Car(i_Model, i_LicenseNumber, wheels, new FuelTypedVehicle(k_FuelType, k_MaxFuelLiters, i_RemainingFuelLiters));

            m_PropertiesForInput = new List<string>();
        }

        public override List<string> GetPropertiesForInput()
        {
            return m_PropertiesForInput;
        }

        public override void SetPropertiesFromInput(List<string> i_PropertiesFromUser)
        {
            m_Vehicle.SetPropertiesFromInput(i_PropertiesFromUser);
        }

        public override string GetDetails()
        {
            return m_Vehicle.GetDetails();
        }
    }
}