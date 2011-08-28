using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    /// <summary>
    /// An Electric Motorcycle
    /// Can Work 1.8 Hours (Maximum Battery Hours)
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
