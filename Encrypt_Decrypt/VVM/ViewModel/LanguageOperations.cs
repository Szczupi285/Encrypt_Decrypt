using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encrypt_Decrypt.VVM.ViewModel
{
    public class LanguageOperations
    {


        public const int polishLetterCount = 32;
        public const int polishXVQLetterCount = 35;
        public const int englishLetterCount = 26;

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
        public Dictionary<int, char> CreateDictionary(string type)
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
                    {33, 'x'},
                    {34, 'v'},
                    {35, 'q'},
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


        public static (int x, int y) GetClosestMultipliers(string language)
        {
            int languageLettersCount = 0;

            if (language == "polish")
                languageLettersCount = polishLetterCount;
            else if (language == "polishXVQ")
                languageLettersCount = polishXVQLetterCount;
            else if (language == "english")
                languageLettersCount = englishLetterCount;
            


            int root = (int)Math.Sqrt(languageLettersCount);

            int firstMultiplier = languageLettersCount;
            int secondMultiplier = 1;

            for(int i = root; i > 0; i--)
            {
                if(languageLettersCount % i == 0)
                {
                     firstMultiplier = languageLettersCount / i;
                     secondMultiplier = i;

                     return (firstMultiplier, secondMultiplier);
                }
            }
            return (firstMultiplier, secondMultiplier);


        }
    }
}
