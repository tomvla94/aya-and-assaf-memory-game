// -----------------------------------------------------------------------
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
    class FueledCar : Car
    {
        private const float k_MaxFuelLiters = 45;
        private const FuelTypedVehicle.eFuelType k_FuelType = FuelTypedVehicle.eFuelType.Octan95;

        public FueledCar(
            string i_Model,
            string i_LicenseNumber,
            string i_WheelManufacturer,
            float i_WheelCurrentAirPressure,
            Car.eCarColor i_CarColor,
            int i_NumOfDoors,
            float i_RemainingFuelLiters)
            : base(i_Model, i_LicenseNumber, i_WheelManufacturer, i_WheelCurrentAirPressure, i_CarColor, i_NumOfDoors)
        {
            m_Engine = new FuelTypedVehicle(k_FuelType, k_MaxFuelLiters, i_RemainingFuelLiters);
        }
    }
}
