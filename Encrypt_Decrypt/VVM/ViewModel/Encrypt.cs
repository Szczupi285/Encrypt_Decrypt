using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace Encrypt_Decrypt.VVM.ViewModel
{

    internal class Encrypt
    {
        private string EncryptionAlgorithm { get; set; }
        
        private string EncryptionKey { get; set; }
        
        private string Input { get; set; }

        private string Language { get; set; }

       
        
        public Encrypt(string algorithm, string key, string input, string language)
        {
            EncryptionAlgorithm = algorithm;
            EncryptionKey = key;
            Input = input;
            Language = language;
        }

        #region CreateDictionary

        /// <summary>
        /// Creates a dictionary with integer keys and character values based on the specified type.
        /// </summary>
        /// <param name="type">
        /// The type of dictionary to create. Possible values: <br></br>
        /// - "polish": Creates a Polish dictionary. <br></br>
        /// - "polishXVQ": Creates a Polish dictionary with 'X', 'V', and 'Q' appended to the end. <br></br>
        /// - "english": Creates an English dictionary. <br></br>
        /// </param>
        /// <returns>A dictionary with the specified key-value pairs.</returns>
        private Dictionary<int, char> CreateDictionary(string type)
        {
            if (type == null)
                throw new ArgumentException("Type cannot be null");

            if (type == "polish")
            {
                Dictionary<int, char> dict = new Dictionary<int, char>
                {
                    {1, 'a'},
                    {2, 'ą'},
                    {3, 'b'},
                    {4, 'c'},
                    {5, 'ć'},
                    {6, 'd'},
                    {7, 'e'},
                    {8, 'ę'},
                    {9, 'f'},
                    {10, 'g'},
                    {11, 'h'},
                    {12, 'i'},
                    {13, 'j'},
                    {14, 'k'},
                    {15, 'l'},
                    {16, 'ł'},
                    {17, 'm'},
                    {18, 'n'},
                    {19, 'ń'},
                    {20, 'o'},
                    {21, 'ó'},
                    {22, 'p'},
                    {23, 'r'},
                    {24, 's'},
                    {25, 'ś'},
                    {26, 't'},
                    {27, 'u'},
                    {28, 'w'},
                    {29, 'y'},
                    {30, 'z'},
                    {31, 'ź'},
                    {32, 'ż'},
                };

                return dict;
            }
            else if (type == "polishXVQ")
            {
                Dictionary<int, char> dict = new Dictionary<int, char>
                {
                    {1, 'a'},
                    {2, 'ą'},
                    {3, 'b'},
                    {4, 'c'},
                    {5, 'ć'},
                    {6, 'd'},
                    {7, 'e'},
                    {8, 'ę'},
                    {9, 'f'},
                    {10, 'g'},
                    {11, 'h'},
                    {12, 'i'},
                    {13, 'j'},
                    {14, 'k'},
                    {15, 'l'},
                    {16, 'ł'},
                    {17, 'm'},
                    {18, 'n'},
                    {19, 'ń'},
                    {20, 'o'},
                    {21, 'ó'},
                    {22, 'p'},
                    {23, 'r'},
                    {24, 's'},
                    {25, 'ś'},
                    {26, 't'},
                    {27, 'u'},
                    {28, 'w'},
                    {29, 'y'},
                    {30, 'z'},
                    {31, 'ź'},
                    {32, 'ż'},
                    {32, 'X'},
                    {32, 'V'},
                    {32, 'Q'},
                };

                return dict;
            }
            else if (type == "english")
            {
                Dictionary<int, char> dict = new Dictionary<int, char>
                {
                    {1, 'a'},
                    {2, 'b'},
                    {3, 'c'},
                    {4, 'd'},
                    {5, 'e'},
                    {6, 'f'},
                    {7, 'g'},
                    {8, 'h'},
                    {9, 'i'},
                    {10, 'j'},
                    {11, 'k'},
                    {12, 'l'},
                    {13, 'm'},
                    {14, 'n'},
                    {15, 'o'},
                    {16, 'p'},
                    {17, 'q'},
                    {18, 'r'},
                    {19, 's'},
                    {20, 't'},
                    {21, 'u'},
                    {22, 'v'},
                    {23, 'w'},
                    {24, 'x'},
                    {25, 'y'},
                    {26, 'z'},
                };

                return dict;
            }
            else
                throw new ArgumentException("The type you provided is incorrect");

        }

        #endregion
        public string performEncryption(Encrypt encrypt)
        {
            if(encrypt.EncryptionAlgorithm == "Caesar cipher")
            {
                if (encrypt.Language == "english")
                    return encryptCaesarCipherInEnglish();
                else if (encrypt.Language == "polish")
                    return encryptCaesarCipherInPolish();
                else if (encrypt.Language == "polishXQV")
                    return encryptCaesarCipherInPolishXQV();
                else
                    throw new ArgumentException("This language is not supported");
            }
            else 
                throw new ArgumentException("This encryption algorithm is not supported");
        }

        private string encryptCaesarCipherInEnglish()
        {
            throw new NotImplementedException();
        }

        private string encryptCaesarCipherInPolish()
        {
            throw new NotImplementedException();

        }

        private string encryptCaesarCipherInPolishXQV()
        {
            throw new NotImplementedException();

        }

    }

}


