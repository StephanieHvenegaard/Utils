using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SHUtils.Util.Time
{
    public class ConvertToTime
    {
        public string GetTimefromMilliesec(int ms)
        {
            string s = "";
            int imsec;
            int isec;
            int imin;
            int iHou;
            // Calcullate Hours minutes secound and millie
            imsec = ms;
            isec = ms / 1000;
            imin = isec / 60;
            iHou = imin / 60;


            imin = imin - (iHou * 60);//imin % iHou;
            isec = isec - ((imin * 60)+(iHou * 3600));//imin % iHou;;//isec % imin;
            imsec = ms - ((isec + (imin * 60) + (iHou * 3600)) * 1000);

            // Create the line
            if (iHou != 0)
            {
                if (iHou > 1) s += iHou.ToString() + " Hours";
                else s += iHou.ToString() + " Hour";
            }
            if (imin != 0)
            {
                if (s != "") s += ", ";
                if (imin > 1) s += imin.ToString() + " Minutes";
                else s += imin.ToString() + " Minute";
            }

            if (isec != 0)
            {
                if (s != "") s += ", ";
                if (isec > 1) s += isec.ToString() + " Seconds";
                else s += isec.ToString() + " Second";
            }
            if (imsec != 0)
            {
                if (s != "") s += " and ";
                if (imsec > 1) s += imsec.ToString() + " Milliseconds";
                else s += imsec.ToString() + " Millisecond";
            }
            return s;
        }
        public string GetTimefromMilliesecDK(int ms)
        {
            string s = "";
            int imsec;
            int isec;
            int imin;
            int iHou;
            // Calcullate Hours minutes secound and millie
            imsec = ms;
            isec = ms / 1000;
            imin = isec / 60;
            iHou = imin / 60;


            imin = imin - (iHou * 60);//imin % iHou;
            isec = isec - ((imin * 60) + (iHou * 3600));//imin % iHou;;//isec % imin;
            imsec = ms - ((isec + (imin * 60) + (iHou * 3600)) * 1000);

            // Create the line
            if (iHou != 0)
            {
                if (iHou > 1) s += iHou.ToString() + " Timer";
                else s += iHou.ToString() + " Time";
            }
            if (imin != 0)
            {
                if (s != "") s += ", ";
                if (imin > 1) s += imin.ToString() + " Minuter";
                else s += imin.ToString() + " Minut";
            }

            if (isec != 0)
            {
                if (s != "") s += ", ";
                if (isec > 1) s += isec.ToString() + " sekunder";
                else s += isec.ToString() + " sekund";
            }
            if (imsec != 0)
            {
                if (s != "") s += " og ";
                if (imsec > 1) s += imsec.ToString() + " millisekunder";
                else s += imsec.ToString() + " millisekund";
            }
            return s;
        }
    }
}
