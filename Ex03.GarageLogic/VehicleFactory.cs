namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// The Vehicle Factory
    /// Here you can Create new vehicles
    /// </summary>
    public class VehicleFactory
    {
        public enum eVehicleType
        {
            FueledCar = 1,
            ElectricCar = 2,
            FueledMotorcycle = 3,
            ElectricMotorcycle = 4,
            FueledBus = 5,
        }

        public static Vehicle CreateVehicle(eVehicleType? i_VehicleType)
        {
            Vehicle vehicle = null;
            switch (i_VehicleType)
            {
                case eVehicleType.FueledCar: 
                {
                    vehicle = new FueledCar();
                    break;
                }

                case eVehicleType.ElectricCar:
                {
                    vehicle = new ElectricCar();
                    break;
                }

                case eVehicleType.FueledMotorcycle:
                {
                    vehicle = new FueledMotorcycle();
                    break;
                }

                case eVehicleType.ElectricMotorcycle:
                {
                    vehicle = new ElectricMotorcycle();
                    break;
                }

                case eVehicleType.FueledBus:
                {
                    vehicle = new FueledBus();
                    break;
                }
            }

            return vehicle;
        }
    }
}
