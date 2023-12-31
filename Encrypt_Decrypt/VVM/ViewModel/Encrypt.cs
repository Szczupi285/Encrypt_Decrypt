﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Encrypt_Decrypt.VVM.ViewModel;

namespace Encrypt_Decrypt.VVM.ViewModel
{

    internal class Encrypt : LanguageOperations
    {
        private string EncryptionAlgorithm { get; }

        private string EncryptionKey { get; }

        private TextBox[,] TextBoxes { get; }

        private Dictionary<char, List<int>> HomophonicKey { get; }

        private string Input { get; }

        private string Language { get; }

       
        
        public Encrypt(string algorithm, string key, string input, string language)
        {
            EncryptionAlgorithm = algorithm;
            EncryptionKey = key;
            Input = input.ToLower().Replace(" ", "");
            Language = language;
        }

        public Encrypt(string algorithm, TextBox[,] textBoxes, string input, string language)
        {
            EncryptionAlgorithm = algorithm;
            TextBoxes = textBoxes;
            Input = input.ToLower().Replace(" ", "");
            Language = language;
        }

        public Encrypt(string algorithm, Dictionary<char, List<int>> homophonicKey, string input, string language)
        {
            EncryptionAlgorithm = algorithm;
            HomophonicKey = homophonicKey;
            Input = input.ToLower().Replace(" ", "");
            Language = language;
        }



        public string performEncryption(Encrypt encrypt)
        {
            if (encrypt.EncryptionAlgorithm == "Caesar cipher")
                return encryptCaesarCipher(encrypt.Language);
            else if (encrypt.EncryptionAlgorithm == "Polybius cipher")
                return encryptPolybiusCipher(encrypt.Language);
            else if (encrypt.EncryptionAlgorithm == "Homophonic cipher")
                return encryptHomophonicCipher();
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

        // prime numbers swap
        private string encryptPolybiusCipher(string language)
        {


            Dictionary<char, string> dict = LanguageOperations.PolybiusDictionary(TextBoxes);
            string result = "";

            string input = "";
            if (language == "english")
                input = Input.Replace('j', 'i');
            else
                input = Input;

            foreach(char letter in input)
            {
                result += dict[letter];
            }

            return result;
        }

        // language right here is not required as we only allow the
        // current language characters in view
        private string encryptHomophonicCipher()
        {


            Random random = new Random();

            string result = "";

            foreach(char letter in Input)
            {
                // create temporary list to store all homophonics for current letter
                List<int> temp = HomophonicKey[letter];

                int randomNum = random.Next(0, temp.Count - 1);
                result += temp[randomNum];
                
            }
            return result;


        }


    }

}


