using System.Collections.Generic;

namespace Ex02
{
    // $G$ CSS-999 (-3) Bad class name - the word handler is redundant because no logic is handled in the struct.
    // $G$ DSN-999 (-3) This should be a class, not a struct - you hold a List reference here. 
    public struct GuessHandler
    {
        public enum eGuessCollectionOptions { A, B, C, D, E, F, G, H }
        public List<eGuessCollectionOptions> Guess { get; set; }

        public GuessHandler(List<eGuessCollectionOptions> i_Guess) 
        {
            Guess = i_Guess;
        }
    }
}