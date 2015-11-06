using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftLogic.Win.Security.Support
{
    using ImageIcon = System.Drawing.Image;
    using JPasswordDialog = SoftLogik.Win.Security.ChangePasswordForm;

    public class Hashcypher
    {


        /// Creates a new instance of Hashcypher 
        public Hashcypher()
        {
        }


        public static bool authenticate(string sPassword, string sHashPassword)
        {
            if (sHashPassword == null || sHashPassword.Equals("") || sHashPassword.StartsWith("empty:"))
            {
                return sPassword == null || sPassword.Equals("");
            }
            else if (sHashPassword.StartsWith("sha1:"))
            {
                return sHashPassword.Equals(hashString(sPassword));
            }
            else if (sHashPassword.StartsWith("plain:"))
            {
                return sHashPassword.Equals("plain:" + sPassword);
            }
            else
            {
                return sHashPassword.Equals(sPassword);
            }
        }

        public static string hashString(string sPassword)
        {

            if (sPassword == null || sPassword.Equals(""))
            {
                return "empty:";
            }
            else
            {
                try
                {
                    MessageDigest md = MessageDigest.getInstance("SHA-1");
                    md.update(sPassword.getBytes("UTF-8"));
                    sbyte[] res = md.digest();
                    return "sha1:" + StringUtils.byte2hex(res);
                }
                catch (NoSuchAlgorithmException e)
                {
                    return "plain:" + sPassword;
                }
                catch (UnsupportedEncodingException e)
                {
                    return "plain:" + sPassword;
                }
            }
        }

        public static string changePassword(Component parent)
        {
            // Show the changePassword dialogs but do not check the old password

            string sPassword = JPasswordDialog.showEditPassword(parent, AppLocal.getIntString("Label.Password"), AppLocal.getIntString("label.passwordnew"), new ImageIcon(typeof(Hashcypher).getResource("/com/softlogik/images/password.png")));
            if (sPassword != null)
            {
                string sPassword2 = JPasswordDialog.showEditPassword(parent, AppLocal.getIntString("Label.Password"), AppLocal.getIntString("label.passwordrepeat"), new ImageIcon(typeof(Hashcypher).getResource("/com/softlogik/images/password.png")));
                if (sPassword2 != null)
                {
                    if (sPassword.Equals(sPassword2))
                    {
                        return Hashcypher.hashString(sPassword);
                    }
                    else
                    {
                        JOptionPane.showMessageDialog(parent, AppLocal.getIntString("message.changepassworddistinct"), AppLocal.getIntString("message.title"), JOptionPane.WARNING_MESSAGE);
                    }
                }
            }

            return null;
        }


        public static string changePassword(Component parent, string sOldPassword)
        {

            string sPassword = JPasswordDialog.showEditPassword(parent, AppLocal.getIntString("Label.Password"), AppLocal.getIntString("label.passwordold"), new ImageIcon(typeof(Hashcypher).getResource("/com/softlogik/images/password.png")));
            if (sPassword != null)
            {
                if (Hashcypher.authenticate(sPassword, sOldPassword))
                {
                    return changePassword(parent);
                }
                else
                {
                    JOptionPane.showMessageDialog(parent, AppLocal.getIntString("message.BadPassword"), AppLocal.getIntString("message.title"), JOptionPane.WARNING_MESSAGE);
                }
            }
            return null;
        }
    }

}
