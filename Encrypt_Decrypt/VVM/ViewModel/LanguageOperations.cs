using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Encrypt_Decrypt.VVM.ViewModel
{
    public class LanguageOperations
    {


        public const int polishLetterCount = 32;
        public const int polishXVQLetterCount = 35;
        public const int PolybiusEnglishLetterCount = 25;
        public const int englishLetterCount = 26;

        /// <summary>
        /// Creates a dictionary with integer keys and character values based on the specified type.
        /// </summary>
        /// <param name="type">
        /// The type of dictionary to create. Possible values: <br></br>
        /// - "polish": Creates a Polish dictionary. <br></br>
        /// - "polishXVQ": Creates a Polish dictionary with 'X', 'V', and 'Q' appended to the end. <br></br>
        /// - "english": Creates an English dictionary. <br></br>
        /// - In english 'j' is absent and i is threated like both i and j<br></br>
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
            // english have to be 25 letters long beacause other way we wouldn't be able to 
            // create fully squared matrix. Adding one letter as another row for example
            // 5x5 and appending last letter as another row with one letter can't be done
            // as it would be helpfull to crack the cipher.
            else if (type == "PolybiusEnglish")
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
                    {10, 'k'},
                    {11, 'l'},
                    {12, 'm'},
                    {13, 'n'},
                    {14, 'o'},
                    {15, 'p'},
                    {16, 'q'},
                    {17, 'r'},
                    {18, 's'},
                    {29, 't'},
                    {20, 'u'},
                    {21, 'v'},
                    {22, 'w'},
                    {23, 'x'},
                    {24, 'y'},
                    {25, 'z'},
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
                    {29, 's'},
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

        public static Dictionary<char, string> PolybiusDictionary(TextBox[,] textBoxes)
        {
            var dict = new Dictionary<char, string>();

            for (int i = 0; i < textBoxes.GetLength(0); i++)
            {
                for (int j = 0; j < textBoxes.GetLength(1); j++)
                {
                    // +1 for i and j because first letter in cipher starts at index 11
                    dict.Add(Convert.ToChar(textBoxes[i, j].Text), $"{i + 1}{j + 1}");
                }
            }

            return dict;
        }


        public static Dictionary<string, char> PolybiusDictionaryStringChar(TextBox[,] textBoxes)
        {
            var dict = new Dictionary<string, char>();

            for (int i = 0; i < textBoxes.GetLength(0); i++)
            {
                for (int j = 0; j < textBoxes.GetLength(1); j++)
                {
                    // +1 for i and j because first letter in cipher starts at index 11
                    dict.Add($"{i + 1}{j + 1}", Convert.ToChar(textBoxes[i, j].Text));
                }
            }

            return dict;
        }

        public static Dictionary<int, (char,int,int)> HomophonicDictionary(string language)
        {
            if (language == "polishXVQ")
            {
                Dictionary<int, (char,int,int)> dict = new Dictionary<int, (char,int,int)>
                {
                    {1, ('a', 9, 9)},
                    {2, ('ą', 1, 10)},
                    {3, ('b', 1, 11)},
                    {4, ('c', 4, 15)},
                    {5, ('ć', 1, 16)},
                    {6, ('d', 3, 19)},
                    {7, ('e', 8, 27)},
                    {8, ('ę', 1, 28)},
                    {9, ('f', 1, 29)},
                    {10, ('g', 1, 30)},
                    {11, ('h', 1, 31)},
                    {12, ('i', 8, 39)},
                    {13, ('j', 2, 41)},
                    {14, ('k', 4, 45)},
                    {15, ('l', 2, 47)},
                    {16, ('ł', 2, 49)},
                    {17, ('m', 3, 52)},
                    {18, ('n', 6, 58)},
                    {19, ('ń', 1, 59)},
                    {20, ('o', 8, 67)},
                    {21, ('ó', 1, 68)},
                    {22, ('p', 3, 71)},
                    {23, ('r', 1, 72)},
                    {24, ('s', 5, 77)},
                    {25, ('ś', 4, 81)},
                    {26, ('t', 1, 82)},
                    {27, ('u', 4, 86)},
                    {28, ('w', 3, 89)},
                    {29, ('y', 1, 90)},
                    {30, ('z', 5, 95)},
                    {31, ('ź', 1, 96)},
                    {32, ('ż', 4, 100)},
                    {33, ('x', 6, 106)},
                    {34, ('v', 1, 107)},
                    {35, ('q', 1, 108)}
                };

                return dict;
            }
            throw new ArgumentException("wrong language");
        }

        public static (int x, int y) GetClosestMultipliers(string language)
        {
            int languageLettersCount = 0;

            if (language == "polish")
                languageLettersCount = polishLetterCount;
            else if (language == "polishXVQ")
                languageLettersCount = polishXVQLetterCount;
            else if(language == "PolybiusEnglish")
                languageLettersCount = PolybiusEnglishLetterCount;
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
