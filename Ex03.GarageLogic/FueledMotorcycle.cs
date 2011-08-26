using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    /// <summary>
    /// 
    /// </summary>
    public class FueledMotorcycle : Motorcycle
    {
        private const float k_MaxFuelLiters = 6;
        private const FuelTypedVehicle.eFuelType k_FuelType = FuelTypedVehicle.eFuelType.Octan98;
        protected List<string> m_PropertiesForInput;

        public FueledMotorcycle():base(new FuelTypedVehicle())
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
