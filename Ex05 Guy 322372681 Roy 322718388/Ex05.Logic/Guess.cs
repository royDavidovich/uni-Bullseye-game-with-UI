using System.Collections.Generic;

namespace Logic
{
    
    public struct Guess
    {
        public enum eGuessCollectionOptions { A, B, C, D, E, F, G, H }
        public List<eGuessCollectionOptions> userGuess { get; set; }

        public Guess(List<eGuessCollectionOptions> i_Guess) 
        {
            userGuess = i_Guess;
        }
    }
}