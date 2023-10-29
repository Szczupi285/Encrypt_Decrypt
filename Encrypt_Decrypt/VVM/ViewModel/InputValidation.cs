using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Text.RegularExpressions;

namespace Encrypt_Decrypt.VVM.ViewModel
{
    public class InputValidation
    {
        public static void TextBox_PreviewTextInputPolish(object sender, TextCompositionEventArgs e)
        {
            string regex = @"^[aąbcćdeęfghijklłmnńoóprsśtuwyzźż]$";
            if (Regex.IsMatch(e.Text, regex))
            {

            }
            else
                e.Handled = true;

        }
       

        public static void TextBox_PreviewTextInputPolishXVQ(object sender, TextCompositionEventArgs e)
        {
            string regex = @"^[aąbcćdeęfghijklłmnńoópqrsśtuvwxyzźż]$";
            if (Regex.IsMatch(e.Text, regex))
            {

            }
            else
                e.Handled = true;

        }

        public static void TextBox_PreviewTextInputPolybiusEnglish(object sender, TextCompositionEventArgs e)
        {
            string regex = @"^[abcdefghiklmnopqrstuwvxyz]$";
            if (Regex.IsMatch(e.Text, regex))
            {

            }
            else
                e.Handled = true;

        }
        public static void TextBox_PreviewTextInputEnglish(object sender, TextCompositionEventArgs e)
        {
            string regex = @"^[a-z]$";
            if (Regex.IsMatch(e.Text, regex))
            {

            }
            else
                e.Handled = true;

        }
        public static void TextBox_PreviewTextInputHomophonic(object sender, TextCompositionEventArgs e)
        {
            string regex = @"^[1-9]+$";
            if (Regex.IsMatch(e.Text, regex))
            {

            }
            else
                e.Handled = true;

        }





    }
}
