using DeepL;
using DeepL.Model;
using Without.Systems.DeepLTranslate.Extensions;
using Without.Systems.DeepLTranslate.Structures;
using Without.Systems.DeepLTranslate.Util;

namespace Without.Systems.DeepLTranslate;

public class OSDeepL : IOSDeepL
{
    private readonly TranslatorOptions _translatorOptions;

    public OSDeepL()
    {
        _translatorOptions = new TranslatorOptions();
        _translatorOptions.appInfo = new AppInfo
        {
            AppName = "OutSystems DeepL Connector",
            AppVersion = "1.0.0"
        };
        _translatorOptions.MaximumNetworkRetries = 3;
    }
    
    public DeepLAccountUsage GetAccountUsage(string authKey)
    {
        using (Translator translator = new Translator(authKey, _translatorOptions))
        {
            Usage result = AsyncUtil.RunSync<Usage>(() => translator.GetUsageAsync());
            return result.ToDeepLAccountUsage();
        }
    }

    public List<DeepLTextTranslation> TranslateText(string authKey, List<string> texts, string targetLang,string? sourceLang = null, string? glossaryId = null,
        bool preserveFormatting = true, string formality = "Default", string? tagHandling = null)
    {
        if (string.IsNullOrEmpty(sourceLang)) sourceLang = null;
        if (string.IsNullOrEmpty(glossaryId)) glossaryId = null;
        if (string.IsNullOrEmpty(formality)) formality = "Default";
        if (string.IsNullOrEmpty(tagHandling)) tagHandling = null;
                
        if(!Formality.TryParse(formality,true, out Formality translationFormalityLevel))
            throw new ArgumentException($"Invalid Formality value of {formality}");

        TextTranslateOptions options = new TextTranslateOptions
        {
            Formality = translationFormalityLevel,
            GlossaryId = glossaryId,
            TagHandling = tagHandling,
            PreserveFormatting = preserveFormatting
        };
        
        using (Translator translator = new Translator(authKey, _translatorOptions))
        {
            TextResult[] result = AsyncUtil.RunSync(() => translator.TranslateTextAsync(texts, sourceLang, targetLang, options));
            IEnumerable<DeepLTextTranslation> translations =
                result.Select(r => new DeepLTextTranslation(r.DetectedSourceLanguageCode, r.Text));
            return translations.ToList();
        }
    }

    public DeepLGlossaryInfo CreateGlossary(string authKey, string name, string sourceLang, string targetLang,
        IReadOnlyList<DeepLGlossaryEntry> entries)
    {
        
        using (Translator translator = new Translator(authKey, _translatorOptions))
        {
            IEnumerable<KeyValuePair<string,string>> glossaryEntries = entries.Select(e =>
                new KeyValuePair<string, string>(e.Source, e.Target));
            GlossaryInfo result = AsyncUtil.RunSync<GlossaryInfo>(() => translator.CreateGlossaryAsync(name, sourceLang,targetLang, new GlossaryEntries(glossaryEntries)));
            return result.ToDeepLGlossaryInfo();

        }
    }

    public void DeleteGlossary(string authKey, string glossaryId)
    {
        using (Translator translator = new Translator(authKey, _translatorOptions))
        {
            AsyncUtil.RunSync(() => translator.DeleteGlossaryAsync(glossaryId));
        }
    }

    public DeepLGlossaryInfo GetGlossaryDetails(string authKey, string glossaryId)
    {
        using (Translator translator = new Translator(authKey, _translatorOptions))
        {
            GlossaryInfo result = AsyncUtil.RunSync<GlossaryInfo>(() => translator.GetGlossaryAsync(glossaryId));
            return result.ToDeepLGlossaryInfo();
        }
    }

    public List<DeepLGlossaryInfo> ListGlossaries(string authKey)
    {
        using (Translator translator = new Translator(authKey, _translatorOptions))
        {
            GlossaryInfo[] result = AsyncUtil.RunSync<GlossaryInfo[]>(() => translator.ListGlossariesAsync());
            IEnumerable<DeepLGlossaryInfo> glossaryInfos = result.Select(r => r.ToDeepLGlossaryInfo());
            return glossaryInfos.ToList();
        }
    }

    public List<DeepLGlossaryEntry> GetGlossaryEntries(string authKey, string glossayId)
    {
        using (Translator translator = new Translator(authKey, _translatorOptions))
        {
            GlossaryEntries result = AsyncUtil.RunSync(() => translator.GetGlossaryEntriesAsync(glossayId));
            IEnumerable<DeepLGlossaryEntry> glossaryEntries =
                result.ToDictionary().Select(r => new DeepLGlossaryEntry(r.Key, r.Value));
            return glossaryEntries.ToList();
        }
    }

    public List<DeepLLanguage> GetSourceLanguages(string authKey)
    {
        using (Translator translator = new Translator(authKey, _translatorOptions))
        {
            SourceLanguage[] result = AsyncUtil.RunSync<SourceLanguage[]>(() => translator.GetSourceLanguagesAsync());
            IEnumerable<DeepLLanguage> languages = result.Select(r => new DeepLLanguage { Language = r.Code, Name = r.Name });
            return languages.ToList();
        }
    }

    public List<DeepLLanguage> GetTargetLanguages(string authKey)
    {
        using (Translator translator = new Translator(authKey, _translatorOptions))
        {
            TargetLanguage[] result = AsyncUtil.RunSync<TargetLanguage[]>(() => translator.GetTargetLanguagesAsync());
            IEnumerable<DeepLLanguage> languages = result.Select(r => new DeepLLanguage { Language = r.Code, Name = r.Name, Formality = r.SupportsFormality });
            return languages.ToList();
        }
    }

    public byte[] TranslateDocument(string authKey, byte[] inputFile, string inputFileName, string targetLang, string? sourceLang = null, string? glossaryId = null,
        string formality = "Default")
    {
        
        if (string.IsNullOrEmpty(sourceLang)) sourceLang = null;
        if (string.IsNullOrEmpty(glossaryId)) glossaryId = null;
        if (string.IsNullOrEmpty(formality)) formality = "Default";
        
        if(!Formality.TryParse(
               string.IsNullOrEmpty(formality) ? "Default" : formality,
               true,
               out Formality translationFormalityLevel))
            throw new ArgumentException($"Invalid Formality value of {formality}");

        DocumentTranslateOptions options = new DocumentTranslateOptions
        {
            Formality = translationFormalityLevel,
            GlossaryId = glossaryId
        };
        
        using (Translator translator = new Translator(authKey, _translatorOptions))
        using (MemoryStream inputFileStream = new MemoryStream(inputFile))
        using (MemoryStream outputFileStream = new MemoryStream())
        {
            AsyncUtil.RunSync(() => translator.TranslateDocumentAsync(inputFileStream, inputFileName, outputFileStream, sourceLang,
                targetLang, options));
            return outputFileStream.ToArray();
        }
    }
}