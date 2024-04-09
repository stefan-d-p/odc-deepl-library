using OutSystems.ExternalLibraries.SDK;
using Without.Systems.DeepL.Structures;

namespace Without.Systems.DeepL;

public class DeepL : IDeepL
{

    public AccountUsage GetAccountUsage(string authKey)
    {
        throw new NotImplementedException();
    }

    public TextTranslation TranslateText(string authKey, string text, string sourceLang, string targetLang, string glossaryId,
        bool preserveFormatting, string formality, string tagHandling)
    {
        throw new NotImplementedException();
    }
}