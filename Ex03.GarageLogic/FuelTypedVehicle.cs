namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Fueled Typed Vehicle Engine Class
    /// </summary>
    public class FuelTypedVehicle : Engine
    {
        public enum eFuelType
        { 
            Octan95 = 1,
            Octan96 = 2,
            Octan98 = 3,
            Soler = 4
        }

        private const string k_WrongFuelErrorFormat = "Wrong Fuel Type! The Engine can only accept {0}, and not {1}";
        private float m_CurrentFuelLitersAmount;
        private float m_MaxFuelLitersAmount;
        private eFuelType m_FuelType;

        public FuelTypedVehicle(eFuelType i_FuelType, float i_MaxFuelLitersAmount)
        {
            m_FuelType = i_FuelType;
            m_MaxFuelLitersAmount = i_MaxFuelLitersAmount;
            EngineType = eEngineType.Fuel;
            fillPropertiesForUser();
        }

        public eFuelType FuelType
        { 
            get { return m_FuelType; } 
        }

        public float MaxFuelLiters
        { 
            get { return m_MaxFuelLitersAmount; } 
        }

        public float CurrentFuelAmount
        { 
            get { return m_CurrentFuelLitersAmount; } 
        }

        /// <summary>
        /// Refuel the Vehicle
        /// </summary>
        /// <param name="i_Amount">Can not exeed the vehicles' Maximum Fuel Liters amount</param>
        /// <param name="i_FuelType">Must be the Same Fuel Type that the Vehicle Needs</param>
        public virtual void Refuel(float i_Amount, eFuelType i_FuelType)
        {
            if (i_FuelType != m_FuelType)
            {
                string wrongFuelErrMsg = string.Format(k_WrongFuelErrorFormat, m_FuelType, i_FuelType);
                throw new FormatException(wrongFuelErrMsg);
            }
            else if (i_Amount > m_MaxFuelLitersAmount || i_Amount <= 0)
            {
                throw new ValueOutOfRangeException(
                            "Amount of fuel is bigger or smaller than possible",
                            1, 
                            m_MaxFuelLitersAmount);
            }

            m_CurrentFuelLitersAmount = i_Amount;
        }

        public override float GetRemainingEnergyPrecentage()
        {
            return m_CurrentFuelLitersAmount / m_MaxFuelLitersAmount;
        }

        public override float GetRemianingEnergyAmount()
        {
            return m_CurrentFuelLitersAmount;
        }

        public override float GetMaximumEnergyAmount()
        {
            return m_MaxFuelLitersAmount;
        }

        private void fillPropertiesForUser()
        {
            m_PropertiesForInput = new List<string>();

            m_PropertiesForInput.Add("Current Fuel Amount (Liters)");
        }

        public override string GetDetails()
        {
            string retDetails = string.Format(
                "Engine Type: {0}{4}Fuel Type: {1}{4}Maximum Fuel Liters: {2}{4}Current Fuel Amount (Liters): {3}{4}", 
                eEngineType.Fuel.ToString(), 
                m_FuelType.ToString(), 
                m_MaxFuelLitersAmount.ToString(), 
                m_CurrentFuelLitersAmount.ToString(), 
                Environment.NewLine);

            return retDetails;   
        }

        public override List<string> GetPropertiesForInput()
        {
            return m_PropertiesForInput;
        }

        /// <summary>
        /// Sets the Fuel Engine Properties Recieved from the User
        /// </summary>
        /// <param name="i_PropertiesFromUser">Must be of Length 3</param>
        public override void SetPropertiesFromInput(List<string> i_PropertiesFromUser)
        {
            // Get First Parameter - The Remaining Amount of Fuel Liters
            bool tryParse = float.TryParse(i_PropertiesFromUser[0], out m_CurrentFuelLitersAmount);
            i_PropertiesFromUser.RemoveAt(0);

            if (!tryParse)
            {
                throw new FormatException("Remaining Fuel Liters must be a number.");
            }

            if (m_CurrentFuelLitersAmount > m_MaxFuelLitersAmount)
            {
                throw new ValueOutOfRangeException(
                            "Amount of fuel is bigger or smaller than possible",
                            1, 
                            m_MaxFuelLitersAmount);
            }
        }
    }
}
