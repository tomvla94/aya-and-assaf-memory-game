namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// A Fueled Car
    /// Works on Octan 95 Fuel Type
    /// Has Maximum Fuel Liters of 45
    /// </summary>
    public class FueledCar : Car
    {
        private const float k_MaxFuelLiters = 45;
        private const FuelTypedVehicle.eFuelType k_FuelType = FuelTypedVehicle.eFuelType.Octan95;

        public FueledCar()
            : base(new FuelTypedVehicle(k_FuelType, k_MaxFuelLiters))
        {
        }
    }
}