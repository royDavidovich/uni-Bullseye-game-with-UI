using System;
using System.Collections.Generic;
using System.Linq;
using static Ex05.Logic.GuessCombination;

namespace Ex05.Logic
{
    public class SecretWordGenerator
    {
        public const int k_SecretWordLength = 4;
        private static readonly Random sr_RandomGenerator = new Random();

        public static GuessCombination GenerateSecretWord()
        {
            Array enumValues = Enum.GetValues(typeof(GuessCombination.eGuessCollectionOptions));
            List<GuessCombination.eGuessCollectionOptions> availableOptions =
                enumValues.Cast<eGuessCollectionOptions>().ToList();
            List<GuessCombination.eGuessCollectionOptions> selectedOptions =
                new List<GuessCombination.eGuessCollectionOptions>();

            for (int i = 0; i < k_SecretWordLength; i++)
            {
                int randomIndex = sr_RandomGenerator.Next(availableOptions.Count);

                selectedOptions.Add(availableOptions[randomIndex]);
                availableOptions.RemoveAt(randomIndex);
            }

            return new GuessCombination(selectedOptions);
        }
    }
}