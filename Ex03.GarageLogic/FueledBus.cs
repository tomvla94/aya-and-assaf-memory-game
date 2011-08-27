using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    /// <summary>
    /// 
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
