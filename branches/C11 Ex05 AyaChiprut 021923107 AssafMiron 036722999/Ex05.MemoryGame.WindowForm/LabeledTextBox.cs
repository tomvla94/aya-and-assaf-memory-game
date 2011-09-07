using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Ex05.MemoryGame.WindowForm
{
    class LabeledTextBox : Control
    {
        private Label label;
        private TextBox textBox;

        public LabeledTextBox()
        {
            initContorls();

            this.Controls.AddRange(new Control[] { label, textBox });
        }

        private void initContorls()
        {
            label = new Label();
            textBox = new TextBox();
            label.Size = new Size(110, 20);
            textBox.Location = new Point(label.Right + 10, this.ClientSize.Height);
//            label.Top += textBox.Size.Height / 2 - 10;
            label.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
            textBox.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
        }

        public string Label
        {
            get { return label.Text; }
            set { label.Text = value; }
        }

        public override string Text
        {
            get { return textBox.Text; }
            set { textBox.Text = value; }
        }

        public new bool Enabled
        {
            get { return textBox.Enabled; }
            set { textBox.Enabled = value; }
        }
    }
}
