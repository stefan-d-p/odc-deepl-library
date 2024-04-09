using DeepL;
using OutSystems.ExternalLibraries.SDK;
using Without.Systems.DeepL.Structures;

namespace Without.Systems.DeepL
{
    [OSInterface(
        Description = "Sample template action")]
    public interface IDeepL
    {
        /// <summary>
        /// Returns Usage data of DeepL account
        /// </summary>
        /// <param name="authKey">DeepL API Key</param>
        /// <returns>Account Usage data for DeppL acount</returns>
        [OSAction(
            Description = "Returns Usage data of DeepL account",
            ReturnType = OSDataType.InferredFromDotNetType)]
        AccountUsage GetAccountUsage(
            [OSParameter(
                Description = "DeepL API Key",
                DataType = OSDataType.Text)]
            string authKey);

        [OSAction(
            Description = "Translate text to a specified and supported target language",
            ReturnType = OSDataType.InferredFromDotNetType)]
        TextTranslation TranslateText(
            [OSParameter(
                Description = "DeepL API Key",
                DataType = OSDataType.Text)] string authKey,
            [OSParameter(
                Description = "Source text",
                DataType = OSDataType.Text)] string text,
            [OSParameter(
                Description = "The language of the source text. If not specified DeepL will try to autodiscover the source language.",
                DataType = OSDataType.Text)] string sourceLang,
            [OSParameter(
                Description = "Language code of the language the source text should be translated to.",
                DataType = OSDataType.Text)] string targetLang,
            [OSParameter(
                Description = "Specify the glossary to use for the translation. Important: This requires the source_lang parameter to be set and the language pair of the glossary has to match the language pair of the request.",
                DataType = OSDataType.Text)] string glossaryId,
            [OSParameter(
                Description = "Sets whether the translation engine should respect the original formatting, even if it would usually correct some aspects",
                DataType = OSDataType.Boolean)] bool preserveFormatting,
            [OSParameter(
                Description = "Sets whether the translated text should lean towards formal or informal language. This feature currently only works for target languages \"DE\" (German), \"FR\" (French), \"IT\" (Italian), \"ES\" (Spanish), \"NL\" (Dutch), \"PL\" (Polish), \"PT-PT\", \"PT-BR\" (Portuguese) and \"RU\" (Russian).",
                DataType = OSDataType.Text)] string formality,
            [OSParameter(
                Description = "Sets which kind of tags should be handled. Xml and Html supported",
                DataType = OSDataType.Text)] string tagHandling);

        

    }
}