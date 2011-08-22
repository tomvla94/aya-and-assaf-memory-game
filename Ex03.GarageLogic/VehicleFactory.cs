using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class VehicleFactory
    {
        public enum eVehicleType
        {
            FueledCar = 1,
            ElectricCar = 2,
            FueledMotorcycle = 3,
            ElectricMotorcycle = 4,
            FueledBus = 5
        }

        public static Vehicle CreateVehicle(eVehicleType i_VehicleType)
        {
            Vehicle retVehicle = null;
            switch (i_VehicleType)
            {
                
            }

            return retVehicle;
        }
    }
}
