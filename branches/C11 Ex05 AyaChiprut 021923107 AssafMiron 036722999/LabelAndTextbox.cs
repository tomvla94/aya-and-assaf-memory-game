using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace C11_Ex05_AyaChiprut_021923107_AssafMiron_036722999
{
    class LabelAndTextbox : Control
    {
        private const int k_SpacingBetweenLabelAndText = 10;
        private Label m_Label;
        private TextBox m_TextBox;
        
        public LabelAndTextbox()
        {
            m_Label = new Label();
            m_TextBox = new TextBox();
        }

        public LabelAndTextbox(string i_LabelText, string i_TextBoxText)
        {
            m_Label = new Label();
            m_TextBox = new TextBox();

            m_Label.Text = i_LabelText;
            m_TextBox.Text = i_TextBoxText;
        }

        public new Point Location
        {
            get { return this.Location; }
            set
            {
                this.Location = value;
                m_Label.Location = new Point(this.Location.X, this.Location.Y);
                m_TextBox.Location = new Point(m_Label.Location.X + m_Label.Size.Width + k_SpacingBetweenLabelAndText, m_Label.Location.Y);
            }
        }

        public new Size Size
        {
            get { return this.Size; }
            set
            {
                try
                {
                    this.Size = value;
                    int controlsWidth = (this.Size.Width / 2) - k_SpacingBetweenLabelAndText;
                    m_Label.Size = new Size(controlsWidth, this.Size.Height);
                    m_TextBox.Size = new Size(controlsWidth, this.Size.Height);
                }
                catch(Exception e)
                { MessageBox.Show(e.StackTrace); }
            }
        }

        public void SetText(string i_LabelText, string i_TextBoxText)
        {
            m_Label.Text = i_LabelText;
            m_TextBox.Text = i_TextBoxText;
        }

        public void SetText(string i_TextBoxText)
        {
            m_TextBox.Text = i_TextBoxText;
        }

        public void ClearText()
        {
            m_TextBox.Text = "";
        }

        public new bool Enabled
        {
            get { return m_TextBox.Enabled; }
            set { m_TextBox.Enabled = value; }
        }
    }
}
