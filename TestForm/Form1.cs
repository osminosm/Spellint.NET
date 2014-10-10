using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace TestForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void spellButton_Click(object sender, EventArgs e)
        {
            this.output.Text = Spellint.Arabic.Spell(this.input.Text);
            this.textBox1.Text = Spellint.English.Spell(this.input.Text);
            this.textBox2.Text = Spellint.French.Spell(this.input.Text);
        }
    }
}
