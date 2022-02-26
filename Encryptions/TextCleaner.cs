using System.Collections.Generic;
using TheoryOfInformation.lab1.Structs;
using System.Linq;
using TheoryOfInformation.lab1.ENUMS;

namespace TheoryOfInformation.lab1.Encryptions
{
    public delegate string Operation(string text, string key);

    public static class TextCleaner
    {
        private static readonly Dictionary<LangIds, string> langs;

        static TextCleaner()
        {
            langs = new Dictionary<LangIds, string>
            {
                [LangIds.RU] = "широкая электрификация южных губерний даст мощный толчок подъёму сельского хозяйства",
                [LangIds.EN] = "the quick brown fox jumps over the lazy dog"
            };

            langs[LangIds.RU] = (langs[LangIds.RU] + langs[LangIds.RU].ToUpper()).Replace(" ", "");
            langs[LangIds.EN] = (langs[LangIds.EN] + langs[LangIds.EN].ToUpper()).Replace(" ", "");
        }

        public static string WorkWithText(string key, string text, Operation operation, LangIds lang)
        {
            List<RemovedSymbl> removedSymbls = CleanText(ref text, lang);

            string encodedTxt = operation(text, key);

            return ReturnText(encodedTxt, removedSymbls);
        }

        private static List<RemovedSymbl> CleanText(ref string text, LangIds lang)
        {
            List<RemovedSymbl> result = new List<RemovedSymbl>();
            for (int i = 0; i < text.Length; i++)
            {
                if (!langs[lang].Contains(text[i]))
                {
                    result.Add(new RemovedSymbl(i, text));
                    text = text.Remove(i, 1);
                    i--;
                }
            }

            return result;
        }

        private static string ReturnText(string text, List<RemovedSymbl> removedSymbls)
        {
            for (int i = removedSymbls.Count - 1; i >= 0; i--)
                text = text.Insert(removedSymbls[i].index, removedSymbls[i].symble.ToString());
            return text;
        }
    }
}