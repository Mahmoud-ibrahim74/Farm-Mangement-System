using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FMS
{
    static class RegularExepression
    {
        static Regex reg = new Regex(@"^-?\d+[.]?\d*$");

        public static Regex PostiveOrNegative
        {
            get { return reg; }
        }

        public static void ValidationofDecimalPoint(object sender, KeyPressEventArgs e,Guna.UI2.WinForms.Guna2TextBox amount)
        {           
            char ch = e.KeyChar;
            decimal x;
            if (ch == (char)Keys.Back)
            {
                e.Handled = false;
            }
            else if (!char.IsDigit(ch) && ch != '.' || !Decimal.TryParse(amount.Text + ch, out x))
            {
                e.Handled = true;
            }
        }

    }
}
