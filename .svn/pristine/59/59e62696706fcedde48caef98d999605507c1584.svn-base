using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SHUtils.Forms.InputBoxes
{  
    /**********************************
    * Used in
    * Proevent Client 
    * Project manegar 2.5
    *********************************/
    public partial class OneLineInputbox : Form
    {

        public string Input { get; set; }
        public OneLineInputbox(string Headder)
        {
            InitializeComponent();
            this.Text = Headder;
        }
        public OneLineInputbox(string Headder,string PreviosText)
        {
            InitializeComponent();
            this.Text = Headder;
            textBox1.Text = PreviosText;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
               DialogResult dr= MessageBox.Show("text field is blank do you wanna continue?","Really",MessageBoxButtons.YesNo);
               if (dr ==DialogResult.Yes) this.DialogResult = System.Windows.Forms.DialogResult.OK; this.Close();
            }
            else
            { 
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                button1_Click(sender, new EventArgs());
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Input = textBox1.Text;
        }            
    }
}
