using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageManagementSystem.ConsoleUI
{
    public class VehicleFactory
    {
        private AbstractVehicleUI m_VehicleUI;
        public enum eVehicleType
        {
            FueledCar = 1,
            ElectricCar = 2,
            FueledMotorcycle = 3,
            ElectricMotorcycle = 4,
            FueledBus = 5
        }

        public void CreateVehicle(eVehicleType i_VehicleType)
        {
            switch (i_VehicleType)
            {
                case eVehicleType.FueledCar: 
                    {
                        m_VehicleUI = new CarUI();
                        break;
                    }
            }
            
            m_VehicleUI.GetVehicleProperties();
        }
    }
}
