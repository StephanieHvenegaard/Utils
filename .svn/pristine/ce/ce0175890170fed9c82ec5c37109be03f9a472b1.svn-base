using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Windows.Forms.Design.Behavior;

namespace SHUtils.Controls
{
    /**********************************
    * Used in
    * ProeventServer2
    * Proevent Client 
    * Project manegar 2.5
    *********************************/
    [Designer(typeof(ToggleSwith.Designer))]
    public class ToggleSwith : Control
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        object _Lock = new object();
        private Color _OffColor = SystemColors.ControlDarkDark;
        private Color _OnColor = Color.LimeGreen;
        private bool _ColorText = false;
        private bool _UseYesNo = false;
        private string _OnText = "On";
        private string _OffText = "Off";
        private string _YesText = "Yes";
        private string _NoText = "No";

        private int MouseDownX = 0;

        // private bool _BeenDrawn = false;
        private bool _Checked = false;
        [Browsable(false)]
        internal double TextSnapOffset { get { return this.Size.Height/2+Font.Height/2; } }
        [Browsable(false)]
        public override string Text { get { return null; } }
        [Browsable(false)]
        public override bool AutoSize { get { return false; } }
        [Category("Appearance")]
        public virtual Color OffColor { get { return _OffColor; } set { _OffColor = value; Invalidate(); } }
        [Category("Appearance")]
        public virtual Color OnColor { get { return _OnColor; } set { _OnColor = value; Invalidate(); } }
        [Category("Appearance")]
        public virtual bool ColorText { get { return _ColorText; } set { _ColorText = value; Invalidate(); } }
        [Category("Appearance")]
        public virtual bool Checked { get { return _Checked; } set { _Checked = value; Invalidate(); OnToggleChanged(); } }
        [Category("Appearance")]
        public virtual string OnText { get{ if(UseYesNo) return _YesText; else return _OnText ;}}
        [Category("Appearance")]
        public virtual bool UseYesNo  { get { return _UseYesNo; } set { _UseYesNo = value; Invalidate(); } }
        [Category("Appearance")]
        public virtual string OffText{get{ if(UseYesNo) return _NoText; else return _OffText ;}}
        //new public bool UseVisualStyleBackColor { get { return false; } set{} }
        protected override Size DefaultSize { get { return new Size(80, 18); } }
        protected override Size DefaultMinimumSize { get { return new Size(40, 13); } }
        public event EventHandler ToggleChanged;
        public ToggleSwith()
        {
            this.Size = new Size(80, 18);
            components = new System.ComponentModel.Container();
            this.MouseDown += ToggleSwith_MouseDown;
            this.MouseUp += ToggleSwith_MouseUp;
            this.SizeChanged += ToggleSwith_SizeChanged;
        }

        void ToggleSwith_SizeChanged(object sender, EventArgs e)
        {
            Invalidate();
        }
        void ToggleSwith_MouseUp(object sender, MouseEventArgs e)
        {
            if (MouseDownX == e.X)
            {
                lock (_Lock)
                {
                    if (_Checked) _Checked = false;
                    else _Checked = true;
                }
                OnToggleChanged();
                Invalidate();
            }
            else
            {
                lock (_Lock)
                {
                    if (MouseDownX > e.X)
                    {
                        if (_Checked)
                        {
                            _Checked = false;
                            OnToggleChanged();
                            Invalidate();
                        }
                    }
                    else
                    {
                        if (!_Checked)
                        {
                            _Checked = true;
                            OnToggleChanged();
                            Invalidate();
                        }
                    }
                }
            }
            
        }
        void ToggleSwith_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDownX = e.X;
        }
        private void OnToggleChanged()
        {
            if (ToggleChanged != null)
            {
                EventArgs ea = new EventArgs();
                ToggleChanged(this, ea);
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            //this.Controls.Clear();
            int toggleblocsize = (int)this.Size.Width / 6;
            int indent = 23;
            int labelx = 2;
            // Declare and instantiate a new pen.
            SolidBrush OffPen = new SolidBrush(this.OffColor);
            SolidBrush OnPen = new SolidBrush(this.OnColor);
            Rectangle texttangle = new Rectangle(new Point(labelx, 0), new Size(indent - labelx, this.Size.Height));


            SolidBrush BackgroundBrush = new SolidBrush(this.Parent.BackColor);
            SolidBrush ToggleBrush = new SolidBrush(SystemColors.ControlText);
            SolidBrush TextBrush = new SolidBrush(SystemColors.ControlText);
            Pen ControlDarkPen = new Pen(SystemColors.ControlDark);
            Pen ControlPen = new Pen(SystemColors.Control);
            e.Graphics.FillRectangle(BackgroundBrush, 0, 0, this.Size.Width, this.Size.Height);
            e.Graphics.FillRectangle(new SolidBrush(BackColor), indent, 0, this.Size.Width - indent, this.Size.Height);
            e.Graphics.DrawRectangle(ControlDarkPen, indent, -0, this.Size.Width - (indent + 1), this.Size.Height - 1);
            if (!this.Enabled)
            {
                OffPen = new SolidBrush(SystemColors.Control);
                OnPen = new SolidBrush(SystemColors.Control);
                ToggleBrush = new SolidBrush(SystemColors.ControlDark);
                TextBrush = new SolidBrush(SystemColors.Control);
            }
            if (this._Checked)
            {
                //ligth
                e.Graphics.FillRectangle(OnPen, (indent + 2), 2, this.Size.Width - (indent + 4), this.Size.Height - 4);
                //Toggle
                e.Graphics.DrawRectangle(ControlPen, this.Size.Width - (toggleblocsize + 1), -0, this.Size.Width - (indent + 1), this.Size.Height - 1);
                e.Graphics.FillRectangle(ToggleBrush, this.Size.Width - (toggleblocsize), -1, this.Size.Width, this.Size.Height + 1);
                if (ColorText && this.Enabled) TextBrush = new SolidBrush(OnColor);//_label.ForeColor = OnColor;
                // _label.Text = "On";
                // Draw string to screen.
                TextRenderer.DrawText(e.Graphics, OnText, this.Font, texttangle, TextBrush.Color, this.Parent.BackColor,
                                    TextFormatFlags.HorizontalCenter |
                                    TextFormatFlags.VerticalCenter |
                                    TextFormatFlags.GlyphOverhangPadding);
            }
            else
            {
                //ligth
                e.Graphics.FillRectangle(OffPen, (indent + 2), 2, this.Size.Width - (indent + 4), this.Size.Height - 4);
                //Toggle
                e.Graphics.DrawRectangle(ControlPen, indent, -0, (toggleblocsize + 1), this.Size.Height - 1);
                e.Graphics.FillRectangle(ToggleBrush, (indent + 1), -1, (toggleblocsize), this.Size.Height + 1);
                if (ColorText && this.Enabled) TextBrush = new SolidBrush(SystemColors.ControlText);
                // Draw string to screen.
                TextRenderer.DrawText(e.Graphics, OffText, this.Font, texttangle, TextBrush.Color, this.Parent.BackColor,
                                TextFormatFlags.HorizontalCenter |
                                TextFormatFlags.VerticalCenter |
                                TextFormatFlags.GlyphOverhangPadding);



            }
        }
        public override Size GetPreferredSize(Size proposedSize)
        {
            return new Size(80, 18);
        }
        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private class Designer : ControlDesigner
        {
            public override System.Collections.IList SnapLines
            {
                get
                {
                    ArrayList lst = base.SnapLines as ArrayList;
                    ToggleSwith ctl = (ToggleSwith)this.Control;
                    SnapLine snap = new SnapLine(SnapLineType.Baseline, Convert.ToInt32(ctl.TextSnapOffset));
                    lst.Add(snap);
                    return lst;
                }
            }
        }
    }
}

