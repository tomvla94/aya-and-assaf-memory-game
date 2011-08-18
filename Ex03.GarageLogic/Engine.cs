// -----------------------------------------------------------------------
// <copyright file="Engine.cs">
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
    public abstract class Engine
    {
        public enum eEngineType
        { 
            Fuel,
            Battery
        }

        private eEngineType m_EngineType;

        public eEngineType EngineType
        {
            get { return m_EngineType; }
            protected set { m_EngineType = value; }
        }

        public abstract float GetRemainingEnergyPrecentage();

        public abstract float GetRemianingEnergyAmount();

        public abstract float GetMaximumEnergyAmount();
    }
}
