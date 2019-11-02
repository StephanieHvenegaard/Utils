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
    public partial class NoteBox : Form
    {
        public NoteBox()
        {
            InitializeComponent();
        }
        public string GetNote { get; set; }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            GetNote = textBox1.Text;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
               DialogResult dr= MessageBox.Show("Leave a blank note ?","Really",MessageBoxButtons.YesNo);
               if (dr ==DialogResult.Yes) this.Close();
            }
            else
            {
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
