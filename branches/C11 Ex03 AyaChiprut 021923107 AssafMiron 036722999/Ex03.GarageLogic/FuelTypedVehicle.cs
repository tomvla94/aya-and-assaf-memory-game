// -----------------------------------------------------------------------
// <copyright file="FuelTypedVehicle.cs">
// Aya Chiprut 021923107 
// Assaf Miron 036722999
// </copyright>
// -----------------------------------------------------------------------

namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class FuelTypedVehicle : Engine
    {
        public enum eFuelType
        { 
            Octan95,
            Octan96,
            Octan98,
            Soler
        }

        private const string k_WrongFuelErrorFormat = "Wrong Fuel Type! The Engine can only accept {0}, and not {1}";
        private float m_CurrentFuelLitersAmount;
        private float m_MaxFuelLitersAmount;
        private eFuelType m_FuelType;

        public FuelTypedVehicle()
        {
            m_PropertiesForInput = new List<string>();

            m_PropertiesForInput.Add("Fuel Type");
            m_PropertiesForInput.Add("Maximum Fuel Liters");
            m_PropertiesForInput.Add("Current Fuel Amount (Liters)");
        }

        public FuelTypedVehicle(eFuelType i_FuelType, float i_MaxFuelLitersAmount, float i_CurrentFuelLitersAmount)
        {
            EngineType = eEngineType.Fuel;
            m_FuelType = i_FuelType;
            m_MaxFuelLitersAmount = i_MaxFuelLitersAmount;
            m_CurrentFuelLitersAmount = i_CurrentFuelLitersAmount;
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

        public virtual void Refuel(int i_Amount, eFuelType i_FuelType)
        {
            if (i_FuelType != m_FuelType)
            {
                string wrongFuelErrMsg = string.Format(k_WrongFuelErrorFormat, m_FuelType, i_FuelType);
                throw new ArgumentException(wrongFuelErrMsg);
            }
            else if (i_Amount + m_CurrentFuelLitersAmount > m_MaxFuelLitersAmount)
            {
                throw new ValueOutOfRangeException(m_MaxFuelLitersAmount, float.MinValue);
            }

            m_CurrentFuelLitersAmount += i_Amount;
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

        public override string GetDetails()
        {
            string retDetails = string.Format("Engine Type: {0}{4}"
                                       + "Fuel Type: {1}{4}"
                                       + "Maximum Fuel Liters: {2}{4}"
                                       + "Current Fuel Amount (Liters): {3}{4}", 
                                       eEngineType.Battery.ToString(), 
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

        public override void SetPropertiesFromInput(List<string> i_PropertiesFromUser)
        {
            // Get First Parameter - The Fuel Type
            m_FuelType = (eFuelType)Enum.Parse(typeof(eFuelType), i_PropertiesFromUser[0]);

            // Get Second Parameter - The Maximun Amount of Liters
            bool tryParse = float.TryParse(i_PropertiesFromUser[0], out m_MaxFuelLitersAmount);
            i_PropertiesFromUser.RemoveAt(0);

            // Get third Parameter - The Remaining Amount of Fuel Liters
            tryParse = float.TryParse(i_PropertiesFromUser[0], out m_CurrentFuelLitersAmount);
            i_PropertiesFromUser.RemoveAt(0);
        }
    }
}
