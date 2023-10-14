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
        public MainWindow()
        {
            InitializeComponent();
        }

        #region ENCRYPTION
        private void BtnEncrypt_Click(object sender, RoutedEventArgs e)
        {
            string inputToEncrypt = txtInputEncrypt.Text;
            string encryptingAlgorithm = comboBoxEncrypt.Text;
        }

        #endregion

        #region DECRYPTION
        private void BtnDecrypt_Click(object sender, RoutedEventArgs e)
        {
            string inputToDecrypt = txtInputDecrypt.Text;
            string decryptingAlgorithm = comboBoxDecrypt.Text;
        }
        #endregion
    }
}
