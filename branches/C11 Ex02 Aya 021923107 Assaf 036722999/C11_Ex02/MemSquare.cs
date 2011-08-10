// -----------------------------------------------------------------------
// <copyright file="MemSquare.cs">
// Aya Chiprut 021923107 
// Assaf Miron 036722999
// </copyright>
// -----------------------------------------------------------------------

namespace C11_Ex02
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class MemSquare
    {
        private int m_Row;
        private int m_Col;
        private Card m_Card;

        /// <summary>
        /// Construct the Memory Game Square
        /// </summary>
        /// <param name="i_Row">The Square Row</param>
        /// <param name="i_Col">The Square Collumn</param>
        /// <param name="i_Leter">The Letter for this Square Card</param>
        public MemSquare(int i_Row, int i_Col, string i_Leter)
        {
            m_Row = i_Row;
            m_Col = i_Col;
            m_Card.Sign = i_Leter;
        }

        public MemSquare()
        {
            m_Row = 0;
            m_Col = 0;
            m_Card = null;
        }

        public int Row
        {
            get { return m_Row; }
            set { m_Row = value; }
        }

        public int Col
        {
            get { return m_Col; }
            set { m_Col = value; }
        }

        public Card Card
        {
            get { return m_Card; }
        }

        public static bool TryParse(string i_SquareStr, out MemSquare o_Square)
        {
            bool retParseResult = false;
            o_Square = new MemSquare();
            int row;
            string convertedUpperCaseSquareString = i_SquareStr.ToUpper();
            int col = (convertedUpperCaseSquareString[0] - 'A');
            if (col > 0)
            {
                retParseResult = int.TryParse(convertedUpperCaseSquareString.Remove(0, 1),out row);
                if (retParseResult)
                {
                    o_Square.Row = row;
                    o_Square.Col = col;
                    retParseResult = true;
                }
            }
            
            return retParseResult;
        }
    }
}