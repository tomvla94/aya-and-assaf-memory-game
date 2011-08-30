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
    /// Abstract Car Class
    /// A Car has the following Properties:
    /// * 4 Wheels with Maximum Air Pressure of 29
    /// * Number of Doors (Minimum 2, Maximum 5)
    /// * Car Color (Black, White, Silver, Blue, Azure)
    /// </summary>
    public abstract class Car : Vehicle
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
        public const int k_MaxNumOfDoors = 5;
        
        private int m_NumOfDoors;
        private eCarColor m_CarColor;

        /// <summary>
        /// Basic Car Contructor
        /// </summary>
        /// <param name="i_EngineType"></param>
        public Car(Engine i_EngineType)
        {
            m_Engine = i_EngineType;

            // Create the Wheel for the Car and Add thier Properties For Input
            m_Wheels = new List<Wheel>(k_NumOfWheels);

            fillPropertiesForUser();
        }

        public eCarColor CarColor
        {
            get { return m_CarColor; }
        }

        public int NumOfDoors
        {
            get { return m_NumOfDoors; }
        }

        private void fillPropertiesForUser()
        {
            for (int i = 0; i < k_NumOfWheels; i++)
            {
                m_Wheels.Add(new Wheel(k_MaxAirPressure));
                m_PropertiesForInput.AddRange(m_Wheels[i].GetPropertiesForInput());
            }

            // Add the Properties for the Car
            string colors;
            colors = "Car Color [";

            Array eColors = Enum.GetValues(typeof(eCarColor));

            for (int i = 0; i < eColors.Length; i++)
            {
                colors += eColors.GetValue(i).ToString() + ", ";
            }

            colors += "\b\b]";

            m_PropertiesForInput.Add(colors);
            m_PropertiesForInput.Add(string.Format("Number of Doors [Value between {0} and {1}]", k_MinNumOfDoors, k_MaxNumOfDoors));
        }

        public override List<string> GetPropertiesForInput()
        {
            return m_PropertiesForInput;
        }

        /// <summary>
        /// Sets the Car Properties Recieved from the User
        /// </summary>
        /// <param name="i_PropertiesFromUser">Must be of Length 8</param>
        public override void SetPropertiesFromInput(List<string> i_PropertiesFromUser)
        {
            // Set the Properties of the Base Vehicle
            base.SetPropertiesFromInput(i_PropertiesFromUser);

            // Get First Parameter - The Car Color
            string colorInTheRightFormat = getColorRightFormat(i_PropertiesFromUser[0]);
            m_CarColor = (eCarColor)Enum.Parse(typeof(eCarColor), colorInTheRightFormat);
            i_PropertiesFromUser.RemoveAt(0);

            // Get Second Parameter - The Number of Doors
            bool tryParse = int.TryParse(i_PropertiesFromUser[0], out m_NumOfDoors);
            i_PropertiesFromUser.RemoveAt(0);

            if (m_NumOfDoors < k_MinNumOfDoors || m_NumOfDoors > k_MaxNumOfDoors)
            {
                throw new ValueOutOfRangeException("Number of doors is smaller or bigger than possible",
                    k_MinNumOfDoors, k_MaxNumOfDoors);
            }
        }

        private string getColorRightFormat(string i_Color)
        {
            string colorInTheRightFormat;
            string firstChar = i_Color[0].ToString().ToUpper();
            string theRest = i_Color.Remove(0, 1).ToLower();

            colorInTheRightFormat = string.Format("{0}{1}", firstChar, theRest);
            return colorInTheRightFormat;
        }

        public override string GetDetails()
        {
            string retDetails = base.GetDetails();
            retDetails += string.Format(
                "{3}Color: {0}{2}Number of Doors: {1}{2}",
                m_CarColor.ToString(), 
                m_NumOfDoors, 
                Environment.NewLine,
                m_Engine.GetDetails());

            return retDetails;
        }
    }
}
