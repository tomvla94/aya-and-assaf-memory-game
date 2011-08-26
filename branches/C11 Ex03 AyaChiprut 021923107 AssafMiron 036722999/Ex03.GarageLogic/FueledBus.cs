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
        private Bus m_Vehicle;
        protected List<string> m_PropertiesForInput;

        public FueledBus()
            : base(new FuelTypedVehicle(k_FuelType, k_MaxFuelLiters))
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
