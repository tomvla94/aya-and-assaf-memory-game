// -----------------------------------------------------------------------
// <copyright file="Engine.cs" company="Microsoft">
// TODO: Update copyright text.
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

        protected eEngineType m_EngineType;
    }
}
