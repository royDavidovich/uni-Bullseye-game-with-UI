using System;
using System.Collections.Generic;
using System.Text;

namespace Ex02
{
    public class SecretWordGenerator
    {
        private static readonly Random sr_RandomGenerator = new Random();
        private static readonly char[] sr_CharsBank = getCharsBankFromEnum();
        // $G$ DSN-007 (-2) This is not used outside the class. Therefore should be private.
        public const int k_SecretWordLength = 4;

        // $G$ DSN-002 (-5) No separation between the logical part of the game and the UI.
        // Generation is pure logical.
        // Presentation of the word from the logic to a char suppose to be done in the UI.
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

            return secretWord.ToString();
        }

        private static char[] getCharsBankFromEnum()
        {
            Array enumValues = Enum.GetValues(typeof(GuessHandler.eGuessCollectionOptions));
            char[] chars = new char[enumValues.Length];
            for (int i = 0; i < enumValues.Length; i++)
            {
                chars[i] = enumValues.GetValue(i).ToString()[0];
            }
            return chars;
        }
    }
}