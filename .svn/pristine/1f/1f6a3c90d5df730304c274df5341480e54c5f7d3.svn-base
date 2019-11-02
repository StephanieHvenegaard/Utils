using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SHUtils.Util.ADV.RadioButtens
{
    public partial class RadioButtomSelectionGroupe : Control
    { 
      
        List<string> Radionames = new List<string>();
        public int Selectedindex; // zero based index for what 
        public string GroupeName ="";
        int DEFAULT_CONTROL_HEIGHT = 30;
        int RadiobuttenSpace = 10;
        int index = 0;
        //int usedRadiobuttenSpace = 0;
        public RadioButtomSelectionGroupe()
        {
            InitializeComponent();
            SetBoundsCore(this.Location.X, this.Location.Y, 100, 100, new BoundsSpecified());
        }
        public RadioButtomSelectionGroupe(string radiogroupename, string[] radionames,int RadiobtnSpace,int RadiobtnStart)
        {
            InitializeComponent();
            SetBoundsCore(this.Location.X, this.Location.Y, 100, 100, new BoundsSpecified());
            InitializeRadioGroupes(radiogroupename, radionames, RadiobtnSpace, RadiobtnStart, -1);
        }
        public RadioButtomSelectionGroupe(string radiogroupename, string[] radionames, int RadiobtnSpace, int RadiobtnStart, int checkedindex)
        {
            InitializeComponent();
            SetBoundsCore(this.Location.X, this.Location.Y, 100, 100, new BoundsSpecified());
            InitializeRadioGroupes(radiogroupename, radionames, RadiobtnSpace, RadiobtnStart, checkedindex);
        }
        public RadioButtomSelectionGroupe(string radiogroupename, string[] radionames, int RadiobtnSpace, int RadiobtnStart, int checkedindex,int Index)
        {
            InitializeComponent();
            SetBoundsCore(this.Location.X, this.Location.Y, 100, 100, new BoundsSpecified());
            InitializeRadioGroupes(radiogroupename, radionames, RadiobtnSpace, RadiobtnStart, checkedindex);
            index = Index;
        }
        public void InitializeRadioGroupes(string radiogroupename, string[] radionames,int RadiobtnSpace,int RadiobtnStart)
        {
            InitializeRadioGroupes(radiogroupename, radionames, RadiobtnSpace, RadiobtnStart, -1);
        }
        public void InitializeRadioGroupes(string radiogroupename, string[] radionames, int RadiobtnSpace,int RadiobtnStart,int checkedindex)
        {
            Selectedindex = checkedindex;
            Radionames.AddRange(radionames);
            GroupeName = radiogroupename;
            // ---- Setup the basicform of the control ---- 
            Label lRadioGroupeName = new Label();
            SizeF Size = GetTextsize(radiogroupename,lRadioGroupeName.Font);
           
            int MiddleY = Convert.ToInt16(Size.Height / 2);

            lRadioGroupeName.Location = new Point(RadiobuttenSpace, (DEFAULT_CONTROL_HEIGHT/2) - MiddleY);
            //   lRadioGroupeName.Width =Convert.ToInt32( Size.Width);
            lRadioGroupeName.Text = radiogroupename;
            lRadioGroupeName.Width = RadiobtnStart;
            int totalXPostion = RadiobtnStart + RadiobuttenSpace; // Space fron the label to the radio btn.
            this.Controls.Add(lRadioGroupeName);
            for (int i = 0; i <radionames.Length ; i++)
            {
                string s = radionames[i];
                RadioButton rdbtn = new RadioButton();
                if (i == checkedindex) rdbtn.Checked = true;
                rdbtn.Text = s; 
                rdbtn.Name = s;
                rdbtn.Width = RadiobtnSpace;
                totalXPostion += RadiobuttenSpace;
                double dYpos = ((DEFAULT_CONTROL_HEIGHT/2) - MiddleY)*0.39393939;
                int iYpos = Convert.ToInt32(dYpos);
                rdbtn.Location = new Point(totalXPostion,iYpos);
                totalXPostion += RadiobtnSpace;
                rdbtn.Click += rbtn_Click;
                this.Controls.Add(rdbtn);
            }
            this.Width = totalXPostion;
        }
        public int Index { get { return index; } }
        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            // EDIT: ADD AN EXTRA HEIGHT VALIDATION TO AVOID INITIALIZATION PROBLEMS
            // BITWISE 'AND' OPERATION: IF ZERO THEN HEIGHT IS NOT INVOLVED IN THIS OPERATION
            if ((specified & BoundsSpecified.Height) == 0 || height == DEFAULT_CONTROL_HEIGHT)
            {
                base.SetBoundsCore(x, y, width, DEFAULT_CONTROL_HEIGHT, specified);
            }
            else
            {
                return; // RETURN WITHOUT DOING ANY RESIZING
            }
        }
        private void RepositionAllControls(int TextSize)
        {
            int MiddleY = TextSize / 2;
            foreach (Control crl in this.Controls)
            {
               // crl.Location = new Point(20 - Middle, crl.Location.Y);

                crl.Location = new Point(crl.Location.X, 20 - MiddleY);
            }
        }
        private SizeF GetTextsize(string str, Font font)
        {
            using (Graphics g = this.CreateGraphics())
            {
               return g.MeasureString(str, font);
            }
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            //SizeF stringSize = pe.Graphics.MeasureString(GroupeName, lRadioGroupeName.Font);
            //RepositionAllControls(Convert.ToInt16(stringSize.Height));
            base.OnPaint(pe);
        }
        // shit to doo on a klick event
        private void rbtn_Click(object sender, EventArgs e)
        {
            RadioButton radiobtn = sender as RadioButton;
            int index = Radionames.IndexOf(radiobtn.Name);
            Selectedindex = index;
        }
    }
}
