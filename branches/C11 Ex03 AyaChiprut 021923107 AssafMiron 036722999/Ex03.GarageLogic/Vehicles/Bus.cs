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
    /// Abstract Bus Class
    /// A Bus has the following Properties:
    /// * 8 Wheels with Maximum air pressure of 25
    /// * Maximum Passengers Allowed on the Bus
    /// * Guide Seat (With or Without)
    /// </summary>
    public abstract class Bus : Vehicle
    {
        public const int k_NumOfWheels = 8;
        public const float k_MaxAirPressure = 25;
        private int m_MaxAllowedAmountOfPassengers;
        private bool v_HasGuideSeat;

        /// <summary>
        /// Basic Bus Constructor
        /// </summary>
        /// <param name="i_EngineType"></param>
        public Bus(Engine i_EngineType)
        {
            m_Engine = i_EngineType;
            m_Wheels = new List<Wheel>(k_NumOfWheels);
            fillPropertiesForUser();
        }

        /// <summary>
        /// Complex Constructor
        /// </summary>
        /// <param name="i_Model"></param>
        /// <param name="i_LicenseNumber"></param>
        /// <param name="i_Wheels">List must be with 8 Wheels</param>
        /// <param name="i_MaxAllowedAmountOfPassengers">Only possitive Numbers</param>
        /// <param name="i_HasGuideSeat"></param>
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
            m_PropertiesForInput.Add("Has Guide Seat [True / False]");
        }

        public override List<string> GetPropertiesForInput()
        {
            return m_PropertiesForInput;
        }

        /// <summary>
        /// Sets the Bus Properties Recieved from the User
        /// </summary>
        /// <param name="i_PropertiesFromUser">Must be of Length 12</param>
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
                "{3}Maximum Allowed Passengers: {0}{2}The Bus Has a Guide Seat: {1}{2}",
                m_MaxAllowedAmountOfPassengers.ToString(),
                v_HasGuideSeat.ToString(),
                Environment.NewLine,
                m_Engine.GetDetails());

            return retDetails;
        }
    }
}
