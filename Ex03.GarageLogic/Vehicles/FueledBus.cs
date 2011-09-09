namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// A Fueled Bus
    /// Works on Soler Fuel Type
    /// Has Maximum Fuel Liters of 200
    /// </summary>
    public class FueledBus : Bus
    {
        private const float k_MaxFuelLiters = 200;
        private const FuelTypedVehicle.eFuelType k_FuelType = FuelTypedVehicle.eFuelType.Soler;

        public FueledBus()
           : base(new FuelTypedVehicle(k_FuelType, k_MaxFuelLiters))
        {
        }
    }
}
