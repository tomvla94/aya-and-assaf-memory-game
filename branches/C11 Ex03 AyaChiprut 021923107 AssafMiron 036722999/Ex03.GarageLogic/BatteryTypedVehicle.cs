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

        public virtual void Charge(float i_HoursToCharge)
        {
            if (i_HoursToCharge + m_RemainingBatteryHours > m_MaxBatteryHours)
            {
                throw new ValueOutOfRangeException(m_RemainingBatteryHours, m_MaxBatteryHours);
            }

            m_RemainingBatteryHours += i_HoursToCharge;
        }

        public BatteryTypedVehicle(float i_MaxBatteryHours, float i_RemainingBatteryHours)
        {
            EngineType = eEngineType.Battery;
            if ((i_MaxBatteryHours <= k_MinBatteryCharge) ||
                    (i_RemainingBatteryHours < k_MinBatteryCharge))
            {
                throw new ValueOutOfRangeException(k_MinBatteryCharge, float.MaxValue);
            }

            m_MaxBatteryHours = i_MaxBatteryHours;
            m_RemainingBatteryHours = i_RemainingBatteryHours;
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
    }
}
