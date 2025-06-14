using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class SecretWordGenerator
    {
        private static readonly Random sr_RandomGenerator = new Random();
        private static readonly char[] sr_CharsBank = getCharsBankFromEnum();
        private const int k_SecretWordLength = 4;
        public static string GenerateSecretWord()
        {
            StringBuilder secretWord = new StringBuilder();
            List<char> availableChars = new List<char>(sr_CharsBank);

            for (int i = 0; i < k_SecretWordLength; i++)
            {
                int randomIndex = sr_RandomGenerator.Next(availableChars.Count);

                secretWord.Append(availableChars[randomIndex]);
                availableChars.RemoveAt(randomIndex);
            }

            return secretWord.ToString(); //not string, we are giving it to the bridge for the UI
        }

        private static char[] getCharsBankFromEnum()
        {
            Array enumValues = Enum.GetValues(typeof(Guess.eGuessCollectionOptions));
            char[] chars = new char[enumValues.Length];
            for (int i = 0; i < enumValues.Length; i++)
            {
                chars[i] = enumValues.GetValue(i).ToString()[0];
            }
            return chars;
        }
    }
}