using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Forms.VisualStyles;

namespace SHUtils.Controls
{
    /**********************************
    * Used in
    * Projectmaneger 2.5
    *********************************/
    public partial class CheckListBox : UserControl
    {
        // fields
        //------------------------------------------------------------------------------------------
        private List<CheckListItem> _Checklistitems = new List<CheckListItem>();
        private Panel _ItemsList = new Panel();
        private CheckListItem _SelectedItem = null;
        // Properties
        //------------------------------------------------------------------------------------------
        [Category("Appearance")]
        public virtual double Completeness
        {
            get
            {
                if (_Checklistitems.Count == 0) return 0;
                else
                {
                    double completeness = 0;
                    foreach (CheckListItem cli in _Checklistitems)
                    {

                        completeness += cli.Completeness;

                    }
                    completeness = completeness / _Checklistitems.Count;

                    return completeness;
                }
            }
        }
        public virtual int Count { get { return _Checklistitems.Count; } }
        public virtual CheckListItem SelectedItem { get { return _SelectedItem; } }
        public virtual int SelectedIndex { get { if (_SelectedItem == null)return -1; else return _Checklistitems.IndexOf(_SelectedItem); } }
        // Construktors
        //------------------------------------------------------------------------------------------
        public CheckListBox()
        {
            InitializeComponent();
            //this.SizeChanged += CheckListBox_SizeChanged;
            //this.Scroll += CheckListBox_Scroll;
            //this.AutoScroll = true;
            //this.Padding = new Padding(5);

            this._ItemsList.SizeChanged += CheckListBox_SizeChanged;
            this._ItemsList.Scroll += CheckListBox_Scroll;
            _ItemsList.Location = VisualStyleInformation.IsEnabledByUser ? new Point(1, 1) : new Point(2, 2);
            _ItemsList.Size = new Size(this.Size.Width - 4, this.Size.Height - 4); /*VisualStyleInformation.IsEnabledByUser ? new Size(this.Size.Width - 3, this.Size.Height - 4) : new Size(this.Size.Width - 4, this.Size.Height - 4);/**/
            _ItemsList.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            _ItemsList.AutoScroll = true;
            _ItemsList.BackColor = this.BackColor;
            this.Controls.Add(_ItemsList);
        }
        void CheckListBox_Scroll(object sender, ScrollEventArgs e)
        {
            if(e.Type == ScrollEventType.ThumbTrack)
                Invalidate();
            if (e.Type == ScrollEventType.Last)
                Invalidate();
        }
        void CheckListBox_SizeChanged(object sender, EventArgs e)
        {
            Refresh();
        }
        // Events
        //------------------------------------------------------------------------------------------
        public event EventHandler CompletenessChanged;
        // General Functions
        //------------------------------------------------------------------------------------------
        protected virtual void RedrawList()
        {
            //int totalYPostion = 2;// start row
            //int xOffset = 4;// _ItemsList.VerticalScroll.Visible ? 21 : 4;//VisualStyleInformation.IsEnabledByUser ? 5 :4; // the width of the border 
            //this.Controls.Clear();
            //for (int i = 0; i < _Checklistitems.Count(); i++)
            //{
            //    _Checklistitems[i].Location = new Point(2, totalYPostion);
            //    _Checklistitems[i].Size = new Size(this.ClientRectangle.Width - xOffset, _Checklistitems[i].Size.Height);
            //    _Checklistitems[i].Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            //    _Checklistitems[i].BackColor = this.BackColor;
            //    totalYPostion += _Checklistitems[i].Height + 1;
            //    //this.Controls.Add(_Checklistitems[i]);
            //}
            //this.Controls.AddRange(_Checklistitems.ToArray()); 
            //Invalidate();

            // OLD CODE FROM THEN I USED A PANEL.
            //
            int totalYPostion = 2;// start row
            int xOffset = VisualStyleInformation.IsEnabledByUser ? 2 :4; // the width of the border 
            if (this.Controls.Count != 0) _ItemsList = ((Panel)this.Controls[0]);            
            this.Controls.Remove(_ItemsList);
            _ItemsList.Controls.Clear();
            for (int i = 0; i < _Checklistitems.Count(); i++)
            {
                _Checklistitems[i].Location = new Point(2, totalYPostion);
                _Checklistitems[i].Size = new Size(_ItemsList.ClientRectangle.Width - xOffset, _Checklistitems[i].Size.Height);
                _Checklistitems[i].Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                _Checklistitems[i].BackColor = SystemColors.Window;
                totalYPostion += _Checklistitems[i].Height + 2;
                _ItemsList.Controls.Add(_Checklistitems[i]);
            }
            this.Controls.Add(_ItemsList);
            Invalidate();
        }
        protected virtual void OnCompletenessChanged()
        {
            if (CompletenessChanged != null)
            {
                CompletenessChanged(this, new EventArgs());
            }
        }  
        public virtual void Add(CheckListItem chli)
        {
            chli.ClickDescription += OpenDescription;
            chli.CompletenessChanged += CompletenessChanged;
            chli.Click += Item_Click;
            _Checklistitems.Add(chli);
            RedrawList();
            OnCompletenessChanged();
        }
        public virtual void Clear()
        {
            _Checklistitems.Clear();
            Refresh();
            //OnCompletenessChanged();
        }
        public override void Refresh()
        {
            RedrawList();
        }
        public virtual int IndexOf(CheckListItem chli)
        {
            return _Checklistitems.IndexOf(chli);
        }
        // EventHandlers
        //------------------------------------------------------------------------------------------ 
        protected virtual void OnCompletenessChanged(object sender, EventArgs e)
        {
            if (CompletenessChanged != null)
            {
                CompletenessChanged(sender, e);
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            if (this.Controls.Count != 0) this.Controls[0].BackColor = this.BackColor;
            if (VisualStyleInformation.IsEnabledByUser)
            {
                Pen border = new Pen(new SolidBrush(Color.FromArgb(130, 135, 144)));
                e.Graphics.DrawRectangle(border, this.ClientRectangle.X, this.ClientRectangle.Y, this.ClientRectangle.Width - 1, this.ClientRectangle.Height - 1);//ControlPaint.DrawBorder3D(e.Graphics, this.ClientRectangle, Border3DStyle.Flat);
            }
            else ControlPaint.DrawBorder3D(e.Graphics, new Rectangle(0, 0, this.Size.Width, this.Size.Height), Border3DStyle.Sunken);

        }     
        private void OpenDescription(object sender, EventArgs e)
        {
            RedrawList();
        }
        private void Items_CompletenessChanged(object sender, EventArgs e)
        {
            OnCompletenessChanged(sender, e);
        } 
        private void Item_Click(object sender, EventArgs e)
        {
            CheckListItem cli = (CheckListItem)sender;
            if (SelectedIndex != -1) _Checklistitems[SelectedIndex].Selected = false;
            _Checklistitems[_Checklistitems.IndexOf(cli)].Selected = true;
            _SelectedItem = cli;
        }
    }
}
