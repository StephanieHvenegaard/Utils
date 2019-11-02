using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SHUtils.Controls.Helpers
{
    public static class RenderHelper
    {
        public static int DropDownWidth(ComboBox cbox)
        {
            int maxWidth = 0;
            int temp = 0;
            using (Label label1 = new Label())
            {

                foreach (var obj in cbox.Items)
                {
                    label1.Text = obj.ToString();
                    temp = label1.PreferredWidth;
                    if (temp > maxWidth)
                    {
                        maxWidth = temp;
                    }
                }
            }
            return maxWidth;
        }
    }
}
