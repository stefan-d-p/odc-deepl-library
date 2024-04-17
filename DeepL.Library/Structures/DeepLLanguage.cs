using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.DeepLTranslate.Structures;

[OSStructure(Description = "DeepL supported language structure")]
public struct DeepLLanguage
{
    [OSStructureField(
        Description = "Language code",
        DataType = OSDataType.Text)]
    public string Language;
    
    [OSStructureField(
        Description = "Language name",
        DataType = OSDataType.Text)]
    public string Name;
    
    [OSStructureField(
        Description = "Supports formality parameter. Only applicable with target languages.",
        DataType = OSDataType.Boolean)]
    public bool Formality;
}