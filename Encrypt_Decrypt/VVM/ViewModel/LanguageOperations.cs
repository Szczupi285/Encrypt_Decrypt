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

        public static Dictionary<int, (char,int)> HomophonicDictionary(string language)
        {
            if (language == "polishXVQ")
            {
                Dictionary<int, (char,int)> dict = new Dictionary<int, (char,int)>
                {
                    {1, ('a', 9)},
                    {2, ('ą', 10)},
                    {3, ('b', 11)},
                    {4, ('c', 15)},
                    {5, ('ć', 16)},
                    {6, ('d', 19)},
                    {7, ('e', 27)},
                    {8, ('ę', 28)},
                    {9, ('f', 29)},
                    {10, ('g', 30)},
                    {11, ('h', 31)},
                    {12, ('i', 39)},
                    {13, ('j', 41)},
                    {14, ('k', 45)},
                    {15, ('l', 47)},
                    {16, ('ł', 49)},
                    {17, ('m', 52)},
                    {18, ('n', 58)},
                    {19, ('ń', 59)},
                    {20, ('o', 67)},
                    {21, ('ó', 68)},
                    {22, ('p', 71)},
                    {23, ('r', 72)},
                    {24, ('s', 77)},
                    {25, ('ś', 81)},
                    {26, ('t', 82)},
                    {27, ('u', 86)},
                    {28, ('w', 89)},
                    {29, ('y', 90)},
                    {30, ('z', 95)},
                    {31, ('ź', 96)},
                    {32, ('ż', 100)},
                    {33, ('x', 106)},
                    {34, ('v', 107)},
                    {35, ('q', 108)}
                };

                return dict;
            }
            else if (language == "polish")
            {
                Dictionary<int, (char, int)> dict = new Dictionary<int, (char, int)>
                {
                    {1, ('a', 11)},
                    {2, ('ą', 12)},
                    {3, ('b', 13)},
                    {4, ('c', 16)},
                    {5, ('ć', 17)},
                    {6, ('d', 20)},
                    {7, ('e', 28)},
                    {8, ('ę', 29)},
                    {9, ('f', 30)},
                    {10, ('g', 31)},
                    {11, ('h', 32)},
                    {12, ('i', 40)},
                    {13, ('j', 42)},
                    {14, ('k', 46)},
                    {15, ('l', 48)},
                    {16, ('ł', 50)},
                    {17, ('m', 53)},
                    {18, ('n', 59)},
                    {19, ('ń', 60)},
                    {20, ('o', 68)},
                    {21, ('ó', 69)},
                    {22, ('p', 72)},
                    {23, ('r', 73)},
                    {24, ('s', 78)},
                    {25, ('ś', 79)},
                    {26, ('t', 80)},
                    {27, ('u', 84)},
                    {28, ('w', 87)},
                    {29, ('y', 90)},
                    {30, ('z', 95)},
                    {31, ('ź', 96)},
                    {32, ('ż', 100)}
                };

                    return dict;
            }
            else if (language == "english")
            {
                Dictionary<int, (char, int)> dict = new Dictionary<int, (char, int)>
                {
                    {1, ('a', 8)},
                    {2, ('b', 9)},
                    {3, ('c', 11)},
                    {4, ('d', 15)},
                    {5, ('e', 28)},
                    {6, ('f', 30)},
                    {7, ('g', 32)},
                    {8, ('h', 38)},
                    {9, ('i', 45)},
                    {10, ('j', 46)},
                    {11, ('k', 47)},
                    {12, ('l', 51)},
                    {13, ('m', 53)},
                    {14, ('n', 59)},
                    {15, ('o', 66)},
                    {16, ('p', 67)},
                    {17, ('q', 68)},
                    {18, ('r', 74)},
                    {19, ('s', 80)},
                    {20, ('t', 89)},
                    {21, ('u', 91)},
                    {22, ('v', 92)},
                    {23, ('w', 94)},
                    {24, ('x', 95)},
                    {25, ('y', 97)},
                    {26, ('z', 98)}
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
