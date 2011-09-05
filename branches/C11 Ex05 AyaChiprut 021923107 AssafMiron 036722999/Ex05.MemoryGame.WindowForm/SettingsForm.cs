// -----------------------------------------------------------------------
// <copyright file="SettingsForm.cs" company="Microsoft">
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

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class SettingsForm : Form
    {
        private bool v_ApponentComputer = true;
        private Button m_ButtonStart;
        private Button m_ButtonBoard;
        private Button m_ButtonApponent;
        private Label m_LabelHeader;
        private Label m_LabelSubHeader;
        private Label m_LabelFirstPlayer;
        private Label m_LabelSecondPlayer;
        private TextBox m_TextFirstPlayer;
        private TextBox m_TextSecondPlayer;
        private int m_CurrentWidth;
        private int m_CurrentHeight;

        public SettingsForm()
        {
            this.Text = "Memory Game - Settings";
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.Size = new Size(450, 300);
            this.StartPosition = FormStartPosition.CenterScreen;

            m_CurrentHeight = m_CurrentWidth = Ex05.MemoryGame.Logic.MemBoard.k_MinBoradSizeValue;

            initHeader();
            initControls();
        }

        private void initHeader()
        {
            m_LabelHeader = new Label();
            m_LabelSubHeader = new Label();
            m_LabelHeader.Text = "Memory Game";
            m_LabelHeader.Font = new Font("Calibri", 20);
            m_LabelHeader.Location = new Point((this.Size.Width / 2) - (m_LabelHeader.Text.Length * 9), 10);
            m_LabelHeader.AutoSize = true;

            m_LabelSubHeader.Text = "by Aya and Assaf";
            m_LabelSubHeader.Font = new Font("Calibri", 12);
            m_LabelSubHeader.Location = new Point(m_LabelHeader.Location.X + m_LabelSubHeader.Text.Length, m_LabelHeader.Location.Y + m_LabelHeader.Size.Height + 20);
            m_LabelSubHeader.AutoSize = true;

            this.Controls.Add(m_LabelHeader);
            this.Controls.Add(m_LabelSubHeader);
        }

        private void initControls()
        {
            // Setting the First Player Label and Text
            initFirstPlayerControls();

            // Setting the Second Player Label and Text
            initSecondPlayerControls();

            // Setting The Apponent Button
            m_ButtonApponent = new Button();
            m_ButtonApponent.Text = "Against a Friend";
            m_ButtonApponent.AutoSize = true;
            m_ButtonApponent.Click += new EventHandler(m_ButtonApponent_FriendClick);
            m_ButtonApponent.Parent = this;

            // Setting the Board Button
            m_ButtonBoard = new Button();
            // TODO: Get the Initial Board Size
            m_ButtonBoard.Text = getButtonBoardText();
            m_ButtonBoard.Size = new Size(50, 50);
            m_ButtonBoard.Click += new EventHandler(m_ButtonBoard_Click);
            m_ButtonBoard.Parent = this;

            // Setting the Start Button
            m_ButtonStart = new Button();
            m_ButtonStart.Text = "Start!";
            m_ButtonStart.AutoSize = true;
            m_ButtonStart.Click += new EventHandler(m_ButtonStart_Click);
            m_ButtonStart.Parent = this;

            // Arrange the Controls
            arrangeControls(30, 20, 10, 30);
        }

        private void initFirstPlayerControls()
        {
            m_LabelFirstPlayer = new Label();
            m_TextFirstPlayer = new TextBox();
            m_LabelFirstPlayer.Text = "First Player Name:";
            m_TextFirstPlayer.Text = string.Empty;
            m_TextFirstPlayer.Size = new Size(100, 50);
            m_LabelFirstPlayer.Size = new Size(120, 20);
            m_LabelFirstPlayer.Parent = this;
            m_TextFirstPlayer.Parent = this;
        }

        private void initSecondPlayerControls()
        {
            m_LabelSecondPlayer = new Label();
            m_TextSecondPlayer = new TextBox();
            m_LabelSecondPlayer.Text = "Second Player Name:";
            m_TextSecondPlayer.Text = "Computer";
            m_TextSecondPlayer.Enabled = false;
            m_TextSecondPlayer.Size = new Size(100, 50);
            m_LabelSecondPlayer.Size = new Size(120, 20);
            m_LabelSecondPlayer.Parent = this;
            m_TextSecondPlayer.Parent = this;
        }

        private string getButtonBoardText()
        {
            return string.Format("{0} X {1}", m_CurrentHeight, m_CurrentWidth);
        }

        private void arrangeControls(int i_Top, int i_Left, int i_Right, int i_Bottom)
        {
            m_LabelFirstPlayer.Location = new Point(i_Left, m_LabelSubHeader.Location.Y + m_LabelSubHeader.Size.Height + i_Top);
            m_TextFirstPlayer.Location = new Point(m_LabelFirstPlayer.Location.X + m_LabelFirstPlayer.Size.Width + i_Right, m_LabelFirstPlayer.Location.Y);
            m_LabelSecondPlayer.Location = new Point(i_Left, m_LabelFirstPlayer.Location.Y + i_Top);
            m_TextSecondPlayer.Location = new Point(m_LabelSecondPlayer.Location.X + m_LabelSecondPlayer.Size.Width + i_Right, m_LabelSecondPlayer.Location.Y);
            m_ButtonApponent.Location = new Point(m_TextSecondPlayer.Location.X + m_TextSecondPlayer.Size.Width + i_Right, m_TextSecondPlayer.Location.Y);
            m_ButtonBoard.Location = new Point(i_Left, m_LabelSecondPlayer.Location.Y + i_Top + i_Bottom);
            m_ButtonStart.Location = new Point(m_ButtonBoard.Location.X + m_ButtonBoard.Size.Width + i_Right, m_ButtonBoard.Location.Y);
        }

        private void m_ButtonApponent_FriendClick(object sender, EventArgs e)
        {
            m_ButtonApponent.Text = "Against the Computer";
            v_ApponentComputer = false;
            m_ButtonApponent.Click -= new EventHandler(m_ButtonApponent_FriendClick);
            m_ButtonApponent.Click += new EventHandler(m_ButtonApponent_ComputerClick);

            m_TextSecondPlayer.Text = string.Empty;
            m_TextSecondPlayer.Enabled = true;
        }

        private void m_ButtonBoard_Click(object sender, EventArgs e)
        {
            if (m_CurrentWidth + 1 > MemoryGame.Logic.MemBoard.k_MaxBoradSizeValue)
            {
                m_CurrentWidth = MemoryGame.Logic.MemBoard.k_MinBoradSizeValue;
                if (m_CurrentHeight + 1 > MemoryGame.Logic.MemBoard.k_MaxBoradSizeValue)
                {
                    m_CurrentHeight = MemoryGame.Logic.MemBoard.k_MinBoradSizeValue;
                }
                else
                {
                    m_CurrentHeight++;
                }
            }
            else
            {
                m_CurrentWidth++;
            }

            m_ButtonBoard.Text = getButtonBoardText();
        }

        

        private void m_ButtonStart_Click(object sender, EventArgs e)
        {
            // TODO: Start the Game
        }

        private void m_ButtonApponent_ComputerClick(object sender, EventArgs e)
        {
            m_ButtonApponent.Text = "Against a Friend";
            v_ApponentComputer = true;
            m_ButtonApponent.Click -= new EventHandler(m_ButtonApponent_ComputerClick);
            m_ButtonApponent.Click += new EventHandler(m_ButtonApponent_FriendClick);

            m_TextSecondPlayer.Text = "Computer";
            m_TextSecondPlayer.Enabled = false;
        }

        public string GetFirstPlayerName()
        {
            return m_TextFirstPlayer.Text;
        }

        public string GetSecondPlayerName()
        {
            string retPlayerName = null;
            if (m_TextSecondPlayer.Text != "Computer")
            {
                retPlayerName = m_TextSecondPlayer.Text;
            }

            return retPlayerName;
        }

        public int GetBoardHeight()
        {
            return m_CurrentHeight;
        }

        public int GetBoardWidth()
        {
            return m_CurrentWidth;
        }
    }
}
