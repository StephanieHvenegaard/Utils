using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SHUtils.Forms.Passwords
{
    public class PasswordControl : Form
    {
        public bool bShowPassword = true;
        string sPassword = "";
        public string Password { get { return sPassword; } set { sPassword = value; } }
        public bool ShowPassword { get { return bShowPassword; } set { bShowPassword = value; } }
    }
}
