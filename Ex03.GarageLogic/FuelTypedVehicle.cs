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

        public FuelTypedVehicle(eFuelType i_FuelType, float i_MaxFuelLitersAmount, float i_CurrentFuelLitersAmount)
        {
            EngineType = eEngineType.Fuel;
            m_FuelType = i_FuelType;
            m_MaxFuelLitersAmount = i_MaxFuelLitersAmount;
            m_CurrentFuelLitersAmount = i_CurrentFuelLitersAmount;
        }

        public eFuelType FuelType
        { get { return m_FuelType; } }

        public float MaxFuelLiters
        { get { return m_MaxFuelLitersAmount; } }

        public float CurrentFuelAmount
        { get { return m_CurrentFuelLitersAmount; } }

        public virtual void Refuel(int i_Amount, eFuelType i_FuelType)
        {
            if (i_FuelType != m_FuelType)
            {
                string wrongFuelErrMsg = String.Format(k_WrongFuelErrorFormat, m_FuelType, i_FuelType);
                throw new ArgumentException(wrongFuelErrMsg);
            }
            else if (i_Amount + m_CurrentFuelLitersAmount > m_MaxFuelLitersAmount)
            {
                throw new ValueOutOfRangeException(m_MaxFuelLitersAmount,float.MinValue);
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
    }
}
