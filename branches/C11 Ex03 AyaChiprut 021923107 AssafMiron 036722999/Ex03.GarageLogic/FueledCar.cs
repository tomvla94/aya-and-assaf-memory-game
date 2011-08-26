-﻿// -----------------------------------------------------------------------
// <copyright file="FueledCar.cs">
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
    public class FueledCar : Car
    {
        private Car m_Vehicle;
        private const float k_MaxFuelLiters = 45;
        private const FuelTypedVehicle.eFuelType k_FuelType = FuelTypedVehicle.eFuelType.Octan95;
        protected List<string> m_PropertiesForInput;

        public FueledCar()
            : base(new FuelTypedVehicle())
        {
        }

        public virtual List<string> GetPropertiesForInput()
        {
            return m_PropertiesForInput;
        }

        public void SetPropertiesFromInput(List<string> i_PropertiesFromUser)
        {
            base.SetPropertiesFromInput(i_PropertiesFromUser);
        }

        public virtual string GetDetails()
        {
            return base.GetDetails();
        }
    }
}