using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Windows.Forms;

namespace cine
{
    public class Validaciones
    {
        public static bool ContieneLetrasyEspacios( KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ignora el carácter ingresado
            }
            return true;
        }

        public static bool ContieneNumeros(KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar))
            {
                e.Handled = true; // Ignora el carácter ingresado
            }
            return true;
        }
        public static bool mailValido(string mail)
        {
            if (mail!= string.Empty)
            {
                try
                {
                    MailAddress mailAddress = new MailAddress(mail);
                    return true;
                }
                catch (FormatException)
                {

                    return false;
                }
                
            }
            return false;
        }
    }
}
