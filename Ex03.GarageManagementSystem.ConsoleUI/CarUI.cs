using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageManagementSystem.ConsoleUI
{
    class CarUI : AbstractVehicleUI
    {
        public override string[] GetVehicleProperties()
        {
            return GarageLogic.Car.GetProperties();
        }

        public GarageLogic.Car CreateNewCar()
        { 
            return GarageLogic.Car
        }
    }
}
