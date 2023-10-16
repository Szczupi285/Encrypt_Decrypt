using Encrypt_Decrypt.VVM.VIewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Encrypt_Decrypt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CaesarKey caesarKey;

        public string Key;

        public string input;

        public string Algorithm;

        public string language;
        public MainWindow()
        {
            InitializeComponent();
            caesarKey = new CaesarKey();
        }

        public void hide()
        {
            CaesarsKeyControl.Content = null;
        }

        #region ENCRYPTION
        private void BtnEncrypt_Click(object sender, RoutedEventArgs e)
        {

            caesarKey.IsEncryption = true;

            input = txtInputEncrypt.Text;
            Algorithm = comboBoxEncrypt.Text;
            language = comboBoxLangEncrypt.Text;
            
            if(Algorithm == "Caesar cipher")
                CaesarsKeyControl.Content = caesarKey;

        }
        

        #endregion

        #region DECRYPTION
        private void BtnDecrypt_Click(object sender, RoutedEventArgs e)
        {
            caesarKey.IsEncryption = false;

            input = txtInputDecrypt.Text;
            Algorithm = comboBoxDecrypt.Text;
            language = comboBoxLangDecrypt.Text;

            if (Algorithm == "Caesar cipher")
                CaesarsKeyControl.Content = caesarKey;
        }
        #endregion
    }
}
