using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
//using IAI.Util.Math;

namespace SHUtils.Forms.MessegeBoxes
{
    public partial class AutoResizeMessageBox : Form
    {
        int MaxCharsPerLine = 70;
        int CharacterWidth = 7;
        int CharacterHeight = 11;
        int borderHigth = 38; // the Size of the header and lower border combined. 
        int BorderWidth = SystemInformation.FrameBorderSize.Width; // The Size of the Border/Frame on left and rigth is 132
        int PaddingXY = 20; // the Amaunt of Free Space From the Border to the text aria.
        //  NumberConvertion NB = new NumberConvertion();
        public AutoResizeMessageBox(string Messege)
        {
            InitializeComponent();
            SetSizeandText(Messege);

            //tbTextAria.Select(0, 0);
            //tbTextAria.Location = new Point(PaddingXY,PaddingXY);

            this.Activate();
        }
        public AutoResizeMessageBox(string Messege, int maxChars)
        {
            MaxCharsPerLine = maxChars;
            InitializeComponent();
            if (((MaxCharsPerLine*CharacterWidth) + PaddingXY + PaddingXY) < 132)
            {
                int CharsTooAdd = MaxCharsPerLine + PaddingXY + PaddingXY;
                CharsTooAdd = 132 - CharsTooAdd;
                MaxCharsPerLine += CharsTooAdd;
            }
            SetSizeandText(Messege);

            //tbTextAria.Select(0, 0);
            //tbTextAria.Location = new Point(PaddingXY, PaddingXY);

            this.Activate();
        }
        public AutoResizeMessageBox(string Messege, int maxChars, int Padding)
        {
            MaxCharsPerLine = maxChars;
            PaddingXY = Padding;
            InitializeComponent();
            if (((MaxCharsPerLine * CharacterWidth) + PaddingXY + PaddingXY) < 132)
            {
                int CharsTooAdd = MaxCharsPerLine + PaddingXY + PaddingXY;
                CharsTooAdd = 132 - CharsTooAdd;
                MaxCharsPerLine += CharsTooAdd/CharacterWidth;
            }
            SetSizeandText(Messege);

            this.Activate();
        }
        public void ChangeText(string Messege)
        {
            SetSizeandText(Messege);

        }
        private void SetSizeandText(string messege)
        {
            string Working = "";
            double lines = 0.0;
            //lines = messege.Length * 1.0 / MaxCharsPerLine;
            //lines = NB.RoundToHighestInt(lines);
            int i = 0;
            while (true)
            {
                if (messege.Contains("\r\n"))
                {
                    string[] arStr = Regex.Split(messege, "\r\n");
                    lines = arStr.Length;
                    for (i = 0; i < arStr.Length; i++)
                    {

                        if (arStr[i].Length > MaxCharsPerLine)
                        {
                            int lineindex = 0;
                            while (true)
                            {
                                string s = arStr[i].Substring(lineindex, MaxCharsPerLine);
                                if (s.Substring(0, 1) == " ") s = s.Remove(0, 1);
                                string lastchar = arStr[i].Substring(MaxCharsPerLine + lineindex - 1, 1);
                                string nextchar = arStr[i].Substring(MaxCharsPerLine + lineindex, 1);
                                int index = s.Length;
                                if (lastchar != " " && nextchar != " ")
                                {
                                    while (true)
                                    {
                                        string spacechar = s.Substring(index - 1, 1);
                                        if (spacechar == " ")
                                        {
                                            break;
                                        }
                                        index--;
                                        if (index == 0)
                                        {
                                            index = s.Length;
                                            break;
                                        }
                                    }
                                    s = s.Substring(0, index);
                                    lineindex = lineindex + index;
                                }
                                else
                                {
                                    lineindex = lineindex + MaxCharsPerLine;
                                }
                                Working = Working + s + "\r\n";
                                lines++;
                                if ((lineindex + MaxCharsPerLine) >= arStr[i].Length)
                                {
                                    s = arStr[i].Substring(lineindex, (arStr[i].Length - lineindex));
                                    if (s.Substring(0, 1) == " ") s = s.Remove(0, 1);
                                    Working = Working + s;
                                    //  lines++;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            Working += arStr[i] + "\r\n";
                        }
                    }  
                    break;
                }
                if (MaxCharsPerLine <= messege.Length)
                {
                    string s = messege.Substring(i, MaxCharsPerLine);
                    if (s.Substring(0, 1) == " ") s = s.Remove(0, 1);
                    string lastchar = messege.Substring(MaxCharsPerLine + i - 1, 1);
                    string nextchar = messege.Substring(MaxCharsPerLine + i, 1);
                    int index = s.Length;
                    if (lastchar != " " && nextchar != " ")
                    {
                        while (true)
                        {
                            string spacechar = s.Substring(index - 1, 1);
                            if (spacechar == " ")
                            {
                                break;
                            }
                            index--;
                            if (index == 0)
                            {
                                index = s.Length;
                                break;
                            }
                        }
                        s = s.Substring(0, index);
                        i = i + index;
                    }
                    else
                    {
                        i = i + MaxCharsPerLine;
                    }
                    Working = Working + s + "\r\n";
                    lines++;
                    if ((i + MaxCharsPerLine) >= messege.Length)
                    {
                        s = messege.Substring(i, (messege.Length - i));
                        if (s.Substring(0, 1) == " ") s = s.Remove(0, 1);
                        Working = Working + s;
                        lines++;
                        break;
                    }
                }
                else
                {
                    Working = messege;
                    lines = 1;
                    break;
                }
            }
            tbTextAria.Height = Convert.ToInt32(lines) * CharacterHeight;
            tbTextAria.Width = MaxCharsPerLine * CharacterWidth;
            Height = PaddingXY + (Convert.ToInt32(lines) * CharacterHeight) + PaddingXY + borderHigth;
            Width = PaddingXY + (MaxCharsPerLine * CharacterWidth) + PaddingXY + (BorderWidth * 2);
            tbTextAria.Text = Working;
            tbTextAria.Select(0, 0);
            tbTextAria.Location = new Point(PaddingXY, PaddingXY);
        }
    }
}

