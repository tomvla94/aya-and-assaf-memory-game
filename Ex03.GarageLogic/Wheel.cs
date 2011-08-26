// -----------------------------------------------------------------------
// <copyright file="Wheel.cs">
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
    public sealed class Wheel
    {
        private const int k_MinAirPressure = 0;
        private string m_Manufacturer;
        private float m_CurrentAirPressure;
        private float m_MaxAirPressureByManufacturer;
        private List<string> m_PropertiesForInput;

        public Wheel(string i_Manufacturer, float i_CurrentAirPressure, float i_MaxAirPressureByManufacturer)
        {
            m_Manufacturer = i_Manufacturer;
            if (i_MaxAirPressureByManufacturer <= k_MinAirPressure)
            {
                throw new ValueOutOfRangeException(i_MaxAirPressureByManufacturer, k_MinAirPressure);
            }

            m_MaxAirPressureByManufacturer = i_MaxAirPressureByManufacturer;
            Inflate(i_CurrentAirPressure);
        }

        public void Inflate(float i_AirAmount)
        {
            if ((i_AirAmount < 0) || (i_AirAmount > m_MaxAirPressureByManufacturer))
            {
                throw new ValueOutOfRangeException(k_MinAirPressure, m_MaxAirPressureByManufacturer);
            }

            m_CurrentAirPressure = i_AirAmount;
        }

        public float CurrentAirPressure
        {
            get { return m_CurrentAirPressure; }
        }

        public string Manufacturer
        {
            get { return m_Manufacturer; }
        }

        public float MaxAirPressureByManufacturer
        {
            get { return m_MaxAirPressureByManufacturer; }
        }

        public List<string> GetPropertiesForInput()
        {
            return m_PropertiesForInput;
        }

        internal List<Wheel> SetPropertiesFromInput(List<string> i_PropertiesFromUser)
        {
            throw new NotImplementedException();
        }

        public string GetDetails()
        {
            throw new NotImplementedException();
        }
    }
}
