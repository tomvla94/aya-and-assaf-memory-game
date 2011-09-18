﻿ // -----------------------------------------------------------------------
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
        private int m_BoardHeight;
        private int m_BoardWidth;
        private MemCardButton[,] m_ButtonBoard;
        private MemCardButton m_PrevClickedButton;
        private Label m_LabelCurrentPlayer;
        private Label m_LabelFirstPlayerScore;
        private Label m_LabelSecondPlayerScore;
        private Control m_ButtonExit;

        public void Run()
        {
            SettingsForm gameSettings = new SettingsForm();
            gameSettings.ShowDialog();

            if (gameSettings.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                initPlayers(gameSettings.FirstPlayerName, gameSettings.SecondPlayerName);

                m_BoardHeight = gameSettings.BoardHeight;
                m_BoardWidth = gameSettings.BoardWidth;

                showGameBoard(m_MemoryLogic.Board);
            }
        }

        private void showGameBoard(MemBoard memBoard)
        {
            initBoardSize();
            initControls();

            m_MemoryLogic.PlayCurrentPlayerTurn += new CurrentPlayerTurnEventHandler(PlayCurrentPlayerTurn);

            this.ShowDialog();
            // TODO: Need to have an Event on each player turn (Maybe use delegate in Change Player Index)
            // The event will triger the appropiate functionality
            // no need to apply PlayPlayerTurn on Button Click
            // Need to save Clicked buttons 
            //do
            //{
            //    // Start a Memory Game Round
            //    // Inform the Players Turn
            //    // Check if the Player is Human
            //    if (m_MemoryLogic.CurrentPlayer.Type == Player.ePlayerType.Human)
            //    {

            //    }
            //    else
            //    {
            //        playComputerTurn();
            //    }
            //}
            //while (!m_MemoryLogic.RoundFinished);
        }

        private void initBoardSize()
        {
            this.Text = "Memory Game";
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.Size = new Size(m_BoardHeight * 100, m_BoardWidth * 100 + 150);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Initialize a Game Round
            m_MemoryLogic.InitRound(m_BoardHeight, m_BoardWidth);
        }

        private void initControls()
        {
            this.SuspendLayout();

            createMemoryButtons();

            int lastControlYPos = m_ButtonBoard[m_BoardHeight - 1, m_BoardWidth - 1].Location.Y + 90;
            int lastControlXPos = m_ButtonBoard[m_BoardHeight - 1, m_BoardWidth - 1].Location.X;

            createLabel(out m_LabelCurrentPlayer, 15, lastControlYPos + 20);
            setCurrentPlayerNameLabel();

            createLabel(out m_LabelFirstPlayerScore, 15, m_LabelCurrentPlayer.Location.Y + 30);
            setFirstPlayerScore();

            createLabel(out m_LabelSecondPlayerScore, 15, m_LabelFirstPlayerScore.Location.Y + 30);
            setSecondPlayerScore();

            m_ButtonExit = new Button();
            m_ButtonExit.Text = "Exit";
            m_ButtonExit.AutoSize = true;
            m_ButtonExit.Location = new Point(lastControlXPos, m_LabelSecondPlayerScore.Location.Y);
            m_ButtonExit.Click += new EventHandler(m_ButtonExit_Click);
            this.Controls.Add(m_ButtonExit);
            
            this.ResumeLayout();
        }

        private void createMemoryButtons()
        {
            m_ButtonBoard = new MemCardButton[m_BoardHeight, m_BoardWidth];

            // Print Each Row with its Squares
            for (int i = 0; i < m_BoardHeight; i++)
            {
                // Loop through the Row Squares and Print them Out
                for (int j = 0; j < m_BoardWidth; j++)
                {
                    m_ButtonBoard[i, j] = new MemCardButton();
                    m_ButtonBoard[i, j].Text = "";
                    m_ButtonBoard[i, j].Size = new Size(90, 90);
                    m_ButtonBoard[i, j].Square = m_MemoryLogic.Board[i, j];
                    m_ButtonBoard[i, j].Location = new Point(i * 90 + 15, j * 90 + 20);
                    m_ButtonBoard[i, j].Click += new EventHandler(memcard_Click);
                    this.Controls.Add(m_ButtonBoard[i, j]);
                }
            }
        }

        private void createLabel(out Label o_LabelToSet, int i_PosX, int i_PosY)
        {
            o_LabelToSet = new Label();
            o_LabelToSet.Size = new Size(150, 20);
            o_LabelToSet.Location = new Point(i_PosX, i_PosY);
            o_LabelToSet.TextAlign = ContentAlignment.MiddleLeft;
            this.Controls.Add(o_LabelToSet);
        }

        private void setFirstPlayerScore()
        {
            m_LabelFirstPlayerScore.Text = string.Format("{0}: {1} Pair(s)",
                m_MemoryLogic.FirstPlayer.Name,
                m_MemoryLogic.FirstPlayer.Score);
            m_LabelFirstPlayerScore.BackColor = Color.FromName(m_MemoryLogic.FirstPlayer.Color.ToString());
        }

        private void setSecondPlayerScore()
        {
            m_LabelSecondPlayerScore.Text = string.Format("{0}: {1} Pair(s)",
                m_MemoryLogic.SecondPlayer.Name,
                m_MemoryLogic.SecondPlayer.Score);
            m_LabelSecondPlayerScore.BackColor = Color.FromName(m_MemoryLogic.SecondPlayer.Color.ToString());
        }

        private void setCurrentPlayerNameLabel()
        {
            m_LabelCurrentPlayer.Text = string.Format("Current Player: {0}", m_MemoryLogic.CurrentPlayer.Name);
            m_LabelCurrentPlayer.BackColor = Color.FromName(m_MemoryLogic.CurrentPlayer.Color.ToString());
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

        void PlayCurrentPlayerTurn()
        {
            if (m_MemoryLogic.CurrentPlayer.Type == Player.ePlayerType.Human)
            {
                MessageBox.Show(string.Format("{0}'s Turn!", m_MemoryLogic.CurrentPlayer.Name), "Memory game", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Computer Player Turn");
                playComputerTurn();
            }
        }

        private void memcard_Click(object sender, EventArgs e)
        {
            
            MemCardButton clickedButton = (MemCardButton)sender;
            if (IsButtonClicked(clickedButton))
            {
                clickedButton.BackColor = Color.FromName(m_MemoryLogic.CurrentPlayer.Color.ToString());
                clickedButton.Enabled = false;
                bool keepCardsVisible = m_MemoryLogic.PlayPlayerTurn(clickedButton.Square);
                if (m_PrevClickedButton == null)
                {
                    m_PrevClickedButton = clickedButton;
                }
                else
                {
                    if (!endPlayerTurn(m_PrevClickedButton.Square, clickedButton.Square, keepCardsVisible))
                    {
                        clickedButton.BackColor = Color.Empty;
                        clickedButton.Enabled = true;
                        m_PrevClickedButton.BackColor = Color.Empty;
                        m_PrevClickedButton.Enabled = true;
                    }
                    m_PrevClickedButton = null;
                }
            }
            else
            {
                clickedButton.BackColor = Color.Empty;
                clickedButton.Enabled = true;
            }
        }

        private bool IsButtonClicked(Button i_ButtonClicked)
        {
            bool retButtonIsClicked = false;
            if (i_ButtonClicked.BackColor == Color.Empty)
            {
                retButtonIsClicked = false;
            }
            else
            {
                retButtonIsClicked = true;
            }

            return retButtonIsClicked;
        }

        private bool endPlayerTurn(MemSquare i_FirstSquare, MemSquare i_SecondSquare, bool i_IsMatch)
        {
            bool retUserGotPoint = m_MemoryLogic.EndPlayerTurn(i_FirstSquare, i_SecondSquare, i_IsMatch);
            showEndTurnMessage(retUserGotPoint);
            return retUserGotPoint;
        }

        private void showEndTurnMessage(bool i_UserGotPoint)
        {
            string infoMessage;
            if (i_UserGotPoint)
            {
                infoMessage = string.Format("Hey You Found a Match! :){0}Play another turn!", Environment.NewLine);
            }
            else
            {
                infoMessage = string.Format("Sorry... No Match here.{0}The Turn goes to the other Player.", Environment.NewLine);
            }

            MessageBox.Show(infoMessage);
            setCurrentPlayerNameLabel();
            setFirstPlayerScore();
            setSecondPlayerScore();
        }

        void m_ButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void playComputerTurn()
        {
            bool keepCardsVisible = false;
            MemSquare firstSquareChoise = null;
            MemSquare matchSquareChoice = null;
            m_MemoryLogic.PlayComputerTurn(out firstSquareChoise, out matchSquareChoice, out keepCardsVisible);
            endPlayerTurn(firstSquareChoise, matchSquareChoice, keepCardsVisible);
        }
    }
}