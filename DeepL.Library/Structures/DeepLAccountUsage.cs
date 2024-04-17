using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.DeepLTranslate.Structures;

/// <summary>
/// Account Usage Structure
/// </summary>
[OSStructure(
    Description = "Account Usage Structure")]
public struct DeepLAccountUsage
{
    [OSStructureField(
        Description = "Characters translated so far in the current billing period",
        DataType = OSDataType.LongInteger)]
    public long? CharacterCount;

    [OSStructureField(
        Description = "Current maximum number of characters that can be translated per billing period",
        DataType = OSDataType.LongInteger)]
    public long? CharacterLimit;

    [OSStructureField(
        Description = "Documents translated so far in the current billing period",
        DataType = OSDataType.LongInteger)]
    public long? DocumentLimit;
    
    [OSStructureField(
        Description = "Current maximum number of documents that can be translated per billing period",
        DataType = OSDataType.LongInteger)]
    public long? DocumentCount;

    public DeepLAccountUsage(long? characterCount, long? characterLimit, long? documentLimit, long? documentCount)
    {
        CharacterCount = characterCount;
        CharacterLimit = characterLimit;
        DocumentLimit = documentLimit;
        DocumentCount = documentCount;
    }
}