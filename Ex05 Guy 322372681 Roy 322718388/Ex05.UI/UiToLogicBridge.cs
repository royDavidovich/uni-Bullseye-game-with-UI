using System.Collections.Generic;
using System.Drawing;
using Ex05.Logic;

namespace Ex05.UI
{
    public static class UiToLogicBridge
    {
        private class DataPair
        {
            public Color PairColor { get; }
            public GuessCombination.eGuessCollectionOptions PairTranslated { get; }

            public DataPair(Color i_Color, GuessCombination.eGuessCollectionOptions i_Translation)
            {
                PairColor = i_Color;
                PairTranslated = i_Translation;
            }
        }

        private static readonly List<DataPair> sr_TranslatorList =
            new List<DataPair> {
                                   new DataPair(Color.Red, GuessCombination.eGuessCollectionOptions.A),
                                   new DataPair(Color.Blue, GuessCombination.eGuessCollectionOptions.B),
                                   new DataPair(Color.Green, GuessCombination.eGuessCollectionOptions.C),
                                   new DataPair(Color.Yellow, GuessCombination.eGuessCollectionOptions.D),
                                   new DataPair(Color.Orange, GuessCombination.eGuessCollectionOptions.E),
                                   new DataPair(Color.Purple, GuessCombination.eGuessCollectionOptions.F),
                                   new DataPair(Color.Brown, GuessCombination.eGuessCollectionOptions.G),
                                   new DataPair(Color.Pink, GuessCombination.eGuessCollectionOptions.H)
                                };

        public static GuessCombination.eGuessCollectionOptions GetFromUiToLogicIndex(Color i_ToTranslate)
        {
            int translatedFromUiIndex;

            for (translatedFromUiIndex = 0; translatedFromUiIndex < sr_TranslatorList.Count; translatedFromUiIndex++)
            {
                if (sr_TranslatorList[translatedFromUiIndex].PairColor == i_ToTranslate)
                {
                    break;
                }
            }

            return sr_TranslatorList[translatedFromUiIndex].PairTranslated;
        }

        public static Color GetFromLogicToUiIndex(GuessCombination.eGuessCollectionOptions i_ToTranslate)
        {
            int translatedFromLogicIndex;

            for (translatedFromLogicIndex = 0; translatedFromLogicIndex < sr_TranslatorList.Count; translatedFromLogicIndex++)
            {
                if (sr_TranslatorList[translatedFromLogicIndex].PairTranslated == i_ToTranslate)
                {
                    break;
                }
            }

            return sr_TranslatorList[translatedFromLogicIndex].PairColor;
        }
    }
}