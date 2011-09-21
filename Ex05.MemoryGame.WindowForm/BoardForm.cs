// -----------------------------------------------------------------------
// <copyright file="BoardForm.cs">
// Aya Chiprut 021923107 
// Assaf Miron 036722999
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
    /// The Main Game Board Form
    /// Will be presented only after all Settings are Done
    /// </summary>
    public class BoardForm : Form
    {
        private const int k_NumerOfTicksToWait = 100000000;
        private MemGameBL m_MemoryLogic = new MemGameBL();
        private int m_BoardHeight;
        private int m_BoardWidth;
        private MemCardButton[,] m_ButtonBoard;
        private MemCardButton m_PrevClickedButton;
        private Label m_LabelCurrentPlayer;
        private Label m_LabelFirstPlayerScore;
        private Label m_LabelSecondPlayerScore;
        private Button m_ButtonExit;
        private bool v_EndPlayerMessageWasShown;

        /// <summary>
        /// The Main Function for running the Game
        /// </summary>
        public void Run()
        {
            SettingsForm gameSettings = new SettingsForm();
            gameSettings.ShowDialog();

            if (gameSettings.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                // Initialize the Players in the Game
                initPlayers(gameSettings.FirstPlayerName, gameSettings.SecondPlayerName);

                // Save the Board Width and Height
                m_BoardHeight = gameSettings.BoardHeight;
                m_BoardWidth = gameSettings.BoardWidth;

                showGameBoard();
            }
        }

        private void showGameBoard()
        {
            // Initialize the Form Board Size
            initBoardSize();
            // Initialize all the controls on the form
            initControls();

            this.ShowDialog();
        }

        private void initBoardSize()
        {
            this.Text = "Memory Game";
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.Size = new Size(m_BoardHeight * 100, (m_BoardWidth * 100) + 150);
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
            setPlayerScore(m_MemoryLogic.FirstPlayer, m_LabelFirstPlayerScore);

            createLabel(out m_LabelSecondPlayerScore, 15, m_LabelFirstPlayerScore.Location.Y + 30);
            setPlayerScore(m_MemoryLogic.SecondPlayer, m_LabelSecondPlayerScore);

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
                    m_ButtonBoard[i, j].Text = string.Empty;
                    m_ButtonBoard[i, j].Size = new Size(90, 90);
                    m_ButtonBoard[i, j].Square = m_MemoryLogic.Board[i, j];
                    m_ButtonBoard[i, j].Location = new Point((i * 90) + 15, (j * 90) + 20);
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

        private void setPlayerScore(Player i_Player, Label i_LabelToUpdate)
        {
            i_LabelToUpdate.Text = string.Format(
                  "{0}: {1} Pair(s)",
                  i_Player.Name,
                  i_Player.Score);
            i_LabelToUpdate.BackColor = Color.FromName(i_Player.Color.ToString());
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

        private void playCurrentPlayerTurn()
        {
            if (v_EndPlayerMessageWasShown)
            {
                if (!m_LabelCurrentPlayer.Text.Contains(m_MemoryLogic.CurrentPlayer.Name))
                {
                    MessageBox.Show(string.Format("{0}'s Turn!", m_MemoryLogic.CurrentPlayer.Name), "Memory game", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                v_EndPlayerMessageWasShown = false;
                if (m_MemoryLogic.CurrentPlayer.Type == Player.ePlayerType.Computer)
                {
                    v_EndPlayerMessageWasShown = false;
                    playComputerTurn();
                }
            }
        }

        private void memcard_Click(object sender, EventArgs e)
        {
            if (m_MemoryLogic.CurrentPlayer.Type == Player.ePlayerType.Human)
            {
                MemCardButton clickedButton = (MemCardButton)sender;
                bool keepCardsVisible = m_MemoryLogic.PlayPlayerTurn(clickedButton.Square);
                if (m_PrevClickedButton == null)
                {
                    v_EndPlayerMessageWasShown = false;
                    m_PrevClickedButton = clickedButton;
                }
                else
                {
                    waitBeforeShowingCard(k_NumerOfTicksToWait);
                    endPlayerTurn(m_PrevClickedButton.Square, clickedButton.Square, keepCardsVisible);

                    m_PrevClickedButton = null;
                    playCurrentPlayerTurn();
                }
            }
        }

        private bool endPlayerTurn(MemSquare i_FirstSquare, MemSquare i_SecondSquare, bool i_IsMatch)
        {
            bool retUserGotPoint = false;
            if (!m_MemoryLogic.RoundFinished)
            {
                retUserGotPoint = m_MemoryLogic.EndPlayerTurn(i_FirstSquare, i_SecondSquare, i_IsMatch);
                showEndTurnMessage(retUserGotPoint);
            }
            else
            {
                printRoundSummary();
            }

            return retUserGotPoint;
        }

        /// <summary>
        /// Prints the Round Summary
        /// </summary>
        private void printRoundSummary()
        {
            if (m_MemoryLogic.Winner != m_MemoryLogic.Loser)
            {
                string roundMessage = string.Format(
                                "The winner is : {0} with: {1} points against {2} points of {3}",
                                m_MemoryLogic.Winner.Name,
                                m_MemoryLogic.Winner.Score,
                                m_MemoryLogic.Loser.Score,
                                m_MemoryLogic.Loser.Name);

                MessageBox.Show(
                    roundMessage,
                    "Memory Game",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                Console.WriteLine("Its a Tie!\nEverybody is a Winner! :)");
            }
        }

        /// <summary>
        /// Shows the Appropiate Message for the User
        /// </summary>
        /// <param name="i_UserGotPoint"></param>
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
            setPlayerScore(m_MemoryLogic.FirstPlayer, m_LabelFirstPlayerScore);
            setPlayerScore(m_MemoryLogic.SecondPlayer, m_LabelSecondPlayerScore);
            v_EndPlayerMessageWasShown = true;
        }

        private void m_ButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void playComputerTurn()
        {
            bool keepCardsVisible = false;
            MemSquare firstSquareChoise = null;
            MemSquare matchSquareChoice = null;
            string compColor = m_MemoryLogic.CurrentPlayer.Color.ToString();
            m_MemoryLogic.PlayComputerTurn(out firstSquareChoise, out matchSquareChoice, out keepCardsVisible);
            matchSquareChoice.Card.Flip(compColor);
            waitBeforeShowingCard(k_NumerOfTicksToWait);
            matchSquareChoice.Card.Flip(compColor);
            waitBeforeShowingCard(k_NumerOfTicksToWait);
            endPlayerTurn(firstSquareChoise, matchSquareChoice, keepCardsVisible);
            playCurrentPlayerTurn();
        }

        /// <summary>
        /// Creates a Delay the size of the Interval
        /// </summary>
        /// <param name="i_Interval"></param>
        private void waitBeforeShowingCard(int i_Interval)
        {
            int count = 0;
            while (count < i_Interval)
            {
                count++;
            }
        }
    }
}