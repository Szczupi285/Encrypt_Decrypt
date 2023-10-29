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

        // item1 is a letter
        // item2 is a cumulative sum
        public Dictionary<int, (char, int)> dict { get; set; }

        public int LettersHomophonicsCount { get; set; }

        public int iterator { get; set; }

        public int keyIterator { get; set; } = 1;

        public int nextNumIterator { get; set; } = 1;

        public Dictionary<char, List<int>> HomophonicAlphabetEnc { get; set; } = new Dictionary<char, List<int>>();
        public Dictionary<string, char> HomophonicAlphabetDec { get; set; } = new Dictionary<string, char>();

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
            CustomCharacterInput.PreviewTextInput += InputValidation.TextBox_PreviewTextInputHomophonic;
        }




        private void AddMapping_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Window.GetWindow(this) as MainWindow;
            string customCharacter = CustomCharacterInput.Text;

            // if we iterate througth all letters and append homophonics for each of them 
            // encryption/decryption will be automatic
            if (dict.Last().Value.Item2 == iterator)
            {


                if (mainWindow.IsEncryption == true)
                {
                    Encrypt Homophonic = new Encrypt(mainWindow.Algorithm, HomophonicAlphabetEnc,
                    mainWindow.input, mainWindow.language);
                    mainWindow.Result.Text = Homophonic.performEncryption(Homophonic);
                    mainWindow.HomophonicKeyControl.Content = null;

                }
                else
                {
                    Decrypt Homophonic = new Decrypt(mainWindow.Algorithm, HomophonicAlphabetDec,
                    mainWindow.input, mainWindow.language);
                    mainWindow.Result.Text = Homophonic.performDecryption(Homophonic);
                    mainWindow.HomophonicKeyControl.Content = null;
                }

            }
            else if (mainWindow.IsEncryption == true && customCharacter.Length == 3)
            {
                // if iterator is equal to the cumulative sum of current item
                // we increment the keyIterator and move on to the next letter
                if (iterator == dict[keyIterator].Item2)
                    keyIterator++;
                // if the next letter after current onclick event is changing 
                // we display next letter in CurrentLetter textBlock
                // keyIterator + 1 <= dict.Count is a flag so we don't try to display any letter after the last one
                if (iterator == dict[keyIterator].Item2 - 1 && keyIterator + 1 <= dict.Count)
                    this.CurrentLetter.Text = $"Current letter: {dict[keyIterator + 1].Item1}";
                int homophonic;

                if (!string.IsNullOrEmpty(customCharacter) && int.TryParse(customCharacter, out homophonic))
                {
                    MappingListView.Items.Add(new HomophonicKey { Letter = dict[keyIterator].Item1, CustomCharacter = customCharacter });

                    // create instance of a list for every number and add initial homophonic to it.
                    // if list already exist just add a homophonic for it
                    if (HomophonicAlphabetEnc.ContainsKey(dict[keyIterator].Item1))
                        HomophonicAlphabetEnc[dict[keyIterator].Item1].Add(homophonic);
                    else
                    {
                        HomophonicAlphabetEnc.Add(dict[keyIterator].Item1, new List<int> { });
                        HomophonicAlphabetEnc[dict[keyIterator].Item1].Add(homophonic);
                    }






                }

                iterator++;
                CustomCharacterInput.Clear();
            }
            else if (mainWindow.IsEncryption == false && customCharacter.Length == 3)
            {
                // if iterator is equal to the cumulative sum of current item
                // we increment the keyIterator and move on to the next letter
                if (iterator == dict[keyIterator].Item2)
                    keyIterator++;
                // if the next letter after current onclick event is changing 
                // we display next letter in CurrentLetter textBlock
                // keyIterator + 1 <= dict.Count is a flag so we don't try to display any letter after the last one
                if (iterator == dict[keyIterator].Item2 - 1 && keyIterator + 1 <= dict.Count)
                    this.CurrentLetter.Text = $"Current letter: {dict[keyIterator + 1].Item1}";

                if (!string.IsNullOrEmpty(customCharacter))
                {
                    MappingListView.Items.Add(new HomophonicKey { Letter = dict[keyIterator].Item1, CustomCharacter = customCharacter });
                    // for every homophonic we add new record to our dictionary
                    HomophonicAlphabetDec.Add(customCharacter, dict[keyIterator].Item1);
                }

                iterator++;
                CustomCharacterInput.Clear();

            }





        }


    }
}
