﻿// -----------------------------------------------------------------------
// <copyright file="Car.cs">
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
    public sealed class Car : Vehicle
    {
        public enum eCarColor
        {
            Black,
            White,
            Silver,
            Blue,
            Azure
        }

        public const int k_NumOfWheels = 4;
        public const float k_MaxAirPressure = 29;
        public const int k_MinNumOfDoors = 2;
        
        private int m_NumOfDoors;
        private eCarColor m_CarColor;

        public Car(
            string i_Model,
            string i_LicenseNumber,
            List<Wheel> i_Wheels,
            Engine i_EngineType)
            : base(i_Model, i_LicenseNumber, k_NumOfWheels, i_Wheels)
        {
            m_Engine = i_EngineType;
            m_PropertiesForInput = new List<string>();

            string colors;
            colors = "Color [";

            Array eColors = Enum.GetValues(typeof(eCarColor));

            for (int i = 0; i < eColors.Length; i++)
            {
                colors += eColors.GetValue(i).ToString() + ",";
            }
            colors += "\b]";

            m_PropertiesForInput.Add(colors);
            m_PropertiesForInput.Add("Doors Number");
        }

        public Car(
            string i_Model,
            string i_LicenseNumber,
            List<Wheel> i_Wheels,
            eCarColor i_CarColor,
            int i_NumOfDoors,
            Engine i_EngineType)
            : base(i_Model, i_LicenseNumber, k_NumOfWheels, i_Wheels)
        {
            
            m_Engine = i_EngineType;
            m_CarColor = i_CarColor;
            if (i_NumOfDoors < k_MinNumOfDoors)
            {
                throw new ValueOutOfRangeException(k_MinNumOfDoors, float.MaxValue);
            }

            m_NumOfDoors = i_NumOfDoors;
        }

        public eCarColor CarColor
        {
            get { return m_CarColor; }
        }

        public int NumOfDoors
        {
            get { return m_NumOfDoors; }
        }

        public override List<string> GetPropertiesForInput()
        {
            return m_PropertiesForInput;
        }

        public override void SetPropertiesFromInput(List<string> i_PropertiesFromUser)
        {
            // Get First Parameter - The Car Color
            m_CarColor = (eCarColor)Enum.Parse(typeof(eCarColor), i_PropertiesFromUser[0]);
            i_PropertiesFromUser.RemoveAt(0);

            // Get Second Parameter - The Number of Doors
            bool tryParse = int.TryParse(i_PropertiesFromUser[0], out m_NumOfDoors);
            i_PropertiesFromUser.RemoveAt(0);
        }

        public override string GetDetails()
        {
            string retDetails = base.GetDetails();
            retDetails = m_Engine.GetDetails();
            retDetails += string.Format("Color: {0}{3}"
                         + "Number of Doors: {1}{3}"
                          , m_CarColor.ToString(), m_NumOfDoors, Environment.NewLine);

            return retDetails;
        }
    }
}
