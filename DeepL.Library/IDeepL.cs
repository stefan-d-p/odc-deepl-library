using OutSystems.ExternalLibraries.SDK;
using Without.Systems.DeepLTranslate.Structures;

namespace Without.Systems.DeepLTranslate
{
    [OSInterface(
        Name = "DeepL",
        Description = "Wrapper for the official DeepL .NET SDK. Translate text and documents and manage glossaries.",
        IconResourceName = "Without.Systems.DeepLTranslate.Resources.DeepL.png")]
    public interface IOSDeepL
    {
        [OSAction(
            Description = "Returns supported languages as source",
            ReturnName = "sourceLanguages",
            ReturnType = OSDataType.InferredFromDotNetType,
            IconResourceName = "Without.Systems.DeepLTranslate.Resources.DeepL.png")]
        List<DeepLLanguage> GetSourceLanguages([OSParameter(
                Description = "DeepL API Key",
                DataType = OSDataType.Text)]
            string authKey);
        
        [OSAction(
            Description = "Returns supported languages as target",
            ReturnName = "targetLanguages",
            ReturnType = OSDataType.InferredFromDotNetType,
            IconResourceName = "Without.Systems.DeepLTranslate.Resources.DeepL.png")]
        List<DeepLLanguage> GetTargetLanguages([OSParameter(
                Description = "DeepL API Key",
                DataType = OSDataType.Text)]
            string authKey);
        
        [OSAction(
            Description = "Returns Usage data of DeepL account",
            ReturnName = "usage",
            ReturnType = OSDataType.InferredFromDotNetType,
            IconResourceName = "Without.Systems.DeepLTranslate.Resources.DeepL.png")]
        DeepLAccountUsage GetAccountUsage(
            [OSParameter(
                Description = "DeepL API Key",
                DataType = OSDataType.Text)]
            string authKey);

        [OSAction(
            Description = "Translate text to a specified and supported target language",
            ReturnName = "translatedTexts",
            ReturnDescription = "Translated text items.",
            ReturnType = OSDataType.InferredFromDotNetType,
            IconResourceName = "Without.Systems.DeepLTranslate.Resources.DeepL.png")]
        List<DeepLTextTranslation> TranslateText(
            [OSParameter(
                Description = "DeepL API Key",
                DataType = OSDataType.Text)] string authKey,
            [OSParameter(
                Description = "Source texts",
                DataType = OSDataType.InferredFromDotNetType)] List<string> texts,
            [OSParameter(
                Description = "Language code of the language the source text should be translated to.",
                DataType = OSDataType.Text)] string targetLang,
            [OSParameter(
                Description = "The language of the source text. If not specified DeepL will try to auto discover the source language.",
                DataType = OSDataType.Text)] string? sourceLang = null,
            [OSParameter(
                Description = "Specify the glossary to use for the translation. Important: This requires the source_lang parameter to be set and the language pair of the glossary has to match the language pair of the request.",
                DataType = OSDataType.Text)] string? glossaryId = null,
            [OSParameter(
                Description = "Sets whether the translation engine should respect the original formatting, even if it would usually correct some aspects",
                DataType = OSDataType.Boolean)] bool preserveFormatting = true,
            [OSParameter(
                Description = "Sets whether the translated text should lean towards formal or informal language. This feature currently only works for target languages \"DE\" (German), \"FR\" (French), \"IT\" (Italian), \"ES\" (Spanish), \"NL\" (Dutch), \"PL\" (Polish), \"PT-PT\", \"PT-BR\" (Portuguese) and \"RU\" (Russian).",
                DataType = OSDataType.Text)] string formality = "Default",
            [OSParameter(
                Description = "Sets which kind of tags should be handled. Xml and Html supported",
                DataType = OSDataType.Text)] string? tagHandling = null);
        
        [OSAction(
            Description = "Translate a document to a specified and supported target language",
            ReturnName = "translatedDocument",
            ReturnDescription = "Translated document",
            ReturnType = OSDataType.BinaryData,
            IconResourceName = "Without.Systems.DeepLTranslate.Resources.DeepL.png")]
        byte[] TranslateDocument(
            [OSParameter(
                Description = "DeepL API Key",
                DataType = OSDataType.Text)] string authKey,
            [OSParameter(
                Description = "Input file",
                DataType = OSDataType.BinaryData)] byte[] inputFile, 
            [OSParameter(
                Description = "Input Filename",
                DataType = OSDataType.Text
                )] string inputFileName,
            [OSParameter(
                Description = "Language code of the language the source text should be translated to.",
                DataType = OSDataType.Text)] string targetLang,
            [OSParameter(
                Description = "The language of the source text. If not specified DeepL will try to auto discover the source language.",
                DataType = OSDataType.Text)] string? sourceLang = null,
            [OSParameter(
                Description = "Specify the glossary to use for the translation. Important: This requires the source_lang parameter to be set and the language pair of the glossary has to match the language pair of the request.",
                DataType = OSDataType.Text)] string? glossaryId = null,
            [OSParameter(
                Description = "Sets whether the translated text should lean towards formal or informal language. This feature currently only works for target languages \"DE\" (German), \"FR\" (French), \"IT\" (Italian), \"ES\" (Spanish), \"NL\" (Dutch), \"PL\" (Polish), \"PT-PT\", \"PT-BR\" (Portuguese) and \"RU\" (Russian).",
                DataType = OSDataType.Text)] string formality = "Default");

        [OSAction(
            Description = "Create a new glossary",
            ReturnName = "glossaryInfo",
            ReturnType = OSDataType.InferredFromDotNetType,
            IconResourceName = "Without.Systems.DeepLTranslate.Resources.DeepL.png")]
        DeepLGlossaryInfo CreateGlossary(
            [OSParameter(
                Description = "DeepL API Key",
                DataType = OSDataType.Text)] string authKey,
            [OSParameter(
                Description = "Name to be associated with the glossary",
                DataType = OSDataType.Text)] string name,
            [OSParameter(
                Description = "The language in which the source texts in the glossary are specified.",
                DataType = OSDataType.Text)] string sourceLang,
            [OSParameter(
                Description = "The language in which the target texts in the glossary are specified.",
                DataType = OSDataType.Text)] string targetLang,
            [OSParameter(
                Description = "List of glossary entries",
                DataType = OSDataType.InferredFromDotNetType)] IReadOnlyList<DeepLGlossaryEntry> entries);
        
        [OSAction(
            Description = "Delete a glossary",
            IconResourceName = "Without.Systems.DeepLTranslate.Resources.DeepL.png")]
        void DeleteGlossary(
            [OSParameter(
                Description = "DeepL API Key",
                DataType = OSDataType.Text)] string authKey,
            [OSParameter(
                Description = "Glossary ID",
                DataType = OSDataType.Text)] string glossaryId);
   
        [OSAction(
            Description = "Retrieve glossary details",
            ReturnName = "glossaryInfo",
            ReturnType = OSDataType.InferredFromDotNetType,
            IconResourceName = "Without.Systems.DeepLTranslate.Resources.DeepL.png")]
        DeepLGlossaryInfo GetGlossaryDetails(
            [OSParameter(
                Description = "DeepL API Key",
                DataType = OSDataType.Text)] string authKey,
            [OSParameter(
                Description = "Glossary ID",
                DataType = OSDataType.Text)] string glossaryId);

        [OSAction(
            Description = "List glossaries in account",
            ReturnName = "glossaries",
            ReturnType = OSDataType.InferredFromDotNetType,
            IconResourceName = "Without.Systems.DeepLTranslate.Resources.DeepL.png")]
        List<DeepLGlossaryInfo> ListGlossaries(
            [OSParameter(
                Description = "DeepL API Key",
                DataType = OSDataType.Text)]
            string authKey);
        
        [OSAction(
            Description = "Get language pair entries of a glossary",
            ReturnName = "glossaryEntries",
            ReturnType = OSDataType.InferredFromDotNetType,
            IconResourceName = "Without.Systems.DeepLTranslate.Resources.DeepL.png")]
        List<DeepLGlossaryEntry> GetGlossaryEntries(
            [OSParameter(
                Description = "DeepL API Key",
                DataType = OSDataType.Text)]
            string authKey,
            [OSParameter(
                Description = "Glossary ID",
                DataType = OSDataType.Text)] string glossaryId);
    }
}