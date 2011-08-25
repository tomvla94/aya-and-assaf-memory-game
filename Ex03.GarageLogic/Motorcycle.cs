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
    public sealed class Motorcycle : Vehicle
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
            List<Wheel> i_Wheels,
            Engine i_EngineType)
            : base(i_Model, i_LicenseNumber, k_NumOfWheels, i_Wheels)
        {
            m_Engine = i_EngineType;
            m_PropertiesForInput = new List<string>();

            m_PropertiesForInput.Add("License Type");
        }

        public Motorcycle(
            string i_Model,
            string i_LicenseNumber,
            List<Wheel> i_Wheels,
            eLicenseType i_LicenseType)
            : base(i_Model, i_LicenseNumber, k_NumOfWheels, i_Wheels)
        {
            m_LicenseType = i_LicenseType;
        }

        public eLicenseType LicenseType
        { 
            get { return m_LicenseType; } 
        }

        public override List<string> GetPropertiesForInput()
        {
            return m_PropertiesForInput;
        }

        public override void SetPropertiesFromInput(List<string> i_PropertiesFromUser)
        {
            // Get First Parameter - The License Type
            m_LicenseType = (eLicenseType)Enum.Parse(typeof(eLicenseType), i_PropertiesFromUser[0]);
            i_PropertiesFromUser.RemoveAt(0);
        }

        public override string GetDetails()
        {
            string retDetails = string.Format("License Tyoe: {0}{2}"
                          , m_LicenseType.ToString(), Environment.NewLine);

            return retDetails;
        }
    }
}
