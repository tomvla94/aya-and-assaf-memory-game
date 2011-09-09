namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Abstract Motorcycle Class
    /// A Motorcycle has the following Properties:
    /// * 2 Wheels with Maximum Air Pressure of 31
    /// * License Type (A, A1, A2, B)
    /// </summary>
    public abstract class Motorcycle : Vehicle
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

        /// <summary>
        /// Basic Motorcycle Constructor
        /// </summary>
        /// <param name="i_EngineType"></param>
        public Motorcycle(Engine i_EngineType)
        {
            m_Engine = i_EngineType;

            // Create the Wheel for the Motorcycle and Add thier Properties For Input
            m_Wheels = new List<Wheel>(k_NumOfWheels);
            fillPropertiesForUser();
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

            // Add the Properties for the Energy Type of the Car
            m_PropertiesForInput.AddRange(m_Engine.GetPropertiesForInput());

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

        /// <summary>
        /// Sets the Motorcycle Properties Recieved from the User
        /// </summary>
        /// <param name="i_PropertiesFromUser">Must be of Length 5</param>
        public override void SetPropertiesFromInput(List<string> i_PropertiesFromUser)
        {
            // Set the Properties of the Base Vehicle
            base.SetPropertiesFromInput(i_PropertiesFromUser);

            // Set the Properties for the Engine
            m_Engine.SetPropertiesFromInput(i_PropertiesFromUser);

            // Get First Parameter - The License Type
            string licenseTypeInTheRightFormat = getLicensTypeRightFormat(i_PropertiesFromUser[0]);
            m_LicenseType = (eLicenseType)Enum.Parse(typeof(eLicenseType), licenseTypeInTheRightFormat);
            i_PropertiesFromUser.RemoveAt(0);
        }

        private string getLicensTypeRightFormat(string i_LicenseType)
        {
            string licenseTypeInTheRightFormat = string.Format(
                "{0}{1}",
                i_LicenseType[0].ToString().ToUpper(), 
                i_LicenseType.Remove(0, 1));

            return licenseTypeInTheRightFormat;
        }

        public override string GetDetails()
        {
            string retDetails = base.GetDetails();
            retDetails += string.Format(
                "{0}License Type: {1}{2}",
                m_Engine.GetDetails(),
                m_LicenseType.ToString(), 
                Environment.NewLine);

            return retDetails;
        }
    }
}
