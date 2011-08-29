using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    /// <summary>
    /// A Fueled Motorcycle
    /// Works on Octan 98 Fuel Type
    /// Has Maximum Fuel Liters of 6
    /// </summary>
    public class FueledMotorcycle : Motorcycle
    {
        private const float k_MaxFuelLiters = 6;
        private const FuelTypedVehicle.eFuelType k_FuelType = FuelTypedVehicle.eFuelType.Octan98;

        public FueledMotorcycle()
            : base(new FuelTypedVehicle(k_FuelType, k_MaxFuelLiters))
        {
        }
    }
}
