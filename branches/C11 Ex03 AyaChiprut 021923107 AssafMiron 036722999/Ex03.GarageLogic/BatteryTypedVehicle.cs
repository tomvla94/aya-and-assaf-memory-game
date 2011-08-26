// -----------------------------------------------------------------------
// <copyright file="BattaryTypedVehicle.cs">
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
    public class BatteryTypedVehicle : Engine
    {
        private const float k_MinBatteryCharge = 0;
        private float m_RemainingBatteryHours;
        private float m_MaxBatteryHours;

        public BatteryTypedVehicle(float i_MaxBatteryHours)
        {
            EngineType = eEngineType.Battery;
            if (i_MaxBatteryHours <= k_MinBatteryCharge)
            {
                throw new ValueOutOfRangeException(k_MinBatteryCharge, float.MaxValue);
            }

            m_MaxBatteryHours = i_MaxBatteryHours;

            fillPropertiesForUser();
        }

        public virtual void Charge(float i_HoursToCharge)
        {
            if (i_HoursToCharge + m_RemainingBatteryHours > m_MaxBatteryHours)
            {
                throw new ValueOutOfRangeException(m_RemainingBatteryHours, m_MaxBatteryHours);
            }

            m_RemainingBatteryHours += i_HoursToCharge;
        }

        public float MaxBatteryHours
        {
            get { return m_MaxBatteryHours; }
        }

        public float RemainingBatteryHours
        {
            get { return m_RemainingBatteryHours; }
        }

        public override float GetRemainingEnergyPrecentage()
        {
            return m_RemainingBatteryHours / m_MaxBatteryHours;
        }

        private void fillPropertiesForUser()
        {
            m_PropertiesForInput = new List<string>();

            m_PropertiesForInput.Add("Maximum Battery Hours");
            m_PropertiesForInput.Add("Remiaing Battery Hours");
        }

        public override string GetDetails()
        {
            string retDetails = string.Format(
                "Engine Type: {0}{3}"
                + "Maximum Battery Hours: {1}{3}"
                + "Remaining Battery Hours: {2}{3}", 
                eEngineType.Battery.ToString(), 
                m_MaxBatteryHours.ToString(), 
                m_RemainingBatteryHours.ToString(), 
                Environment.NewLine);

            return retDetails;   
        }

        public override List<string> GetPropertiesForInput()
        {
            return m_PropertiesForInput;
        }

        public override void SetPropertiesFromInput(List<string> i_PropertiesFromUser)
        {
            // Get First Parameter - The Maximum Battery Hours
            bool tryParse = float.TryParse(i_PropertiesFromUser[0], out m_MaxBatteryHours);
            i_PropertiesFromUser.RemoveAt(0);

            // Get Second Parameter - The Remaining Battery Hours
            tryParse = float.TryParse(i_PropertiesFromUser[0], out m_RemainingBatteryHours);
            i_PropertiesFromUser.RemoveAt(0);

            if(m_RemainingBatteryHours < k_MinBatteryCharge || m_RemainingBatteryHours > m_MaxBatteryHours)
            {
                throw new ValueOutOfRangeException(k_MinBatteryCharge, m_MaxBatteryHours);
            }
        }
    }
}
