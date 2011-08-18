using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class ElectricMotorcycle : Motorcycle
    {
        private const float k_MaxBatteryHours = 1.8F;

        public ElectricMotorcycle(
            string i_Model,
            string i_LicenseNumber,
            string i_WheelManufacturer,
            float i_WheelCurrentAirPressure,
            float i_RemainingBatteryHours,
            eLicenseType i_LicenseType)
            : base(i_Model, i_LicenseNumber, i_WheelManufacturer, i_WheelCurrentAirPressure, i_LicenseType)
        {
            m_Engine = new BatteryTypedVehicle(k_MaxBatteryHours, i_RemainingBatteryHours);
        }
    }
}
