using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    /// <summary>
    /// 
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
