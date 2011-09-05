// -----------------------------------------------------------------------
// <copyright file="BoardForm.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Ex05.MemoryGame.WindowForm
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Forms;
    using System.Drawing;
    using MemoryGame.Logic;
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class BoardForm : Form
    {
        private MemGameBL m_MemoryLogic = new MemGameBL();
        public void Run()
        {
            SettingsForm gameSettings = new SettingsForm();
            gameSettings.ShowDialog();


            initPlayers(gameSettings.GetFirstPlayerName(), gameSettings.GetSecondPlayerName());

            // Initialize a Game Round
            m_MemoryLogic.InitRound(gameSettings.GetBoardHeight(), gameSettings.GetBoardWidth());
            showGameBoard(m_MemoryLogic.Board);
        }

        private void showGameBoard(MemBoard memBoard)
        {
            ShowDialog();
        }

        private void initPlayers(string i_FirstPlayerName, string i_SecondPlayerName)
        {
            if (i_SecondPlayerName != null)
            {
                m_MemoryLogic.InitializePlayers(i_FirstPlayerName, i_SecondPlayerName);
            }
            else
            {
                m_MemoryLogic.InitializePlayers(i_FirstPlayerName);
            }
        }
        
    }
}
