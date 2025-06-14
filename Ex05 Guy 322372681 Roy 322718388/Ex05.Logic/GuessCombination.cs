using System.Collections.Generic;

namespace Ex05.Logic
{
    //  v   $G$ CSS-999 (-3) Bad class name - the word handler is redundant because no logic is handled in the struct.
    //  v   $G$ DSN-999 (-3) This should be a class, not a struct - you hold a List reference here. 
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