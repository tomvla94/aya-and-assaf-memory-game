// -----------------------------------------------------------------------
// <copyright file="FueledMotorcycle.cs">
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
    public class FueledMotorcycle : Motorcycle
    {
        private const float k_MaxFuelLiters = 6;
        private const FuelTypedVehicle.eFuelType k_FuelType = FuelTypedVehicle.eFuelType.Octan98;

        public FueledMotorcycle(
            string i_Model,
            string i_LicenseNumber,
            string i_WheelManufacturer,
            float i_WheelCurrentAirPressure,
            float i_RemainingFuelLiters,
            eLicenseType i_LicenseType) : base(i_Model, i_LicenseNumber, i_WheelManufacturer, i_WheelCurrentAirPressure, i_LicenseType)
        {
            m_Engine = new FuelTypedVehicle(k_FuelType, k_MaxFuelLiters, i_RemainingFuelLiters);
        }
    }
}
