using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SHUtils.Forms.Passwords
{
    public partial class Passwordbox : Form
    {
        string CorrectPassword = "";
        
        public Passwordbox(string PW)
        {
            InitializeComponent();
            CorrectPassword = PW;
            if (PW == "")
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            this.AcceptButton = button1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == CorrectPassword)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Abort;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                button1_Click(sender, new EventArgs());
            }
        }            
    }
}
