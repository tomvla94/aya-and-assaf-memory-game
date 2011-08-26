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

        public Wheel(float i_MaxAirPressureByManufacturer)
        {
            if (i_MaxAirPressureByManufacturer <= k_MinAirPressure)
            {
                throw new ValueOutOfRangeException(i_MaxAirPressureByManufacturer, k_MinAirPressure);
            }

            m_MaxAirPressureByManufacturer = i_MaxAirPressureByManufacturer;

            fillPropertiesForUser();
        }

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

        private void fillPropertiesForUser()
        {
            m_PropertiesForInput = new List<string>();

            m_PropertiesForInput.Add("Manufacturer");
            m_PropertiesForInput.Add("CurrentAirPressure");
        }

        internal List<string> GetPropertiesForInput()
        {
            return m_PropertiesForInput;
        }

        internal string GetDetails()
        {
            string retDetails = string.Format("Manufacturer: {0}{2}CurrentAirPressure: {1}{2}",
                                m_Manufacturer,
                                m_CurrentAirPressure,
                                Environment.NewLine);
            return retDetails;
        }

        internal void SetPropertiesFromInput(string i_Manufacturer, string i_CurrentAirPressure)
        {
            m_Manufacturer = i_Manufacturer;
            if (float.TryParse(i_CurrentAirPressure, out m_CurrentAirPressure))
            {
                Inflate(m_CurrentAirPressure);
            }
        }
    }
}
