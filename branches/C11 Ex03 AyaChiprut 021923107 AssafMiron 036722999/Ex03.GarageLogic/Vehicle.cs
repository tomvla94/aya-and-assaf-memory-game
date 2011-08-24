// -----------------------------------------------------------------------
// <copyright file="Vehicle.cs">
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
    public abstract class Vehicle
    {
        public const int k_MinNumOfWheels = 2;
        private string m_Model;
        private string m_LicenseNumber;
        private List<Wheel> m_Wheels;
        protected Engine m_Engine;

        protected Vehicle(
            string i_Model,
            string i_LicenseNumber,
            int i_NumOfWeels,
            List<Wheel> i_Wheels)
        {
            m_Model = i_Model;
            m_LicenseNumber = i_LicenseNumber;
            if (i_NumOfWeels <= k_MinNumOfWheels)
            {
                throw new ValueOutOfRangeException(k_MinNumOfWheels, float.MaxValue);
            }

            m_Wheels = i_Wheels;
        }

        public string Model
        {
            get { return m_Model; }
        }

        public string LicenseNumber
        {
            get { return m_LicenseNumber; }
        }

        public List<Wheel> Wheels
        {
            get { return m_Wheels; }
        }

        public float getRemainingEnergyPrecentage()
        {
            return m_Engine.GetRemainingEnergyPrecentage();
        }

        public Engine.eEngineType getEngineType()
        {
            return m_Engine.EngineType;
        }

        public void InflateWheelsToMax()
        {
            foreach (Wheel wheel in m_Wheels)
            {
                wheel.Inflate(wheel.MaxAirPressureByManufacturer);
            }
        }

        public static abstract string[] GetProperties();
    }
}
