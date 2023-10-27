using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Encrypt_Decrypt.VVM.ViewModel
{
    internal class Decrypt : LanguageOperations
    {

        private string DecryptionAlgorithm { get; }

        private string DecryptionKey { get; }

        private TextBox[,] TextBoxes { get; }
        private string Input { get; }

        private string Language { get; }

        public Decrypt(string algorithm, string key, string input, string language)
        {
            DecryptionAlgorithm = algorithm;
            DecryptionKey = key;
            Input = input.ToLower().Replace(" ", "");
            Language = language;
        }

        public Decrypt(string algorithm, TextBox[,] textBoxes, string input, string language)
        {
            DecryptionAlgorithm = algorithm;
            TextBoxes = textBoxes;
            Input = input.ToLower().Replace(" ", "");
            Language = language;
        }



        public string performDecryption(Decrypt decrypt)
        {
            if (decrypt.DecryptionAlgorithm == "Caesar cipher")
            {
                return decryptCaesarCipher(decrypt.Language);

            }
            else if(decrypt.DecryptionAlgorithm == "Polybius cipher")
            {
                return decryptPolybiusCipher(decrypt.Language);
            }
            else 
                throw new ArgumentException("This encryption algorithm is not supported");
        }

        




        private string decryptCaesarCipher(string language) 
        {
            Dictionary<int, char> dict = CreateDictionary(language);

            int decKey = Convert.ToInt32(DecryptionKey);

            char[] letters = Input.Replace(" ", "").ToCharArray();
            string result = "";

            foreach (char letter in letters)
            {
                int key = dict.First(pair => pair.Value == letter).Key;
                int keyAfterChange = (key - decKey) % dict.Count;

                // if modulo returns 0 that means the letter did a whole loop and is itself again
                if (keyAfterChange == 0)
                    result += dict[dict.Count];
                else if(keyAfterChange < 0)
                    result += dict[dict.Count + keyAfterChange];
                else
                    result += dict[keyAfterChange];

            }

            return result;
        }


        private string decryptPolybiusCipher(string language)
        {

            Dictionary<string, char> dict = LanguageOperations.PolybiusDictionaryStringChar(TextBoxes);
            string result = "";

            string input = "";
            if (language == "english")
                input = Input.Replace('j', 'i');
            else
                input = Input;

            for (int i = 0; i < input.Length; i+=2)
            {
                result += dict[$"{input[i]}{input[i + 1]}"];
            }

            return result;
        }



    }
}
