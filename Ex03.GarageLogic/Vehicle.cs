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
        protected List<Wheel> m_Wheels;
        protected Engine m_Engine;
        protected List<string> m_PropertiesForInput;

        protected Vehicle()
        {
            m_PropertiesForInput = new List<string>();

            m_PropertiesForInput.Add("Model");
            m_PropertiesForInput.Add("License Number");
        }

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

        public Engine Engine
        {
            get { return m_Engine; }
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

        public override int GetHashCode()
        {
            return m_LicenseNumber.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            bool found = false;
            Vehicle vehicleToCompare = obj as Vehicle;
            if (vehicleToCompare != null)
            {
                found = this.m_LicenseNumber == vehicleToCompare.LicenseNumber;
            }

            return found;
        }

        public virtual List<string> GetPropertiesForInput()
        {
            return m_PropertiesForInput;
        }

        public virtual void SetPropertiesFromInput(List<string> i_PropertiesFromUser)
        {
            // Get First Parameter - The Vehicle Model
            m_Model = i_PropertiesFromUser[0];
            i_PropertiesFromUser.RemoveAt(0);

            // Get Second Parameter - The Vehicle License Number
            m_LicenseNumber = i_PropertiesFromUser[0];
            i_PropertiesFromUser.RemoveAt(0);

            // Get Third Parameter - The Vehicle Wheels List
            foreach (Wheel wheel in m_Wheels)
            {
                wheel.SetPropertiesFromInput(i_PropertiesFromUser[0], i_PropertiesFromUser[1]);
                i_PropertiesFromUser.RemoveAt(0);
                i_PropertiesFromUser.RemoveAt(0);
            }
        }

        public virtual string GetDetails()
        {
            string wheelsDetails = string.Empty;
            for (int i = 0; i < m_Wheels.Count; i++)
            {
                wheelsDetails += string.Format(
                    "Wheel No. {0}{1}"
                    + m_Wheels[i].GetDetails(),
                    i,
                    Environment.NewLine);
            }

            string retDetails = string.Format(
                "Model: {0}{3}"
                + "License Number: {1}{3}"
                + "Wheels List: {3}{2}",
                m_Model, 
                m_LicenseNumber,
                wheelsDetails,
                Environment.NewLine);

            return retDetails;
        }
    }
}
