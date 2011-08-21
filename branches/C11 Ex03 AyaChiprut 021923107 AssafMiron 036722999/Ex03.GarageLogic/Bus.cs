// -----------------------------------------------------------------------
// <copyright file="Bus.cs">
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
    public class Bus : Vehicle
    {
        public const int k_NumOfWheels = 8;
        public const float k_MaxAirPressure = 25;
        private int m_EngineSize;
        private int m_MaxAllowedAmountOfPassengers;
        private bool v_HasGuideSeat;

        protected Bus(
            string i_Model,
            string i_LicenseNumber,
            string i_WheelManufacturer,
            float i_WheelCurrentAirPressure,
            int i_MaxAllowedAmountOfPassengers,
            bool i_HasGuideSeat)
            : base(i_Model, i_LicenseNumber, k_NumOfWheels, i_WheelManufacturer, i_WheelCurrentAirPressure, k_MaxAirPressure)
        {
            m_MaxAllowedAmountOfPassengers = i_MaxAllowedAmountOfPassengers;
            v_HasGuideSeat = i_HasGuideSeat;
        }

        public int MaxAllowedAmountOfPassengers
        {
            get { return m_MaxAllowedAmountOfPassengers; }
        }

        public bool HasGuideSeat
        {
            get { return v_HasGuideSeat; }
        }
    }
}
