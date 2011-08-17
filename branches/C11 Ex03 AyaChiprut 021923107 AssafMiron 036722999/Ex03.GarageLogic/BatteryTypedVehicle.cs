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
        private float m_BatteryTimeLegt;
        private float m_MaxBatteryTime;

        public virtual void Charge(float i_Time)
        { }
    }
}
