using System.Collections.Generic;

namespace Ex05.Logic
{
    public class GuessCombination
    {
        public enum eGuessCollectionOptions { A, B, C, D, E, F, G, H }
        public List<eGuessCollectionOptions> UserGuess { get; set; }

        public GuessCombination(List<eGuessCollectionOptions> i_UserGuess) 
        {
            UserGuess = i_UserGuess;
        }
    }
}