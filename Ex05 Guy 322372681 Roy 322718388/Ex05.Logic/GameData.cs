using System.Collections.Generic;

namespace Ex05.Logic
{
    public class GameData
    {   
        public readonly int r_MaxUserGuesses;
        public int RemainingNumberOfGuesses { get; set; }
        public GuessCombination SecretWordCombination { get; private set; }
        public bool IsVictory { get; set; } = false;

        public GameData(int i_MaxUserGuesses)
        {
            SecretWordCombination = SecretWordGenerator.GenerateSecretWord();
            r_MaxUserGuesses = i_MaxUserGuesses;
            RemainingNumberOfGuesses = i_MaxUserGuesses;
        }
    }
}