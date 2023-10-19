using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Encrypt_Decrypt.VVM.ViewModel
{

    internal class Encrypt : LanguageOperations
    {
        private string EncryptionAlgorithm { get; }
        
        private string EncryptionKey { get; }

        private TextBox[,] TextBoxes { get; }

        private string Input { get; }

        private string Language { get; }

       
        
        public Encrypt(string algorithm, string key, string input, string language)
        {
            EncryptionAlgorithm = algorithm;
            EncryptionKey = key;
            Input = input.ToLower();
            Language = language;
        }

        public Encrypt(string algorithm, TextBox[,] textBoxes, string input, string language)
        {
            EncryptionAlgorithm = algorithm;
            TextBoxes = textBoxes;
            Input = input.ToLower();
            Language = language;
        }



        public string performEncryption(Encrypt encrypt)
        {
            if(encrypt.EncryptionAlgorithm == "Caesar cipher")
            {
                return encryptCaesarCipher(encrypt.Language);
            }
            else if(encrypt.EncryptionAlgorithm == "Polybius cipher")
            {
                throw new NotImplementedException();
            }
            else 
                throw new ArgumentException("This encryption algorithm is not supported");
        }


        private string encryptCaesarCipher(string language)
        {
            Dictionary<int, char> dict = CreateDictionary(language);
            
            int encKey = Convert.ToInt32(EncryptionKey);

            char[] letters = Input.Replace(" ", "").ToCharArray();
            string result = "";

            foreach (char letter in letters)
            {
                int key = dict.First(pair => pair.Value == letter).Key;
                
                // if modulo returns 0 that means the letter did a whole loop and is itself again
                if ((key + encKey) % dict.Count == 0)
                    result += dict[dict.Count];
                else
                    result += dict[(key + encKey) % dict.Count];
            }

            return result;

        }

        private string encryptPolybiusCipher(TextBox[,] textBoxes)
        {


            throw new NotImplementedException();


        }



    }

}


