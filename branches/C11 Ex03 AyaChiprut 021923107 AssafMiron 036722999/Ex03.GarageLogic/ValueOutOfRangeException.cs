namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Exception of Value Out of Range
    /// </summary>
    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;

        public ValueOutOfRangeException(string message, float i_MinValue, float i_MaxValue)
            : base(message)
        {
            m_MinValue = i_MinValue;
            m_MaxValue = i_MaxValue;
        }

        public float MaxValue
        {
            get { return m_MaxValue; }
        }
        
        public float MinValue
        {
            get { return m_MinValue; }
        }
    }
}
