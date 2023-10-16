using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encrypt_Decrypt.VVM.ViewModel
{
    internal class Decrypt : CreateDictionaries
    {

        private string DecryptionAlgorithm { get; }

        private string DecryptionKey { get; }

        private string Input { get; }

        private string Language { get; }

        public Decrypt(string algorithm, string key, string input, string language)
        {
            DecryptionAlgorithm = algorithm;
            DecryptionKey = key;
            Input = input.ToLower();
            Language = language;
        }



        public string performDecryption(Decrypt decrypt)
        {
            if (decrypt.DecryptionAlgorithm == "Caesar cipher")
            {
                return decryptCaesarCipher(decrypt.Language);

            }
            else
                throw new ArgumentException("This encryption algorithm is not supported");
        }


        private string decryptCaesarCipher(string language) 
        {
            Dictionary<int, char> dict = CreateDictionary(language);

            int encKey = Convert.ToInt32(DecryptionKey);

            char[] letters = Input.Replace(" ", "").ToCharArray();
            string result = "";

            foreach (char letter in letters)
            {
                int key = dict.First(pair => pair.Value == letter).Key;

                // if modulo returns 0 that means the letter did a whole loop and is itself again
                if ((key - encKey) % dict.Count == 0)
                    result += dict[dict.Count];
                else
                    result += dict[(key - encKey) % dict.Count];
            }

            return result;
        }

       
    }
}
