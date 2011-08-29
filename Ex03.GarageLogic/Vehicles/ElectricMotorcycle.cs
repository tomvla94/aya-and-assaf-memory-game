using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    /// <summary>
    /// 
    /// </summary>
    public class ElectricMotorcycle : Motorcycle
    {
        private const float k_MaxBatteryHours = 1.8F;

        public ElectricMotorcycle()
            : base(new BatteryTypedVehicle(k_MaxBatteryHours))
        {
        }
    }
}
