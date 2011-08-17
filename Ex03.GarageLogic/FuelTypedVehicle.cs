// -----------------------------------------------------------------------
// <copyright file="FuelTypedVehicle.cs">
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
    public class FuelTypedVehicle : Engine
    {
        public enum eFuelType
        { 
            Octan95,
            Octan96,
            Octan98,
            Soler
        }

        private float m_CurrentFuelAmount;
        private float m_MaxFuelAmount;

        public virtual void Refuel(int i_Amount)
        { }
    }
}
