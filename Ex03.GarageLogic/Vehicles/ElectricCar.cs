using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    /// <summary>
    /// An Electric Car
    /// Can Work 2.5 Hours (Maximum Battery Hours)
    /// </summary>
    public class ElectricCar : Car
    {
        private const float k_MaxBatteryHours = 2.5F;

        public ElectricCar()
            : base(new BatteryTypedVehicle(k_MaxBatteryHours))
        {
        }
    }
}
