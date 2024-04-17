using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.DeepLTranslate.Structures;

/// <summary>
/// Text translation result structure
/// </summary>
[OSStructure(
    Description = "Text translation result structure")]
public struct DeepLTextTranslation
{
    [OSStructureField(
        Description = "Detected source language by DeepL",
        DataType = OSDataType.Text)]
    public string DetectedSourceLanguage;
    
    [OSStructureField(
        Description = "Translated text by DeepL",
        DataType = OSDataType.Text)]
    public string Text;

    public DeepLTextTranslation(string detectedSourceLanguage, string translatedText)
    {
        DetectedSourceLanguage = detectedSourceLanguage;
        Text = translatedText;
    }
}