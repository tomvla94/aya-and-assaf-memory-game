// -----------------------------------------------------------------------
// <copyright file="Motorcycle.cs">
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
    public class Motorcycle : Vehicle
    {
        public enum eLicenseType
        { 
            A,
            A1,
            A2,
            B
        }
        public const int k_NumOfWheels = 2;
        public const float k_MaxAirPressure = 31;
        private int m_EngineSize;
        private eLicenseType m_LicenseType;

        public Motorcycle(
            string i_Model,
            string i_LicenseNumber,
            string i_WheelManufacturer,
            float i_WheelManufacturerMaxAirPressure,
            eLicenseType i_LicenseType)
            : base(i_Model, i_LicenseNumber, k_NumOfWheels, i_WheelManufacturer, i_WheelManufacturerMaxAirPressure, k_MaxAirPressure)
        {
            m_LicenseType = i_LicenseType;
        }

        public eLicenseType LicenseType
        { 
            get { return m_LicenseType; } 
        }
    }
}
