// -----------------------------------------------------------------------
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

        protected Car(
            string i_Model,
            string i_LicenseNumber,
            List<Wheel> i_Wheels,
            eCarColor i_CarColor,
            int i_NumOfDoors,
            Engine i_Enginetype)
            : base(i_Model, i_LicenseNumber, k_NumOfWheels, i_Wheels)
        {
            m_Engine = i_Enginetype;
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

        public static override string[] GetProperties()
        {
            return new string[]{"NumOfDoors", "CarColor"};
        }

   
    }
}
