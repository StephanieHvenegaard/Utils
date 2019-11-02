using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SHUtils.Util.LigthComponents
{
    public partial class SkadaFlashLamp : Control
    {    
        // delegates.
        delegate void NoParamiter_callback();
        Color cLigthColor = Color.Red;
        bool bBlinking = true;
        bool bActive = true;
        bool bCreateAndSave = true;
        int iBrushTransparency = 127;
        Thread t;
       // Bitmap Background;
        // Declare delegate for submit button clicked.
        // by Akadia.com
        // Most action events (like the Click event) in Windows Forms
        // use the EventHandler delegate and the EventArgs arguments.
        // We will define our own delegate that does not specify parameters.
        // Mostly, we really don't care what the conditions of the
        // click event for the button were, we just care that
        // the button was clicked.
        public delegate void ClickedHandler();

        public SkadaFlashLamp()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.Opaque, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            this.BackColor = Color.Transparent;
        }
        public void GetBackground()
        {
            System.Drawing.Bitmap flag = new System.Drawing.Bitmap(this.Width, this.Height);
          //string start = DateTime.Now.ToString();
            for (int x = 1; x < flag.Width; ++x)
            {
                for (int y = 1; y < flag.Height; ++y)
                {
                   
                   //this.FindForm().PointToClient
                    Point p =  this.Parent.PointToScreen(this.Location);
                    Color c = GetPixelColor(x+ p.X , y+p.Y );
                    flag.SetPixel(x, y, c);
                }
            }
            BackgroundImage = flag;
           // MessageBox.Show(start + " - " +DateTime.Now.ToString());
            if(bCreateAndSave)BackgroundImage.Save("C://"+this.Name+".bmp");
        }
        [DllImport("user32.dll")]
        static extern IntPtr GetDC(IntPtr hwnd);
        [DllImport("user32.dll")]
        static extern Int32 ReleaseDC(IntPtr hwnd, IntPtr hdc);
        [DllImport("gdi32.dll")]
        static extern uint GetPixel(IntPtr hdc, int nXPos, int nYPos);
        static public System.Drawing.Color GetPixelColor(int x, int y)
        {
            
            IntPtr hdc = GetDC(IntPtr.Zero);
            uint pixel = GetPixel(hdc, x, y);
            ReleaseDC(IntPtr.Zero, hdc);
            Color color = Color.FromArgb((int)(pixel & 0x000000FF),
                         (int)(pixel & 0x0000FF00) >> 8,
                         (int)(pixel & 0x00FF0000) >> 16);
            return color;
        }
        [Browsable(false)]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
            }
        }
        [Browsable(true)]
        [Category("Graphics")]
        public bool BlinkingMode
        {
            get {
                return bBlinking;
            }
            set {
                if (value == false)
                {
                    iBrushTransparency = 127;
                }
                bBlinking = value;
            }
        }
        [Browsable(true)]
        [Category("Graphics")]
        public bool Active
        {
            get { return bActive; }
            set { bActive = value; }
        }
        [Browsable(true)]
        [Category("Graphics")]
        [Description("Allow this control to create a copy of the background and save it at C://")]
        public bool CreateAndSaveBackground
        {
            get { return bCreateAndSave; }
            set { bCreateAndSave = value; }
        }
        [Browsable(true)]
        [Category("Graphics")]
        public Color LigthColor
        {
            get { return cLigthColor; }
            set { cLigthColor = value; }
        }
        
        public void SetError()
        {
            cLigthColor = Color.Red;
        }
        public void SetWarning()
        {
            cLigthColor = Color.Yellow;
        }
        public void SetCustomLigthColor(Color toUse)
        {
            cLigthColor = toUse;
        }
        public void LigthOn()
        {
            if (!bActive)
            {
                Show();
                bActive = true;
                if (BackgroundImage == null) GetBackground();
                if (bBlinking)
                {
                    t = new Thread(new ThreadStart(Blinking));
                    t.IsBackground = true;
                    t.Start();
                }
                this.Invalidate();
            }
        }
        public void LigthOff()
        {
            bActive = false;
            if(t != null)  t.Abort();
            Hide();
            this.Invalidate();

        }
        private void Blinking()
        {
            iBrushTransparency = 0;
            bool Direction = true; // From Trans to Colors;
            while (bActive)
            {
                if (iBrushTransparency >=120)
                {
                    Direction = true;
                }
                if (iBrushTransparency <= 0)
                {
                    Direction = false;
                }
                if (Direction)
                {
                    iBrushTransparency = iBrushTransparency - 20;
                }
                else
                {
                    iBrushTransparency = iBrushTransparency+ 20;
                } 
                Thread.Sleep(150);
                //this.Invalidate();
                ReFreshLigth();
            }
        }
        private void ReFreshLigth()
        {
            try
            {

                if (this.InvokeRequired)
                {
                    this.Invoke(new NoParamiter_callback(ReFreshLigth), new object[] {});
                }
                else
                {
                    this.Refresh();
                }
            }
            catch (InvalidOperationException)
            {
                return;
            }

        }
        protected override void OnPaint(PaintEventArgs pevent)
        {  
            Graphics g = pevent.Graphics;
            Pen pPen = new Pen(Color.FromArgb(0,0,0,0));
           
            g.DrawRectangle(pPen, this.ClientRectangle);
            if (BackgroundImage != null) g.DrawImage(BackgroundImage, this.ClientRectangle);
            //  error Event. 
            if (bActive)
            {
                Color cColor = Color.FromArgb(iBrushTransparency, cLigthColor);
                SolidBrush sbBrush = new SolidBrush(cColor);
                g.FillRectangle(sbBrush, this.ClientRectangle);
                sbBrush.Dispose();
            } 
            // Clean up
            g.Dispose();
            pPen.Dispose();
           
        }
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            // don't call the base class
            //base.OnPaintBackground(pevent);
        }
        protected override CreateParams CreateParams
        {
            // the beuti of getting transparrent. 
            get
            {
                const int WS_EX_TRANSPARENT = 0x20;
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= WS_EX_TRANSPARENT;
                return cp;
            }
        }
        //{
        //    SetStyle(ControlStyles.Opaque |
        //    ControlStyles.UserPaint |
        //    ControlStyles.DoubleBuffer,  true);    

        //    InitializeComponent();
        // //   BackColor = Color.FromArgb(128, LampColor);
        //}

        //protected override void OnPaint(PaintEventArgs pe)
        //{
        //    int brushTransparency = 127;
        //    Color bRed = Color.FromArgb(brushTransparency, 255, 0, 0);
        //    BackColor = bRed;
        //}
        ////// Declare the event, which is associated with our
        ////// delegate SubmitClickedHandler(). Add some attributes
        ////// for the Visual C# control property.
        ////[Category("Action")]
        ////[Description("Fires when the Submit button is clicked.")]
        ////public event SubmitClickedHandler SubmitClicked;

    }
}
