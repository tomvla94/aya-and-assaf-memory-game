using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
namespace C11_Ex05_AyaChiprut_021923107_AssafMiron_036722999
{
    class MemoryGameSettingsForm : Form
    {
        private bool v_ApponentComputer = true;
        private Button m_ButtonStart;
        private Button m_ButtonBoard;
        private Button m_ButtonApponent;
        private LabelAndTextbox m_TextFirstPlayer;
        private LabelAndTextbox m_TextSecondPlayer;

        public MemoryGameSettingsForm()
        {
            this.Text = "Memory Game - Settings";
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.Size = new Size(300, 300);
            this.StartPosition = FormStartPosition.CenterScreen;

            InitControls();
        }

        void InitControls()
        {
            // Setting the First Player Label and Text
            m_TextFirstPlayer = new LabelAndTextbox("First Player Name:", "");
            m_TextFirstPlayer.Size = new Size(200, 50);
            m_TextFirstPlayer.Parent = this;

            // Setting the Second Player Label and Text
            m_TextSecondPlayer = new LabelAndTextbox("Second Player Name:", "Computer");
            m_TextSecondPlayer.Size = new Size(200, 50);
            m_TextSecondPlayer.Enabled = false;
            m_TextSecondPlayer.Parent = this;

            // Setting The Apponent Button
            m_ButtonApponent = new Button();
            m_ButtonApponent.Text = "Against a Friend";
            m_ButtonApponent.AutoSize = true;
            m_ButtonApponent.Click += new EventHandler(m_ButtonApponent_FriendClick);
            m_ButtonApponent.Parent = this;

            // Setting the Board Button
            m_ButtonBoard = new Button();
            // TODO: Get the Initial Board Size
            m_ButtonBoard.Text = "4 X 4";
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
            ArrangeControls(10, 10, 10, 20);
        }

        private void ArrangeControls(int i_Top, int i_Left, int i_Right, int i_Bottom)
        {
            for (int i = 0; i < this.Controls.Count; i++)
            {
                if (i == 0)
                {
                    this.Controls[i].Location = new Point(i_Left, i_Top);
                }
                else if (i == this.Controls.Count - 1)
                {
                    this.Controls[i].Location = new Point(i_Left, this.Height - i_Bottom);
                }
                else
                {
                    int calcX = this.Controls[i - 1].Location.X;
                    int calcY = this.Controls[i - 1].Location.Y + this.Controls[i - 1].Size.Height;
                    this.Controls[i].Location = new Point(
                        calcX, 
                        calcY + i_Top);
                }
            }
        }

        void m_ButtonApponent_FriendClick(object sender, EventArgs e)
        {
            m_ButtonApponent.Text = "Against the Computer";
            v_ApponentComputer = false;
            m_ButtonApponent.Click -= new EventHandler(m_ButtonApponent_FriendClick);
            m_ButtonApponent.Click += new EventHandler(m_ButtonApponent_ComputerClick);

            m_TextSecondPlayer.ClearText();
            m_TextSecondPlayer.Enabled = true;
        }

        private void m_ButtonBoard_Click(object sender, EventArgs e)
        { 
            // TODO: Set the Button Text by Board Enum Size
            // TODO: Set the Board Size
        }

        public void m_ButtonStart_Click(object sender, EventArgs e)
        { 
            // TODO: Start the Game
        }

        void m_ButtonApponent_ComputerClick(object sender, EventArgs e)
        {
            m_ButtonApponent.Text = "Against a Friend";
            v_ApponentComputer = true;
            m_ButtonApponent.Click -= new EventHandler(m_ButtonApponent_ComputerClick);         
            m_ButtonApponent.Click += new EventHandler(m_ButtonApponent_FriendClick);

            m_TextSecondPlayer.SetText("Computer");
            m_TextSecondPlayer.Enabled = false;
        }
    }
}
