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
        private eLicenseType m_LicenseType;

        public Motorcycle(Engine i_EngineType)
        {
            m_Engine = i_EngineType;

            // Create the Wheel for the Motorcycle and Add thier Properties For Input
            m_Wheels = new List<Wheel>(k_NumOfWheels);
            fillPropertiesForUser();
        }

        public Motorcycle(
            string i_Model,
            string i_LicenseNumber,
            List<Wheel> i_Wheels,
            Engine i_EngineType)
            : base(i_Model, i_LicenseNumber, k_NumOfWheels, i_Wheels)
        {
            m_Engine = i_EngineType;
            m_PropertiesForInput = new List<string>();

            string licenseType = "License Type [";
            Array eLicense = Enum.GetValues(typeof(eLicenseType));

            for (int i = 0; i < eLicense.Length; i++)
            {
                licenseType += eLicense.GetValue(i).ToString() + ", ";
            }

            licenseType += "\b\b]";

            m_PropertiesForInput.Add(licenseType);
        }

        public eLicenseType LicenseType
        { 
            get { return m_LicenseType; } 
        }

        private void fillPropertiesForUser()
        {
            for (int i = 0; i < k_NumOfWheels; i++)
            {
                m_Wheels.Add(new Wheel(k_MaxAirPressure));
                m_PropertiesForInput.AddRange(m_Wheels[i].GetPropertiesForInput());
            }

            // Add the Properties for the Motorcycle
            string licenseType = "License Type [";
            Array eLicense = Enum.GetValues(typeof(eLicenseType));

            for (int i = 0; i < eLicense.Length; i++)
            {
                licenseType += eLicense.GetValue(i).ToString() + ", ";
            }

            licenseType += "\b\b]";

            m_PropertiesForInput.Add(licenseType);
        }

        public override List<string> GetPropertiesForInput()
        {
            return m_PropertiesForInput;
        }

        public override void SetPropertiesFromInput(List<string> i_PropertiesFromUser)
        {
            // Set the Properties of the Base Vehicle
            base.SetPropertiesFromInput(i_PropertiesFromUser);

            // Get First Parameter - The License Type
            m_LicenseType = (eLicenseType)Enum.Parse(typeof(eLicenseType), i_PropertiesFromUser[0]);
            i_PropertiesFromUser.RemoveAt(0);
        }

        public override string GetDetails()
        {
            string retDetails = base.GetDetails();
            retDetails += string.Format(
                "License Type: {0}{2}", 
                m_LicenseType.ToString(), 
                Environment.NewLine);

            return retDetails;
        }
    }
}
