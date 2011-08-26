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
        private Motorcycle m_Vehicle;
        private const float k_MaxBatteryHours = 1.8F;
        protected List<string> m_PropertiesForInput;

        public ElectricMotorcycle()
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
