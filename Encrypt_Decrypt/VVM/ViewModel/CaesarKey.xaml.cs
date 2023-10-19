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
using Encrypt_Decrypt;
using Encrypt_Decrypt.VVM.ViewModel;

namespace Encrypt_Decrypt.VVM.ViewModel
{
    /// <summary>
    /// Logika interakcji dla klasy CaesarKey.xaml
    /// </summary>
    public partial class CaesarKey : UserControl
    {
        public bool IsEncryption { get; set; }

        public CaesarKey()
        {
            InitializeComponent();
        }

        private void CaesarsKey_Click(object sender, RoutedEventArgs e)
        {
            // validation
            if (keyInput.Text is null || keyInput.Text.Length == 0 || !int.TryParse(keyInput.Text, out _))
                keyInput.Text = "Wrong input";
            else
            {
                // gets the parent reference
                var mainWindow = Window.GetWindow(this) as MainWindow;
                mainWindow.Key = keyInput.Text;


                // encrypt/decrypt using parents properties already set in BtnEncrypt_Click/BtnDecrypt_Click
                if (IsEncryption == true)
                {
                    Encrypt caesar = new Encrypt(mainWindow.Algorithm, mainWindow.Key,
                    mainWindow.input, mainWindow.language);
                    mainWindow.Result.Text = caesar.performEncryption(caesar);
                }
                else
                {
                    Decrypt caesar = new Decrypt(mainWindow.Algorithm, mainWindow.Key,
                    mainWindow.input, mainWindow.language);
                    mainWindow.Result.Text = caesar.performDecryption(caesar);
                }
                    



                mainWindow!.CaesarsKeyControl.Content = null;
            }
           
        }
    }
}
