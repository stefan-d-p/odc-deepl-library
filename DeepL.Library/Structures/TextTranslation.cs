using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.DeepL.Structures;

/// <summary>
/// Text translation result structure
/// </summary>
[OSStructure(
    Description = "Text translation result structure")]
public struct TextTranslation
{
    [OSStructureField(
        Description = "Detected source language by DeepL",
        DataType = OSDataType.Text)]
    public string DetectedSourceLanguage;
    
    [OSStructureField(
        Description = "Translated text by DeepL",
        DataType = OSDataType.Text)]
    public string TranslatedText;
}