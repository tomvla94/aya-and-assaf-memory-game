using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Ex05.MemoryGame.WindowForm
{
    public class LabeledTextBox : Control
    {
        private Label label;
        private TextBox textBox;

        public LabeledTextBox()
        {
            initContorls();
        }

        private void initContorls()
        {
            label = new Label();
            textBox = new TextBox();
            label.Size = new Size(120, 0);
            label.TextAlign = ContentAlignment.BottomLeft;
            textBox.Location = new Point(label.Right + 10, this.ClientSize.Height);
            label.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
            textBox.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            label.TabIndex = this.TabIndex;
            textBox.TabIndex = label.TabIndex + 1;
            this.Controls.AddRange(new Control[] { label, textBox });
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

        public override bool Focused
        {
            get { return textBox.Focused; }
        }

        public new void Focus()
        {
            textBox.Focus();
        }
    }
}
