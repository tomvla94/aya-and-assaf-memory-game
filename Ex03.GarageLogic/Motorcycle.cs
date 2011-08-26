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

        public Motorcycle(Engine i_EngineType)
        {
            m_Engine = i_EngineType;

            // Create the Wheel for the Motorcycle and Add thier Properties For Input
            m_Wheels = new List<Wheel>(k_NumOfWheels);
            for (int i = 0; i < k_NumOfWheels; i++)
            {
                m_Wheels[i] = new Wheel(k_MaxAirPressure);
                foreach (string wheelProp in m_Wheels[i].GetPropertiesForInput())
                {
                    m_PropertiesForInput.Add(wheelProp);
                }
            }

            // Add the Properties for the Motorcycle
            m_PropertiesForInput.Add("License Type");
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

        public override void SetPropertiesFromInput(List<string> io_PropertiesFromUser)
        {
            // Set the Properties of the Base Vehicle
            base.SetPropertiesFromInput(io_PropertiesFromUser);

            // Get First Parameter - The License Type
            m_LicenseType = (eLicenseType)Enum.Parse(typeof(eLicenseType), io_PropertiesFromUser[0]);
            io_PropertiesFromUser.RemoveAt(0);
        }

        public override string GetDetails()
        {
            string retDetails = base.GetDetails();
            retDetails += string.Format("License Type: {0}{2}", 
                                m_LicenseType.ToString(), 
                                Environment.NewLine);

            return retDetails;
        }
    }
}
