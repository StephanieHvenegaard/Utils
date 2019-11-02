using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SHUtils.Forms.Passwords
{
    public class PasswordProtected : Form
    {
        public PasswordProtected(){}
        //public void PasswordProtectedForm_Load(object sender, EventArgs e)
        //{
        //    if (PasswordController != null)
        //    {
        //        ShowPasswordBox_Loading();
        //    }
        //    else
        //    {
        //        throw new NullReferenceException();
        //    }
        //}
        /// <summary>
        /// This if password is typed in wrongly 
        /// Close the form wit out question.
        /// </summary>
        public void ShowPasswordBox_Loading()
        {
            bool Continue = ShowPasswordBox();
            if (!Continue)
            {
                this.Close();
            }
        }
        /// <summary>
        /// this is the les drastic virsion 
        /// here we just return a bool and let the future deside wha to do
        /// </summary>
        /// <returns>true if password matched or false if not</returns>
        public bool ShowPasswordBox()
        {
            if (PasswordController != null)
            {
                try
                {

                    if (PasswordController.ShowPassword)
                    {
                        Passwordbox ps = new Passwordbox(PasswordController.Password);
                        DialogResult Result = ps.ShowDialog();
                        if (Result == System.Windows.Forms.DialogResult.OK)
                        {
                            PasswordController.ShowPassword = false;
                            return true;
                        }
                        return false;
                    }
                    PasswordController.ShowPassword = false;
                    return true;
                }
                catch (InvalidOperationException)
                {
                    PasswordController.ShowPassword = false;
                    return true;
                }
            }
            else
            {
                throw new NullReferenceException();
            }
        }
        public bool CheckIFPasswordStatusClear()
        {
            if (PasswordController != null)
            {
                if (PasswordController.bShowPassword)
                {
                    if (PasswordController.Password == "")
                    {
                        PasswordController.bShowPassword = false;
                        return true;
                    }
                }
                else
                {
                    return true;
                }

                return false;
            }
            else
            {
                throw new NullReferenceException();
            }
        }
        public PasswordControl PasswordController{get;set;}
    }
}
