using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    /// <summary>
    /// 
    /// </summary>
    public class ElectricCar : Car
    {
        private const float k_MaxBatteryHours = 2.5F;
        private Car m_Vehicle;
        protected List<string> m_PropertiesForInput;

        public ElectricCar()
            : base(new BatteryTypedVehicle(k_MaxBatteryHours))
        {
        }

        public virtual List<string> GetPropertiesForInput()
        {
            return m_PropertiesForInput;
        }

        public virtual void SetPropertiesFromInput(List<string> i_PropertiesFromUser)
        {
            base.SetPropertiesFromInput(i_PropertiesFromUser);
        }

        public virtual string GetDetails()
        {
            return base.GetDetails();
        }
    }
}
