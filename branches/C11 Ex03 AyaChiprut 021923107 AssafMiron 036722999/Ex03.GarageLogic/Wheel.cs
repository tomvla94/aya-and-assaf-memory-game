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
    /// Wheel Class
    /// A Wheel has the following Properties:
    /// * Wheel Manufacturer
    /// * Wheel Air Pressure (Maximum defiened by Manufacturer and Current)
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
                throw new ValueOutOfRangeException("Max air pressure has to be possitive",
                    k_MinAirPressure, m_MaxAirPressureByManufacturer);
            }

            m_MaxAirPressureByManufacturer = i_MaxAirPressureByManufacturer;

            fillPropertiesForUser();
        }

        public void Inflate(float i_AirAmount)
        {
            if (checkAirPressureRange(i_AirAmount))
            {
                m_CurrentAirPressure = i_AirAmount;
            }
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

        private bool checkAirPressureRange(float i_AirPressure)
        {
            bool retAirPressureOK = false;
            if ((i_AirPressure < 0) || (i_AirPressure > m_MaxAirPressureByManufacturer))
            {
                throw new ValueOutOfRangeException("Air pressure is smaller or bigger than possible",
                    k_MinAirPressure, m_MaxAirPressureByManufacturer);
            }
            else
            {
                retAirPressureOK = true;
            }

            return retAirPressureOK;
        }

        private void fillPropertiesForUser()
        {
            m_PropertiesForInput = new List<string>();

            m_PropertiesForInput.Add("Wheel Manufacturer");
            m_PropertiesForInput.Add(string.Format("Current Wheel Air Pressure [Value between {0} and {1}]", k_MinAirPressure, MaxAirPressureByManufacturer));
        }

        internal List<string> GetPropertiesForInput()
        {
            return m_PropertiesForInput;
        }

        internal string GetDetails()
        {
            string retDetails = string.Format(
                "Wheel Manufacturer: {0}{2}Current Air Pressure: {1}{2}",
                m_Manufacturer,
                m_CurrentAirPressure,
                Environment.NewLine);

            return retDetails;
        }

        internal void SetPropertiesFromInput(string i_Manufacturer, string i_CurrentAirPressure)
        {
            m_Manufacturer = i_Manufacturer;
            float currAirPressure;
            if (float.TryParse(i_CurrentAirPressure, out currAirPressure))
            {
                try
                {
                    if (checkAirPressureRange(currAirPressure))
                    {
                        m_CurrentAirPressure = currAirPressure;
                    }
                }
                catch (ValueOutOfRangeException ex)
                {
                    m_CurrentAirPressure = 0;
                    throw ex;
                }
            }
        }
    }
}
