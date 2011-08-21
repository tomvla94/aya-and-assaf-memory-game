// -----------------------------------------------------------------------
// <copyright file="ElectricCar.cs">
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
    public sealed class ElectricCar : Car
    {
        private const float k_MaxBatteryHours = 2.5F;

        public ElectricCar(
            string i_Model,
            string i_LicenseNumber,
            string i_WheelManufacturer,
            float i_WheelCurrentAirPressure,
            Car.eCarColor i_CarColor,
            int i_NumOfDoors,
            float i_RemainingBatteryHours)
            : base(i_Model, i_LicenseNumber, i_WheelManufacturer, i_WheelCurrentAirPressure, i_CarColor, i_NumOfDoors)
        {
            m_Engine = new BatteryTypedVehicle(k_MaxBatteryHours, i_RemainingBatteryHours);
        }
    }
}
