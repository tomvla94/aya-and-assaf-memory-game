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
        private int m_MaxAllowedAmountOfPassengers;
        private bool v_HasGuideSeat;

        public Bus(Engine i_EngineType)
        {
            m_Engine = i_EngineType;
            m_Wheels = new List<Wheel>(k_NumOfWheels);
            fillPropertiesForUser();
        }

        public Bus(
            string i_Model,
            string i_LicenseNumber,
            List<Wheel> i_Wheels,
            int i_MaxAllowedAmountOfPassengers,
            bool i_HasGuideSeat)
            : base(i_Model, i_LicenseNumber, k_NumOfWheels, i_Wheels)
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

        private void fillPropertiesForUser()
        {
            for (int i = 0; i < k_NumOfWheels; i++)
            {
                m_Wheels.Add(new Wheel(k_MaxAirPressure));
                m_PropertiesForInput.AddRange(m_Wheels[i].GetPropertiesForInput());
            }

            // Add the Properties for the Bus
            m_PropertiesForInput.Add("Maximum Allowed Number of Passengers");
            m_PropertiesForInput.Add("Has Guide Seat [Yes (Y) / No (N)]");
        }

        public override List<string> GetPropertiesForInput()
        {
            return m_PropertiesForInput;
        }

        public override void SetPropertiesFromInput(List<string> i_PropertiesFromUser)
        {
            // Set the Properties of the Base Vehicle
            base.SetPropertiesFromInput(i_PropertiesFromUser);

            // Get First Parameter - The Number of Allowed Passengers
            bool tryParse = int.TryParse(i_PropertiesFromUser[0], out m_MaxAllowedAmountOfPassengers);
            i_PropertiesFromUser.RemoveAt(0);

            // Get Second Parameter - If the Bus has a Guid seat or not
            v_HasGuideSeat = bool.Parse(i_PropertiesFromUser[0]);
            i_PropertiesFromUser.RemoveAt(0);
        }

        public override string GetDetails()
        {
            string retDetails = base.GetDetails();
            retDetails += string.Format(
                "Maximum Allowed Passengers: {0}{3}"
                + "The Bus Has a Guide Seat: {1}{3}",
                m_MaxAllowedAmountOfPassengers.ToString(),
                v_HasGuideSeat.ToString(),
                Environment.NewLine);

            return retDetails;
        }
    }
}
