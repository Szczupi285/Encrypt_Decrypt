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
using Encrypt_Decrypt.VVM.ViewModel;

namespace Encrypt_Decrypt.VVM.ViewModel
{
    /// <summary>
    /// Logika interakcji dla klasy HomophonicKey.xaml
    /// </summary>
    public partial class HomophonicKey : UserControl
    {
        public char Letter { get; set; }
        public string CustomCharacter { get; set; }

        // item1 is a letter, item 2 is a number of Homophonics that this letter have
        // item3 is a cumulative sum
        public Dictionary<int, (char, int, int)> dict { get; set; }

        public int LettersHomophonicsCount { get; set; }

        public int iterator { get; set; }

        public int keyIterator { get; set; } = 1;

        public int nextNumIterator {get;set;} = 1;

        public HomophonicKey()
        {
            InitializeComponent();

        }

        // dictionary initialized here because mainWindow.language
        // is not know while initializing component
        public void InitializeProperties()
        {
            var mainWindow = Window.GetWindow(this) as MainWindow;
            dict = LanguageOperations.HomophonicDictionary(mainWindow.language);

            LettersHomophonicsCount = dict.Values.Last().Item2;

            this.CurrentLetter.Text = $"Current letter: {dict.Values.First().Item1}";
        }




        private void AddMapping_Click(object sender, RoutedEventArgs e)
        {
            string customCharacter = CustomCharacterInput.Text;
            
            if (iterator == dict[keyIterator].Item3)
                keyIterator++;
            if (iterator == dict[keyIterator].Item3 - 1)
                this.CurrentLetter.Text = $"Current letter: {dict[keyIterator + 1].Item1}";

            if (!string.IsNullOrEmpty(customCharacter))
            {
                MappingListView.Items.Add(new HomophonicKey { Letter = dict[keyIterator].Item1 , CustomCharacter = customCharacter });
            }

            iterator++;

           

            CustomCharacterInput.Clear();
        }



    }

   
}
